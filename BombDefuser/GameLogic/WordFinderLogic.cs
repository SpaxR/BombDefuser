using System.Collections.Generic;
using System.Linq;
using BombDefuser.FileAccess;

namespace BombDefuser.GameLogic
{
	/// <summary>Logic to solve Module 11</summary>
	public class WordFinderLogic : GameLogicBase<IWordFinderInteraction>
	{
		private readonly string _wordsFile;

		/// <inheritdoc/>
		/// <param name="words">List of possible Words</param>
		/// <param name="interaction"><see cref="IWordFinderInteraction"/></param>
		public WordFinderLogic(IEnumerable<string> words, IWordFinderInteraction interaction)
			: base(interaction)
		{
			_wordsFile = words.FirstOrDefault() ?? "words.txt";
		}

		/// <inheritdoc/>
		public override void MainLoop()
		{
			string[] words = DataAccess.WordFinderWords(_wordsFile);

			UserInteraction.DisplayWordStats(words);

			for (int i = 0; words.Length > 1; i++)
			{
				string letters = UserInteraction.ReadLetters(i);
				words = words.Where(word => letters.Contains(word[i])).ToArray();
				UserInteraction.DisplayWordStats(words);
			}
		}
	}
}