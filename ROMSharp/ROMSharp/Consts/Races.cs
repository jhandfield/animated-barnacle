using System.Collections.Generic;
using ROMSharp.Models;
using ROMSharp.Helpers;
using ROMSharp.Enums;

namespace ROMSharp.Consts
{
    public class Races
    {
        public static List<Race> RaceTable = new List<Race>() {
            #region PC Races
            new Race() {
                Name="Unique",
                IsPCRace=false,
            },
            new Race() {
                Name="human",
                IsPCRace=true,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFGHIJK")
            },
            new Race() {
                Name="elf",
                IsPCRace=true,
                Affects=AffectedByFlag.Infrared,
                Resistances=ResistanceFlag.Charm,
                Vulnerabilities=VulnerabilityFlag.Iron,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFGHIJK")
            },
            new Race() {
                Name="dwarf",
                IsPCRace=true,
                Affects=AffectedByFlag.Infrared,
                Resistances=ResistanceFlag.Poison | ResistanceFlag.Disease,
                Vulnerabilities=VulnerabilityFlag.Drowning,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFGHIJK")
            },
            new Race() {
                Name="giant",
                IsPCRace=true,
                Resistances=ResistanceFlag.Fire | ResistanceFlag.Cold,
                Vulnerabilities=VulnerabilityFlag.Mental | VulnerabilityFlag.Lightning,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFGHIJK")
            },
            #endregion

#region NPC-only Races
            new Race() {
                Name="bat",
                IsPCRace=false,
                Affects=AffectedByFlag.Flying | AffectedByFlag.DarkVision,
                Offenses=OffensiveFlag.Offense_Dodge | OffensiveFlag.Offense_Fast,
                Vulnerabilities = VulnerabilityFlag.Light,
                Form = AlphaConversions.ConvertROMAlphaToFormFlag("AGV"),
                Parts = AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHJKP")
            },
            new Race() {
                Name="bear",
                IsPCRace=false,
                Offenses=OffensiveFlag.Offense_Crush | OffensiveFlag.Offense_Disarm | OffensiveFlag.Offense_Berserk,
                Resistances=ResistanceFlag.Bash | ResistanceFlag.Cold,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFHJKUV")
            },
            new Race() {
                Name="cat",
                IsPCRace=false,
                Affects=AffectedByFlag.DarkVision,
                Offenses=OffensiveFlag.Offense_Fast | OffensiveFlag.Offense_Dodge,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHJKQUV")
            },
            new Race() {
                Name="centipede",
                IsPCRace=false,
                Affects=AffectedByFlag.DarkVision,
                Resistances=ResistanceFlag.Pierce | ResistanceFlag.Cold,
                Vulnerabilities = VulnerabilityFlag.Bash,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("ABGO"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACK")
            },
            new Race() {
                Name="dog",
                IsPCRace=false,
                Offenses=OffensiveFlag.Offense_Fast,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHJKUV")
            },
            new Race() {
                Name="doll",
                IsPCRace=false,
                Immunities=ImmunityFlag.Cold | ImmunityFlag.Poison | ImmunityFlag.Holy | ImmunityFlag.Negative | ImmunityFlag.Mental | ImmunityFlag.Disease | ImmunityFlag.Drowning,
                Resistances=ResistanceFlag.Bash | ResistanceFlag.Light,
                Vulnerabilities=VulnerabilityFlag.Slash | VulnerabilityFlag.Fire | VulnerabilityFlag.Acid | VulnerabilityFlag.Lightning | VulnerabilityFlag.Energy,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("EJMcc"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCGHK")
            },
            new Race() {
                Name="dragon",
                IsPCRace=false,
                Affects=AffectedByFlag.Infrared | AffectedByFlag.Flying,
                Resistances=ResistanceFlag.Fire | ResistanceFlag.Bash | ResistanceFlag.Charm,
                Vulnerabilities=VulnerabilityFlag.Pierce | VulnerabilityFlag.Cold,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AHZ"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFGHIJKPQUVX")
            },
            new Race() {
                Name="fido",
                IsPCRace=false,
                Offenses=OffensiveFlag.Offense_Dodge|OffensiveFlag.Assist_Race,
                Vulnerabilities=VulnerabilityFlag.Magic,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("ABGV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHJKQV")
            },
            new Race(){
                Name="fox",
                IsPCRace=false,
                Affects=AffectedByFlag.DarkVision,
                Offenses=OffensiveFlag.Offense_Fast | OffensiveFlag.Offense_Dodge,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHJKQV")
            },
            new Race() {
                Name="goblin",
                IsPCRace=false,
                Affects=AffectedByFlag.Infrared,
                Resistances=ResistanceFlag.Disease,
                Vulnerabilities=VulnerabilityFlag.Magic,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFGHIJK")
            },
            new Race() {
                Name="hobgoblin",
                IsPCRace=false,
                Affects=AffectedByFlag.Infrared,
                Resistances=ResistanceFlag.Disease | ResistanceFlag.Poison,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFGHIJKY")
            },
            new Race(){
                Name="kobold",
                IsPCRace=false,
                Affects=AffectedByFlag.Infrared,
                Resistances=ResistanceFlag.Poison,
                Vulnerabilities=VulnerabilityFlag.Magic,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("ABHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFGHIJKWQ")
            },
            new Race(){
                Name="lizard",
                IsPCRace=false,
                Resistances=ResistanceFlag.Poison,
                Vulnerabilities=VulnerabilityFlag.Cold,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGXcc"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHKQV")
            },
            new Race(){
                Name="modron",
                IsPCRace=false,
                Affects=AffectedByFlag.Infrared,
                Offenses=OffensiveFlag.Assist_Race | OffensiveFlag.Assist_Align,
                Immunities=ImmunityFlag.Charm | ImmunityFlag.Disease | ImmunityFlag.Mental | ImmunityFlag.Holy | ImmunityFlag.Negative,
                Resistances=ResistanceFlag.Fire | ResistanceFlag.Cold | ResistanceFlag.Acid,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("H"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABGHJK")
            },
            new Race(){
                Name="orc",
                IsPCRace=false,
                Affects=AffectedByFlag.Infrared,
                Resistances=ResistanceFlag.Disease,
                Vulnerabilities=VulnerabilityFlag.Light,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFHIJK")
            },
            new Race(){
                Name="pig",
                IsPCRace=false,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHJK")
            },
            new Race(){
                Name="rabbit",
                IsPCRace=false,
                Offenses=OffensiveFlag.Offense_Dodge | OffensiveFlag.Offense_Fast,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHJK")
            },
            new Race(){
                Name="school monster",
                IsPCRace=false,
                Actions=ActionFlag.NoAlign,
                Immunities=ImmunityFlag.Charm | ImmunityFlag.Summon,
                Vulnerabilities=VulnerabilityFlag.Magic,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFHJKQU")
            },
            new Race(){
                Name="snake",
                IsPCRace=false,
                Resistances=ResistanceFlag.Poison,
                Vulnerabilities=VulnerabilityFlag.Cold,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGXYcc"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ADEFKLQVX")
            },
            new Race(){
                Name="song bird",
                IsPCRace=false,
                Affects=AffectedByFlag.Flying,
                Offenses=OffensiveFlag.Offense_Fast | OffensiveFlag.Offense_Dodge,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGW"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHKP")
            },
            new Race(){
                Name="troll",
                IsPCRace=false,
                Affects=AffectedByFlag.Regeneration | AffectedByFlag.Infrared | AffectedByFlag.DetectHidden,
                Offenses=OffensiveFlag.Offense_Berserk,
                Resistances=ResistanceFlag.Charm | ResistanceFlag.Bash,
                Vulnerabilities=VulnerabilityFlag.Fire | VulnerabilityFlag.Acid,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("ABHMV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ABCDEFGHIJKUV")
            },
            new Race(){
                Name="water fowl",
                IsPCRace=false,
                Affects=AffectedByFlag.Swim | AffectedByFlag.Flying,
                Resistances = ResistanceFlag.Drowning,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGW"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHKP")
            },
            new Race(){
                Name="wolf",
                IsPCRace=false,
                Affects=AffectedByFlag.DarkVision,
                Offenses=OffensiveFlag.Offense_Fast | OffensiveFlag.Offense_Dodge,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("AGV"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFJKQV")
            },
            new Race(){
                Name="wyvern",
                IsPCRace=false,
                Affects=AffectedByFlag.Flying | AffectedByFlag.DetectInvis | AffectedByFlag.DetectHidden,
                Offenses=OffensiveFlag.Offense_Bash | OffensiveFlag.Offense_Fast | OffensiveFlag.Offense_Dodge,
                Immunities=ImmunityFlag.Poison,
                Vulnerabilities=VulnerabilityFlag.Light,
                Form=AlphaConversions.ConvertROMAlphaToFormFlag("ABGZ"),
                Parts=AlphaConversions.ConvertROMAlphaToPartFlag("ACDEFHJKQVX")
            }
            #endregion
        };

        public Races() { }
    }
}