using System.Collections.Generic;
using BombDefuser.GameLogic;

namespace BombDefuser.ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialise Game-Solver
			var interaction = new BasicInteraction();

			// Interaction-Loop
			interaction.DisplayWelcomeMessage();

			int menuChoice = 0;

			do
			{
				switch (menuChoice)
				{
					case 0:
						menuChoice = interaction.AskForSolverModule();
						break;
					case > 0:
						interaction.Reset();
						LoadModule(menuChoice, args).MainLoop();
						menuChoice = interaction.AskToContinue(menuChoice);
						break;
				}
			} while (menuChoice >= 0);


			// Exit Application
			interaction.Reset();
			interaction.DisplayGoodbyeMessage();
		}

		private static IGameLogic LoadModule(int num, IEnumerable<string> args)
		{
			return new WordFinderLogic(args, new WordFinderConsole());
		}
	}
}