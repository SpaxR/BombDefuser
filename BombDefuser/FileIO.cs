using System.IO;
using System.Linq;

namespace BombDefuser
{
	public class FileIO
	{
		public bool DoesFileExist(string path)
		{
			return File.Exists(path);
		}

		public string[] LoadWordFinderFile(string path)
		{
			return File.ReadAllText(path)
					   .Replace("\r", "") // Windows-Enter uses \r\n
					   .Split(' ', ',', '\n')
					   .Where(s => !string.IsNullOrWhiteSpace(s))
					   .ToArray();
		}
	}
}