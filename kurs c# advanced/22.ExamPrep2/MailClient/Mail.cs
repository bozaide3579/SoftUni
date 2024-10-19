using System.Text;

namespace MailClient
{
    public class Mail
    {
		public Mail(string sender, string receiver, string body)
		{
			this.Sender = sender;
			this.Receiver = receiver;
			this.Body = body;
		}

		public string Sender { get; }
        public string Receiver { get; }
        public string Body { get; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"From: {this.Sender} / To: {this.Receiver}");
			sb.Append($"Message: {this.Body}");

			return sb.ToString().Trim();
		}

	}
}
