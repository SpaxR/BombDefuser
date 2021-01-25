using BombDefuser.GameLogic;

namespace BombDefuser.Tests.Fakes
{
	public class GameLogicBaseFake : GameLogicBase<IInteraction>
	{
		public IInteraction ProtectedUserInteraction => base.UserInteraction;
		public FileIO       ProtectedIO              => base.IO;

		/// <inheritdoc />
		public GameLogicBaseFake(IInteraction interaction, FileIO io) : base(interaction, io) { }

		/// <inheritdoc />
		public override void MainLoop() { }
	}
}