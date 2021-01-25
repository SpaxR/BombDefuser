using BombDefuser.GameLogic;

namespace BombDefuser.Tests.Fakes
{
	public class GameLogicBaseFake : GameLogicBase<IInteraction>
	{
		public IInteraction ProtectedUserInteraction => UserInteraction;

		/// <inheritdoc />
		public GameLogicBaseFake(IInteraction interaction) : base(interaction) { }

		/// <inheritdoc />
		public override void MainLoop() { }
	}
}