namespace WordFinder
{
	public interface IInteraction
	{
		void Reset();
		void DisplayWelcomeMessage();
		void DisplayGoodbyeMessage();
		bool AskToContinue();
	}
}