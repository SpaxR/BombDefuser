using System;
using System.Linq;

namespace BombDefuser.ConsoleUI
{
	public class WordFinderConsole : BasicInteraction, IWordFinderInteraction
	{
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
					WriteColoredLine("Not Matches Found !!!", ConsoleColor.Red);
					return;
				case 1:
					Console.WriteLine("!!! Found Match !!!");
					WriteColoredLine("--- " + words.Single() + " ---", ConsoleColor.Yellow);
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