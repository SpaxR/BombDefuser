namespace BombDefuser
{
	public interface IInteraction
	{
		void Reset();
		void DisplayWelcomeMessage();
		void DisplayGoodbyeMessage();

		/// <summary> Asks the User how to continue </summary>
		/// <param name="previousModule">number of the previously used Module (default to zero (menu))</param>
		/// <returns>
		///	Number depending on Users decision:
		/// Negative - Quit Application
		/// Zero - Back to Module-Selection
		/// Positive - Switch to Module
		/// </returns>
		int AskToContinue(int previousModule = 0);

		int AskForSolverModule();
	}
}