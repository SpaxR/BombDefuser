using System;

namespace WordFinder
{
	class Program
	{
		static void Main(string[] args)
		{
			// TODO Load Word-File

			var interaction = new Interaction();

			interaction.WriteInitialMessage();

			while (interaction.AskToContinue())
			{
				string letters = interaction.ReadLetters(0);
				// Read Letters
				// Display Stats
				// -- Repeat until Result found

				Console.WriteLine("Not implemented yet!");
			}


			interaction.WriteGoodbyeMessage();
		}
	}
}