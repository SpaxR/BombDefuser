using System;

namespace WordFinder
{
	public class Interaction
	{
		public void WriteInitialMessage()
		{
			Console.WriteLine("Word-Finder for -- Keep Talking and Nobody Explodes --");
		}

		public void WriteGoodbyeMessage()
		{
			Console.WriteLine("kthxbye");
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

			Console.Write($"Input {column} letter:");
			return Console.ReadLine();
		}


		public bool AskToContinue()
		{
			Console.Write("Do it Again? y/n [y]");
			string input = Console.ReadLine()?.ToLower();
			return string.IsNullOrWhiteSpace(input) || input.StartsWith("y");
		}
	}
}