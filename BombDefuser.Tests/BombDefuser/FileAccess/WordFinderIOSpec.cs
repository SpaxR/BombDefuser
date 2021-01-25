using BombDefuser.FileAccess;
using Xunit;

namespace BombDefuser.Tests
{
	public class WordFinderIOSpec
	{
		private readonly WordFinderIO _sut;
		private const    string       File = "words.txt";

		public WordFinderIOSpec()
		{
			_sut = new WordFinderIO();
		}

		[Theory]
		[InlineData(',')]
		[InlineData(' ')]
		[InlineData('\n')]
		public void LoadWords_uses_delimiters(char delimiter)
		{
			string content = string.Join(delimiter, DefaultValues.WordFinderWords);

			System.IO.File.WriteAllText(File, content);

			Assert.Equal(DefaultValues.WordFinderWords, _sut.LoadWords(File));
		}

		[Fact]
		public void LoadWords_trims_carriage_return()
		{
			string content = string.Join("\r\n", DefaultValues.WordFinderWords);

			System.IO.File.WriteAllText(File, content);

			Assert.All(_sut.LoadWords(File), word => Assert.DoesNotContain('\r', word));
		}

		[Fact]
		public void LoadWords_result_does_not_contain_whitespace()
		{
			const string content = ", , \n,    ";

			System.IO.File.WriteAllText(File, content);

			Assert.Empty(_sut.LoadWords(File));
		}

		[Fact]
		public void LoadWords_invalid_path_returns_default_values()
		{
			string[] words = _sut.LoadWords("does not exist");
			Assert.Equal(DefaultValues.WordFinderWords, words);
		}
	}
}