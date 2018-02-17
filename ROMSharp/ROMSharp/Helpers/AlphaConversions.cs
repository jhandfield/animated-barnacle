﻿using System;
using ROMSharp.Enums;
using ROMSharp.Models;

namespace ROMSharp.Helpers
{
    public static class AlphaConversions
    {
        /// <summary>
        /// Converts legacy ROM macro-based room flags to a RoomAttributes object
        /// </summary>
        /// <returns>A RoomAttributes object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static RoomAttributes ConvertROMAlphaToRoomAttributes(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return (RoomAttributes)0;
            
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
                return (ActionFlag)0;
            
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

            // Convert the sum to a RoomAttributes value and return it
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
                return (AffectedByFlag)0;

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
                return (FormFlag)0;
            
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

            // Convert the sum to a RoomAttributes value and return it
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
                return (PartFlag)0;
            
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

            // Convert the sum to a RoomAttributes value and return it
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
                return (OffensiveFlag)0;

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

            // Convert the sum to a RoomAttributes value and return it
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
                return (ImmunityFlag)0;

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

            // Convert the sum to a RoomAttributes value and return it
            return (ImmunityFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based offense flags to a ResistanceFlag object
        /// </summary>
        /// <returns>A RestistanceFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static ResistanceFlag ConvertROMAlphaToResistanceFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return (ResistanceFlag)0;

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

            // Convert the sum to a RoomAttributes value and return it
            return (ResistanceFlag)inFlagsSum;
        }

        /// <summary>
        /// Converts legacy ROM macro-based offense flags to a VulnerabilityFlag object
        /// </summary>
        /// <returns>A VulnerabilityFlag object representation of the input flags</returns>
        /// <param name="inputFlags">Legacy ROM room flags to convert; must contain no characters other than A-ee</param>
        public static VulnerabilityFlag ConvertROMAlphaToVulnerabilityFlag(string inputFlags)
        {
            // Check if input flag is 0
            if (inputFlags.Equals("0"))
                return (VulnerabilityFlag)0;

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

            // Convert the sum to a RoomAttributes value and return it
            return (VulnerabilityFlag)inFlagsSum;
        }
    }
}