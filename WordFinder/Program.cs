namespace WordFinder
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialise Game-Solver
			var io          = new FileIO();
			var interaction = new Interaction();

			// Load Logic
			var gamelogic = new WordFinderLogic(args, interaction, io);

			// Interaction-Loop
			interaction.WriteInitialMessage();
			do
			{
				interaction.ClearScreen();
				gamelogic.MainLoop();
			} while (interaction.AskToContinue());

			// Exit Application
			interaction.ClearScreen();
			interaction.WriteGoodbyeMessage();
		}
	}
}