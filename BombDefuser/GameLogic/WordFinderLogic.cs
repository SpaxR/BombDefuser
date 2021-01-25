using System.Linq;
using BombDefuser.Interaction;

namespace BombDefuser.GameLogic
{
	public class WordFinderLogic : GameLogicBase
	{
		private readonly WordFinderConsole _interaction;
		private readonly string[]          _words;

		public WordFinderLogic(string[] args, WordFinderConsole interaction, FileIO io) : base(args, interaction, io)
		{
			_interaction = interaction;

			string filePath = args.FirstOrDefault() ?? "words.txt";
			_words = io.DoesFileExist(filePath) ? io.LoadWordFinderFile(filePath) : DefaultValues.WordFinderWords;
		}

		public override void MainLoop()
		{
			string[] filteredWords = _words;

			for (int i = 0; i < 5 && filteredWords.Length > 1; i++)
			{
				string letters = _interaction.ReadLetters(i);
				_interaction.Reset();
				filteredWords = FilterWords(filteredWords, letters, i);
				_interaction.DisplayWordStats(filteredWords);
			}
		}

		private string[] FilterWords(string[] words, string letters, int index)
		{
			return words.Where(word => letters.Contains(word[index])).ToArray();
		}
	}
}