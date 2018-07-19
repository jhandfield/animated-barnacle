using System;
namespace ROMSharp.Models
{
    public class WearSlots
    {
        /// <summary>
        /// The character's light source
        /// </summary>
        public ObjectData Light { get; set; }

        /// <summary>
        /// The character's left finger
        /// </summary>
        public ObjectData LeftFinger { get; set; }

        /// <summary>
        /// The character's right finger
        /// </summary>
        public ObjectData RightFinger { get; set; }

        /// <summary>
        /// The character's neck (max of 2 items, Neck1 and Neck2)
        /// </summary>
        public ObjectData Neck1 { get; set; }

        /// <summary>
        /// The character's neck (max of 2 items, Neck1 and Neck2)
        /// </summary>
        public ObjectData Neck2 { get; set; }

        /// <summary>
        /// The character's body / torso
        /// </summary>
        public ObjectData Body { get; set; }

        /// <summary>
        /// The character's head
        /// </summary>
        public ObjectData Head { get; set; }

        /// <summary>
        /// The character's legs
        /// </summary>
        public ObjectData Legs { get; set; }

        /// <summary>
        /// The character's feet
        /// </summary>
        public ObjectData Feet { get; set; }

        /// <summary>
        /// The character's hands
        /// </summary>
        public ObjectData Hands { get; set; }

        /// <summary>
        /// On the character's arms
        /// </summary>
        public ObjectData Arms { get; set; }

        /// <summary>
        /// The character's shield
        /// </summary>
        public ObjectData Shield { get; set; }

        /// <summary>
        /// About the character's body (e.g. cloaks)
        /// </summary>
        public ObjectData About { get; set; }

        /// <summary>
        /// Around the character's waist
        /// </summary>
        /// <value>The waist.</value>
        public ObjectData Waist { get; set; }

        /// <summary>
        /// Around the character's left wrist
        /// </summary>
        public ObjectData LeftWrist { get; set; }

        /// <summary>
        /// Around the character's right wrist
        /// </summary>
        public ObjectData RightWrist { get; set; }

        /// <summary>
        /// Wielded by the character as a weapon
        /// </summary>
        public ObjectData Wield { get; set; }

        /// <summary>
        /// Held by the character
        /// </summary>
        public ObjectData Hold { get; set; }

        /// <summary>
        /// Floating in the vicinity of the character
        /// </summary>
        public ObjectData Float { get; set; }

        public WearSlots()
        {
        }
    }
}
