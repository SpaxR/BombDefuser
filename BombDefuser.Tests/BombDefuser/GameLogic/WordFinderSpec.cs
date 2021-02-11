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
		
		protected WordFinderSpec()
		{
			File.WriteAllText(WordsFile, string.Join(',', DefaultValues.WordFinderWords));
			_sut = new WordFinderLogic(new[]
			{
				WordsFile
			}, _interactionMock.Object);
		}

		public class MainLoop : WordFinderSpec
		{
			[Fact]
			public void starts_with_reading_first_letters()
			{
				_interactionMock.Setup(interaction => interaction.ReadLetters(0))
								.Returns("");

				_sut.MainLoop();

				_interactionMock.Verify(interaction => interaction.ReadLetters(0), Times.Once);
			}

			[Fact]
			public void after_reading_letters_displays_matching_words()
			{
				_interactionMock.Setup(interaction => interaction.ReadLetters(0)).Returns("a");
				_interactionMock.Setup(interaction => interaction.ReadLetters(1)).Returns("!"); // No Matching Word

				_sut.MainLoop();

				_interactionMock.Verify(interaction => interaction.DisplayWordStats(new[]
				{
					"angst",
					"atmen"
				}), Times.Once);
			}

			[Fact]
			public void no_matching_word_displays_no_matching_results_found()
			{
				_interactionMock.Setup(interaction => interaction.ReadLetters(0))
								.Returns("");

				_sut.MainLoop();

				_interactionMock.Verify(interaction => interaction.DisplayWordStats(Array.Empty<string>()), Times.Once);
			}

			[Fact]
			public void reads_letters_until_result_is_found()
			{
				_interactionMock.Setup(interaction => interaction.ReadLetters(0)).Returns("a");
				_interactionMock.Setup(interaction => interaction.ReadLetters(1)).Returns("n");

				_sut.MainLoop();

				_interactionMock.Verify(interaction => interaction.ReadLetters(0), Times.Once);
				_interactionMock.Verify(interaction => interaction.ReadLetters(1), Times.Once);
			}

			[Fact]
			public void reads_until_one_match_is_found()
			{
				_interactionMock.Setup(interaction => interaction.ReadLetters(0)).Returns("a");
				_interactionMock.Setup(interaction => interaction.ReadLetters(1)).Returns("n");
				_interactionMock.Setup(interaction => interaction.ReadLetters(2)).Returns("g");
				_interactionMock.Setup(interaction => interaction.ReadLetters(3)).Returns("s");
				_interactionMock.Setup(interaction => interaction.ReadLetters(4)).Returns("t");

				_sut.MainLoop();

				_interactionMock.Verify(interaction => 
											interaction.DisplayWordStats(
												It.Is<string[]>(words => words.Contains("angst"))),
										Times.Exactly(3));

				_interactionMock.Verify(interaction =>
											interaction.DisplayWordStats(
												It.Is<string[]>(words => words.Length == 1)),
										Times.Once);
			}
			
			[Fact]
			public void runs_until_no_match_is_found()
			{
				_interactionMock.Setup(interaction => interaction.ReadLetters(0)).Returns("az");
				_interactionMock.Setup(interaction => interaction.ReadLetters(1)).Returns("z");
				
				_sut.MainLoop();
				
				_interactionMock.Verify(interaction => interaction.ReadLetters(It.IsAny<int>()), Times.Exactly(2));
			}
		}
	}
}