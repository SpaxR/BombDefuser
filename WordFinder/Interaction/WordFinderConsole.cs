using System;
using System.Linq;

namespace WordFinder
{
	public class WordFinderConsole : ConsoleInteraction
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

			Console.Write($"Input {column} letter:");
			return Console.ReadLine();
		}

		public void DisplayWordStats(string[] words)
		{
			switch (words.Length)
			{
				case 0:
					Console.WriteLine("Not Matches Found !!!");
					return;
				case 1:
					Console.WriteLine("Found Match: " + words.Single());
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