using System.Linq;
using BombDefuser.Interaction;

namespace BombDefuser.GameLogic
{
	public class WordFinderLogic : GameLogicBase
	{
		private readonly WordFinderConsole _interaction;
		private          string[]          _words;

		public WordFinderLogic(string[] args, WordFinderConsole interaction, FileIO io) : base(args, interaction, io)
		{
			_interaction = interaction;

			string filePath = args.FirstOrDefault() ?? "words.txt";
			_words = io.DoesFileExist(filePath) ? io.LoadWordFinderFile(filePath) : DefaultValues.WordFinderWords;
		}

		public override void MainLoop()
		{
			for (int i = 0; i < 5 && _words.Length > 1; i++)
			{
				string letters = _interaction.ReadLetters(i);
				_interaction.Reset();
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