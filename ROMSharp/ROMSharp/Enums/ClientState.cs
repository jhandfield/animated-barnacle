using System;

namespace ROMSharp.Enums
{
	/// <summary>
	/// Represents the state of the client in-game
	/// </summary>
	public enum ClientState
	{
		/// <summary>
		/// The next input from the client will be treated as the character name being logged into
		/// </summary>
		Login_WaitingForCharacterName,

		/// <summary>
		/// The next input is the user's password
		/// </summary>
		Login_WaitingForPassword,

		/// <summary>
		/// The next input is the user's chosen password
		/// </summary>
		Creation_WaitingForPassword,

		/// <summary>
		/// The next input is the user confirming their password
		/// </summary>
		Creation_WaitingForPasswordConfirm,

		/// <summary>
		/// The next input is the user choosing their character's race
		/// </summary>
		Creation_WaitingForRace,

		/// <summary>
		/// The next input is the user choosing their character's gender
		/// </summary>
		Creation_WaitingForGender,

		/// <summary>
		/// The next input is the user choosing their class
		/// </summary>
		Creation_WaitingForClass,

		/// <summary>
		/// The next input is the user choosing their alignment
		/// </summary>
		Creation_WaitingForAlignment,

		/// <summary>
		/// The next input is the user choosing Y/N as to whether they want to customize their character's skills
		/// </summary>
		Creation_WaitingForCustomizationYN,

		/// <summary>
		/// The next input is the user choosing their starting weapon
		/// </summary>
		Creation_WaitingForStartingWeapon,

		/// <summary>
		/// The next input is the user accepting the MOTD
		/// </summary>
		Creation_WaitingForFinalConfirmation,

		/// <summary>
		/// Indicates we're not waiting for anything special, treat the next input as a regular command + argument combo
		/// </summary>
		Idle
	}
}