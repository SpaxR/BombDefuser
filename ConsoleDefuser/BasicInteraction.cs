using System;

namespace BombDefuser.ConsoleUI
{
	public class BasicInteraction : IInteraction
	{
		protected static void WriteColored(string text, ConsoleColor foreground, ConsoleColor background = default)
		{
			Console.ForegroundColor = foreground;
			if (background != default) Console.BackgroundColor = background;
			Console.Write(text);
			Console.ResetColor();
		}

		protected static void WriteColoredLine(string text, ConsoleColor foreground, ConsoleColor background = default)
		{
			Console.ForegroundColor = foreground;
			if (background != default) Console.BackgroundColor = background;
			Console.WriteLine(text);
			Console.ResetColor();
		}

		/// <inheritdoc />
		public void DisplayErrorMessage(string userError)
		{
			WriteColoredLine(userError, ConsoleColor.Red);
		}

		public void Reset()
			=> Console.Clear();

		public void DisplayGoodbyeMessage()
			=> Console.WriteLine("kthxbye");

		public void DisplayWelcomeMessage()
		{
			Console.WriteLine("Module-Solver for -- Keep Talking and Nobody Explodes --");
			WriteColoredLine("!!! This is an early build - Most Modules may be missing !!!", ConsoleColor.Red);
		}

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
			Console.WriteLine("Module:");
			Console.WriteLine(" - - - - - ");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(" 1. Drähte");
			Console.WriteLine(" 2. Großer Knopf");
			Console.WriteLine(" 3. Tastenfeld");
			Console.WriteLine(" 4. Simon sagt");
			Console.WriteLine(" 5. \"Was\" steht auf dem Knopf");
			Console.WriteLine(" 6. Memory");
			Console.WriteLine(" 7. Morsecode");
			Console.WriteLine(" 8. Komplizierte Drähte");
			Console.WriteLine(" 9. Drahtfolgen");
			Console.WriteLine("10. Labyrinth");
			Console.ResetColor();
			Console.WriteLine("11. Passwort");
			Console.WriteLine(" - - - - - ");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("12. Gas ablesen");
			Console.WriteLine("13. Kondensator entladen");
			Console.WriteLine("14. Drehknopf");
			Console.ResetColor();
			Console.WriteLine(" B. Beenden");
			Console.WriteLine(" - - - - - ");

			Console.Write("Auswahl:");
			string input = Console.ReadLine()?.ToLower() ?? string.Empty;

			if (input.StartsWith('b')) return -1;

			return int.TryParse(input, out int result) ? result : throw new Exception("Fehlerhafte Eingabe");
		}
	}
}