using System;
using ROMSharp.Enums;
using ROMSharp.Models;

namespace ROMSharp.Helpers
{
    public static class AlphaConversions
    {
        /// <summary>
        /// Converts legacy ROM macro-based flags to an int
        /// </summary>
        /// <returns>The integer representation of <paramref name="inputFlag"/></returns>
        /// <param name="inputFlag">Legacy ROM flags to convert; must contain no characters other than A-ee</param>
        public static int ConvertROMAlphaToInt32(string inputFlag)
        {
            // Check if input flag is 0
            if (inputFlag.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlag)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                Enums.AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Return the raw inFlagSum value
            return inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based room flags to a RoomAttributes object
        /// </summary>
        /// <returns>A RoomAttributes object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static RoomAttributes ConvertROMAlphaToRoomAttributes(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;
            
            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                Enums.AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a RoomAttributes value and return it
            return (RoomAttributes)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based action flags to an ActionFlag object
        /// </summary>
        /// <returns>An ActionFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static ActionFlag ConvertROMAlphaToActionFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;
            
            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a ActionFlag value and return it
            return (ActionFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based room flags to a RoomAttributes object
        /// </summary>
        /// <returns>A RoomAttributes object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static AffectedByFlag ConvertROMAlphaToAffectedByFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                Enums.AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a AffectedByFlag value and return it
            return (AffectedByFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based action flags to an FormFlag object
        /// </summary>
        /// <returns>A FormFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static FormFlag ConvertROMAlphaToFormFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;
            
            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a FormFlag value and return it
            return (FormFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based part flags to a PartFlag object
        /// </summary>
        /// <returns>A PartFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static PartFlag ConvertROMAlphaToPartFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;
            
            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a PartFlag value and return it
            return (PartFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based offense flags to an OffensiveFlag object
        /// </summary>
        /// <returns>A FormFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static OffensiveFlag ConvertROMAlphaToOffensiveFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a OffensiveFlag value and return it
            return (OffensiveFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based immunity flags to an ImmunityFlag object
        /// </summary>
        /// <returns>An ImmunityFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static ImmunityFlag ConvertROMAlphaToImmunitylag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a ImmunityFlag value and return it
            return (ImmunityFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based resistace flags to a ResistanceFlag object
        /// </summary>
        /// <returns>A RestistanceFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static ResistanceFlag ConvertROMAlphaToResistanceFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a ResistanceFlag value and return it
            return (ResistanceFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based vulnerability flags to a VulnerabilityFlag object
        /// </summary>
        /// <returns>A VulnerabilityFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static VulnerabilityFlag ConvertROMAlphaToVulnerabilityFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a VulnerabilityFlag value and return it
            return (VulnerabilityFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based item extra flags to a ItemExtraFlag object
        /// </summary>
        /// <returns>A ItemExtraFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static ItemExtraFlag ConvertROMAlphaToItemExtraFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a ItemExtraFlag value and return it
            return (ItemExtraFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based wear flags to a WearFlag object
        /// </summary>
        /// <returns>A WearFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static WearFlag ConvertROMAlphaToWearFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a WearFlag value and return it
            return (WearFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based weapon flags to a WeaponFlag object
        /// </summary>
        /// <returns>A WeaponFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static WeaponFlag ConvertROMAlphaToWeaponFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a WeaponFlag value and return it
            return (WeaponFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based container flags to a WeaponFlag object
        /// </summary>
        /// <returns>A WeaponFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static ContainerFlag ConvertROMAlphaToContainerFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return 0;

            // Will hold the sum of the flags for conversion
            int inFlagsSum = 0;

            // Buffer to hold multi-character flags
            string charFlagBuffer = String.Empty;

            // Loop over each character
            foreach (char c in inputFlags)
            {
                // Set or append the current character
                if (String.IsNullOrEmpty((charFlagBuffer)))
                    charFlagBuffer = c.ToString();
                else
                    charFlagBuffer += c.ToString();

                // If the character is lower case, move to the next iteration
                if (Char.IsLower(c))
                    continue;

                // Declare an AlphaMacros object to hold the (potentially) parsed value below
                AlphaMacros parsed;

                // Attempt to parse each character as an AlphaMacro and add to the running sum
                if (Enum.TryParse<Enums.AlphaMacros>(charFlagBuffer, out parsed))
                    inFlagsSum += (int)parsed;
                else
                    throw new ArgumentException(String.Format("Invalid character found in inFlags: {0}", c));

                // Empty the buffer
                charFlagBuffer = String.Empty;
            }

            // Convert the sum to a WeaponFlag value and return it
            return (ContainerFlag)inFlagsSum;
        }
    }
}