using BombDefuser.FileAccess;
using Xunit;
using System;
using System.IO;

namespace BombDefuser.Tests
{
	public class FileLoaderSpec : IDisposable
	{
		private readonly string _wordsFile;

		public FileLoaderSpec() => _wordsFile = Path.GetTempFileName();

		/// <inheritdoc />
		public void Dispose() => File.Delete(_wordsFile);


		[Theory]
		[InlineData(',')]
		[InlineData(' ')]
		[InlineData('\n')]
		public void LoadWords_uses_delimiters(char delimiter)
		{
			string content = string.Join(delimiter, DefaultValues.WordFinderWords);

			File.WriteAllText(_wordsFile, content);

			Assert.Equal(DefaultValues.WordFinderWords, DataAccess.WordFinderWords(_wordsFile));
		}

		[Fact]
		public void LoadWords_trims_carriage_return()
		{
			string content = string.Join("\r\n", DefaultValues.WordFinderWords);

			System.IO.File.WriteAllText(_wordsFile, content);

			Assert.All(DataAccess.WordFinderWords(_wordsFile), word => Assert.DoesNotContain('\r', word));
		}

		[Fact]
		public void LoadWords_result_does_not_contain_whitespace()
		{
			const string content = ", , \n,    ";

			System.IO.File.WriteAllText(_wordsFile, content);

			Assert.Empty(DataAccess.WordFinderWords(_wordsFile));
		}

		[Fact]
		public void LoadWords_invalid_path_returns_default_values()
		{
			string[] words = DataAccess.WordFinderWords("does not exist");
			Assert.Equal(DefaultValues.WordFinderWords, words);
		}
	}
}