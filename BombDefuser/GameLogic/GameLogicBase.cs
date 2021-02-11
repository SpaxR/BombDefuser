using System;

namespace BombDefuser.GameLogic
{
	// TODO Unit-Test
	/// <inheritdoc />
	/// <summary>Baseclass for Module-Logic with a strongly typed Interaction</summary>
	/// <typeparam name="TInteraction"></typeparam>
	public abstract class GameLogicBase<TInteraction> : IGameLogic where TInteraction : IInteraction
	{
		/// <summary>Instance of <see cref="TInteraction"/> that is used to interact with the User </summary>
		protected TInteraction UserInteraction { get; }

		/// <summary>Creates an instance of this class to solve a Module</summary>
		/// <param name="interaction">
		/// Object to use for User-Interaction,
		/// throws <exception cref="ArgumentException"/> if it is null
		/// </param>
		protected GameLogicBase(TInteraction interaction)
		{
			UserInteraction = interaction ?? throw new ArgumentException("Missing Parameter", nameof(interaction));
		}

		/// <inheritdoc />
		public abstract void MainLoop();
	}
}