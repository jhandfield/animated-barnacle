using System;
using System.IO;
using System.Text;

namespace ROMSharp.Helpers
{
    public static class Data
    {
        /// <summary>
        /// Reads and parses the room's VNUM from the first line of a room declaration
        /// </summary>
        /// <returns>The room's vnum if valid, 0 otherwise</returns>
        /// <param name="lineData">Line from an area file containing a VNUM definition</param>
        public static int ParseVNUM(string lineData)
        {
            // First character of first line should be #
            if (!lineData[0].Equals('#'))
            {
                Logging.Log.Error(String.Format("Error parsing VNUM: Expected # in character 1, found {0}", lineData[0]));
                return 0;
            }
            else
            {
                int vnum = 0;

                if (!Int32.TryParse(lineData.TrimStart('#'), out vnum))
                {
                    Logging.Log.Error(String.Format("Error parsing VNUM: Expected integer, got {0}", lineData.TrimStart('#')));
                    return 0;
                }
                else
                    return vnum;
            }
        }

        /// <summary>
        /// Reads a long text field (multiple lines terminated by a tilde) from StringReader <paramref name="sr"/>, which should be on the line preceding the start of the description
        /// </summary>
        /// <returns>The long text data read from the StringReader</returns>
        /// <param name="sr">StringReader from which to read the description</param>
        /// <param name="lineNum">The starting line number, by reference</param>
        /// <param name="areaFile">Filename of the current area</param>
        /// <param name="vNUM">VNUM of object whose field is being read; used for error messages</param>
        public static string ReadLongText(StringReader sr, ref int lineNum, string areaFile, int vNUM)
        {
            StringBuilder sb = new StringBuilder();
            string lineData = String.Empty;
            bool foundEnd = false;

            // Flag to break us out of the loop
            int safetyValve = 0;

            // Loop up to a defined maximum number of times
            while (safetyValve < Consts.Misc.Safety.MaxLongTextLines)
            {
                // Increment safetyValve
                safetyValve++;

                // Read a line
                lineData = sr.ReadLine();
                lineNum++;

                // Append to the output string
                sb.AppendLine(lineData);

                // If the line ends with a tilde, we're done reading
                if (lineData.Trim().EndsWith("~"))
                {
                    foundEnd = true;    // Note that we positively found the end of the string
                    break;
                }
            }

            // Check if we exited the loop due to the safety valve
            if (!foundEnd)
                Logging.Log.Warn(String.Format("When reading long text of object with vnum {0} in area {1}, did not find the description's end in the expected {2} lines", vNUM, areaFile, Consts.Misc.Safety.MaxLongTextLines));

            return sb.ToString().Trim().TrimEnd('~');
        }
    }
}
