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
						LoadModule(menuChoice, args).MainLoop();
						menuChoice = interaction.AskToContinue(menuChoice);
						break;
				}

				interaction.Reset();
			} while (menuChoice >= 0);


			// Exit Application
			interaction.DisplayGoodbyeMessage();
		}

		private static IGameLogic LoadModule(int num, IEnumerable<string> args)
		{
			return num == 11
				? new WordFinderLogic(args, new WordFinderConsole())
				: new NoopLogic(new BasicInteraction());
		}
	}
}