using Core.Models.System;

namespace amf.Areas.Team.Models
{
    public class SkillModel
    {

        public int Id { get; set; }


        public SkillModel(Skill skill)
        {
            
        }

        public SkillModel()
        {
        }

        public Skill AsSkill()
        {
            return new Skill();
        }
    }
}