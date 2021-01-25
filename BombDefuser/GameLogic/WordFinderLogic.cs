using System.Collections.Generic;
using System.Linq;
using BombDefuser.FileAccess;

namespace BombDefuser.GameLogic
{
	public class WordFinderLogic : GameLogicBase<IWordFinderInteraction>
	{
		private readonly WordFinderIO _io;
		private readonly string       _wordsFile;

		public WordFinderLogic(IEnumerable<string> args, IWordFinderInteraction interaction, WordFinderIO io)
			: base(interaction)
		{
			_io        = io;
			_wordsFile = args.FirstOrDefault() ?? "words.txt";
		}

		public override void MainLoop()
		{
			string[] words = _io.LoadWords(_wordsFile);


			for (int i = 0; words.Length > 1; i++)
			{
				string letters = UserInteraction.ReadLetters(i);
				words = words.Where(word => letters.Contains(word[i])).ToArray();
				UserInteraction.DisplayWordStats(words);
			}
		}
	}
}