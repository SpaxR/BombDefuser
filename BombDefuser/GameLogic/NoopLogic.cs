namespace BombDefuser.GameLogic
{
	/// <summary>Represents a non-operational Logic for not implemented Modules</summary>
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