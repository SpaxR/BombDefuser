using BombDefuser.FileAccess;
using BombDefuser.GameLogic;

namespace BombDefuser.ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialise Game-Solver
			var interaction = new WordFinderConsole();
			var io          = new WordFinderIO();
			var gamelogic   = new WordFinderLogic(args, interaction, io);

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