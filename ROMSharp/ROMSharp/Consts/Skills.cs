using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Consts
{
    public class Skills
    {
        public static List<Models.SkillType> SkillTable = new List<Models.SkillType>() {
            // Acid Blast (spell)
            new Models.SkillType() {
                Name = "acid blast",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 28 },
                    { Classes.Cleric, 53 },
                    { Classes.Thief, 35 },
                    { Classes.Warrior, 32 }
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 1 },
                    { Classes.Cleric, 1 },
                    { Classes.Thief, 2 },
                    {Classes.Warrior, 2 }
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 70,
                MinimumManaCost = 20,
                WaitTime = 12,
                DamageMessage = "acid blast",
                WearOffMessage = "!Acid Blast!"
            },

            // Armor (spell)
            new Models.SkillType() {
                Name = "armor",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 7 },
                    { Classes.Cleric, 2},
                    { Classes.Thief, 10 },
                    { Classes.Warrior, 5 }
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 1  },
                    { Classes.Cleric, 1 },
                    { Classes.Thief, 2 },
                    { Classes.Warrior, 2 }
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Defensive,
                MinimumPosition = Enums.Position.Standing,
                Slot = 1,
                MinimumManaCost = 5,
                WaitTime = 12,
                WearOffMessage = "You feel less armored."
            },

            // Bless (spell)
            new Models.SkillType() {
                Name = "bless",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 53 },
                    { Classes.Cleric, 7 },
                    { Classes.Thief, 53 },
                    { Classes.Warrior, 8 }
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 1 },
                    { Classes.Cleric, 1 },
                    { Classes.Thief, 2 },
                    { Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Object_Character_Defensive,
                MinimumPosition = Enums.Position.Standing,
                Slot = 3,
                MinimumManaCost = 5,
                WaitTime = 12,
                WearOffMessage = "You feel less righteous.",
                WearOffMessage_Object = "$p's holy aura fades."
            },

            // Blindness (spell)
            new Models.SkillType() {
                Name = "blindness",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 12 },
                    { Classes.Cleric, 8 },
                    { Classes.Thief, 17 },
                    { Classes.Warrior, 15 }
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 1 },
                    { Classes.Cleric, 1 },
                    { Classes.Thief, 2 },
                    { Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 4,
                MinimumManaCost = 5,
                WaitTime = 12,
                WearOffMessage = "You can see again."
            },

            // Burning hands (spell)
            new Models.SkillType() {
                Name = "burning hands",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    { Classes.Mage, 7 },
                    { Classes.Cleric, 53 },
                    { Classes.Thief, 10 },
                    { Classes.Warrior, 9 }
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 5,
                MinimumManaCost = 15,
                WaitTime = 12,
                DamageMessage = "burning hands",
                WearOffMessage = "!Burning Hands!"
            },

            // Call lightning (spell)
            new Models.SkillType() {
                Name = "call lightning",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 26},
                    {Classes.Cleric, 18},
                    {Classes.Thief, 31},
                    {Classes.Warrior, 22}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Ignore,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 6,
                MinimumManaCost = 15,
                WaitTime = 12,
                DamageMessage = "lightning bolt",
                WearOffMessage = "!Call Lightning!"
            },

            // Calm (spell)
            new Models.SkillType() {
                Name = "calm",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 48},
                    {Classes.Cleric, 16},
                    {Classes.Thief, 50},
                    {Classes.Warrior, 20}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Ignore,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 509,
                MinimumManaCost = 30,
                WaitTime = 12,
                WearOffMessage = "You have lost your peace of mind."
            },

            // Cancellation (spell)
            new Models.SkillType() {
                Name = "cancellation",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 18},
                    {Classes.Cleric, 26},
                    {Classes.Thief, 34},
                    {Classes.Warrior, 34}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}

                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Defensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 507,
                MinimumManaCost = 20,
                WaitTime = 12,
                WearOffMessage = "!cancellation!"
            },

            // Cause critical (spell)
            new Models.SkillType() {
                Name = "cause critical",
                RequiredLevels = new Dictionary<Models.Class, int>()  {
                    {Classes.Mage, 53},
                    {Classes.Cleric, 13},
                    {Classes.Thief, 53},
                    {Classes.Warrior, 19}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 63,
                MinimumManaCost = 20,
                WaitTime = 12,
                DamageMessage = "spell",
                WearOffMessage = "!Cause Critical"
            },

            // Cause light (spell)
            new Models.SkillType() {
                Name = "cause light",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 53},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 53},
                    {Classes.Warrior, 3}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 62,
                MinimumManaCost = 15,
                WaitTime = 12,
                DamageMessage = "spell",
                WearOffMessage = "!Cause Light!"
            },

            // Cause serious (spell)
            new Models.SkillType() {
                Name = "cause serious",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 53},
                    {Classes.Cleric, 7},
                    {Classes.Thief, 53},
                    {Classes.Warrior, 10}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 64,
                MinimumManaCost = 17,
                WaitTime = 12,
                DamageMessage = "spell",
                WearOffMessage = "!Cause Serious!"
            },

            // Chain lightning (spell)
            new Models.SkillType() {
                Name = "chain lightning",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 33},
                    {Classes.Cleric, 53},
                    {Classes.Thief, 39},
                    {Classes.Warrior, 39}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 500,
                MinimumManaCost = 25,
                WaitTime = 12,
                DamageMessage = "lightning",
                WearOffMessage = "!Chain Lightning!"
            },

            // Change sex (spell)
            new Models.SkillType() {
                Name = "change sex",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Cleric, 53},
                    {Classes.Mage, 53},
                    {Classes.Thief, 53},
                    {Classes.Warrior, 53}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Defensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 82,
                MinimumManaCost = 15,
                WaitTime = 12,
                WearOffMessage = "Your body feels familiar again."
            },

            // Charm person (spell)
            new Models.SkillType() {
                Name = "charm person",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 20},
                    {Classes.Cleric, 53},
                    {Classes.Thief, 25},
                    {Classes.Warrior, 53}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 7,
                MinimumManaCost = 5,
                WaitTime = 12,
                WearOffMessage = "You feel more self-confient."
            },

            // Chill touch (spell)
            new Models.SkillType() {
                Name = "chill touch",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 4},
                    {Classes.Cleric, 53},
                    {Classes.Thief, 6},
                    {Classes.Warrior, 6}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 8,
                MinimumManaCost = 15,
                WaitTime = 12,
                DamageMessage = "chilling touch",
                WearOffMessage = "You feel less cold."
            },

            // Colour spray (spell)
            new Models.SkillType() {
                Name = "colour spray",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 16},
                    {Classes.Cleric, 53},
                    {Classes.Thief, 22},
                    {Classes.Warrior, 20}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Character_Offensive,
                MinimumPosition = Enums.Position.Fighting,
                Slot = 10,
                MinimumManaCost = 15,
                WaitTime = 12,
                DamageMessage = "colour spray",
                WearOffMessage = "!Colour Spray!"
            },

            // Continual light (spell)
            new Models.SkillType() {
                Name = "continual light",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 6},
                    {Classes.Cleric, 4},
                    {Classes.Thief, 6},
                    {Classes.Warrior, 9}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Ignore,
                MinimumPosition = Enums.Position.Standing,
                Slot = 57,
                MinimumManaCost = 7,
                WaitTime = 12,
                WearOffMessage = "!Continual Light!"
            },

            // Control weather (spell)
            new Models.SkillType() {
                Name = "control weather",
                RequiredLevels = new Dictionary<Models.Class, int>()  {
                    {Classes.Mage, 15},
                    {Classes.Cleric, 19},
                    {Classes.Thief, 28},
                    {Classes.Warrior, 22}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Ignore,
                MinimumPosition = Enums.Position.Standing,
                Slot = 11,
                MinimumManaCost = 25,
                WaitTime = 12,
                WearOffMessage = "!Control Weather!"
            },

            // Create food (spell)
            new Models.SkillType() {
                Name = "create food",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 10},
                    {Classes.Cleric, 5},
                    {Classes.Thief, 11},
                    {Classes.Warrior, 12}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Ignore,
                MinimumPosition = Enums.Position.Standing,
                Slot = 12,
                MinimumManaCost = 5,
                WaitTime = 12,
                WearOffMessage = "!Create Food!"
            },

            // Create rose (spell)
            new Models.SkillType() {
                Name = "create rose",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 16},
                    {Classes.Cleric, 11},
                    {Classes.Thief, 10},
                    {Classes.Warrior, 24}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Ignore,
                MinimumPosition = Enums.Position.Standing,
                Slot = 511,
                MinimumManaCost = 30,
                WaitTime = 12,
                WearOffMessage = "!Create Rose!"
            },

            // Create spring (spell)
            new Models.SkillType() {
                Name = "create spring",
                RequiredLevels = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 14},
                    {Classes.Cleric, 17},
                    {Classes.Thief, 23},
                    {Classes.Warrior, 20}
                },
                Difficulty = new Dictionary<Models.Class, int>() {
                    {Classes.Mage, 1},
                    {Classes.Cleric, 1},
                    {Classes.Thief, 2},
                    {Classes.Warrior, 2}
                },
                SpellFunction = null,
                TargetType = Enums.TargetTypes.Ignore,
                MinimumPosition = Enums.Position.Standing,
                Slot = 80,
                MinimumManaCost = 20,
                WaitTime = 12,
                WearOffMessage = "!Create Spring!"
            }
        };

        public Skills() { }
    }
}
