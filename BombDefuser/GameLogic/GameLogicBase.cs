using System;

namespace BombDefuser.GameLogic
{
	// TODO Unit-Test
	public abstract class GameLogicBase<TInteraction> : IGameLogic where TInteraction : IInteraction
	{
		protected TInteraction UserInteraction { get; }

		protected GameLogicBase(TInteraction interaction)
		{
			UserInteraction = interaction ?? throw new ArgumentException("Missing Parameter", nameof(interaction));
		}

		/// <inheritdoc />
		public abstract void MainLoop();
	}
}