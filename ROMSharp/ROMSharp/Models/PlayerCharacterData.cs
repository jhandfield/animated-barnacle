using System;
using ROMSharp.Enums;

namespace ROMSharp.Models
{
    /// <summary>
    /// A playable character
    /// </summary>
    public class PlayerCharacterData : CharacterData
    {
        /// <summary>
        /// The player's race
        /// </summary>
        /// <remarks>Overrides the Race property of CharacterData</remarks>
        public new PCRace Race { get; set; }

        public byte[] Buffer { get; set; }

        /// <summary>
        /// The character's chosen password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Custom text to display to other players when this character arrives in a room
        /// </summary>
        public string BamfIn { get; set; }

        /// <summary>
        /// Custom text to display to other players when this character leaves a room
        /// </summary>
        public string BamfOut { get; set; }

        /// <summary>
        /// Custom title to display alongside the character name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Timestamp of the most recent Note the player has read
        /// </summary>
        public DateTime LastNote { get; set; }

        /// <summary>
        /// Timestamp of the most recent Idea the player has read
        /// </summary>
        public DateTime LastIdea { get; set; }

        /// <summary>
        /// Timestamp of the most recent Penalty the player has read
        /// </summary>
        public DateTime LastPenalty { get; set; }

        /// <summary>
        /// Timestamp of the most recent News the player has read
        /// </summary>
        public DateTime LastNews { get; set; }

        /// <summary>
        /// Timestamp of the most recent Changes the player has read
        /// </summary>
        public DateTime LastChanges { get; set; }

        /// <summary>
        /// The player's unmodified maximum health
        /// </summary>
        /// <value>The perm health.</value>
        public int PermHealth { get; set; }

        /// <summary>
        /// The player's unmodified maximum mana
        /// </summary>
        public int PermMana { get; set; }

        /// <summary>
        /// The player's unmodified maximum movement points
        /// </summary>
        public int PermMove { get; set; }

        /// <summary>
        /// The player's original chosen gender
        /// </summary>
        public Gender TrueGender { get; set; }

        /// <summary>
        /// I'm not actually sure about this - in most places when it's set it's based on the character's play time
        /// </summary>
        public int LastLevel { get; set; }

        /// <summary>
        /// The player's condition (drunk/full/thirst/hunger)
        /// </summary>
        public int[] Condition { get; set; }

        /// <summary>
        /// Player's proficiency level with skills
        /// </summary>
        public int[] Learned { get; set; }

        /// <summary>
        /// (Skill) groups the player knows
        /// </summary>
        public int[] GroupKnown { get; set; }

        /// <summary>
        /// Points available to train in new skills
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Whether the user is in the process of confirming they wish to delete
        /// </summary>
        public bool ConfirmDelete { get; set; }

        /// <summary>
        /// Used in defining command aliases
        /// </summary>
        public string[] Alias { get; set; }

        /// <summary>
        /// Used in defining command aliases
        /// </summary>
        public string[] AliasSub { get; set; }

        public PlayerCharacterData() {
            Condition = new int[4];
            Learned = new int[Consts.GameParameters.Maximums.Skill];
            GroupKnown = new int[Consts.GameParameters.Maximums.Group];

            Alias = new string[Consts.GameParameters.Maximums.Alias];
            AliasSub = new string[Consts.GameParameters.Maximums.Alias];
        }

		internal override int GetEffectiveStat(Enums.Attribute stat)
		{
            // Base ceiling is the race's max stat +4
            int max = Race.MaxStats[(int)stat] + 4;

            // 2 point bonus for the class's prime attribute
            if (Class.PrimeAttribute == stat)
                max += 2;

            // 1 point bonus for humans
            if (Race.Name.ToLower().Equals("human"))
                max++;

            // Set the ceiling to the lower of the calculated ceiling and 25
            max = Helpers.Miscellaneous.LowestOf(new int[]{ max, 25});

            // Final answer is calculated from an old alias called URANGE
            return Helpers.Miscellaneous.URange(3, PermanentStats[(int)stat] + ModifiedStats[(int)stat], max);
		}
	}
}
