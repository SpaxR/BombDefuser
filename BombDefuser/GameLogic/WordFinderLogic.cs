using System.Collections.Generic;
using System.Linq;

namespace BombDefuser.GameLogic
{
	public class WordFinderLogic : GameLogicBase<IWordFinderInteraction>
	{
		private readonly string _wordsFile;

		public WordFinderLogic(IEnumerable<string> args, IWordFinderInteraction interaction, FileIO io)
			: base(interaction, io)
		{
			_wordsFile = args?.FirstOrDefault() ?? "words.txt";
		}

		public override void MainLoop()
		{
			string[] words = IO.DoesFileExist(_wordsFile)
				? IO.LoadWordFinderFile(_wordsFile)
				: DefaultValues.WordFinderWords;


			for (int i = 0; words.Length > 1; i++)
			{
				string letters = UserInteraction.ReadLetters(i);
				UserInteraction.Reset();
				words = words.Where(word => letters.Contains(word[i])).ToArray();
				UserInteraction.DisplayWordStats(words);
			}
		}
	}
}