using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ROMSharp
{
	public class Character
	{
		/// <summary>
		/// Indicates whether the specified character name <paramref name="charName"/> is a known character
		/// </summary>
		/// <param name="charName">Name to search for</param>
		/// <returns><value>True</value> if the specified character is known, <value>False</value> otherwise.</returns>
		public static bool Exists(string charName)
		{
			// TODO: Run this through the persistent data store.
			// For now, just hard-code it
			return charName.Equals ("Seaf", StringComparison.InvariantCultureIgnoreCase);
		}

		/// <summary>
		/// Determines whether the specified name <paramref name="charName"/> meets legality rules
		/// </summary>
		/// <returns><c>true</c> if is a legal name; otherwise, <c>false</c>.</returns>
		/// <param name="charName">Character name</param>
		public static bool IsLegalName(string charName)
		{
			// Trim the input
			charName = charName.Trim();

			// Test 1: Is the name an outright illegal one?
			if (Consts.Strings.IllegalNames.Contains(charName, StringComparer.InvariantCultureIgnoreCase))
				return false;

			// Test 2: Is the name the same as one of our clans?
			// TODO: Implement

			// Test 3: Is the name too short or too long?
			if (charName.Length < Consts.Misc.CharacterName.MinLength || charName.Length > Consts.Misc.CharacterName.MaxLength)
				return false;

			// Test 4: Is the name all caps?
			if (charName.ToUpper ().Equals (charName, StringComparison.InvariantCulture))
				return false;

			// Test 5: Does the name have non-alphanumeric characters?
			if (Regex.IsMatch (charName, "[^a-zA-Z0-9]"))
				return false;

			// Test 6: Is the name shared by a mob?
			// TODO: Implement

			// If we get here, the name must be fine
			return true;
		}

		public Character ()
		{
		}
	}
}

