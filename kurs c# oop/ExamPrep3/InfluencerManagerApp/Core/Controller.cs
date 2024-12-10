using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InfluencerManagerApp.Core
{
	public class Controller : IController
	{
		private readonly IRepository<IInfluencer> influencerRepository = new InfluencerRepository();
		private readonly IRepository<ICampaign> campaignRepository = new CampaignRepository();

		public string ApplicationReport()
		{
			StringBuilder sb = new StringBuilder();

			List<IInfluencer> orderedInfluencers = influencerRepository.Models
				.OrderByDescending(i => i.Income)
				.ThenByDescending(i => i.Followers)
				.ToList();

			foreach (IInfluencer influencer in orderedInfluencers)
			{
				sb.AppendLine(influencer.ToString());

				if (influencer.Participations.Any())
				{
					sb.AppendLine("Active Campaigns:");

					List<ICampaign> orderedCampaigns = campaignRepository.Models
					.Where(c => c.Contributors.Contains(influencer.Username))
					.OrderBy(c => c.Brand)
					.ToList();

					foreach (ICampaign campaign in orderedCampaigns)
					{
						sb.AppendLine($"--{campaign.ToString()}");
					}
				}
			}

			return sb.ToString().TrimEnd();
		}

		public string AttractInfluencer(string brand, string username)
		{
			IInfluencer infuencer = influencerRepository.FindByName(username);
			ICampaign campaign = campaignRepository.FindByName(brand);

			if (infuencer is null)
			{
				return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
			}

			if (campaign is null)
			{
				return string.Format(OutputMessages.CampaignNotFound, brand);
			}

			if (campaign.Contributors.Contains(username))
			{
				return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
			}

			bool isEligible = false;

			if (campaign.GetType().Name == nameof(ProductCampaign))
			{
				isEligible =
					infuencer.GetType().Name == nameof(BusinessInfluencer) ||
					infuencer.GetType().Name == nameof(FashionInfluencer);
			}
			else if (campaign.GetType().Name == nameof(ServiceCampaign))
			{
				isEligible =
					infuencer.GetType().Name == nameof(BusinessInfluencer) ||
					infuencer.GetType().Name == nameof(BloggerInfluencer);
			}

			if (!isEligible)
			{
				return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
			}

			if (campaign.Budget < infuencer.CalculateCampaignPrice())
			{
				return string.Format(OutputMessages.UnsufficientBudget, brand, username);
			}

			infuencer.EarnFee(infuencer.CalculateCampaignPrice());
			infuencer.EnrollCampaign(brand);
			campaign.Engage(infuencer);
			return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
		}

		public string BeginCampaign(string typeName, string brand)
		{
			ICampaign campaigns;

			if (typeName == nameof(ProductCampaign))
			{
				campaigns = new ProductCampaign(brand);
			}
			else if (typeName == nameof(ServiceCampaign))
			{
				campaigns = new ServiceCampaign(brand);
			}
			else
			{
				return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
			}

			if (campaignRepository.FindByName(brand) is not null)
			{
				return string.Format(OutputMessages.CampaignDuplicated, brand);
			}

			campaignRepository.AddModel(campaigns);
			return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);

		}

		public string CloseCampaign(string brand)
		{
			ICampaign campaign = campaignRepository.FindByName(brand);

			if (campaign is null)
			{
				return string.Format(OutputMessages.InvalidCampaignToClose);
			}

			if (campaign.Budget <= 10000)
			{
				return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
			}

			foreach (string name in campaign.Contributors)
			{
				IInfluencer influencer = influencerRepository.FindByName(name);
				influencer.EarnFee(2000);
				influencer.EndParticipation(campaign.Brand);
			}

			campaignRepository.RemoveModel(campaign);
			return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
		}

		public string ConcludeAppContract(string username)
		{
			IInfluencer influencer = influencerRepository.FindByName(username);

			if (influencer is null)
			{
				return string.Format(OutputMessages.InfluencerNotSigned, username);
			}

			if (influencer.Participations.Any())
			{
				return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
			}

			influencerRepository.RemoveModel(influencer);
			return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
		}

		public string FundCampaign(string brand, double amount)
		{
			ICampaign campaign = campaignRepository.FindByName(brand);

			if (campaign is null)
			{
				return string.Format(OutputMessages.InvalidCampaignToFund);
			}

			if (amount <= 0)
			{
				return string.Format(OutputMessages.NotPositiveFundingAmount);
			}

			campaign.Gain(amount);
			return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
		}

		public string RegisterInfluencer(string typeName, string username, int followers)
		{
			IInfluencer influencers;

			if (typeName == nameof(BloggerInfluencer))
			{
				influencers = new BloggerInfluencer(username, followers);
			}
			else if (typeName == nameof(FashionInfluencer))
			{
				influencers = new FashionInfluencer(username, followers);
			}
			else if (typeName == nameof(BusinessInfluencer))
			{
				influencers = new BusinessInfluencer(username, followers);
			}
			else
			{
				return string.Format(OutputMessages.InfluencerInvalidType, typeName);
			}

			if (influencerRepository.FindByName(username) is not null)
			{
				return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
			}

			influencerRepository.AddModel(influencers);
			return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
		}
	}
}
