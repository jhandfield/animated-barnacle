using System.Collections.Generic;
namespace ROMSharp.Consts
{
    public static class Classes
    {
        /// <summary>
        /// Shortut reference to the Mage class
        /// </summary>
        public static Models.Class Mage { get { return ClassTable[0]; } }

        /// <summary>
        /// Shortcut reference to the Cleric class
        /// </summary>
        public static Models.Class Cleric { get { return ClassTable[1]; } }

        /// <summary>
        /// Shortcut reference to the Thief class
        /// </summary>
        public static Models.Class Thief { get { return ClassTable[2]; } }

        /// <summary>
        /// Shortcut reference to the Warrior class
        /// </summary>
        public static Models.Class Warrior { get { return ClassTable[3]; } }

        /// <summary>
        /// Defines all classes available in the game
        /// </summary>
        public static List<Models.Class> ClassTable = new List<Models.Class>() {
            // Mage
            new Models.Class() {
                Name = "Mage",
                Abbreviation = "Mag",
                PrimeAttribute = Enums.Attribute.Intelligence,
                StarterWeaponVNUM = (int)Enums.ObjectVNUMAlias.SchoolDagger,
                GuildRoomVNUMs = new List<int>() { 3018, 9618 },
                AdeptSkillLevel = 75,
                THAC0_0 = 20,
                THAC0_32 = 6,
                MinHPPerLevel = 6,
                MaxHPPerLevel = 8,
                GainsManaOnLevelUp = true,
                BaseSkillGroup = "mage basics",
                DefaultSkillGroup = "mage default"
            },

            // Cleric
            new Models.Class() {
                Name = "Cleric",
                Abbreviation = "Cle",
                PrimeAttribute = Enums.Attribute.Wisdom,
                StarterWeaponVNUM = (int)Enums.ObjectVNUMAlias.SchoolMace,
                GuildRoomVNUMs = new List<int>() { 3003, 9619 },
                AdeptSkillLevel = 75,
                THAC0_0 = 20,
                THAC0_32 = 2,
                MinHPPerLevel = 7,
                MaxHPPerLevel = 10,
                GainsManaOnLevelUp = true,
                BaseSkillGroup = "cleric basics",
                DefaultSkillGroup = "cleric default"
            },

            // Thief
            new Models.Class() {
                Name = "Thief",
                Abbreviation = "Thi",
                PrimeAttribute = Enums.Attribute.Dexterity,
                StarterWeaponVNUM = (int)Enums.ObjectVNUMAlias.SchoolDagger,
                GuildRoomVNUMs = new List<int>() { 3028, 9639 },
                AdeptSkillLevel = 75,
                THAC0_0 = 20,
                THAC0_32 = -4,
                MinHPPerLevel = 8,
                MaxHPPerLevel = 13,
                GainsManaOnLevelUp = false,
                BaseSkillGroup = "thief basics",
                DefaultSkillGroup = "thief default"
            },

            // Warrior
            new Models.Class() {
                Name = "Warrior",
                Abbreviation = "War",
                PrimeAttribute = Enums.Attribute.Strength,
                StarterWeaponVNUM = (int)Enums.ObjectVNUMAlias.SchoolSword,
                GuildRoomVNUMs = new List<int>() { 3022, 9633 },
                AdeptSkillLevel = 75,
                THAC0_0 = 20,
                THAC0_32 = -10,
                MinHPPerLevel = 11,
                MaxHPPerLevel = 15,
                GainsManaOnLevelUp = false,
                BaseSkillGroup = "warrior basics",
                DefaultSkillGroup = "warrior default"
            }
        };

        public Classes()
        {
        }
    }
}
