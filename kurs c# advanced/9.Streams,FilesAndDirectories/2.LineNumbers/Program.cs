namespace LineNumbers
{
	public class LineNumbers
	{
		static void Main()
		{
			string inputPath = @"..\..\..\Files\input.txt";
			string outputPath = @"..\..\..\Files\output.txt";

			RewriteFileWithLineNumbers(inputPath, outputPath);
		}

		public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
		{
			using (StreamWriter writer = new StreamWriter(outputFilePath))
			{
				using (StreamReader reader = new StreamReader(inputFilePath))
				{

					string line;
					int lineNumber = 1;
					while ((line = reader.ReadLine()) != null)
					{
						writer.WriteLine($"{lineNumber++}. {line}");
					}
				}
			}
		}
	}
}


