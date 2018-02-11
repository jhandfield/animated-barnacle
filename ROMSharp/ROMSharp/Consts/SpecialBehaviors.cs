using System;
using System.Collections.Generic;
using ROMSharp.Helpers;

namespace ROMSharp.Consts
{
    public class SpecialBehaviors
    {
        public static List<Models.SpecialBehavior> SpecialBehaviorTable = new List<Models.SpecialBehavior>() {
            new Models.SpecialBehavior("spec_breath_any", SpecialBehaviorMethods.SpecBreath_Any),
            new Models.SpecialBehavior("spec_breath_acid", SpecialBehaviorMethods.SpecBreath_Acid),
            new Models.SpecialBehavior("spec_breath_fire", SpecialBehaviorMethods.SpecBreath_Fire),
            new Models.SpecialBehavior("spec_breath_frost", SpecialBehaviorMethods.SpecBreath_Frost),
            new Models.SpecialBehavior("spec_breath_gas", SpecialBehaviorMethods.SpecBreath_Gas),
            new Models.SpecialBehavior("spec_breath_lightning", SpecialBehaviorMethods.SpecBreath_Lightning),
            new Models.SpecialBehavior("spec_cast_adept", SpecialBehaviorMethods.SpecCast_Adept),
            new Models.SpecialBehavior("spec_cast_cleric", SpecialBehaviorMethods.SpecCast_Cleric),
            new Models.SpecialBehavior("spec_cast_judge", SpecialBehaviorMethods.SpecCast_Judge),
            new Models.SpecialBehavior("spec_cast_mage", SpecialBehaviorMethods.SpecCast_Mage),
            new Models.SpecialBehavior("spec_cast_undead", SpecialBehaviorMethods.SpecCast_Undead),
            new Models.SpecialBehavior("spec_executioner", SpecialBehaviorMethods.Spec_Executioner),
            new Models.SpecialBehavior("spec_fido", SpecialBehaviorMethods.Spec_Fido),
            new Models.SpecialBehavior("spec_guard", SpecialBehaviorMethods.Spec_Guard),
            new Models.SpecialBehavior("spec_janitor", SpecialBehaviorMethods.Spec_Janitor),
            new Models.SpecialBehavior("spec_mayor", SpecialBehaviorMethods.Spec_Mayor),
            new Models.SpecialBehavior("spec_poison", SpecialBehaviorMethods.Spec_Poison),
            new Models.SpecialBehavior("spec_thief", SpecialBehaviorMethods.Spec_Thief),
            new Models.SpecialBehavior("spec_nasty", SpecialBehaviorMethods.Spec_Nasty),
            new Models.SpecialBehavior("spec_troll_member", SpecialBehaviorMethods.Spec_TrollMember),
            new Models.SpecialBehavior("spec_ogre_member", SpecialBehaviorMethods.Spec_OgreMember),
            new Models.SpecialBehavior("spec_patrolman", SpecialBehaviorMethods.Spec_Patrolman)
        };
    }
}