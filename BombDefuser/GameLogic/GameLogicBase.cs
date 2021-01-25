using System;

namespace BombDefuser.GameLogic
{
	// TODO Unit-Test
	public abstract class GameLogicBase<TInteraction> : IGameLogic
	{
		protected TInteraction UserInteraction { get; }
		protected FileIO       IO              { get; }

		protected GameLogicBase(TInteraction interaction, FileIO io)
		{
			UserInteraction = interaction ?? throw new ArgumentException("Missing Parameter", nameof(interaction));
			IO              = io          ?? throw new ArgumentException("Missing Parameter", nameof(io));
		}

		/// <inheritdoc />
		public abstract void MainLoop();
	}
}