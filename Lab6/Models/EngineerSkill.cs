using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class EngineerSkill
    {
        [Required]
        public int EngineerId { get; set; }

        [ForeignKey("EngineerId")]
        public MaintenanceEngineer Engineer { get; set; }

        [Required]
        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
    }
}
