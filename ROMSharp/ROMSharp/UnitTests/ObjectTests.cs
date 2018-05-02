using NUnit.Framework;
using ROMSharp.Models;
using System;
using System.IO;
using System.Linq;

namespace ROMSharp.UnitTests
{
    [TestFixture()]
    public class ObjectTests
    {
        [Test(), TestOf(typeof(ObjectIndexData))]
        public void Valid_Furniture()
        {
            // Object data to parse, VNUM 3379 (custom) from midgaard.are - there doesn't appear to be any interactive furniture in the stock areas at all?
            string objData = @"#3379
chair~
a chair~
A simple chair is here, waiting for an ass to sit on it.~
wood~
furniture 0 A
1 0 BEHK 5 5
0 1 2000 P
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 3379;
            objExpected.Name = "chair";
            objExpected.ShortDescription = "a chair";
            objExpected.Description = "A simple chair is here, waiting for an ass to sit on it.";
            objExpected.Material = "wood";
            objExpected.ObjectType = Enums.ItemClass.Furniture;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.None;
            objExpected.WearFlags = Enums.WearFlag.Take;
            objExpected.Values[0] = 1;  // Maximum occupancy
            objExpected.Values[1] = 0;  // Appears to be unused?
            objExpected.Values[2] = Enums.FurnitureFlag.StandOn | Enums.FurnitureFlag.SitOn | Enums.FurnitureFlag.RestOn | Enums.FurnitureFlag.SleepOn;  // Furniture flags
            objExpected.Values[3] = 5;  // Heal rate modifier
            objExpected.Values[4] = 5;  // Mana rate modifier
            objExpected.Level = 0;
            objExpected.Weight = 1;
            objExpected.Cost = 2000;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidClothing()
        {
            // Object data to parse, VNUM 1616 from wyvern.are, lines 500-509
            string objData = @"#1616
dark blue cloak~
a dark blue cloak~
A valuable cloak of dark blue cloth lies on the floor.~
oldstyle~
clothing AG AC
0 0 0 0 0
0 20 100 P
A
17 6
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 1616;
            objExpected.Name = "dark blue cloak";
            objExpected.ShortDescription = "a dark blue cloak";
            objExpected.Description = "A valuable cloak of dark blue cloth lies on the floor.";
            objExpected.Material = "oldstyle";
            objExpected.ObjectType = Enums.ItemClass.Clothing;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.Glow | Enums.ItemExtraFlag.Magic;
            objExpected.WearFlags = Enums.WearFlag.Take | Enums.WearFlag.Wear_Neck;
            objExpected.Values[0] = 0;
            objExpected.Values[1] = 0;
            objExpected.Values[2] = 0;
            objExpected.Values[3] = 0;
            objExpected.Values[4] = 0;
            objExpected.Level = 0;
            objExpected.Weight = 20;
            objExpected.Cost = 100;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();
            objExpected.Affected.Add(new AffectData() { Where = Enums.ToWhere.Object, Type = -1, Level = objExpected.Level, Duration = -1, BitVector = 0, Location = Enums.ApplyType.AC, Modifier = 6 });

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidPotion()
        {
            // Object data to parse, VNUM 5019 from eastern.are, lines 414-421
            string objData = @"#5019
potion pink~
a pink potion~
A pink potion stands here.~
oldstyle~
potion 0 A
25 'heal' 'remove curse' '' ''
13 60 1220 P
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 5019;
            objExpected.Name = "potion pink";
            objExpected.ShortDescription = "a pink potion";
            objExpected.Description = "A pink potion stands here.";
            objExpected.Material = "oldstyle";
            objExpected.ObjectType = Enums.ItemClass.Potion;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.None;
            objExpected.WearFlags = Enums.WearFlag.Take;
            objExpected.Values[0] = 25; // Spell level
            objExpected.Values[1] = Consts.Skills.SkillTable.Single(s => s.Name.Equals("heal"));            // Spell 1
            objExpected.Values[2] = Consts.Skills.SkillTable.Single(s => s.Name.Equals("remove curse"));    // Spell 2
            objExpected.Level = 13;
            objExpected.Weight = 60;
            objExpected.Cost = 1220;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidArmor()
        {
            // Object data to parse, VNUM 9304 from galaxy.are, lines 519-533
            string objData = @"#9304
belt orion~
the Titanic Belt of Orion~
A belt of the Zodiac lies here.~
oldstyle~
armor AGK AL
6 6 6 0 0
17 70 3800 P
A
5 2
E
belt~
You can immediately see that it belongs to Orion, from the three stars
engraved on it.
~
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 9304;
            objExpected.Name = "belt orion";
            objExpected.ShortDescription = "the Titanic Belt of Orion";
            objExpected.Description = "A belt of the Zodiac lies here.";
            objExpected.Material = "oldstyle";
            objExpected.ObjectType = Enums.ItemClass.Armor;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.Glow | Enums.ItemExtraFlag.Magic | Enums.ItemExtraFlag.AntiEvil;
            objExpected.WearFlags = Enums.WearFlag.Take | Enums.WearFlag.Wear_Waist;
            objExpected.Values[0] = 6;
            objExpected.Values[1] = 6;
            objExpected.Values[2] = 6;
            objExpected.Values[3] = 0;
            objExpected.Values[4] = 0;
            objExpected.Level = 17;
            objExpected.Weight = 70;
            objExpected.Cost = 3800;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.ExtraDescriptions.Add(new ExtraDescription() { Keywords = "belt", Description = "You can immediately see that it belongs to Orion, from the three stars\nengraved on it." });
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();
            objExpected.Affected.Add(new AffectData() { Where = Enums.ToWhere.Object, Type = -1, Level = objExpected.Level, Duration = -1, BitVector = 0, Location = Enums.ApplyType.Constitution, Modifier = 2 });

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidTreasure()
        {
            // Object data to parse, VNUM 3715 from school.are, lines 509-527, the ever-popular MUD School Diploma
            string objData = @"#3715
diploma~
a mud school diploma~
You see a mud school diploma here.~
vellum~
treasure GU AO
0 0 0 0 0
0 10 1140 P
A
4 1
A
5 1
E
diploma~
This document shows that you have graduated from Mud School.
It also has magical effects on your abilities if you hold it!

Merc Industries
~
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 3715;
            objExpected.Name = "diploma";
            objExpected.ShortDescription = "a mud school diploma";
            objExpected.Description = "You see a mud school diploma here.";
            objExpected.Material = "vellum";
            objExpected.ObjectType = Enums.ItemClass.Treasure;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.Magic | Enums.ItemExtraFlag.MeltDrop;
            objExpected.WearFlags = Enums.WearFlag.Take | Enums.WearFlag.Hold;
            objExpected.Values[0] = 0;
            objExpected.Values[1] = 0;
            objExpected.Values[2] = 0;
            objExpected.Values[3] = 0;
            objExpected.Values[4] = 0;
            objExpected.Level = 0;
            objExpected.Weight = 10;
            objExpected.Cost = 1140;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.ExtraDescriptions.Add(new ExtraDescription() { Keywords = "diploma", Description = "This document shows that you have graduated from Mud School.\nIt also has magical effects on your abilities if you hold it!\n\nMerc Industries" });
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();
            objExpected.Affected.Add(new AffectData() { Where = Enums.ToWhere.Object, Type = -1, Level = objExpected.Level, Duration = -1, BitVector = 0, Location = Enums.ApplyType.Wisdom, Modifier = 1 });
            objExpected.Affected.Add(new AffectData() { Where = Enums.ToWhere.Object, Type = -1, Level = objExpected.Level, Duration = -1, BitVector = 0, Location = Enums.ApplyType.Constitution, Modifier = 1 });

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidWeapon()
        {
            // Object data to parse, VNUM 2005 from catacomb.are, lines 300-311
            string objData = @"#2005
sword excalibur~
the sword Excalibur~
A sword gleams by the light of its magical silvery blade.~
oldstyle~
weapon AGKL AN
sword 5 4 slash 0
24 150 3400 P
A
1 1
A
18 3
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 2005;
            objExpected.Name = "sword excalibur";
            objExpected.ShortDescription = "the sword Excalibur";
            objExpected.Description = "A sword gleams by the light of its magical silvery blade.";
            objExpected.Material = "oldstyle";
            objExpected.ObjectType = Enums.ItemClass.Weapon;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.Glow | Enums.ItemExtraFlag.Magic | Enums.ItemExtraFlag.AntiEvil | Enums.ItemExtraFlag.AntiNeutral;
            objExpected.WearFlags = Enums.WearFlag.Take | Enums.WearFlag.Wield;
            objExpected.Values[0] = Consts.WeaponClass.WeaponTable.Single(s => s.Name.Equals("sword")); // Weapon type
            objExpected.Values[1] = 5;  // Damage dice number
            objExpected.Values[2] = 4;  // Damage dice type
            objExpected.Values[3] = Consts.DamageTypes.AttackTable.Single(s => s.Name.Equals("slash")); // Damage type
            objExpected.Values[4] = Enums.WeaponFlag.None;  // Weapon flag
            objExpected.Level = 24;
            objExpected.Weight = 150;
            objExpected.Cost = 3400;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();
            objExpected.Affected.Add(new AffectData() { Where = Enums.ToWhere.Object, Type = -1, Level = objExpected.Level, Duration = -1, BitVector = 0, Location = Enums.ApplyType.Strength, Modifier = 1 });
            objExpected.Affected.Add(new AffectData() { Where = Enums.ToWhere.Object, Type = -1, Level = objExpected.Level, Duration = -1, BitVector = 0, Location = Enums.ApplyType.HitRoll, Modifier = 3 });

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidStaff()
        {
            // Object data to parse, VNUM 2245 from draconia.are, lines 515-522
            string objData = @"#2245
staff dragon~
the staff of the dragon~
A powerful oak staff has been left here.~
oldstyle~
staff AG AO
25 10 10 'call lightning' 0
15 50 10200 P
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 2245;
            objExpected.Name = "staff dragon";
            objExpected.ShortDescription = "the staff of the dragon";
            objExpected.Description = "A powerful oak staff has been left here.";
            objExpected.Material = "oldstyle";
            objExpected.ObjectType = Enums.ItemClass.Staff;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.Glow | Enums.ItemExtraFlag.Magic;
            objExpected.WearFlags = Enums.WearFlag.Take | Enums.WearFlag.Hold;
            objExpected.Values[0] = 25; // Level
            objExpected.Values[1] = 10;  // Current charges
            objExpected.Values[2] = 10;  // Maximum charges
            objExpected.Values[3] = Consts.Skills.SkillTable.Single(s => s.Name.Equals("call lightning"));  // Spell
            objExpected.Values[4] = 0;  // Unused
            objExpected.Level = 15;
            objExpected.Weight = 50;
            objExpected.Cost = 10200;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidWand()
        {
            // Object data to parse, VNUM 9215 from canyon.are, lines 691-698
            string objData = @"#9215
wand~
elemental wand of fire~
A fire wand lies forgotten on the ground.~
oldstyle~
wand A AO
15 3 3 'fireball' 0
16 70 3900 P
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 9215;
            objExpected.Name = "wand";
            objExpected.ShortDescription = "elemental wand of fire";
            objExpected.Description = "A fire wand lies forgotten on the ground.";
            objExpected.Material = "oldstyle";
            objExpected.ObjectType = Enums.ItemClass.Wand;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.Glow;
            objExpected.WearFlags = Enums.WearFlag.Take | Enums.WearFlag.Hold;
            objExpected.Values[0] = 15; // Level
            objExpected.Values[1] = 3;  // Current charges
            objExpected.Values[2] = 3;  // Maximum charges
            objExpected.Values[3] = Consts.Skills.SkillTable.Single(s => s.Name.Equals("fireball"));  // Spell
            objExpected.Values[4] = 0;  // Unused
            objExpected.Level = 16;
            objExpected.Weight = 70;
            objExpected.Cost = 3900;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidScroll()
        {
            // Object data to parse, VNUM 3000 from midgaard.are, lines 959-966
            string objData = @"#7701
scroll violet~
a violet scroll~
A rolled piece of violet parchment lies on the floor.~
oldstyle~
scroll I A
15 'armor' 'bless' 'shield' ''
11 10 1510 P
E
scroll violet~
The scroll is written on soft violet parchment that has a pleasing smell to it.
~
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 7701;
            objExpected.Name = "scroll violet";
            objExpected.ShortDescription = "a violet scroll";
            objExpected.Description = "A rolled piece of violet parchment lies on the floor.";
            objExpected.Material = "oldstyle";
            objExpected.ObjectType = Enums.ItemClass.Scroll;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.Bless;
            objExpected.WearFlags = Enums.WearFlag.Take;
            objExpected.Values[0] = 15;  // Level
            objExpected.Values[1] = Consts.Skills.SkillTable.Single(s => s.Name.Equals("armor"));  // Spell 1
            objExpected.Values[2] = Consts.Skills.SkillTable.Single(s => s.Name.Equals("bless"));  // Spell 2
            objExpected.Values[3] = Consts.Skills.SkillTable.Single(s => s.Name.Equals("shield"));  // Spell 3
            objExpected.Level = 11;
            objExpected.Weight = 10;
            objExpected.Cost = 1510;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.ExtraDescriptions.Add(new ExtraDescription() { Keywords = "scroll violet", Description = "The scroll is written on soft violet parchment that has a pleasing smell to it." });
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidLight()
        {
            // Object data to parse, VNUM 3000 from astral.are, lines 566-582
            string objData = @"#7713
stone flame~
a brightly flaming stone~
The room is lit by a hot blue flame coming from a small stone.~
oldstyle~
light 0 AO
0 0 -1 0 0
20 10 1440 P
A
20 -2
A
17 -2
E
stone flame~
This stone burns with an flame that emits great heat, yet it can be held with
ease.  The flame creates a light that allows you to see for miles.
~
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 7713;
            objExpected.Name = "stone flame";
            objExpected.ShortDescription = "a brightly flaming stone";
            objExpected.Description = "The room is lit by a hot blue flame coming from a small stone.";
            objExpected.Material = "oldstyle";
            objExpected.ObjectType = Enums.ItemClass.Light;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.None;
            objExpected.WearFlags = (Enums.WearFlag)Enums.AlphaMacros.A | (Enums.WearFlag)Enums.AlphaMacros.O;
            objExpected.Values[0] = 0;
            objExpected.Values[1] = 0;
            objExpected.Values[2] = -1;
            objExpected.Values[3] = 0;
            objExpected.Values[4] = 0;
            objExpected.Level = 20;
            objExpected.Weight = 10;
            objExpected.Cost = 1440;
            objExpected.Condition = 100;
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();
            objExpected.Affected.Add(new AffectData() { 
                Where = Enums.ToWhere.Object,
                Type = -1,
                Level = objExpected.Level,
                Duration = -1,
                BitVector = 0,
                Location = Enums.ApplyType.Saves,
                Modifier = -2
            }); // -2 to saves
            objExpected.Affected.Add(new AffectData() { 
                Where = Enums.ToWhere.Object,
                Type = -1,
                Level = objExpected.Level,
                Duration = -1,
                BitVector = 0,
                Location = Enums.ApplyType.AC, 
                Modifier = -2 
            }); // -2 to AC
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.ExtraDescriptions.Add(new ExtraDescription() { Keywords = "stone flame", Description = "This stone burns with an flame that emits great heat, yet it can be held with\nease.  The flame creates a light that allows you to see for miles." });

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        [Test(), TestOf(typeof(ObjectIndexData))]
        public void TestValidDrink()
        {
            // Object data to parse, VNUM 3000 from midgaard.are, lines 959-966
            string objData = @"#3000
barrel beer~
a barrel of beer~
A beer barrel has been left here.~
wood~
drink 0 A
300 300 'beer' 0 0
0 160 75 P
#$";

            StringReader sr = new StringReader(objData);
            int lineNum = 1;
            string firstLine = sr.ReadLine();

            // Set up the object we expect to have parsed from the string
            ObjectIndexData objExpected = new ObjectIndexData();
            objExpected.VNUM = 3000;
            objExpected.Name = "barrel beer";
            objExpected.ShortDescription = "a barrel of beer";
            objExpected.Description = "A beer barrel has been left here.";
            objExpected.Material = "wood";
            objExpected.ObjectType = Enums.ItemClass.DrinkContainer;
            objExpected.ExtraFlags = Enums.ItemExtraFlag.None;
            objExpected.WearFlags = (Enums.WearFlag)Enums.AlphaMacros.A;
            objExpected.Values[0] = 300;    // Capacity
            objExpected.Values[1] = 300;    // Fill level
            objExpected.Values[2] = Consts.Liquids.LiquidTable.Single(l => l.Name.Equals("beer"));  // Liquid type
            objExpected.Level = 0;
            objExpected.Weight = 160;
            objExpected.Cost = 75;
            objExpected.Condition = 100;
            objExpected.ExtraDescriptions = new System.Collections.Generic.List<ExtraDescription>();
            objExpected.Affected = new System.Collections.Generic.List<AffectData>();

            try
            {
                // Parse the object from the string
                ObjectIndexData obj = ObjectIndexData.ParseObjectData(ref sr, "testArea", ref lineNum, firstLine, false);

                // Compare the two objects
                CompareObjects(objExpected, obj);
            }
            catch (Exception e)
            {
                Assert.Fail(String.Format("Execption thrown loading object: {0} {1}", e.GetType().ToString(), e.Message));
            }
        }

        /// <summary>
        /// Compare two ObjectIndexData objects for differences
        /// </summary>
        /// <param name="objExpected">Model object to compare the parsed version against</param>
        /// <param name="obj">Object returned by ParseObjectData()</param>
        private void CompareObjects(ObjectIndexData objExpected, ObjectIndexData obj)
        {
            // Compare
            if (!objExpected.Equals(obj))
            {
                // Run individual tests to find the culprit
                Assert.AreEqual(objExpected.VNUM, obj.VNUM, String.Format("Object vnum mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.VNUM, obj.VNUM));
                Assert.AreEqual(objExpected.Name, obj.Name, String.Format("Object name mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Name, obj.Name));
                Assert.AreEqual(objExpected.ShortDescription, obj.ShortDescription, String.Format("Object short description mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.ShortDescription, obj.ShortDescription));
                Assert.AreEqual(objExpected.Description, obj.Description, String.Format("Object description mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Description, obj.Description));
                Assert.AreEqual(objExpected.Material, obj.Material, String.Format("Object material mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Material, obj.Material));
                Assert.AreEqual(objExpected.ObjectType, obj.ObjectType, String.Format("Object type mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.ObjectType, obj.ObjectType));
                Assert.AreEqual(objExpected.ExtraFlags, obj.ExtraFlags, String.Format("Object extra flags mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.ExtraFlags.ToString(), obj.ExtraFlags.ToString()));
                Assert.AreEqual(objExpected.WearFlags, obj.WearFlags, String.Format("Object wear flags mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.WearFlags.ToString(), obj.WearFlags.ToString()));
                Assert.AreEqual(objExpected.Values[0], obj.Values[0], String.Format("Object values 1 mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Values[0], obj.Values[0]));
                Assert.AreEqual(objExpected.Values[1], obj.Values[1], String.Format("Object values 2 mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Values[1], obj.Values[1]));
                Assert.AreEqual(objExpected.Values[2], obj.Values[2], String.Format("Object values 3 mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Values[2], obj.Values[2]));
                Assert.AreEqual(objExpected.Values[3], obj.Values[3], String.Format("Object values 4 mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Values[3], obj.Values[3]));
                Assert.AreEqual(objExpected.Values[4], obj.Values[4], String.Format("Object values 5 mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Values[4], obj.Values[4]));
                Assert.AreEqual(objExpected.Level, obj.Level, String.Format("Object level mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Level, obj.Level));
                Assert.AreEqual(objExpected.Weight, obj.Weight, String.Format("Object weight mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Weight, obj.Weight));
                Assert.AreEqual(objExpected.Cost, obj.Cost, String.Format("Object cost mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Cost, obj.Cost));
                Assert.AreEqual(objExpected.Condition, obj.Condition, String.Format("Object condition mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Condition, obj.Condition));
                Assert.AreEqual(objExpected.Affected, obj.Affected, String.Format("Object affected mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.Affected.ToString(), obj.Affected.ToString()));
                Assert.AreEqual(objExpected.ExtraDescriptions, obj.ExtraDescriptions, String.Format("Object extradescription mismatch, expected \"{0}\" but parsed \"{1}\"", objExpected.ExtraDescriptions.ToString(), obj.ExtraDescriptions.ToString()));
            }
            else
                Assert.Pass();
        }
    }
}