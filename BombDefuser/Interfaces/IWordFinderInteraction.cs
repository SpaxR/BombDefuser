namespace BombDefuser
{
	public interface IWordFinderInteraction : IInteraction
	{
		string ReadLetters(int index);

		void DisplayWordStats(string[] words);
	}
}