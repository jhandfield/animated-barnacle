using System;
using System.Collections.Generic;
using System.Linq;

namespace ROMSharp.Models
{
    public class SkillGroup
    {
        public string Name { get; set; }
        public Dictionary<Class, int> Rating { get; set; }
        public List<SkillType> Skills { get; set; }
        public SkillGroup() { 
            Rating = new Dictionary<Class, int>();
            Skills = new List<SkillType>();
        }
        public SkillGroup(string name, Dictionary<Class, int> rating, List<SkillType> skills) : this()
        {
            Name = name;
            Rating = rating;
            Skills = skills;
        }
        public SkillGroup(string name, int[] rating, string[] skills) : this()
        {
            Name = name;

            // Ensure rating has elements for all classes
            if (rating.Length != Consts.Classes.ClassTable.Count)
                throw new ArgumentOutOfRangeException(String.Format("You must include ratings for all classes - passed {0}, expected {1}", rating.Length, Consts.Classes.ClassTable.Count), "rating");
            else
                // Loop over the rating array, appending to the Ratings property
                for (int i = 0; i < rating.Length; i++)
                    Rating.Add(Consts.Classes.ClassTable[i], rating[i]);
            
            // Ensure skillsInGroup has at least 1 element
            if (skills.Length == 0)
                throw new ArgumentOutOfRangeException("You must pass at least one skill name", "skillsInGroup");
            else
            {
                // Loop over each skill/group in skillsInGroup
                foreach(string skill in skills)
                {
                    // Attempt to find a corresponding skill
                    SkillType matchedSkill = Consts.Skills.SkillTable.SingleOrDefault<SkillType>(s => s.Name.ToLower().Equals(skill.ToLower()));

                    // Did we find one?
                    if (matchedSkill != null)
                        // Add to the resolved list
                        Skills.Add(matchedSkill);
                    else
                    {
                        // Check for a group matching the name instead
                        SkillGroup matchedGroup = Consts.Skills.SkillGroupTable.SingleOrDefault(g => g.Name.ToLower().Equals(skill.ToLower()));

                        // Did we find one?
                        if (matchedGroup != null)
                            // Add the group's skills to the resolved list
                            Skills.AddRange(matchedGroup.Skills);
                        else
                            // Log a warning and continue
                            Logging.Log.Warn(String.Format("Unable to find matching skill or group for \"{0}\" defined in skill group {1}", skill, Name));
                    }
                }
            }
        }
    }
}
