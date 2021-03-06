﻿using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Consts
{
    public static class Skills
    {
        public static List<Models.SkillGroup> SkillGroupTable { get; set; }
        public static List<Models.SkillType> SkillTable { get; set; }

        static Skills()
        {
            SkillTable = new List<Models.SkillType>() {
                #region Spells
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
                        { Classes.Cleric, 2 },
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
                },

                // Create Water (spell)
                new Models.SkillType() {
                    Name = "create water",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 8},
                        {Classes.Cleric, 3},
                        {Classes.Thief, 12},
                        {Classes.Warrior, 13}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Inventory,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 13,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "!Create Water!"
                },

                // Cure Blindness (spell)
                new Models.SkillType() {
                    Name = "cure blindness",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 6},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 8}
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
                    Slot = 5,
                    WaitTime = 12,
                    WearOffMessage = "!Cure Blindness!"
                },

                // Cure Critical (spell)
                new Models.SkillType() {
                    Name = "cure critical",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
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
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 15,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    WearOffMessage = "!Cure Critical"
                },

                // Cure Disease (spell)
                new Models.SkillType() {
                    Name = "cure disease",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 13},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 14}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 501,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    WearOffMessage = "!Cure Disease!"
                },

                // Cure Light (spell)
                new Models.SkillType() {
                    Name = "cure light",
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
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 16,
                    MinimumManaCost = 10,
                    WaitTime = 12,
                    WearOffMessage = "!Cure Light!"
                },

                // Cure Poison (spell)
                new Models.SkillType() {
                    Name = "cure poison",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 14},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 16}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 43,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "!Cure Poison!"
                },

                // Cure Serious (spell)
                new Models.SkillType() {
                    Name = "cure serious",
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
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 61,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    WearOffMessage = "!Cure Serious!"
                },

                // Curse (spell)
                new Models.SkillType() {
                    Name = "curse",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 18},
                        {Classes.Cleric, 18},
                        {Classes.Thief, 26},
                        {Classes.Warrior, 22}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Character_Offensive,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 17,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    DamageMessage = "curse",
                    WearOffMessage = "The curse wears off.",
                    WearOffMessage_Object = "$p is no longer impure."
                },

                // Demonfire (spell)
                new Models.SkillType() {
                    Name = "demonfire",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 34},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 45}
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
                    Slot = 505,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    DamageMessage = "torments",
                    WearOffMessage = "!Demonfire!"
                },

                // Detect Evil (spell)
                new Models.SkillType() {
                    Name = "detect evil",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 11},
                        {Classes.Cleric, 4},
                        {Classes.Thief, 12},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 18,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "The red in your vision disappears."
                },

                // Detect Good (spell)
                new Models.SkillType() {
                    Name = "detect good",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 11},
                        {Classes.Cleric, 4},
                        {Classes.Thief, 12},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 513,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "The gold in your vision disappears."
                },

                // Detect Hidden (spell)
                new Models.SkillType() {
                    Name = "detect hidden",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 15},
                        {Classes.Cleric, 11},
                        {Classes.Thief, 12},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 44,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "You feel less aware of your surroundings."
                },

                // Detect Invis (spell)
                new Models.SkillType() {
                    Name = "detect invis",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 3},
                        {Classes.Cleric, 8},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 19,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "You no longer see invisible objects."
                },

                // Detect Magic (spell)
                new Models.SkillType() {
                    Name = "detect magic",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 6},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 20,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "The detect magic wears off."
                },

                // Detect Poison (spell)
                new Models.SkillType() {
                    Name = "detect poison",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 15},
                        {Classes.Cleric, 7},
                        {Classes.Thief, 9},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Inventory,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 21,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "!Detect Poison!"
                },

                // Dispel Evil (spell)
                new Models.SkillType() {
                    Name = "dispel evil",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 15},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 21}
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
                    Slot = 22,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    DamageMessage = "dispel evil",
                    WearOffMessage = "!Dispel Evil!"
                },

                // Dispel Good (spell)
                new Models.SkillType() {
                    Name = "dispel good",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 15},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 21}
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
                    Slot = 512,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    DamageMessage = "dispel good",
                    WearOffMessage = "!Dispel Good!"
                },

                // Dispel Magic (spell)
                new Models.SkillType() {
                    Name = "dispel magic",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 16},
                        {Classes.Cleric, 24},
                        {Classes.Thief, 30},
                        {Classes.Warrior, 30}
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
                    Slot = 59,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    WearOffMessage = "!Dispel Magic!"
                },

                // Earthquake (spell)
                new Models.SkillType() {
                    Name = "earthquake",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 10},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 14}
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
                    Slot = 23,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    DamageMessage = "earthquake",
                    WearOffMessage = "!Earthquake!"
                },

                // Enchant Armor (spell)
                new Models.SkillType() {
                    Name = "enchant armor",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 16},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 2},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Inventory,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 510,
                    MinimumManaCost = 100,
                    WaitTime = 24,
                    WearOffMessage = "!Enchant Armor!"
                },

                // Enchant Weapon (spell)
                new Models.SkillType() {
                    Name = "enchant weapon",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 17},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 2},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Inventory,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 24,
                    MinimumManaCost = 100,
                    WaitTime = 24,
                    WearOffMessage = "!Enchant Weapon!"
                },

                // Energy Drain (spell)
                new Models.SkillType() {
                    Name = "energy drain",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 19},
                        {Classes.Cleric, 22},
                        {Classes.Thief, 26},
                        {Classes.Warrior, 23}
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
                    Slot = 25,
                    MinimumManaCost = 35,
                    WaitTime = 12,
                    DamageMessage = "energy drain",
                    WearOffMessage = "!Energy Drain!"
                },

                // Faerie Fire (spell)
                new Models.SkillType() {
                    Name = "faerie fire",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 6},
                        {Classes.Cleric, 3},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 8}
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
                    Slot = 72,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    DamageMessage = "faerie fire",
                    WearOffMessage = "!Faerie Fire!"
                },

                // Faerie Fog (spell)
                new Models.SkillType() {
                    Name = "faerie fog",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 14},
                        {Classes.Cleric, 21},
                        {Classes.Thief, 16},
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
                    Slot = 73,
                    MinimumManaCost = 12,
                    WaitTime = 12,
                    DamageMessage = "faerie fog",
                    WearOffMessage = "!Faerie Fog!"
                },

                // Farsight (spell)
                new Models.SkillType() {
                    Name = "farsight",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 14},
                        {Classes.Cleric, 16},
                        {Classes.Thief, 16},
                        {Classes.Warrior, 53}
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
                    Slot = 521,
                    MinimumManaCost = 36,
                    WaitTime = 20,
                    DamageMessage = "farsight",
                    WearOffMessage = "!Faright!"
                },

                // Fireball (spell)
                new Models.SkillType() {
                    Name = "fireball",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 22},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 30},
                        {Classes.Warrior, 26}
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
                    Slot = 26,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    DamageMessage = "fireball",
                    WearOffMessage = "!Fireball!"
                },

                // Fireproof (spell)
                new Models.SkillType() {
                    Name = "fireproof",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 13},
                        {Classes.Cleric, 12},
                        {Classes.Thief, 19},
                        {Classes.Warrior, 18}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Inventory,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 523,
                    MinimumManaCost = 10,
                    WaitTime = 12,
                    WearOffMessage_Object = "$p's protective aura fades."
                },

                // Flamestrike (spell)
                new Models.SkillType() {
                    Name = "flamestrike",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 20},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 27}
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
                    Slot = 65,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    DamageMessage = "flamestrike",
                    WearOffMessage = "!Flamestrike!"
                },

                // Fly (spell)
                new Models.SkillType() {
                    Name = "fly",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 10},
                        {Classes.Cleric, 18},
                        {Classes.Thief, 20},
                        {Classes.Warrior, 22}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 56,
                    MinimumManaCost = 10,
                    WaitTime = 18,
                    WearOffMessage = "You slowly float to the ground."
                },

                // Floating Disc (spell)
                new Models.SkillType() {
                    Name = "floating disc",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 4},
                        {Classes.Cleric, 10},
                        {Classes.Thief, 7},
                        {Classes.Warrior, 16}
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
                    Slot = 522,
                    MinimumManaCost = 40,
                    WaitTime = 24,
                    WearOffMessage = "!Floating Disc!"
                },

                // Frenzy (spell)
                new Models.SkillType() {
                    Name = "frenzy",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 24},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 26}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 504,
                    MinimumManaCost = 30,
                    WaitTime = 24,
                    WearOffMessage = "Your rag ebbs."
                },

                // Gate (spell)
                new Models.SkillType() {
                    Name = "gate",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 27},
                        {Classes.Cleric, 17},
                        {Classes.Thief, 32},
                        {Classes.Warrior, 28}
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
                    Slot = 83,
                    MinimumManaCost = 80,
                    WaitTime = 12,
                    WearOffMessage = "!Gate!"
                },

                // Giant Strength (spell)
                new Models.SkillType() {
                    Name = "giant strength",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 11},
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
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 39,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    WearOffMessage = "You feel weaker."
                },

                // Harm (spell)
                new Models.SkillType() {
                    Name = "harm",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 23},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 28}
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
                    Slot = 27,
                    MinimumManaCost = 35,
                    WaitTime = 12,
                    DamageMessage = "harm spell",
                    WearOffMessage = "!Harm!"
                },

                // Haste (spell)
                new Models.SkillType() {
                    Name = "haste",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 21},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 26},
                        {Classes.Warrior, 29}
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
                    Slot = 502,
                    MinimumManaCost = 30,
                    WaitTime = 12,
                    WearOffMessage = "You feel yourself slow down."
                },

                // Heal (spell)
                new Models.SkillType() {
                    Name = "heal",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 21},
                        {Classes.Thief, 33},
                        {Classes.Warrior, 30}
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
                    Slot = 28,
                    MinimumManaCost = 50,
                    WaitTime = 12,
                    WearOffMessage = "!Heal!"
                },

                // Heat Metal (spell)
                new Models.SkillType() {
                    Name = "heat metal",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 16},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 23}
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
                    Slot = 516,
                    MinimumManaCost = 25,
                    WaitTime = 18,
                    DamageMessage = "spell",
                    WearOffMessage = "!Heat Metal!"
                },

                // Holy Word (spell)
                new Models.SkillType() {
                    Name = "holy word",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 36},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 42}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 2},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 506,
                    MinimumManaCost = 200,
                    WaitTime = 24,
                    DamageMessage = "divine wrath",
                    WearOffMessage = "!Holy Word!"
                },

                // Identify (spell)
                new Models.SkillType() {
                    Name = "identify",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 15},
                        {Classes.Cleric, 16},
                        {Classes.Thief, 18},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Inventory,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 53,
                    MinimumManaCost = 12,
                    WaitTime = 24,
                    WearOffMessage = "!Identify!"
                },

                // Infravision (spell)
                new Models.SkillType() {
                    Name = "infravision",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 9},
                        {Classes.Cleric, 13},
                        {Classes.Thief, 10},
                        {Classes.Warrior, 16}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 77,
                    MinimumManaCost = 5,
                    WaitTime = 18,
                    WearOffMessage = "You no longer see in the dark."
                },

                // Invisibility (spell)
                new Models.SkillType() {
                    Name = "invisibility",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 5},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 9},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Character_Offensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 29,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "You are no longer invisible",
                    WearOffMessage_Object = "$p fades into view."
                },

                // Know Alignment (spell)
                new Models.SkillType() {
                    Name = "know alignment",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 12},
                        {Classes.Cleric, 9},
                        {Classes.Thief, 20},
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
                    Slot = 58,
                    MinimumManaCost = 9,
                    WaitTime = 12,
                    WearOffMessage = "!Know Alignment!"
                },

                // Lightning Bolt (spell)
                new Models.SkillType() {
                    Name = "lightning bolt",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 13},
                        {Classes.Cleric, 23},
                        {Classes.Thief, 18},
                        {Classes.Warrior, 16}
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
                    Slot = 30,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    DamageMessage = "lightning bolt",
                    WearOffMessage = "!Lightning Bolt!"
                },

                // Locate Object (spell)
                new Models.SkillType() {
                    Name = "locate object",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 9},
                        {Classes.Cleric, 15},
                        {Classes.Thief, 11},
                        {Classes.Warrior, 53}
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
                    Slot = 31,
                    MinimumManaCost = 20,
                    WaitTime = 18,
                    WearOffMessage = "!Locate Object!"
                },

                // Magic Missile (spell)
                new Models.SkillType() {
                    Name = "magic missile",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
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
                    Slot = 32,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    DamageMessage = "magic missile",
                    WearOffMessage = "!Magic Missile!"
                },

                // Mass Healing (spell)
                new Models.SkillType() {
                    Name = "mass healing",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 38},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 46}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 2},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 508,
                    MinimumManaCost = 100,
                    WaitTime = 36,
                    WearOffMessage = "!Mass Healing!"
                },

                // Mass Invis (spell)
                new Models.SkillType() {
                    Name = "mass invis",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 22},
                        {Classes.Cleric, 25},
                        {Classes.Thief, 31},
                        {Classes.Warrior, 53}
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
                    Slot = 69,
                    MinimumManaCost = 20,
                    WaitTime = 24,
                    WearOffMessage = "You are no longer invisible."
                },

                // Nexus (spell)
                new Models.SkillType() {
                    Name = "nexus",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 40},
                        {Classes.Cleric, 35},
                        {Classes.Thief, 50},
                        {Classes.Warrior, 45}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 2},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 520,
                    MinimumManaCost = 150,
                    WaitTime = 36,
                    WearOffMessage = "!Nexus!"
                },

                // Pass Door (spell)
                new Models.SkillType() {
                    Name = "pass door",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 24},
                        {Classes.Cleric, 32},
                        {Classes.Thief, 25},
                        {Classes.Warrior, 37}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 74,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    WearOffMessage = "You feel solid again."
                },

                // Plague (spell)
                new Models.SkillType() {
                    Name = "plague",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 23},
                        {Classes.Cleric, 17},
                        {Classes.Thief, 36},
                        {Classes.Warrior, 26}
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
                    Slot = 503,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    DamageMessage = "sickness",
                    WearOffMessage = "Your sores vanish."
                },

                // Poison (spell)
                new Models.SkillType() {
                    Name = "poison",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 17},
                        {Classes.Cleric, 12},
                        {Classes.Thief, 15},
                        {Classes.Warrior, 21}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Character_Offensive,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 33,
                    MinimumManaCost = 10,
                    WaitTime = 12,
                    DamageMessage = "poison",
                    WearOffMessage = "You feel less sick.",
                    WearOffMessage_Object = "The poison on $p dries up."
                },

                // Portal (spell)
                new Models.SkillType() {
                    Name = "portal",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 35},
                        {Classes.Cleric, 30},
                        {Classes.Thief, 45},
                        {Classes.Warrior, 40}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 2},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 519,
                    MinimumManaCost = 100,
                    WaitTime = 24,
                    WearOffMessage = "!Portal!"
                },

                // Protection evil (spell)
                new Models.SkillType() {
                    Name = "protection evil",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 12},
                        {Classes.Cleric, 9},
                        {Classes.Thief, 17},
                        {Classes.Warrior, 11}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 34,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "You feel less protected."
                },

                // Protection Good (spell)
                new Models.SkillType() {
                    Name = "protection good",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 12},
                        {Classes.Cleric, 9},
                        {Classes.Thief, 17},
                        {Classes.Warrior, 11}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 514,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "You feel less protected."
                },

                // Ray of Truth (spell)
                new Models.SkillType() {
                    Name = "ray of truth",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 35},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 47}
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
                    Slot = 518,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    DamageMessage = "ray of truth",
                    WearOffMessage = "!Ray of Truth!"
                },

                // Recharge (spell)
                new Models.SkillType() {
                    Name = "recharge",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 9},
                        {Classes.Cleric, 53},
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
                    TargetType = Enums.TargetTypes.Object_Inventory,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 517,
                    MinimumManaCost = 60,
                    WaitTime = 24,
                    WearOffMessage = "!Recharge!"
                },

                // Refresh (spell)
                new Models.SkillType() {
                    Name = "refresh",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 8},
                        {Classes.Cleric, 5},
                        {Classes.Thief, 12},
                        {Classes.Warrior, 9}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 81,
                    MinimumManaCost = 12,
                    WaitTime = 18,
                    DamageMessage = "refresh",
                    WearOffMessage = "!Refresh!"
                },

                // Remove Curse (spell)
                new Models.SkillType() {
                    Name = "remove curse",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 18},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 22}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Object_Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 35,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "!Remove Curse!"
                },

                // Sanctuary (spell)
                new Models.SkillType() {
                    Name = "sanctuary",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 36},
                        {Classes.Cleric, 20},
                        {Classes.Thief, 42},
                        {Classes.Warrior, 30}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 36,
                    MinimumManaCost = 75,
                    WaitTime = 12,
                    WearOffMessage = "The white aura around your body fades."
                },

                // Shield (spell)
                new Models.SkillType() {
                    Name = "shield",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 20},
                        {Classes.Cleric, 35},
                        {Classes.Thief, 35},
                        {Classes.Warrior, 40}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Defensive,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 67,
                    MinimumManaCost = 12,
                    WaitTime = 18,
                    WearOffMessage = "Your force shield shimmers then fades away."
                },

                // Shocking Grasp (spell)
                new Models.SkillType() {
                    Name = "shocking grasp",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 10},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 14},
                        {Classes.Warrior, 13}
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
                    Slot = 53,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    DamageMessage = "shocking grasp",
                    WearOffMessage = "!Shocking Grasp!"
                },

                // Sleep (spell)
                new Models.SkillType() {
                    Name = "sleep",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 10},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 11},
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
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 38,
                    MinimumManaCost = 15,
                    WaitTime = 12,
                    WearOffMessage = "You feel less tired."
                },

                // Slow (spell)
                new Models.SkillType() {
                    Name = "slow",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 23},
                        {Classes.Cleric, 30},
                        {Classes.Thief, 29},
                        {Classes.Warrior, 32}
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
                    Slot = 515,
                    MinimumManaCost = 30,
                    WaitTime = 12,
                    WearOffMessage = "You feel yourself speed up."
                },

                // Stone Skin (spell)
                new Models.SkillType() {
                    Name = "stone skin",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 25},
                        {Classes.Cleric, 40},
                        {Classes.Thief, 40},
                        {Classes.Warrior, 45}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 66,
                    MinimumManaCost = 12,
                    WaitTime = 18,
                    WearOffMessage = "Your skin feels soft again."
                },

                // Summon (spell)
                new Models.SkillType() {
                    Name = "summon",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 24},
                        {Classes.Cleric, 12},
                        {Classes.Thief, 29},
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
                    Slot = 40,
                    MinimumManaCost = 50,
                    WaitTime = 12,
                    WearOffMessage = "!Summon!"
                },

                // Teleport (spell)
                new Models.SkillType() {
                    Name = "teleport",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 13},
                        {Classes.Cleric, 22},
                        {Classes.Thief, 25},
                        {Classes.Warrior, 36}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 2,
                    MinimumManaCost = 35,
                    WaitTime = 12,
                    WearOffMessage = "!Teleport!"
                },

                // Ventriloquate (spell)
                new Models.SkillType() {
                    Name = "ventriloquate",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 53}
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
                    Slot = 41,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "!Ventriloquate!"
                },

                // Weaken (spell)
                new Models.SkillType() {
                    Name = "weaken",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 11},
                        {Classes.Cleric, 14},
                        {Classes.Thief, 16},
                        {Classes.Warrior, 17}
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
                    Slot = 68,
                    MinimumManaCost = 20,
                    WaitTime = 12,
                    DamageMessage = "spell",
                    WearOffMessage = "You feel stronger."
                },

                // Word of Recall (spell)
                new Models.SkillType() {
                    Name = "word of recall",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 32},
                        {Classes.Cleric, 28},
                        {Classes.Thief, 40},
                        {Classes.Warrior, 30}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Self,
                    MinimumPosition = Enums.Position.Resting,
                    Slot = 42,
                    MinimumManaCost = 5,
                    WaitTime = 12,
                    WearOffMessage = "!Word of Recall!"
                },
                #endregion

                #region Dragon Breath
                // Acid Breath (breath)
                new Models.SkillType() {
                    Name = "acid breath",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 31},
                        {Classes.Cleric, 32},
                        {Classes.Thief, 33},
                        {Classes.Warrior, 34}
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
                    Slot = 200,
                    MinimumManaCost = 100,
                    WaitTime = 24,
                    DamageMessage = "blast of acid",
                    WearOffMessage = "!Acid Breath!"
                },

                // Fire Breath (breath)
                new Models.SkillType() {
                    Name = "fire breath",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 40},
                        {Classes.Cleric, 45},
                        {Classes.Thief, 50},
                        {Classes.Warrior, 51}
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
                    Slot = 201,
                    MinimumManaCost = 200,
                    WaitTime = 24,
                    DamageMessage = "blast of flame",
                    WearOffMessage = "The smoke leaves your eyes."
                },

                // Frost Breath (breath)
                new Models.SkillType() {
                    Name = "frost breath",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 34},
                        {Classes.Cleric, 36},
                        {Classes.Thief, 38},
                        {Classes.Warrior, 40}
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
                    Slot = 202,
                    MinimumManaCost = 125,
                    WaitTime = 24,
                    DamageMessage = "blast of frost",
                    WearOffMessage = "!Frost Breath!"
                },

                // Gas Breath (breath)
                new Models.SkillType() {
                    Name = "gas breath",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 39},
                        {Classes.Cleric, 43},
                        {Classes.Thief, 47},
                        {Classes.Warrior, 50}
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
                    Slot = 203,
                    MinimumManaCost = 175,
                    WaitTime = 24,
                    DamageMessage = "blast of gas",
                    WearOffMessage = "!Gas Breath!"
                },

                // Lightning Breath (breath)
                new Models.SkillType() {
                    Name = "lightning breath",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 37},
                        {Classes.Cleric, 40},
                        {Classes.Thief, 43},
                        {Classes.Warrior, 46}
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
                    Slot = 204,
                    MinimumManaCost = 150,
                    WaitTime = 24,
                    DamageMessage = "blast of lightning",
                    WearOffMessage = "!Lightning Breath!"
                },
                #endregion

                #region Spells for mega1.are
                // General Purpose Ammo (skill)
                new Models.SkillType() {
                    Name = "general purpose",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 0},
                        {Classes.Warrior, 0}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Offensive,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 401,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    DamageMessage = "general purpose ammo",
                    WearOffMessage = "!General Purpose Ammo!"
                },

                // High Explosive Ammo (skill)
                new Models.SkillType() {
                    Name = "high explosive",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 0},
                        {Classes.Warrior, 0}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Offensive,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 402,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    DamageMessage = "high explosive ammo",
                    WearOffMessage = "!High Explosive Ammo!"
                },
                #endregion

                #region Combat and weapons Skills
                // Axe (weapon skill)
                new Models.SkillType() {
                    Name = "axe",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 6},
                        {Classes.Cleric, 6},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Axe!"
                },

                // Dagger (weapon skill)
                new Models.SkillType() {
                    Name = "dagger",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 3},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Dagger!"
                },

                // Flail (weapon skill)
                new Models.SkillType() {
                    Name = "flail",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 6},
                        {Classes.Cleric, 3},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Flail!"
                },

                // Mace (weapon skill)
                new Models.SkillType() {
                    Name = "mace",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 5},
                        {Classes.Cleric, 2},
                        {Classes.Thief, 3},
                        {Classes.Warrior, 3}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Mace!"
                },

                // Polearm (weapon skill)
                new Models.SkillType() {
                    Name = "polearm",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 6},
                        {Classes.Cleric, 6},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Polearm!"
                },

                // Shield Block (combat skill)
                new Models.SkillType() {
                    Name = "shield block",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 6},
                        {Classes.Cleric, 4},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Shield!"
                },

                // Spear (weapon skill)
                new Models.SkillType() {
                    Name = "spear",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 4},
                        {Classes.Cleric, 4},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 3}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Spear!"
                },

                // Sword (weapon skill)
                new Models.SkillType() {
                    Name = "sword",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 5},
                        {Classes.Cleric, 6},
                        {Classes.Thief, 3},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Sword!"
                },

                // Whip (weapon skill)
                new Models.SkillType() {
                    Name = "whip",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 6},
                        {Classes.Cleric, 5},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Whip!"
                },

                // Backstab (combat skill)
                new Models.SkillType() {
                    Name = "backstab",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 0}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 24,
                    DamageMessage = "backstab",
                    WearOffMessage = "!Backstab!"
                },

                // Bash (combat skill)
                new Models.SkillType() {
                    Name = "bash",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 0},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    DamageMessage = "bash",
                    WearOffMessage = "!Bash!"
                },

                // Berserk (combat skill)
                new Models.SkillType() {
                    Name = "berserk",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 18}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 0},
                        {Classes.Warrior, 5}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 24,
                    WearOffMessage = "You feel your pulse slow down."
                },

                // Dirt Kicking (combat skill)
                new Models.SkillType() {
                    Name = "dirt kicking",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 3},
                        {Classes.Warrior, 3}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 24,
                    DamageMessage = "kicked dirt",
                    WearOffMessage = "You rub the dirt out of your eyes."
                },

                // Disarm (combat skill)
                new Models.SkillType() {
                    Name = "disarm",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 12},
                        {Classes.Warrior, 11}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 24,
                    WearOffMessage = "!Disarm!"
                },

                // Dodge (combat skill)
                new Models.SkillType() {
                    Name = "dodge",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 20},
                        {Classes.Cleric, 22},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 13}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 8},
                        {Classes.Cleric, 8},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 6}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Dodge!"
                },

                // Enhanced Damage (combat skill)
                new Models.SkillType() {
                    Name = "enhanced damage",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 45},
                        {Classes.Cleric, 30},
                        {Classes.Thief, 25},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 10},
                        {Classes.Cleric, 9},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 3}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Enhanced Damage!"
                },

                // Envenom (combat skill)
                new Models.SkillType() {
                    Name = "envenom",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 10},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 0}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Resting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 36,
                    WearOffMessage = "!Envenom!"
                },

                // Hand to Hand (combat skill)
                new Models.SkillType() {
                    Name = "hand to hand",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 25},
                        {Classes.Cleric, 10},
                        {Classes.Thief, 15},
                        {Classes.Warrior, 6}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 8},
                        {Classes.Cleric, 5},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Hand to Hand!"
                },

                // Kick (combat skill)
                new Models.SkillType() {
                    Name = "kick",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 12},
                        {Classes.Thief, 14},
                        {Classes.Warrior, 8}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 4},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 3}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Character_Offensive,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    DamageMessage = "kick",
                    WearOffMessage = "!Kick!"
                },

                // Parry (combat skill)
                new Models.SkillType() {
                    Name = "parry",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 22},
                        {Classes.Cleric, 20},
                        {Classes.Thief, 13},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 8},
                        {Classes.Cleric, 8},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Parry!"
                },

                // Rescue (combat skill)
                new Models.SkillType() {
                    Name = "rescue",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 53},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 0},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    WearOffMessage = "!Rescue!"
                },

                // Trip (combat skill)
                new Models.SkillType() {
                    Name = "trip",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 15}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 8}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 24,
                    WearOffMessage = "!Trip!"
                },

                // Second Attack (combat skill)
                new Models.SkillType() {
                    Name = "second attack",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 30},
                        {Classes.Cleric, 24},
                        {Classes.Thief, 12},
                        {Classes.Warrior, 5}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 10},
                        {Classes.Cleric, 8},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 3}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Second Attack!"
                },

                // Third Attack (combat skill)
                new Models.SkillType() {
                    Name = "third attack",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 24},
                        {Classes.Warrior, 12}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 10},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Fighting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Third Attack!"
                },
                #endregion

                #region Non-Combat Skills
                // Fast Healing (non-combat skill)
                new Models.SkillType() {
                    Name = "fast healing",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 15},
                        {Classes.Cleric, 9},
                        {Classes.Thief, 16},
                        {Classes.Warrior, 6}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 8},
                        {Classes.Cleric, 5},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 4}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Sleeping,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Fast Healing!"
                },

                // Haggle (non-combat skill)
                new Models.SkillType() {
                    Name = "haggle",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 7},
                        {Classes.Cleric, 18},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 14}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 5},
                        {Classes.Cleric, 8},
                        {Classes.Thief, 3},
                        {Classes.Warrior, 6}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Resting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Haggle!"
                },

                // Hide (non-combat skill)
                new Models.SkillType() {
                    Name = "hide",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 12}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 6}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Resting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    WearOffMessage = "!Hide!"
                },

                // Lore (non-combat skill)
                new Models.SkillType() {
                    Name = "lore",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 10},
                        {Classes.Cleric, 10},
                        {Classes.Thief, 6},
                        {Classes.Warrior, 20}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 6},
                        {Classes.Cleric, 6},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 8}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Resting,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 36,
                    WearOffMessage = "!Lore!"
                },

                // Meditation (non-combat skill)
                new Models.SkillType() {
                    Name = "meditation",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 6},
                        {Classes.Cleric, 6},
                        {Classes.Thief, 15},
                        {Classes.Warrior, 15}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 5},
                        {Classes.Cleric, 5},
                        {Classes.Thief, 8},
                        {Classes.Warrior, 8}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Sleeping,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "Meditation"
                },

                // Peek (non-combat skill)
                new Models.SkillType() {
                    Name = "peek",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 8},
                        {Classes.Cleric, 21},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 14}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 5},
                        {Classes.Cleric, 7},
                        {Classes.Thief, 3},
                        {Classes.Warrior, 6}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 0,
                    WearOffMessage = "!Peek!"
                },

                // Pick Lock (non-combat skill)
                new Models.SkillType() {
                    Name = "pick lock",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 25},
                        {Classes.Cleric, 25},
                        {Classes.Thief, 7},
                        {Classes.Warrior, 25}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 8},
                        {Classes.Cleric, 8},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 8}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    WearOffMessage = "!Pick!"
                },

                // Sneak (non-combat skill)
                new Models.SkillType() {
                    Name = "sneak",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 10}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 6}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    WearOffMessage = "You no longer feel stealthy."
                },

                // Steal (non-combat skill)
                new Models.SkillType() {
                    Name = "steal",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 53},
                        {Classes.Cleric, 53},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 53}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 0},
                        {Classes.Cleric, 0},
                        {Classes.Thief, 4},
                        {Classes.Warrior, 0}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 24,
                    WearOffMessage = "!Steal!"
                },

                // Scrolls (non-combat skill)
                new Models.SkillType() {
                    Name = "scrolls",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 3},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 8}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 24,
                    WearOffMessage = "!Scrolls!"
                },

                // Staves (non-combat skill)
                new Models.SkillType() {
                    Name = "staves",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 3},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 8}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    WearOffMessage = "!Staves!"
                },

                // Wands (non-combat skill)
                new Models.SkillType() {
                    Name = "wands",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 3},
                        {Classes.Thief, 5},
                        {Classes.Warrior, 8}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    WearOffMessage = "!Wands!"
                },

                // Recall (non-combat skill)
                new Models.SkillType() {
                    Name = "recall",
                    RequiredLevels = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 1},
                        {Classes.Cleric, 1},
                        {Classes.Thief, 1},
                        {Classes.Warrior, 1}
                    },
                    Difficulty = new Dictionary<Models.Class, int>() {
                        {Classes.Mage, 2},
                        {Classes.Cleric, 2},
                        {Classes.Thief, 2},
                        {Classes.Warrior, 2}
                    },
                    SpellFunction = null,
                    TargetType = Enums.TargetTypes.Ignore,
                    MinimumPosition = Enums.Position.Standing,
                    Slot = 0,
                    MinimumManaCost = 0,
                    WaitTime = 12,
                    WearOffMessage = "!Recall!"
                }
            };
            #endregion

            SkillGroupTable = new List<Models.SkillGroup>();
            #region Skill groupings
            SkillGroupTable.Add(new Models.SkillGroup("Weaponsmaster", new int[4] { 40, 40, 40, 20 }, new string[] { "axe", "dagger", "flail", "mace", "polearm", "spear", "sword", "whip" }));
            SkillGroupTable.Add(new Models.SkillGroup("Attack", new int[4] { -1, 5, -1, 8 }, new string[] { "demonfire", "dispel evil", "dispel good", "earthquake", "flamestrike", "heat metal", "ray of truth" }));
            SkillGroupTable.Add(new Models.SkillGroup("Beguiling", new int[4] { 4, -1, 6, -1 }, new string[] { "calm", "charm person", "sleep" }));
            SkillGroupTable.Add(new Models.SkillGroup("Benedictions", new int[4] { -1, 4, -1, 8 }, new string[] { "bless", "calm", "frenzy", "holy word", "remove curse" }));
            SkillGroupTable.Add(new Models.SkillGroup("Combat", new int[4] { 6, -1, 10, 9 }, new string[] { "acid blast", "burning hands", "chain lightning", "chill touch", "colour spray", "fireball", "lightning bolt", "magic missile", "shocking grasp" }));
            SkillGroupTable.Add(new Models.SkillGroup("Creation", new int[4] { 4, 4, 8, 8 }, new string[] { "continual light", "create food", "create spring", "create water", "create rose", "floating disc" }));
            SkillGroupTable.Add(new Models.SkillGroup("Curative", new int[4] { -1, 4, -1, 8 }, new string[] { "cure blindness", "cure disease", "cure poison" }));
            SkillGroupTable.Add(new Models.SkillGroup("Detection", new int[4] { 4, 3, 6, -1 }, new string[] { "detect evil", "detect good", "detect hidden", "detect invis", "detect magic", "detect poison", "farsight", "identify", "know alignment", "locate object" }));
            SkillGroupTable.Add(new Models.SkillGroup("Draconian", new int[4] { 8, -1, -1, -1 }, new string[] { "acid breath", "fire breath", "frost breath", "gas breath", "lightning breath" }));
            SkillGroupTable.Add(new Models.SkillGroup("Enhancement", new int[4] { 5, -1, 9, 9 }, new string[] { "giant strength", "haste", "infravision", "refresh" }));
            SkillGroupTable.Add(new Models.SkillGroup("Harmful", new int[4] { -1, 3, -1, 6 }, new string[] { "cause critical", "cause light", "cause serious", "harm" }));
            SkillGroupTable.Add(new Models.SkillGroup("Healing", new int[4] { -1, 3, -1, 6 }, new string[] { "cure critical", "cure light", "cure serious", "heal", "mass healing", "refresh" }));
            SkillGroupTable.Add(new Models.SkillGroup("Illusion", new int[4] { 4, -1, 7, -1 }, new string[] { "invisibility", "mass invis", "ventriloquate" }));
            SkillGroupTable.Add(new Models.SkillGroup("Maladictions", new int[4] { 5, 5, 9, 9 }, new string[] { "blindness", "change sex", "curse", "energy drain", "plague", "poison", "slow", "weaken" }));
            SkillGroupTable.Add(new Models.SkillGroup("Protective", new int[4] { 4, 4, 7, 8 }, new string[] { "armor", "cancellation", "dispel magic", "fireproof", "protection evil", "protection good", "sanctuary", "shield", "stone skin" }));
            SkillGroupTable.Add(new Models.SkillGroup("Transportation", new int[4] { 4, 4, 8, 9 }, new string[] { "fly", "gate", "nexus", "pass door", "portal", "summon", "teleport", "word of recall" }));
            SkillGroupTable.Add(new Models.SkillGroup("Weather", new int[4] { 4, 4, 8, 8 }, new string[] { "call lightning", "control weather", "faerie fire", "faerie fog", "lightning bolt" }));
            #endregion

            #region Basics
            SkillGroupTable.Add(new Models.SkillGroup("ROM Basics", new int[4] { 0, 0, 0, 0 }, new string[] { "scrolls", "staves", "wands", "recall" }));
            SkillGroupTable.Add(new Models.SkillGroup("Mage Basics", new int[4] { 0, -1, -1, -1 }, new string[] { "dagger" }));
            SkillGroupTable.Add(new Models.SkillGroup("Cleric Basics", new int[4] { -1, 0, -1, -1 }, new string[] { "mace" }));
            SkillGroupTable.Add(new Models.SkillGroup("Thief Basics", new int[4] { -1, -1, 0, -1 }, new string[] { "dagger" }));
            SkillGroupTable.Add(new Models.SkillGroup("Warrior Basics", new int[4] { -1, -1, -1, 0 }, new string[] { "sword", "second attack" }));
            #endregion

            #region Defaults
            SkillGroupTable.Add(new Models.SkillGroup("Mage Default", new int[4] { 40, -1, -1, -1 }, new string[] { "lore", "beguiling", "combat", "detection", "enhancement", "illusion", "maladictions", "protective", "transportation", "weather" }));
            SkillGroupTable.Add(new Models.SkillGroup("Cleric Default", new int[4] { -1, 40, -1, -1 }, new string[] { "flail", "attack", "creation", "curative", "benedictions", "detection", "healing", "maladictions", "protective", "shield block", "transportation", "weather" }));
            SkillGroupTable.Add(new Models.SkillGroup("Thief Default", new int[4] { -1, -1, 40, -1 }, new string[] { "mace", "sword", "backstab", "disarm", "dodge", "second attack", "trip", "hide", "peek", "pick lock", "sneak" }));
            SkillGroupTable.Add(new Models.SkillGroup("Warrior Default", new int[4] { -1, -1, -1, 40 }, new string[] { "weaponsmaster", "shield block", "bash", "disarm", "enhanced damage", "parry", "rescue", "third attack" }));
            #endregion
        }
    }
}
