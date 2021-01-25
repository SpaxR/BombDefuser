namespace WordFinder
{
	class Program
	{
		static void Main(string[] args)
		{
			var interaction = new Interaction();
			var gamelogic   = new WordFinderLogic();
			interaction.WriteInitialMessage();

			do
			{
				interaction.ClearScreen();
				gamelogic.MainLoop(interaction);
			} while (interaction.AskToContinue());

			interaction.ClearScreen();
			interaction.WriteGoodbyeMessage();
		}
	}
}