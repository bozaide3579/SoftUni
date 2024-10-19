using System.Text;

namespace MailClient
{
	public class MailBox
	{

		public MailBox(int capacity)
		{
			Capacity = capacity;
			Inbox = new List<Mail>();
			Archive = new List<Mail>();
		}

		public int Capacity { get; }
		public List<Mail> Inbox { get; }
		public List<Mail> Archive { get; }

		public void IncomingMail(Mail mail)
		{
			if (this.Inbox.Count < Capacity)
			{
				this.Inbox.Add(mail);
			}
		}

		public bool DeleteMail(string sender)
		{
			Mail? remove = this.Inbox.FirstOrDefault(x => x.Sender == sender);
			if (remove != null)
			{
				return this.Inbox.Remove(remove);
			}

			return false;
		}

		public int ArchiveInboxMessages()
		{
			int mailsMoved = Inbox.Count;
			Archive.AddRange(Inbox);
			Inbox.Clear();
			return mailsMoved;
		}

		public string GetLongestMessage()
		{
			return Inbox.OrderByDescending(i => i.Body.Length).First().ToString();
		}


		public string InboxView()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("Inbox:");
			bool isFirst = true;
			foreach (Mail mail in Inbox)
			{
				if (isFirst)
				{
					isFirst = false;
				}
				else
				{
					sb.AppendLine();
				}

				sb.Append($"{mail}");
			}

			return sb.ToString().Trim();
		}
	}
}
