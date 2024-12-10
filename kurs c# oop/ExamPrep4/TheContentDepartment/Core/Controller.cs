using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
	public class Controller : IController
	{
		private readonly ResourceRepository resources = new ResourceRepository();
		private readonly MemberRepository members = new MemberRepository();
		public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
		{
			var resource = resources.TakeOne(resourceName);

            if (!resource.IsTested)
			{
				return string.Format(OutputMessages.ResourceNotTested, resourceName);
			}
            
            var teamLead = members.Models.First(m => m is TeamLead);

			if (!isApprovedByTeamLead)
			{
				resource.Test();
				return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
			}
			else
			{
				resource.Approve();
				teamLead.FinishTask(resourceName);
				return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
			}

		}

		public string CreateResource(string resourceType, string resourceName, string path)
		{
			var creator = members.Models.FirstOrDefault(c => c.Path == path);
			if (creator == null)
			{
				return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
			}

			if (creator.InProgress.Contains(resourceName))
			{
				return string.Format(OutputMessages.ResourceExists, resourceName);
			}

			IResource resource;

			if (resourceType == nameof(Exam))
			{
				resource = new Exam(resourceName, creator.Name);
			}
			else if (resourceType == nameof(Workshop))
			{
				resource = new Workshop(resourceName, creator.Name);
			}
			else if (resourceType == nameof(Presentation))
			{
				resource = new Presentation(resourceName, creator.Name);
			}
			else
			{
				return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
			}

			resources.Add(resource);
			creator.WorkOnTask(resourceName);
			return string.Format(OutputMessages.ResourceCreatedSuccessfully, creator.Name, resourceType, resourceName);
		}

		public string DepartmentReport()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("Finished Tasks:");
			var approvedResources = resources.Models.Where(r => r.IsApproved).ToList();

			foreach (var resource in approvedResources)
			{
				sb.AppendLine($"--{resource}");
			}

			sb.AppendLine("Team Report:");
			var teamLead = members.Models.OfType<TeamLead>().SingleOrDefault();

			if (teamLead != null)
			{
				sb.AppendLine($"--{teamLead}");
			}

			foreach (var contentMember in members.Models.OfType<ContentMember>())
			{
				sb.AppendLine(contentMember.ToString());
			}

			return sb.ToString().TrimEnd();
		}

		public string JoinTeam(string memberType, string memberName, string path)
		{
			ITeamMember member;

			if (memberType == nameof(TeamLead))
			{
				member = new TeamLead(memberName, path);
			}
			else if (memberType == nameof(ContentMember))
			{
				member = new ContentMember(memberName, path);
			}
			else
			{
				return string.Format(OutputMessages.MemberTypeInvalid, memberType);
			}

			if (members.Models.Any(m => m.Path == path))
			{
				return string.Format(OutputMessages.PositionOccupied);
			}

			if (members.Models.Any(m => m.Name == memberName))
			{
				return string.Format(OutputMessages.MemberExists, memberName);
			}

			members.Add(member);
			return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
		}

		public string LogTesting(string memberName)
		{
			var member = members.TakeOne(memberName);

			if (member is null)
			{
				return string.Format(OutputMessages.WrongMemberName);
			}

			var resource = resources.Models
				.Where(m => !m.IsTested && m.Creator == memberName)
				.OrderBy(m => m.Priority)
		        .FirstOrDefault();

			if (resource is null)
			{
				return string.Format(OutputMessages.NoResourcesForMember, memberName);
			}

			var teamLead = members.Models.First(m => m is TeamLead);

			member.FinishTask(resource.Name);
			teamLead.WorkOnTask(resource.Name);
			resource.Test();

			return string.Format(OutputMessages.ResourceTested, resource.Name);
		}
	}
}
