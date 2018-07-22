using System;
using System.Linq;
using ROMSharp.Models;
using NUnit.Framework;
using System.IO;

namespace ROMSharp.UnitTests
{
    [TestFixture(Author = "Justin Handfield", TestOf = typeof(Models.MobPrototypeData))]
    public class MobPrototypeTests
    {
        [Test(), TestOf(typeof(Models.MobPrototypeData))]
        public void TestBrotherJohn()
        {
            // Mob data to parse, VNUM 3011 from midgaard.are, lines 167-185
            string mobData = @"#9506
oldstyle john brother singer lead~
Brother John~
Brother John, lead singer for the Lokettes, stands on stage.
~
You see the lead singer of the Lokettes lip synching to an old Zeppelin tune.
~
human~
ABG D 0 0
18 0 3d9+283 9d9+100 2d7+4 none
-3 -3 -3 7
EFNU 0 0 0
stand stand male 250
0 0 tiny 0
F par GHIJK";

            // Set up the mob prototype we expect to have parsed from the string
            MobPrototypeData mobExpected = new MobPrototypeData();
            mobExpected.VNUM = 9506;
            mobExpected.Name = "oldstyle john brother singer lead";
            mobExpected.ShortDescription = "Brother John";
            mobExpected.LongDescription = "Brother John, lead singer for the Lokettes, stands on stage.";
            mobExpected.Description = @"You see the lead singer of the Lokettes lip synching to an old Zeppelin tune.";
            mobExpected.Race = Consts.Races.RaceTable.SingleOrDefault(r => r.Name.ToLower().Equals("human"));
            mobExpected.Resistance = Enums.ResistanceFlag.None;
            mobExpected.Vulnerability = Enums.VulnerabilityFlag.None;
            mobExpected.Form = Enums.FormFlag.Edible | Enums.FormFlag.Sentient | Enums.FormFlag.Biped | Enums.FormFlag.Mammal;
            mobExpected.Parts = Enums.PartFlag.Head | Enums.PartFlag.Arms | Enums.PartFlag.Legs | Enums.PartFlag.Heart | Enums.PartFlag.Brains | Enums.PartFlag.Guts | Enums.PartFlag.Hands | Enums.PartFlag.Feet | Enums.PartFlag.Fingers | Enums.PartFlag.Ear | Enums.PartFlag.Eye;
            mobExpected.Actions = Enums.ActionFlag.IsNPC | Enums.ActionFlag.Sentinel | Enums.ActionFlag.StayInArea;
            mobExpected.AffectedBy = Enums.AffectedByFlag.DetectInvis;
            mobExpected.Alignment = 0;
            mobExpected.Group = 0;
            mobExpected.Level = 18;
            mobExpected.HitRoll = 0;
            mobExpected.Health = new DiceRoll("3d9+283");
            mobExpected.Mana = new DiceRoll("9d9+100");
            mobExpected.Damage = new DiceRoll("2d7+4");
            mobExpected.DamageType = Consts.DamageTypes.AttackTable.Single(a => a.Abbreviation.ToLower().Equals("none"));
            mobExpected.ArmorRating = new ArmorRating(-3, -3, -3, 7);
            mobExpected.Offense |= Enums.OffensiveFlag.Offense_Disarm | Enums.OffensiveFlag.Offense_Dodge | Enums.OffensiveFlag.Offense_Trip | Enums.OffensiveFlag.Assist_VNUM;
            mobExpected.Immunity |= Enums.ImmunityFlag.None;
            mobExpected.Resistance |= Enums.ResistanceFlag.None;
            mobExpected.StartingPosition = Consts.Positions.PositionTable.Single(p => p.ShortName.ToLower().Equals("stand"));
            mobExpected.DefaultPosition = Consts.Positions.PositionTable.Single(p => p.ShortName.ToLower().Equals("stand"));
            mobExpected.Gender = Consts.Gender.GenderTable.Single(g => g.Name.ToLower().Equals("male"));
            mobExpected.Wealth = 250;
            mobExpected.Size = Consts.Size.SizeTable.Single(s => s.Name.ToLower().Equals("tiny"));

            // "F par" removes parts flags GHIJK
            mobExpected.Parts &= ~(Enums.PartFlag.Hands) & ~(Enums.PartFlag.Feet) & ~(Enums.PartFlag.Fingers) & ~(Enums.PartFlag.Ear) & ~(Enums.PartFlag.Eye);

            StringReader sr = new StringReader(mobData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Parse the object from the string
            MobPrototypeData mob = MobPrototypeData.ParseMobData(ref sr, "testArea", ref lineNum, firstLine);

            // Compare the two objects
            CompareMobs(mobExpected, mob);
        }

        [Test(), TestOf(typeof(Models.MobPrototypeData))]
        public void TestHassan()
        {
            // Mob data to parse, VNUM 3011 from midgaard.are, lines 167-185
            string mobData = @"#3011
Hassan~
Hassan~
Hassan is here, waiting to dispense some justice.
~
Big. Very big.
Stupid. Very stupid.

Hassan, the guardian of  the Temple of Mota, towers over you.  He's over 12 
feet tall, every inch of it muscle. It would be a Bad Thing to commit a crime
in his presence.
~
giant~
ABTV CDFJVZ 1000 3000
45 30 1d1+3999 1d1+499 5d4+40 crush
-25 -25 -25 -15
ACDEFHIKLNOT ABP CD 0
stand stand male 0
0 0 huge 0";

            // Set up the mob prototype we expect to have parsed from the string
            MobPrototypeData mobExpected = new MobPrototypeData();
            mobExpected.VNUM = 3011;
            mobExpected.Name = "Hassan";
            mobExpected.ShortDescription = "Hassan";
            mobExpected.LongDescription = "Hassan is here, waiting to dispense some justice.";
            mobExpected.Description = @"Big. Very big.
Stupid. Very stupid.

Hassan, the guardian of  the Temple of Mota, towers over you.  He's over 12 
feet tall, every inch of it muscle. It would be a Bad Thing to commit a crime
in his presence.";
            mobExpected.Race = Consts.Races.RaceTable.SingleOrDefault(r => r.Name.ToLower().Equals("giant"));
            mobExpected.Resistance = Enums.ResistanceFlag.Fire | Enums.ResistanceFlag.Cold;
            mobExpected.Vulnerability = Enums.VulnerabilityFlag.Mental | Enums.VulnerabilityFlag.Lightning;
            mobExpected.Form = Enums.FormFlag.Edible | Enums.FormFlag.Sentient | Enums.FormFlag.Biped | Enums.FormFlag.Mammal;
            mobExpected.Parts = Enums.PartFlag.Head | Enums.PartFlag.Arms | Enums.PartFlag.Legs | Enums.PartFlag.Heart | Enums.PartFlag.Brains | Enums.PartFlag.Guts | Enums.PartFlag.Hands | Enums.PartFlag.Feet | Enums.PartFlag.Fingers | Enums.PartFlag.Ear | Enums.PartFlag.Eye;
            mobExpected.Actions = Enums.ActionFlag.IsNPC | Enums.ActionFlag.Sentinel | Enums.ActionFlag.Warrior | Enums.ActionFlag.NoPurge;
            mobExpected.AffectedBy = Enums.AffectedByFlag.DetectEvil | Enums.AffectedByFlag.DetectInvis | Enums.AffectedByFlag.DetectHidden | Enums.AffectedByFlag.Infrared | Enums.AffectedByFlag.Haste | Enums.AffectedByFlag.DarkVision;
            mobExpected.Alignment = 1000;
            mobExpected.Group = 3000;
            mobExpected.Level = 45;
            mobExpected.HitRoll = 30;
            mobExpected.Health = new DiceRoll("1d1+3999");
            mobExpected.Mana = new DiceRoll("1d1+499");
            mobExpected.Damage = new DiceRoll("5d4+40");
            mobExpected.DamageType = Consts.DamageTypes.AttackTable.Single(a => a.Abbreviation.ToLower().Equals("crush"));
            mobExpected.ArmorRating = new ArmorRating(-25, -25, -25, -15);
            mobExpected.Offense |= Enums.OffensiveFlag.Offense_AreaAttack | Enums.OffensiveFlag.Offense_Bash | Enums.OffensiveFlag.Offense_Berserk | Enums.OffensiveFlag.Offense_Disarm | Enums.OffensiveFlag.Offense_Dodge | Enums.OffensiveFlag.Offense_Fast | Enums.OffensiveFlag.Offense_Kick | Enums.OffensiveFlag.Offense_Parry | Enums.OffensiveFlag.Offense_Rescue | Enums.OffensiveFlag.Offense_Trip | Enums.OffensiveFlag.Offense_Crush | Enums.OffensiveFlag.Assist_Guard;
            mobExpected.Immunity |= Enums.ImmunityFlag.Summon | Enums.ImmunityFlag.Charm | Enums.ImmunityFlag.Mental;
            mobExpected.Resistance |= Enums.ResistanceFlag.Magic | Enums.ResistanceFlag.Weapon;
            mobExpected.StartingPosition = Consts.Positions.PositionTable.Single(p => p.ShortName.ToLower().Equals("stand"));
            mobExpected.DefaultPosition = Consts.Positions.PositionTable.Single(p => p.ShortName.ToLower().Equals("stand"));
            mobExpected.Gender = Consts.Gender.GenderTable.Single(g => g.Name.ToLower().Equals("male"));
            mobExpected.Wealth = 0;
            mobExpected.Size = Consts.Size.SizeTable.Single(s => s.Name.ToLower().Equals("huge"));

            StringReader sr = new StringReader(mobData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Parse the object from the string
            MobPrototypeData mob = MobPrototypeData.ParseMobData(ref sr, "testArea", ref lineNum, firstLine);

            // Compare the two objects
            CompareMobs(mobExpected, mob);
        }

        /// <summary>
        /// Compare two ObjectIndexData objects for differences
        /// </summary>
        /// <param name="objExpected">Model object to compare the parsed version against</param>
        /// <param name="obj">Object returned by ParseObjectData()</param>
        private void CompareMobs(MobPrototypeData mobExpected, MobPrototypeData mob)
        {
            // Compare
            if (!mobExpected.Equals(mob))
            {
                // Run individual tests to find the culprit
                Assert.AreEqual(mobExpected.VNUM, mob.VNUM, String.Format("Mobile vnum mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.VNUM, mob.VNUM));
                Assert.AreEqual(mobExpected.Name, mob.Name, String.Format("Mobile name mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Name, mob.Name));
                Assert.AreEqual(mobExpected.ShortDescription, mob.ShortDescription, String.Format("Mobile short description mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.ShortDescription, mob.ShortDescription));
                Assert.AreEqual(mobExpected.LongDescription, mob.LongDescription, String.Format("Mobile long description mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.LongDescription, mob.LongDescription));
                Assert.AreEqual(mobExpected.Description, mob.Description, String.Format("Mobile description mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Description, mob.Description));
                Assert.AreEqual(mobExpected.Race, mob.Race, String.Format("Mobile race mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Race, mob.Race));
                Assert.AreEqual(mobExpected.Resistance, mob.Resistance, String.Format("Mobile resistance mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Resistance, mob.Resistance));
                Assert.AreEqual(mobExpected.Vulnerability, mob.Vulnerability, String.Format("Mobile vulnerability mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Vulnerability, mob.Vulnerability));
                Assert.AreEqual(mobExpected.Form, mob.Form, String.Format("Mobile form mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Form, mob.Form));
                Assert.AreEqual(mobExpected.Parts, mob.Parts, String.Format("Mobile parts mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Parts, mob.Parts));
                Assert.AreEqual(mobExpected.Actions, mob.Actions, String.Format("Mobile actions mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Actions, mob.Actions));
                Assert.AreEqual(mobExpected.AffectedBy, mob.AffectedBy, String.Format("Mobile affects mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.AffectedBy, mob.AffectedBy));
                Assert.AreEqual(mobExpected.Alignment, mob.Alignment, String.Format("Mobile alignment mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Alignment, mob.Alignment));
                Assert.AreEqual(mobExpected.Group, mob.Group, String.Format("Mobile group mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Group, mob.Group));
                Assert.AreEqual(mobExpected.Level, mob.Level, String.Format("Mobile level mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Level, mob.Level));
                Assert.AreEqual(mobExpected.HitRoll, mob.HitRoll, String.Format("Mobile hitroll mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.HitRoll, mob.HitRoll));
                Assert.AreEqual(mobExpected.Health, mob.Health, String.Format("Mobile health mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Health, mob.Health));
                Assert.AreEqual(mobExpected.Mana, mob.Mana, String.Format("Mobile mana mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Mana, mob.Mana));
                Assert.AreEqual(mobExpected.Damage, mob.Damage, String.Format("Mobile damage mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Damage, mob.Damage));
                Assert.AreEqual(mobExpected.DamageType, mob.DamageType, String.Format("Mobile damage type mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.DamageType, mob.DamageType));
                Assert.AreEqual(mobExpected.ArmorRating, mob.ArmorRating, String.Format("Mobile armor rating mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.ArmorRating, mob.ArmorRating));
                Assert.AreEqual(mobExpected.Offense, mob.Offense, String.Format("Mobile offenseive flag mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Offense, mob.Offense));
                Assert.AreEqual(mobExpected.Immunity, mob.Immunity, String.Format("Mobile immunity flag mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Immunity, mob.Immunity));
                Assert.AreEqual(mobExpected.Resistance, mob.Resistance, String.Format("Mobile resistance mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Resistance, mob.Resistance));
                Assert.AreEqual(mobExpected.StartingPosition, mob.StartingPosition, String.Format("Mobile starting position mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.StartingPosition, mob.StartingPosition));
                Assert.AreEqual(mobExpected.DefaultPosition, mob.DefaultPosition, String.Format("Mobile default position mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.DefaultPosition, mob.DefaultPosition));
                Assert.AreEqual(mobExpected.Gender, mob.Gender, String.Format("Mobile gender mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Gender, mob.Gender));
                Assert.AreEqual(mobExpected.Wealth, mob.Wealth, String.Format("Mobile wealth mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Wealth, mob.Wealth));
                Assert.AreEqual(mobExpected.Size, mob.Size, String.Format("Mobile size mismatch, expected \"{0}\" but parsed \"{1}\"", mobExpected.Size, mob.Size));
            }
            else
                Assert.Pass();
        }
    }
}
