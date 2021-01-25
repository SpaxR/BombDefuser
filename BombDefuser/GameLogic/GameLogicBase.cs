namespace BombDefuser.GameLogic
{
	public abstract class GameLogicBase<TInteraction> : IGameLogic
	{
		protected TInteraction UserInteraction { get; }
		protected FileIO       IO              { get; }

		public GameLogicBase(string[] args, TInteraction interaction, FileIO io)
		{
			UserInteraction = interaction;
			IO              = io;
		}

		/// <inheritdoc />
		public abstract void MainLoop();
	}
}