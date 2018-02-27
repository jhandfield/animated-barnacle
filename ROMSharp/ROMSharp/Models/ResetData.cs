using System;
namespace ROMSharp.Models
{
    public class ResetData
    {
        #region Properties
        /// <summary>
        /// Determines the command the reset should perform
        /// </summary>
        public ResetCommand Command { get; set; }

        /// <summary>
        /// First argument for the reset - varies by reset type
        /// </summary>
        public int Arg1 { get; set; }

        /// <summary>
        /// Second argument for the reset - varies by reset type
        /// </summary>
        public int Arg2 { get; set; }

        /// <summary>
        /// Third argument for the reset - varies by reset type
        /// </summary>
        public int Arg3 { get; set; }

        /// <summary>
        /// Fourth argument for the reset - varies by reset type
        /// </summary>
        public int Arg4 { get; set; }
        #endregion

        public ResetData() { }
    }

    public enum ResetCommand {
        SpawnMobile = 'M',
        SpawnObject = 'O',
        PutInObject = 'P',
        GiveObjectToMob = 'G',
        EquipObjectOnMob = 'E',
        SetDoorState = 'D',
        RandomizeExits = 'R'
    }
}
