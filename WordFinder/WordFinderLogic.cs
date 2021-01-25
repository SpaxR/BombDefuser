using System.Linq;

namespace WordFinder
{
	public class WordFinderLogic
	{
		private static readonly string[] BaseWords = {"abc", "def", "abf", "asd"};

		public WordFinderLogic()
		{
			// TODO Load Word-File
		}

		public void MainLoop(Interaction interaction)
		{
			string[] filteredWords = BaseWords;

			for (int i = 0; i < 5 && filteredWords.Length > 1; i++)
			{
				string letters = interaction.ReadLetters(i);
				interaction.ClearScreen();
				filteredWords = FilterWords(filteredWords, letters, i);
				interaction.DisplayWordStats(filteredWords);
			}
		}

		public string[] FilterWords(string[] words, string letters, int index)
		{
			return words.Where(word => letters.Contains(word[index])).ToArray();
		}
	}
}