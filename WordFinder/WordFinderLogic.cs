using System.Collections.Generic;
using System.Linq;

namespace WordFinder
{
	public class WordFinderLogic
	{
		private readonly Interaction _interaction;
		private          string[]    _words;

		public WordFinderLogic(IEnumerable<string> args, Interaction interaction, FileIO io)
		{
			_interaction = interaction;

			string filePath = args.FirstOrDefault() ?? "words.txt";
			_words = io.DoesFileExist(filePath) ? io.LoadWordFinderFile(filePath) : DefaultValues.WordFinderWords;
		}

		public void MainLoop()
		{
			for (int i = 0; i < 5 && _words.Length > 1; i++)
			{
				string letters = _interaction.ReadLetters(i);
				_interaction.ClearScreen();
				_words = FilterWords(_words, letters, i);
				_interaction.DisplayWordStats(_words);
			}
		}

		private string[] FilterWords(string[] words, string letters, int index)
		{
			return words.Where(word => letters.Contains(word[index])).ToArray();
		}
	}
}