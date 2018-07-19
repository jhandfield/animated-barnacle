using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ROMSharp.Models
{
    public class ResetData
    {
        #region Properties
        /// <summary>
        /// Determines the command the reset should perform
        /// </summary>
        public ResetCommand Command { get; set; }

        /// <summary>
        /// First argument for the reset - varies by reset type
        /// </summary>
        public int Arg1 { get; set; }

        /// <summary>
        /// Second argument for the reset - varies by reset type
        /// </summary>
        public int Arg2 { get; set; }

        /// <summary>
        /// Third argument for the reset - varies by reset type
        /// </summary>
        public int Arg3 { get; set; }

        /// <summary>
        /// Fourth argument for the reset - varies by reset type
        /// </summary>
        public int Arg4 { get; set; }
        #endregion

        public ResetData() { }

        internal static ResetData ParseResetData(ref StringReader sr, string areaFile, ref int lineNum, string firstLine, bool log = true)
        {
            if (log)
                Logging.Log.Debug(String.Format("ParseObjectData() called for area {0} starting on line {1}", areaFile, lineNum));

            // Instantiate variables for the method
            ResetData outReset = new ResetData();
            string lineData = firstLine;

            // Read the first character
            do
            {
                // Regex to parse reset lines
                Regex lineRegex = new Regex(@"(\w+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)");  // Mob
                lineRegex = new Regex(@"([a-zA-Z]){1}\s+(\d+)\s+(\d+)\s+(-?\d+)");  // Give


                // Attempt to parse the line
                Match matches = lineRegex.Match(lineData);

                // Ensure we got the expected number of matches 
            }
            while ((lineData = sr.ReadLine()) != null);

            return outReset;
        }
    }

    public enum ResetCommand {
        SpawnMobile = 'M',
        SpawnObject = 'O',
        PutInObject = 'P',
        GiveObjectToMob = 'G',
        EquipObjectOnMob = 'E',
        SetDoorState = 'D',
        RandomizeExits = 'R'
    }
}
