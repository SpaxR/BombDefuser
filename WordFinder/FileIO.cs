using System.IO;

namespace WordFinder
{
	public class FileIO
	{
		public bool DoesFileExist(string path)
		{
			return !string.IsNullOrWhiteSpace(path) && File.Exists(path);
		}

		public string[] LoadWordFinderFile(string path)
		{
			File.ReadAllText(path);
			return null;
		}
	}
}