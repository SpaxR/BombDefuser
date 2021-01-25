namespace BombDefuser.GameLogic
{
	public class NoopLogic : GameLogicBase<IInteraction>
	{
		/// <inheritdoc />
		public NoopLogic(IInteraction interaction) : base(interaction) { }

		/// <inheritdoc />
		public override void MainLoop()
		{
			UserInteraction.DisplayErrorMessage("Modul nicht verfügbar");
		}
	}
}