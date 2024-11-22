using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        [MaxLength(20)]
        public string SkillCode { get; set; }

        [MaxLength(200)]
        public string SkillDescription { get; set; }

        public ICollection<EngineerSkill> EngineerSkills { get; set; }
    }
}
