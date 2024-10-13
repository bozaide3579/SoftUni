namespace EvenLines
{
	using System;
	using System.Text;

	public class EvenLines
	{
		public static void Main()
		{
			string inputFilePath = @"..\..\..\text.txt";

			Console.WriteLine(ProcessLines(inputFilePath));
		}

		public static string ProcessLines(string inputFilePath)
		{
			using FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open,
				FileAccess.Read, FileShare.Read); 

			using StreamReader inputFileReader = new StreamReader(inputFileStream);

			StringBuilder resultBuilder = new StringBuilder();

			bool isEven = true;
			while (!inputFileReader.EndOfStream)
			{
				string currentLine = inputFileReader.ReadLine();
                if (isEven)
                {
					string sanitizedLine = SanitizeLine(currentLine);
					resultBuilder.AppendLine(sanitizedLine);
                }

				isEven = !isEven;
            }

			return resultBuilder.ToString();
		}

		private const string CharsToReplace = "-,.!?";

		private static string SanitizeLine(string text)
		{
			foreach (char specialSymbol in CharsToReplace)
			{
				text = text.Replace(specialSymbol, '@');
			}

			string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			Array.Reverse(words);

			return string.Join(" ", words);

		}
	}
}
