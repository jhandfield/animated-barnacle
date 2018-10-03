using ROMSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ROMSharp.Models
{
    /// <summary>
    /// Represents a character (player or non-player) within the game
    /// </summary>
    public class CharacterData
    {
        private Func<CharacterData, bool> _specialFunction;
        private RoomIndexData _inRoom;

        /// <summary>
        /// Indicates whether the character is a PC
        /// </summary>
        /// <value><c>true</c> if is PC; otherwise, <c>false</c>.</value>
        public bool IsPC { get; set; }

        /// <summary>
        /// Indicates whether the character is an NPC
        /// </summary>
        /// <value><c>true</c> if is NPC; otherwise, <c>false</c>.</value>
        public bool IsNPC { get { return !IsPC; } }

        /// <summary>
        /// The master of a charmed character
        /// </summary>
        public CharacterData Master { get; set; }

        /// <summary>
        /// Who the character is following (via the follow command)
        /// </summary>
        public CharacterData Leader { get; set; }

        /// <summary>
        /// Who the character is currently fighting
        /// </summary>
        public CharacterData Fighting { get; set; }

        /// <summary>
        /// Who the "reply" command will send to
        /// </summary>
        public CharacterData Reply { get; set; }

        /// <summary>
        /// The character's pet
        /// </summary>
        public CharacterData Pet { get; set; }

        /// <summary>
        /// Special behavior method for this mobile
        /// </summary>
        public Func<CharacterData, bool> SpecialFunction
        {
            get
            {
                return _specialFunction;
            }
            set
            {
                if (IsNPC)
                    _specialFunction = value;
                else
                    throw new NotSupportedException("PCs cannot have special functions assigned to them.");
            }
        }

        /// <summary>
        /// The prototype from which this mob was created
        /// </summary>
        public CharacterData PrototypeMob { get; set; }

        /// <summary>
        /// The character's connection metadata
        /// </summary>
        public Network.ClientConnection Descriptor { get; set; }

        /// <summary>
        /// Effects currently applied to the character
        /// </summary>
        public List<AffectData> Affects { get; set; }

        /// <summary>
        /// Notes the character has sent/received
        /// </summary>
        public List<Models.NoteData> Notes { get; set; }

        /// <summary>
        /// The object the character is currently (standing|resting|sleeping) on
        /// </summary>
        public ObjectData On { get; set; }

        /// <summary>
        /// Objects in the character's inventory
        /// </summary>
        public List<ObjectData> Inventory { get; set; }

        /// <summary>
        /// Objects the character is wearing / holding
        /// </summary>
        public WearSlots Equipment { get; set; }

        /// <summary>
        /// Room the character is currently in
        /// </summary>
        public RoomIndexData InRoom
        {
            get
            {
                if (_inRoom == null)
                    return Program.World.Rooms[3001];
                else
                    return _inRoom;

            }
            set
            {
                _inRoom = value;
            }
        }

        /// <summary>
        /// Previous room the character was in
        /// </summary>
        public RoomIndexData WasInRoom { get; set; }

        /// <summary>
        /// Name of the character
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique ID for the character; used primarily while saving & loading, it appears
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Version of the character - I suspect this may not be needed and is only for compatibility with older versions
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Short description of the character
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Long description of the character
        /// </summary>
        public string LongDescription { get; set; }

        /// <summary>
        /// Description of the character
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The character's prompt
        /// </summary>
        public string Prompt { get; set; }

        /// <summary>
        /// The character's prefix (after the prompt, before the command)
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// The character's group - used primarily for handling cases of whether to
        /// assist another character in combat.
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// The character's clan
        /// </summary>
        public int Clan { get; set; }

        /// <summary>
        /// The character's gender
        /// </summary>
        public Models.Gender Gender { get; set; }

        /// <summary>
        /// The character's class
        /// </summary>
        public Models.Class Class { get; set; }

        /// <summary>
        /// The character's race
        /// </summary>
        public Models.Race Race { get; set; }

        /// <summary>
        /// The character's level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The character's trust level - handler.c indicates this is for permission checking?
        /// </summary>
        /// <remarks>
        /// Looking through the ROM 2.4 source code, I only see a few locations where the trust value is even
        /// tested, never mind incremented or even set to >0. The "order" command is one of the few places that
        /// seems to use it.
        /// </remarks>
        public int Trust { get; set; }

        /// <summary>
        /// The character's playtime
        /// </summary>
        public int Played { get; set; }

        /// <summary>
        /// Number of lines per page, used for the pager
        /// </summary>
        public int Lines { get; set; }

        /// <summary>
        /// Start timestamp of the character's current session
        /// </summary>
        public DateTime Logon { get; set; }

        /// <summary>
        /// Timer used to detect inactivity in characters
        /// </summary>
        /// <value>The timer.</value>
        public int Timer { get; set; }

        public int Wait { get; set; }

        public int Daze { get; set; }

        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int Move { get; set; }
        public int MaxMove { get; set; }

        public long Gold { get; set; }
        public long Silver { get; set; }

        public int Experience { get; set; }
        public ActionFlag Action { get; set; }
        public CommunicationFlag Communication { get; set; }
        public WizNetFlag WizNet { get; set; }
        public ImmunityFlag Immunity { get; set; }
        public ResistanceFlag Resist { get; set; }
        public VulnerabilityFlag Vulnerability { get; set; }
        public int InvisLevel { get; set; }
        public int IncogLevel { get; set; }
        public AffectedByFlag AffectedBy { get; set; }
        public Position Position { get; set; }
        public int Practice { get; set; }
        public int Train { get; set; }
        public int CarryWeight { get; set; }
        public int CarryNumber { get; set; }
        public int SavingThrow { get; set; }
        public int Alignment { get; set; }
        public int HitRoll { get; set; }
        public int DamRoll { get; set; }
        public ArmorRating Armor { get; set; }

        /// <summary>
        /// Point at which the character will automatically attempt to flee from combat
        /// </summary>
        public int Wimpy { get; set; }

        public Stats PermanentStats { get; set; }
        public Stats ModifiedStats { get; set; }

        public FormFlag Form { get; set; }
        public PartFlag Parts { get; set; }
        public Size Size { get; set; }
        public string Material { get; set; }
        public OffensiveFlag Offense { get; set; }
        public DiceRoll Damage { get; set; }
        public DamageType DamageType { get; set; }
        public Position StartPosition { get; set; }
        public Position DefaultPosition { get; set; }

        public CharacterData() {
            Lines = Consts.GameParameters.Defaults.PageLength;
            Armor = new ArmorRating(Consts.GameParameters.Defaults.ArmorRating);
            Position = Consts.GameParameters.Defaults.Position;
            Health = Consts.GameParameters.Defaults.Health;
            MaxHealth = Consts.GameParameters.Defaults.Health;
            Mana = Consts.GameParameters.Defaults.Mana;
            MaxMana = Consts.GameParameters.Defaults.Mana;
            Move = Consts.GameParameters.Defaults.Movement;
            MaxMove = Consts.GameParameters.Defaults.Movement;
            PermanentStats = new Stats();
            ModifiedStats = new Stats();
            Logon = DateTime.Now;
            Damage = new DiceRoll();
            Affects = new List<AffectData>();
            Equipment = new WearSlots();
            Inventory = new List<ObjectData>();

            // Set default stats
            //for (int i = 0; i < PermanentStats.Length; i++)
            //{
            //    PermanentStats[i] = Consts.GameParameters.Defaults.Stats;
            //    ModifiedStats[i] = 0;
            //}
        }

        public CharacterData(MobPrototypeData prototype) : this()
        {
            // Simple assignments
            Name = prototype.Name;
            ShortDescription = prototype.ShortDescription;
            LongDescription = prototype.LongDescription;
            Description = prototype.Description;
            SpecialFunction = prototype.SpecialFunction;
            Prompt = null;
            Group = prototype.Group;
            Action = prototype.Actions;
            Communication = CommunicationFlag.NoChannels | CommunicationFlag.NoShout | CommunicationFlag.NoTell;
            AffectedBy = prototype.AffectedBy;
            Alignment = prototype.Alignment;
            Level = prototype.Level;
            HitRoll = prototype.HitRoll;
            DamRoll = prototype.Damage.Bonus;
            Damage = prototype.Damage;
            Armor = prototype.ArmorRating;
            Offense = prototype.Offense;
            Immunity = prototype.Immunity;
            Resist = prototype.Resistance;
            Vulnerability = prototype.Vulnerability;
            StartPosition = prototype.StartingPosition;
            DefaultPosition = prototype.DefaultPosition;
            Race = prototype.Race;
            Form = prototype.Form;
            Parts = prototype.Parts;
            Size = prototype.Size;
            Material = prototype.Material;
            Affects = new List<AffectData>();
            PermanentStats = new Stats();
            ModifiedStats = new Stats();

            // Calculated assignments
            if (prototype.Wealth == 0)
            {
                Gold = 0;
                Silver = 0;
            }
            else
            {
                Random rand = new Random();

                // Calculate the randomized wealth of the mob (0.5x - 1.5x the mob's wealth value)
                long actualWealth = rand.Next(prototype.Wealth / 2, 3 * prototype.Wealth / 2);

                // Set gold based on actual wealth
                Gold = rand.Next((int)actualWealth / 200, (int)actualWealth / 100);
                Silver = actualWealth - (Gold * 100);
            }

            // Roll the hit dice to determine max health; set current to the max.
            MaxHealth = prototype.Health.RollDice();
            Health = MaxHealth;

            // Roll the mana dice to determine max mana; set current to the max
            MaxMana = prototype.Mana.RollDice();
            Mana = MaxMana;

            // If no damage class is set, choose from slash, pound, and pierce
            if (prototype.DamageType.DamageClass == DamageClass.None)
            {
                Random rand = new Random();
                DamageType = Consts.DamageTypes.AttackTable[rand.Next(3)];
            }
            else
                DamageType = prototype.DamageType;


            // If the prototype gender is random, choose one now; otherwise, set
            if (prototype.Gender.GenderCode == Sex.Random)
            {
                Random rng = new Random();
                Gender = Consts.Gender.GenderTable[rng.Next(2)];
            }
            else
                Gender = prototype.Gender;

            // Set stats - first, set a base across all stats
            PermanentStats = new Stats(Helpers.Miscellaneous.LowestOf(new int[] { 25, 11 + (Level / 4) }));

            // Next, adjust stats based on action flags (classes, mostly)
            if (Action.HasFlag(ActionFlag.Warrior))
            {
                PermanentStats.Strength += 3;
                PermanentStats.Intelligence -= 1;
                PermanentStats.Constitution += 2;
            }

            if (Action.HasFlag(ActionFlag.Thief))
            {
                PermanentStats.Dexterity += 3;
                PermanentStats.Intelligence += 1;
                PermanentStats.Wisdom -= 1;
            }

            if (Action.HasFlag(ActionFlag.Cleric))
            {
                PermanentStats.Wisdom += 3;
                PermanentStats.Dexterity -= 1;
                PermanentStats.Strength += 1;
            }

            if (Action.HasFlag(ActionFlag.Mage))
            {
                PermanentStats.Intelligence += 3;
                PermanentStats.Strength -= 1;
                PermanentStats.Dexterity += 1;
            }

            // 2 point dexterity bonus for Fast
            if (Offense.HasFlag(OffensiveFlag.Offense_Fast))
                PermanentStats.Dexterity += 2;

            // Size modifiers to strength and constitution - increase when size > medium
            PermanentStats.Strength += (int)Size.SizeCode - (int)Enums.Size.Medium;
            PermanentStats.Constitution += ((int)Size.SizeCode - (int)Enums.Size.Medium) / 2;

            // Permanent spells
            // Sanctuary
            if (AffectedBy.HasFlag(AffectedByFlag.Sanctuary))
            {
                SkillType skill = Consts.Skills.SkillTable.SingleOrDefault(s => s.Name.ToLower().Equals("sanctuary"));
                AffectData affect = new AffectData()
                {
                    Where = ToWhere.Affects,
                    Type = skill,
                    Level = Level,
                    Duration = -1,
                    Location = ApplyType.None,
                    Modifier = 0,
                    BitVector = AffectedByFlag.Sanctuary
                };

                ApplyAffect(affect);
            }

            // Haste - also applies a dexterity modifier based on level
            if (AffectedBy.HasFlag(AffectedByFlag.Haste))
            {
                SkillType skill = Consts.Skills.SkillTable.Single(s => s.Name.ToLower().Equals("haste"));
                AffectData affect = new AffectData()
                {
                    Where = ToWhere.Affects,
                    Type = skill,
                    Level = Level,
                    Duration = -1,
                    Location = ApplyType.Dexterity,
                    Modifier = (Level >= 32) ? 4 : (Level >= 25) ? 3 : (Level >= 18) ? 2 : 1,
                    BitVector = AffectedByFlag.Haste
                };

                ApplyAffect(affect);
            }

            // Protection from Evil
            if (AffectedBy.HasFlag(AffectedByFlag.ProtectEvil))
            {
                SkillType skill = Consts.Skills.SkillTable.Single(s => s.Name.ToLower().Equals("protection evil"));
                AffectData affect = new AffectData()
                {
                    Where = ToWhere.Affects,
                    Type = skill,
                    Level = Level,
                    Duration = -1,
                    Location = ApplyType.Saves,
                    Modifier = -1,
                    BitVector = AffectedByFlag.ProtectEvil
                };

                ApplyAffect(affect);
            }

            // Protection from Good
            if (AffectedBy.HasFlag(AffectedByFlag.ProtectGood))
            {
                SkillType skill = Consts.Skills.SkillTable.Single(s => s.Name.ToLower().Equals("protection good"));

                AffectData affect = new AffectData()
                {
                    Where = ToWhere.Affects,
                    Type = skill,
                    Level = Level,
                    Duration = -1,
                    Location = ApplyType.Saves,
                    Modifier = -1,
                    BitVector = AffectedByFlag.ProtectGood
                };

                ApplyAffect(affect);
            }

        }

        internal void ApplyAffect(AffectData affect, bool adding = true)
        {
            // Add the affect to the list
            Affects.Add(affect);

            // Add/remove the affect flag to the appropriate property
            switch (affect.Where)
            {
                case ToWhere.Affects:
                    if (adding)
                        this.AffectedBy |= (AffectedByFlag)affect.BitVector;
                    else
                        this.AffectedBy &= ~(AffectedByFlag)affect.BitVector;
                    
                    break;
                case ToWhere.Vuln:
                    if (adding)
                        this.Vulnerability |= (VulnerabilityFlag)affect.BitVector;
                    else
                        this.Vulnerability &= ~(VulnerabilityFlag)affect.BitVector;
                    
                    break;
                case ToWhere.Resist:
                    if (adding)
                        this.Resist |= (ResistanceFlag)affect.BitVector;
                    else
                        this.Resist &= ~(ResistanceFlag)affect.BitVector;
                    break;
                case ToWhere.Immune:
                    if (adding)
                        this.Immunity |= (ImmunityFlag)affect.BitVector;
                    else
                        this.Immunity &= ~(ImmunityFlag)affect.BitVector;
                    
                    break;
            }

            // Set the modifier
            int modifier = affect.Modifier;

            // If we're removing, reverse the modifier
            if (!adding) modifier *= -1;

            // Apply the modifier to the appropriate location
            switch (affect.Location)
            {
                case ApplyType.None:
                    break;

                case ApplyType.Strength:
                    this.ModifiedStats.Strength += modifier;
                    break;

                case ApplyType.Dexterity:
                    this.ModifiedStats.Dexterity += modifier;
                    break;

                case ApplyType.Intelligence:
                    this.ModifiedStats.Intelligence += modifier;
                    break;

                case ApplyType.Wisdom:
                    this.ModifiedStats.Wisdom += modifier;
                    break;

                case ApplyType.Constitution:
                    this.ModifiedStats.Constitution += modifier;
                    break;

                case ApplyType.Gender:
                    // Calculate the new gender value
                    int newGenderVal = (int)this.Gender.GenderCode + modifier;

                    // Attempt to locate a matching new gender value
                    Gender newGender = Consts.Gender.GenderTable.SingleOrDefault(g => (int)g.GenderCode == newGenderVal);

                    if (newGender != null)
                        this.Gender = newGender;
                    else
                        throw new ArgumentException("Unable to find new gender matching modified value " + newGenderVal);
                    
                    break;

                case ApplyType.Class:
                    break;

                case ApplyType.Level:
                    break;

                case ApplyType.Age:
                    break;

                case ApplyType.Height:
                    break;

                case ApplyType.Weight:
                    break;

                case ApplyType.Health:
                    this.MaxHealth += modifier;
                    break;

                case ApplyType.Mana:
                    this.MaxMana += modifier;
                    break;

                case ApplyType.Movement:
                    this.MaxMove += modifier;
                    break;

                case ApplyType.Gold:
                    break;

                case ApplyType.Experience:
                    break;

                case ApplyType.AC:
                    this.Armor.Modify(modifier);
                    break;

                case ApplyType.HitRoll:
                    this.HitRoll += modifier;
                    break;

                case ApplyType.DamageRoll:
                    this.DamRoll += modifier;
                    break;

                // There is actually only one saving throw stat, all feed into it
                case ApplyType.Saves:
                case ApplyType.Saving_Rod:
                case ApplyType.Saving_Spell:
                case ApplyType.Saving_Breath:
                case ApplyType.Saving_Paralyze:
                case ApplyType.Saving_Petrification:
                    this.SavingThrow += modifier;
                    break;

                case ApplyType.SpellAffect:
                    break;
            }

            // Check if the PC is wielding a weapon heavier than their maximum wield weight; if so, drop the item (can happens as strength-boosting effects drop, for example)
            if (!IsNPC && Equipment.Wield != null 
                && Equipment.Wield.Weight > Consts.AttributeBonuses.StrengthBonusTable[GetEffectiveStat(Enums.Attribute.Strength)].Wield*10)
            {
                // Drop the item
                // TODO: Implement
            }
        }

        /// <summary>
        /// Returns the effective value of a given stat for an NPC
        /// </summary>
        /// <returns>The effective value (permanent + modifier) of the stat</returns>
        /// <param name="stat">Statistic to return</param>
        internal virtual int GetEffectiveStat(Enums.Attribute stat)
        {
            // In the original code, NPCs have a static maximum of 25
            int max = 25;

            // Run the mob's stats and max through URange for the answer
            return Helpers.Miscellaneous.URange(3, PermanentStats[(int)stat] + ModifiedStats[(int)stat], max);
        }
    }
}
