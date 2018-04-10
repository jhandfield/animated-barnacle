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