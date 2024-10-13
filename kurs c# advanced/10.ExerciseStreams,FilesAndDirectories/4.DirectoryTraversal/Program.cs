namespace DirectoryTraversal
{
	using System;
	using System.Text;

	public class DirectoryTraversal
	{
		static void Main()
		{
			string path = Console.ReadLine();
			string reportFileName = @"\report.txt";

			string reportContent = TraverseDirectory(path);
			Console.WriteLine(reportContent);

			WriteReportToDesktop(reportContent, reportFileName);
		}

		public static string TraverseDirectory(string inputFolderPath)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);
			FileInfo[] files = directoryInfo.GetFiles();

			Dictionary<string, List<FileInfo>> filesByExtention = new Dictionary<string, List<FileInfo>>();

			foreach (FileInfo file in files)
			{
				if (!filesByExtention.ContainsKey(file.Extension))
				{
					filesByExtention[file.Extension] = new List<FileInfo>();
				}

				filesByExtention[file.Extension].Add(file);
			}

			StringBuilder result = new StringBuilder();
			foreach (var (extention, relatedFiles) in filesByExtention.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
			{
				result.AppendLine(extention);

				foreach (FileInfo file in relatedFiles.OrderBy(x => x.Length))
				{
					result.AppendLine($"--{file.Name} - {file.Length / 1024.0}kb");
				}
			}
				return result.ToString();
		}

		public static void WriteReportToDesktop(string textContent, string reportFileName)
		{
			string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string pathToReportFile = Path.Combine(pathToDesktop, reportFileName);

			File.WriteAllText(pathToReportFile, textContent);
		}
	}
}
