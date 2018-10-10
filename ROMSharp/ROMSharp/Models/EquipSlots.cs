using System;
using System.Linq;
using ROMSharp.Enums;
namespace ROMSharp.Models
{
    public class EquipSlots
    {
        /// <summary>
        /// The maximum equip slot as an integer
        /// </summary>
        public static int MaxValue { get {
                return (int)Enum.GetValues(typeof(Enums.EquipSlot)).Cast<Enums.EquipSlot>().Max();
            }
        }

        public ObjectData this[int slot]
        {
            get {
                switch (slot)
                {
                    case 0:
                        return this.Light;
                    case 1:
                        return this.LeftFinger;
                    case 2:
                        return this.RightFinger;
                    case 3:
                        return this.Neck1;
                    case 4:
                        return this.Neck2;
                    case 5:
                        return this.Body;
                    case 6:
                        return this.Head;
                    case 7:
                        return this.Legs;
                    case 8:
                        return this.Feet;
                    case 9:
                        return this.Hands;
                    case 10:
                        return this.Arms;
                    case 11:
                        return this.Shield;
                    case 12:
                        return this.About;
                    case 13:
                        return this.Waist;
                    case 14:
                        return this.LeftWrist;
                    case 15:
                        return this.RightWrist;
                    case 16:
                        return this.Wield;
                    case 17:
                        return this.Hold;
                    case 18:
                        return this.Float;
                    default:
                        throw new IndexOutOfRangeException("Index is out of bounds");
                }
            }
        }
        public ObjectData this[Enums.EquipSlot loc]
        {
            get {
                switch (loc) {
                    case EquipSlot.Light:
                        return this.Light;
                    case EquipSlot.LeftFinger:
                        return this.LeftFinger;
                    case EquipSlot.RightFinger:
                        return this.RightFinger;
                    case EquipSlot.Neck1:
                        return this.Neck1;
                    case EquipSlot.Neck2:
                        return this.Neck2;
                    case EquipSlot.Body:
                        return this.Body;
                    case EquipSlot.Head:
                        return this.Head;
                    case EquipSlot.Legs:
                        return this.Legs;
                    case EquipSlot.Feet:
                        return this.Feet;
                    case EquipSlot.Hands:
                        return this.Hands;
                    case EquipSlot.Arms:
                        return this.Arms;
                    case EquipSlot.Shield:
                        return this.Shield;
                    case EquipSlot.About:
                        return this.About;
                    case EquipSlot.Waist:
                        return this.Waist;
                    case EquipSlot.LeftWrist:
                        return this.LeftWrist;
                    case EquipSlot.RightWrist:
                        return this.RightWrist;
                    case EquipSlot.Wield:
                        return this.Wield;
                    case EquipSlot.Hold:
                        return this.Hold;
                    case EquipSlot.Float:
                        return this.Float;
                    default:
                        return null;
                }
            }
            set {
                switch (loc) {
                    case EquipSlot.Light:
                        this.Light = value;
                        break;
                    case EquipSlot.LeftFinger:
                        this.LeftFinger = value;
                        break;
                    case EquipSlot.RightFinger:
                        this.RightFinger = value;
                        break;
                    case EquipSlot.Neck1:
                        this.Neck1 = value;
                        break;
                    case EquipSlot.Neck2:
                        this.Neck2 = value;
                        break;
                    case EquipSlot.Body:
                        this.Body = value;
                        break;
                    case EquipSlot.Head:
                        this.Head = value;
                        break;
                    case EquipSlot.Legs:
                        this.Legs = value;
                        break;
                    case EquipSlot.Feet:
                        this.Feet = value;
                        break;
                    case EquipSlot.Hands:
                        this.Hands = value;
                        break;
                    case EquipSlot.Arms:
                        this.Arms = value;
                        break;
                    case EquipSlot.Shield:
                        this.Shield = value;
                        break;
                    case EquipSlot.About:
                        this.About = value;
                        break;
                    case EquipSlot.Waist:
                        this.Waist = value;
                        break;
                    case EquipSlot.LeftWrist:
                        this.LeftWrist = value;
                        break;
                    case EquipSlot.RightWrist:
                        this.RightWrist = value;
                        break;
                    case EquipSlot.Wield:
                        this.Wield = value;
                        break;
                    case EquipSlot.Hold:
                        this.Hold = value;
                        break;
                    case EquipSlot.Float:
                        this.Float = value;
                        break;
                    default:
                        throw new ArgumentException("Unknown equipment slot passed", "loc");
                }
            }
        }

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

        /// <summary>
        /// Is nothing equipped?
        /// </summary>
        /// <value><c>true</c> if is naked; otherwise, <c>false</c>.</value>
        public bool IsNaked
        {
            get
            {
                return (this.About == null &&
                    this.Arms == null &&
                   this.Body == null &&
                   this.Feet == null &&
                    this.Float == null &&
                   this.Hands == null &&
                   this.Head == null &&
                   this.Hold == null &&
                   this.LeftFinger == null &&
                   this.LeftWrist == null &&
                   this.Legs == null &&
                   this.Light == null &&
                   this.Neck1 == null &&
                    this.Neck2 == null &&
                    this.RightFinger == null &&
                    this.RightFinger == null &&
                    this.Shield == null &&
                    this.Waist == null &&
                        this.Wield == null);


            }
        }

        public EquipSlots()
        {
        }
    }
}
