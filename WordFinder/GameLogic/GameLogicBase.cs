namespace WordFinder
{
	public abstract class GameLogicBase : IGameLogic
	{
		public IInteraction UserInteraction { get; }
		public FileIO       IO              { get; }

		public GameLogicBase(string[] args, IInteraction interaction, FileIO io)
		{
			UserInteraction = interaction;
			IO              = io;
		}

		/// <inheritdoc />
		public abstract void MainLoop();
	}
}