using System;

namespace BombDefuser.ConsoleUI
{
	public class BasicInteraction : IInteraction
	{
		public void Reset()
			=> Console.Clear();

		public void DisplayGoodbyeMessage()
			=> Console.WriteLine("kthxbye");

		public void DisplayWelcomeMessage()
			=> Console.WriteLine("Module-Solver for -- Keep Talking and Nobody Explodes --");

		public int AskToContinue(int previousModule = 0)
		{
			Console.Write("[N]ochmal, [M]enü, Module-[Num], [B]eenden? [N]");
			string input = Console.ReadLine()?.ToLower() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(input) || input.StartsWith('n'))
				return previousModule;

			if (input.StartsWith('m')) return 0;
			if (input.StartsWith('b')) return -1;

			return int.TryParse(input, out int result)
				? result
				: throw new Exception("Fehlerhafte Eingabe");
		}

		/// <inheritdoc />
		public int AskForSolverModule()
		{
			Console.WriteLine("Select Module:");
			Console.WriteLine("1. Drähte");
			Console.WriteLine("2. Großer Knopf");
			Console.WriteLine("3. Tastenfeld");
			Console.WriteLine("4. Simon sagt");
			Console.WriteLine("5. \"Was\" steht auf dem Knopf");
			Console.WriteLine("6. Memory");
			Console.WriteLine("7. Morsecode");
			Console.WriteLine("8. Komplizierte Drähte");
			Console.WriteLine("9. Drahtfolgen");
			Console.WriteLine("10. Labyrinth");
			Console.WriteLine("11. Passwort");
			Console.WriteLine(" - - - - - ");
			Console.WriteLine("12. Gas ablesen");
			Console.WriteLine("13. Kondensator entladen");
			Console.WriteLine("14. Drehknopf");
			Console.WriteLine("B. Beenden");

			return int.TryParse(Console.ReadLine(), out int result) ? result : -1;
		}
	}
}