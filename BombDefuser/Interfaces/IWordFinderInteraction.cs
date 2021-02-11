namespace BombDefuser
{
	/// <inheritdoc/>
	public interface IWordFinderInteraction : IInteraction
	{
		/// <summary> Reads the Letters for the requested index </summary>
		/// <param name="index">The index to ask for</param>
		/// <returns>The read Letters</returns>
		string ReadLetters(int index);

		/// <summary>Displays the words that are remaining</summary>
		/// <param name="words">The remaining words</param>
		void DisplayWordStats(string[] words);
	}
}