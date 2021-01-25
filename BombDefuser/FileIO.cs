using System.IO;
using System.Linq;

namespace BombDefuser
{
	public class FileIO
	{
		public bool DoesFileExist(string path)
		{
			return !string.IsNullOrWhiteSpace(path) && File.Exists(path);
		}

		public string[] LoadWordFinderFile(string path)
		{
			return File.ReadAllText(path)
					   .Split(' ', ',', '\n')
					   .Where(s => !string.IsNullOrWhiteSpace(s))
					   .ToArray();
		}
	}
}