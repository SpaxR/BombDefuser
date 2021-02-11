using System;
using BombDefuser.Tests.Fakes;
using Moq;
using Xunit;

namespace BombDefuser.Tests
{
	public class GameLogicBaseSpec
	{
		private readonly Mock<IInteraction> _interactionMock = new Mock<IInteraction>();

		public class Constructor : GameLogicBaseSpec
		{
			[Fact]
			public void Constructor_sets_properties()
			{
				var sut = new GameLogicBaseFake(_interactionMock.Object);

				Assert.Equal(_interactionMock.Object, sut.ProtectedUserInteraction);
			}


			[Fact]
			public void Missing_interaction_throws_exception()
			{
				Assert.Throws<ArgumentException>(() => new GameLogicBaseFake(null));
			}
		}
	}
}