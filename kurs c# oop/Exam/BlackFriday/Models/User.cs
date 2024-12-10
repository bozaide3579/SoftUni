using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
	public abstract class User : IUser
	{
		private string email;
		protected User(string userName, string email, bool hasDataAccess)
		{
			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentException(ExceptionMessages.UserNameRequired);
			}

			UserName = userName;
			HasDataAccess = hasDataAccess;
			Email = email;
		}

		public string UserName { get; private set; }
		public bool HasDataAccess { get; private set; }
		public string Email
		{
			get => HasDataAccess ? "hidden" : email;
			private set
			{
				if (!HasDataAccess && string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Email is required.");
				}
				email = value;
			}
		}

		public override string ToString()
		{
			string type = GetType().Name;
			return $"{UserName} - Status: {type}, Contact Info: {Email}";
		}
	}
}
