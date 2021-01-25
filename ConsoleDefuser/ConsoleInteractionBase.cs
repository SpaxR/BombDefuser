using System;

namespace BombDefuser.ConsoleUI
{
	public abstract class ConsoleInteractionBase : IInteraction
	{
		public void Reset()
			=> Console.Clear();

		public void DisplayGoodbyeMessage()
			=> Console.WriteLine("kthxbye");

		public void DisplayWelcomeMessage()
			=> Console.WriteLine("Module-Solver for -- Keep Talking and Nobody Explodes --");

		public bool AskToContinue()
		{
			Console.Write("Do it Again? y/n [y]");
			string input = Console.ReadLine()?.ToLower();
			return string.IsNullOrWhiteSpace(input) || input.StartsWith("y");
		}
	}
}