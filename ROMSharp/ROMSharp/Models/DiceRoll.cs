using System;
using System.Text.RegularExpressions;

namespace ROMSharp.Models
{
    /// <summary>
    /// Represents a potential dice roll (e.g. 1d6+3). Can also roll dice, <see cref="RollDice()"/> 
    /// </summary>
    public class DiceRoll
    {
        #region Properties
        /// <summary>
        /// Number of dice to roll (x in [x]d[y]+[z])
        /// </summary>
        public int NumDice { get; set; }

        /// <summary>
        /// The type of dice to roll (y in [x]d[y]+[z])
        /// </summary>
        public int DiceType { get; set; }

        /// <summary>
        /// An optional bonus to apply to the dice roll (z in [x]d[y]+[z])
        /// </summary>
        public int Bonus { get; set; }
        #endregion

        #region Constructors
        public DiceRoll() { }

        /// <summary>
        /// Initialize a new DiceRoll object from the supplied string representation <paramref name="input"/>
        /// </summary>
        /// <param name="input">String representation of the dice roll (in [x]d[y] or [x]d[y]+[z] notation) to build from</param>
        public DiceRoll(string input)
        {
            // Regex to test the input string - supports #d# and #d#+# formats
            Regex validationRegex = new Regex(@"^(\d+)d(\d+)(\+(\d+))*$");

            // Check if the input string does not match
            if (!validationRegex.IsMatch(input))
            {
                // Log a warning and set nothing
                Logging.Log.Warn(String.Format("Invalid dice roll string {0} passed into DiceRoll", input));
            }
            else
            {
                // Match the regex
                Match result = validationRegex.Match(input);

                // Matches will contain 2-4 captures, set pieces
                NumDice = Convert.ToInt32(result.Captures[0].Value);
                DiceType = Convert.ToInt32(result.Captures[1].Value);

                // If we have 4 captures, also set the bonux
                if (result.Captures.Count == 4)
                    Bonus = Convert.ToInt32(result.Captures[3].Value);
                else
                    Bonus = 0;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Roll the dice!
        /// </summary>
        /// <returns>The sum of the dice roll</returns>
        public int RollDice()
        {
            // Instantiate random number generator
            // TODO: Seems to be a hot topic whether System.Random is worth using, look into this
            Random rng = new Random();

            // Initialize the total using the Bonus value
            int total = Bonus;

            // Add to the total the requested number of dice rolls
            for (int i = 1; i <= NumDice; i++)
                // Random.Next()'s max value is exclusive, so we add 1
                total += rng.Next(1, DiceType + 1);

            // Return the generated total
            return total;
        }
        #endregion
    }
}
