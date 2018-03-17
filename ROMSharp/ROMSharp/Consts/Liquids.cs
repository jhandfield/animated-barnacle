using System.Collections.Generic;

namespace ROMSharp.Consts
{
    public static class Liquids
    {
        /// <summary>
        /// Collection of liquids
        /// </summary>
        public static List<Models.LiquidType> LiquidTable;

        static Liquids() {
            LiquidTable = new List<Models.LiquidType>();
            LiquidTable.Add(new Models.LiquidType("water", "clear", new int[] { 0, 1, 10, 0, 16 }));
            LiquidTable.Add(new Models.LiquidType("beer", "amber", new int[] { 12, 1, 8, 1, 12 }));
            LiquidTable.Add(new Models.LiquidType("red wine", "burgundy", new int[] { 30, 1, 8, 1, 5}));
            LiquidTable.Add(new Models.LiquidType("ale", "brown", new int[] { 15, 1, 8, 1, 12}));
            LiquidTable.Add(new Models.LiquidType("dark ale", "dark", new int[] { 16, 1, 8, 1, 12}));

            LiquidTable.Add(new Models.LiquidType("whisky", "golden", new int[] { 120, 1, 5, 0, 2}));
            LiquidTable.Add(new Models.LiquidType("lemonade", "pink", new int[] { 0, 1, 9, 2, 12}));
            LiquidTable.Add(new Models.LiquidType("firebreather", "boiling", new int[] { 190, 0, 4, 0, 2}));
            LiquidTable.Add(new Models.LiquidType("local specialty", "clear", new int[] { 151, 1, 3, 0, 2}));
            LiquidTable.Add(new Models.LiquidType("slime mold juice", "green", new int[] { 0, 2, -8, 1, 2}));

            LiquidTable.Add(new Models.LiquidType("milk", "white", new int[] { 0, 2, 9, 3, 12}));
            LiquidTable.Add(new Models.LiquidType("tea", "tan", new int[] { 0, 1, 8, 0, 6}));
            LiquidTable.Add(new Models.LiquidType("coffee", "black", new int[] { 0, 1, 8, 0, 6}));
            LiquidTable.Add(new Models.LiquidType("blood", "red", new int[] { 0, 2, -1, 2, 6}));
            LiquidTable.Add(new Models.LiquidType("salt water", "clear", new int[] { 0, 1, -2, 0, 1}));

            LiquidTable.Add(new Models.LiquidType("coke", "brown", new int[] { 0, 2, 9, 2, 12}));
            LiquidTable.Add(new Models.LiquidType("root beer", "brown", new int[] { 0, 2, 9, 2, 12}));
            LiquidTable.Add(new Models.LiquidType("elvish wine", "green", new int[] { 35, 2, 8, 1, 5}));
            LiquidTable.Add(new Models.LiquidType("white wine", "golden", new int[] { 28, 1, 8, 1, 5}));
            LiquidTable.Add(new Models.LiquidType("champagne", "golden", new int[] { 32, 1, 8, 1, 5}));

            LiquidTable.Add(new Models.LiquidType("mead", "honey-colored", new int[] { 34, 2, 8, 2, 12}));
            LiquidTable.Add(new Models.LiquidType("rose wine", "pink", new int[] { 26, 1, 8, 1, 5}));
            LiquidTable.Add(new Models.LiquidType("benedictine wine", "burgundy", new int[] { 40, 1, 8, 1, 5}));
            LiquidTable.Add(new Models.LiquidType("vodka", "clear", new int[] { 130, 1, 5, 0, 2}));
            LiquidTable.Add(new Models.LiquidType("cranberry juice", "red", new int[] { 0, 1, 9, 2, 12}));

            LiquidTable.Add(new Models.LiquidType("orange juice", "orange", new int[] { 0, 2, 9, 3, 12}));
            LiquidTable.Add(new Models.LiquidType("absinthe", "green", new int[] { 200, 1, 4, 0, 2}));
            LiquidTable.Add(new Models.LiquidType("brandy", "golden", new int[] { 80, 1, 5, 0, 4}));
            LiquidTable.Add(new Models.LiquidType("aquavit", "cear", new int[] { 140, 1, 5, 0, 2}));

            LiquidTable.Add(new Models.LiquidType("schnapps", "clear", new int[] { 90, 1, 5, 0, 2 }));
            LiquidTable.Add(new Models.LiquidType("icewine", "purple", new int[] { 50, 2, 6, 1, 5}));
            LiquidTable.Add(new Models.LiquidType("amontillado", "burgundy", new int[] { 35, 2, 8, 1, 5}));
            LiquidTable.Add(new Models.LiquidType("sherry", "red", new int[] { 38, 2, 7, 1, 5}));
            LiquidTable.Add(new Models.LiquidType("framboise", "red", new int[] { 50, 1, 7, 1, 5}));

            LiquidTable.Add(new Models.LiquidType("rum", "amber", new int[] { 151, 1, 4, 0, 2}));
            LiquidTable.Add(new Models.LiquidType("cordial", "clear", new int[] { 100, 1, 5, 0, 2}));
        }
    }
}