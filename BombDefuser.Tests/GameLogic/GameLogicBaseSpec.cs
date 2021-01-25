using System;
using BombDefuser.Tests.Fakes;
using Moq;
using Xunit;

namespace BombDefuser.Tests.GameLogic
{
	public class GameLogicBaseSpec
	{
		private readonly Mock<IInteraction> _interactionMock = new Mock<IInteraction>();
		private readonly Mock<FileIO>       _ioMock          = new Mock<FileIO>();

		[Fact]
		public void Constructor_sets_properties()
		{
			var sut = new GameLogicBaseFake(_interactionMock.Object, _ioMock.Object);

			Assert.Equal(_interactionMock.Object, sut.ProtectedUserInteraction);
			Assert.Equal(_ioMock.Object,          sut.ProtectedIO);
		}


		[Fact]
		public void Missing_interaction_throws_exception()
		{
			Assert.Throws<ArgumentException>(() => new GameLogicBaseFake(null, _ioMock.Object));

			Assert.Throws<ArgumentException>(() => new GameLogicBaseFake(_interactionMock.Object, null));
		}
	}
}