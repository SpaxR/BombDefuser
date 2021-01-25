using System;

namespace WordFinder
{
	public class ConsoleInteraction : IInteraction
	{
		/// <inheritdoc />
		public void Reset()
		{
			Console.Clear();
		}

		public void DisplayWelcomeMessage()
		{
			Console.WriteLine("Module-Solver for -- Keep Talking and Nobody Explodes --");
		}

		public void DisplayGoodbyeMessage()
		{
			Console.WriteLine("kthxbye");
		}

		public bool AskToContinue()
		{
			Console.Write("Do it Again? y/n [y]");
			string input = Console.ReadLine()?.ToLower();
			return string.IsNullOrWhiteSpace(input) || input.StartsWith("y");
		}
	}
}