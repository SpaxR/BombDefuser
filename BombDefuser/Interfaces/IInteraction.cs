namespace BombDefuser
{
	/// <summary> Represents the Interaction with a User </summary>
	public interface IInteraction
	{
		/// <summary> Resets the Screen or Display to it's default State </summary>
		void Reset();

		/// <summary> Displays a Welcome-Message to the User </summary>
		void DisplayWelcomeMessage();

		/// <summary> Displays a Goodbye-Message to the User </summary>
		void DisplayGoodbyeMessage();

		/// <summary> Displays an Error-Message </summary>
		/// <param name="userError"> The Message to display </param>
		void DisplayErrorMessage(string userError);

		/// <summary> Asks the User how to continue </summary>
		/// <param name="previousModule"> Number of the previously used Module (defaults to zero (menu)) </param>
		/// <returns>
		///	Number depending on Users decision:
		/// Negative - Quit Application
		/// Zero - Back to Module-Selection
		/// Positive - Switch to Module
		/// </returns>
		int AskToContinue(int previousModule = 0);

		/// <summary> Asks the User to Select a Module </summary>
		/// <returns> Number of the selected Module, or a negative Number to exit </returns>
		int AskForSolverModule();
	}
}