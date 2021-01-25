using System.IO;
using System.Linq;

namespace BombDefuser.FileAccess
{
	public class WordFinderIO
	{
		public string[] LoadWords(string path)
		{
			if (File.Exists(path))
			{
				return File.ReadAllText(path)
						   .Replace("\r", "") // Windows-Enter uses \r\n
						   .Split(' ', ',', '\n')
						   .Where(s => !string.IsNullOrWhiteSpace(s))
						   .ToArray();
			}

			return DefaultValues.WordFinderWords;
		}
	}
}