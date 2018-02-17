using System;
namespace ROMSharp.Models
{
    public class Gender
    {
        /// <summary>
        /// Name of the gender
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Corresponding Enums.Sex value for this gender
        /// </summary>
        public Enums.Sex GenderCode { get; set; }

        public Gender() { }
        public Gender(string name, Enums.Sex code)
        {
            Name = name;
            GenderCode = code;
        }
    }
}
