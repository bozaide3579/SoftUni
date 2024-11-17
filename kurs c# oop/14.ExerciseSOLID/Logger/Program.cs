using Logger.Appenders;
using Logger.Interfaces;
using Logger.Layouts;

namespace Logger
{
	using Logger.Enums;
	using Logger.Loggers;

	public class Program
	{
		private static readonly Dictionary<string, Func<ILayout, Func<string, ReportLevel, string, bool>?, IAppender>> _appenderFact =
			new Dictionary<string, Func<ILayout, Func<string, ReportLevel, string, bool>?, IAppender>>
			{
				[nameof(ConsoleAppender)] = (layout, filter ) => new ConsoleAppender(layout, filter),
				[nameof(FileAppender)] = (layout, filter) => new FileAppender("./logs.txt", layout, filter),
			};

		private static readonly Dictionary<string, Func<ILayout>> _layoutFact = new Dictionary<string, Func<ILayout>>
		{
			[nameof(SimpleLayout)] = () => new SimpleLayout(),
			[nameof(XmlLayout)] = () => new XmlLayout(),
		};
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			IAppender[] appenders = new IAppender[n];
			for (int i = 0; i < n; i++)
			{
				string[] data = Console.ReadLine()!.Split();

                string appenderType = data[0];
				if (!_appenderFact.ContainsKey(appenderType))
					throw new InvalidOperationException("Invalid appender type");

				string layoutType = data[1];
				if (!_layoutFact.ContainsKey(layoutType))
					throw new InvalidOperationException("Invalid layout type");

				Func<ILayout> currentLayoutFact = _layoutFact[layoutType];
				ILayout layout = currentLayoutFact();
				
				Func<string, ReportLevel, string, bool>? filter = null;
				if (data.Length == 3)
				{
					ReportLevel minimumReportLevel = Enum.Parse<ReportLevel>(data[2], ignoreCase: true);

				}

				Func<ILayout, Func<string, ReportLevel, string, bool>, IAppender> currentAppenderFact =
					_appenderFact[appenderType];
				appenders[i] = currentAppenderFact(layout, filter);
			}

			ILogger logger = new Logger(appenders);

			logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
			logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
		}
	}
}
