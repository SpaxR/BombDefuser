using System;
using System.Linq;

namespace BombDefuser.ConsoleUI
{
	public class WordFinderConsole : IWordFinderInteraction
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
			string input = Console.ReadLine()?.ToLower() ?? string.Empty;
			return string.IsNullOrWhiteSpace(input) || input.StartsWith("y");
		}

		public string ReadLetters(int index)
		{
			string column = index switch
			{
				0 => "first",
				1 => "second",
				2 => "third",
				3 => "fourth",
				4 => "fifth",
				5 => "sixth",
				_ => "unknown"
			};

			Console.Write($"Input {column} letters:");
			string result = Console.ReadLine()?.TrimEnd('\r') ?? string.Empty;
			Console.Clear();
			return result;
		}

		public void DisplayWordStats(string[] words)
		{
			switch (words.Length)
			{
				case 0:
					Console.WriteLine("Not Matches Found !!!");
					return;
				case 1:
					Console.WriteLine("!!! Found Match !!!");
					Console.WriteLine("--- " + words.Single() + " ---");
					return;
				default:
					Console.WriteLine(words.Length + " words matching");
					Console.WriteLine(" - - - - - ");
					foreach (string word in words)
					{
						Console.WriteLine(" - " + word);
					}

					Console.WriteLine(" - - - - - ");
					break;
			}
		}
	}
}