using ROMSharp.Enums;
using System;

namespace ROMSharp.Helpers
{
    public static class Extensions
    {
        /// <summary>
        /// Convert an Enum of one type to an Enum of another type
        /// </summary>
        /// <returns>The <paramref name="value"/> converted to an Enum of type <paramref name="T"/></returns>
        /// <typeparam name="T">The Enum type to convert to</typeparam>
        public static T ConvertTo<T>(this object value) where T : struct, IConvertible
        {
            var sourceType = value.GetType();
            if (!sourceType.IsEnum)
                throw new ArgumentException("Source type is not enum");
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Destination type is not enum");

            // Do the conversion via int, since we're using flags trying to convert directly will fail with >1 flag
            return (T)Enum.Parse(typeof(T), ((int)value).ToString());
        }
    }

    public static class AlphaMacroConversion
    {
        /// <summary>
        /// Convert an enum value to a ROM-compatible alpha flag string
        /// </summary>
        /// <returns>The source enum as represented by AlphaMacros in the legacy ROM format</returns>
        /// <param name="sourceValue">Source value to convert - MUST BE A FLAG-BASED ENUM</param>
        public static string EnumToROMAlpha(object sourceValue)
        {
            return ((AlphaMacros)sourceValue).ToString().Replace(", ", "");
        }

        public static object ConvertToDestEnum(string value, Type type)
        {
            if (type.IsEnum)
            {
                return Enum.Parse(type, value);
            }
            else
                throw new ArgumentException("Type must be an enum");
        }

        //public static object ROMAlphaToEnum(string sourceValue, object destType)
        //{
        //    // First, convert the source value to a native AlphaMacros object
        //    AlphaMacros sourceInNative = ROMAlphaToNativeAlpha(sourceValue);
        //    //Type outputType = destType.GetEnumUnderlyingType();

        //    // Next, cast the native enum to the target type
        //    //return sourceInNative.ConvertTo<destType.GetType(>();

        //    // Return the result
        //    //return result;
        //}

        /// <summary>
        /// Converts a ROM-compatible alpha flag string to a native AlphaMacros enum
        /// </summary>
        /// <param name="sourceValue">Source value to convert - must be ROM flags from A to ee</param>
        private static AlphaMacros ROMAlphaToNativeAlpha(string sourceValue)
        {
            AlphaMacros output = AlphaMacros.NUL;

            foreach (char c in sourceValue)
            {
                AlphaMacros temp = (AlphaMacros)Enum.Parse(typeof(AlphaMacros), c.ToString().ToUpper());
                output |= temp;
            }

            return output;
        }
    }
}
