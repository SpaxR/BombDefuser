using BombDefuser.GameLogic;
using BombDefuser.Interaction;

namespace BombDefuser
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialise Game-Solver
			var io          = new FileIO();
			var interaction = new ConsoleInteraction();

			// Load Logic
			IGameLogic gamelogic = new WordFinderLogic(args, new WordFinderConsole(), io);

			// Interaction-Loop
			interaction.DisplayWelcomeMessage();
			do
			{
				interaction.Reset();
				gamelogic.MainLoop();
			} while (interaction.AskToContinue());

			// Exit Application
			interaction.Reset();
			interaction.DisplayGoodbyeMessage();
		}
	}
}