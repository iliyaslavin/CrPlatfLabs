using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class SkillRequiredToFix
    {
        [Key]
        public int SkillRequiredToFixId { get; set; }

        [Required]
        public int PartFaultId { get; set; }

        [ForeignKey("PartFaultId")]
        public PartFault PartFault { get; set; }

        [Required]
        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
    }
}
