using Xunit;

namespace BombDefuser.Tests
{
	public class FileIOSpec
	{
		private readonly FileIO _sut;
		private const    string File = "words.txt";

		public FileIOSpec()
		{
			_sut = new FileIO();
		}

		[Theory]
		[InlineData(""), InlineData(null)]
		public void DoesFileExist_with_invalid_parameter_returns_false(string invalidPath)
		{
			Assert.False(_sut.DoesFileExist(invalidPath));
		}


		[Fact]
		public void DoesFileExist_with_existing_file_returns_true()
		{
			Assert.True(_sut.DoesFileExist(File));
		}

		[Theory]
		[InlineData(',')]
		[InlineData(' ')]
		[InlineData('\n')]
		public void LoadWordFinderFile_uses_delimiters(char delimiter)
		{
			string content = string.Join(delimiter, DefaultValues.WordFinderWords);

			System.IO.File.WriteAllText(File, content);

			Assert.Equal(DefaultValues.WordFinderWords, _sut.LoadWordFinderFile(File));
		}

		[Fact]
		public void LoadWordFinderFile_trims_carriage_return()
		{
			string content = string.Join("\r\n", DefaultValues.WordFinderWords);

			System.IO.File.WriteAllText(File, content);

			Assert.All(_sut.LoadWordFinderFile(File), word => Assert.DoesNotContain('\r', word));
		}

		[Fact]
		public void LoadWordFinderFile_result_does_not_contain_whitespace()
		{
			const string content = ", , \n,    ";

			System.IO.File.WriteAllText(File, content);

			Assert.Empty(_sut.LoadWordFinderFile(File));
		}
	}
}