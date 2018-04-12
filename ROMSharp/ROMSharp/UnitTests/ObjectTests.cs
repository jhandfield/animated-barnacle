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