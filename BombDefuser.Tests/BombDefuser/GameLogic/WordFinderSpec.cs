using System;
using System.IO;
using System.Linq;
using BombDefuser.GameLogic;
using Moq;
using Xunit;

namespace BombDefuser.Tests
{
	public class WordFinderSpec
	{
		private readonly WordFinderLogic              _sut;
		private readonly Mock<IWordFinderInteraction> _interactionMock = new Mock<IWordFinderInteraction>();
		private const    string                       WordsFile        = "words.txt";


		public WordFinderSpec()
		{
			File.WriteAllText(WordsFile, string.Join(',', DefaultValues.WordFinderWords));
			_sut = new WordFinderLogic(new[] {WordsFile}, _interactionMock.Object);
		}

		[Fact]
		public void MainLoop_starts_with_reading_first_letters()
		{
			_interactionMock.Setup(interaction => interaction.ReadLetters(0))
							.Returns("");

			_sut.MainLoop();

			_interactionMock.Verify(interaction => interaction.ReadLetters(0), Times.Once);
		}

		[Fact]
		public void After_reading_letters_displays_matching_words()
		{
			_interactionMock.Setup(interaction => interaction.ReadLetters(0)).Returns("a");
			_interactionMock.Setup(interaction => interaction.ReadLetters(1)).Returns("!"); // No Matching Word

			_sut.MainLoop();

			_interactionMock.Verify(interaction => interaction.DisplayWordStats(new[] {"angst", "atmen"}), Times.Once);
		}

		[Fact]
		public void No_matching_word_displays_not_matching_results_found()
		{
			_interactionMock.Setup(interaction => interaction.ReadLetters(0))
							.Returns("");

			_sut.MainLoop();

			_interactionMock.Verify(interaction => interaction.DisplayWordStats(Array.Empty<string>()), Times.Once);
		}

		[Fact]
		public void MainLoop_reads_letters_until_result_is_found()
		{
			_interactionMock.Setup(interaction => interaction.ReadLetters(0)).Returns("a");
			_interactionMock.Setup(interaction => interaction.ReadLetters(1)).Returns("n");

			_sut.MainLoop();

			_interactionMock.Verify(interaction => interaction.ReadLetters(0), Times.Once);
			_interactionMock.Verify(interaction => interaction.ReadLetters(1), Times.Once);
		}

		[Fact]
		public void MainLoop_reads_until_one_match_is_found()
		{
			_interactionMock.Setup(interaction => interaction.ReadLetters(0)).Returns("a");
			_interactionMock.Setup(interaction => interaction.ReadLetters(1)).Returns("n");
			_interactionMock.Setup(interaction => interaction.ReadLetters(2)).Returns("g");
			_interactionMock.Setup(interaction => interaction.ReadLetters(3)).Returns("s");
			_interactionMock.Setup(interaction => interaction.ReadLetters(4)).Returns("t");

			_sut.MainLoop();

			_interactionMock.Verify(interaction =>
										interaction.DisplayWordStats(It.Is<string[]>(words => words.Contains("angst"))),
									Times.Exactly(2));

			_interactionMock.Verify(interaction =>
										interaction.DisplayWordStats(It.Is<string[]>(words => words.Length == 1)),
									Times.Once);
		}

		[Fact]
		public void MainLoop_runs_at_most_five_times()
		{
			_interactionMock.Setup(interaction => interaction.ReadLetters(0)).Returns("aa");
			_interactionMock.Setup(interaction => interaction.ReadLetters(1)).Returns("nt");
			_interactionMock.Setup(interaction => interaction.ReadLetters(2)).Returns("gm");
			_interactionMock.Setup(interaction => interaction.ReadLetters(3)).Returns("se");
			_interactionMock.Setup(interaction => interaction.ReadLetters(4)).Returns("tn");
			_interactionMock.Setup(interaction => interaction.ReadLetters(4)).Returns("");

			_sut.MainLoop();

			_interactionMock.Verify(interaction => interaction.DisplayWordStats(It.IsAny<string[]>()), Times.AtMost(5));
		}
	}
}