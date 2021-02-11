using System.IO;
using System.Linq;

namespace BombDefuser.FileAccess
{
	public static class DataAccess
	{
		/// <summary>Attempts to load a list of Words for the WordFinder-Module</summary>
		/// <param name="path">Path of the Words-File</param>
		/// <returns>Array of words from the file, or a default-list if the File could not be loaded</returns>
		public static string[] WordFinderWords(string path)
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