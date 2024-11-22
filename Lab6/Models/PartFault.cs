using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class PartFault
    {
        [Key]
        public int PartFaultId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FaultShortName { get; set; }

        [MaxLength(500)]
        public string FaultDescription { get; set; }

        [MaxLength(500)]
        public string OtherFaultDetails { get; set; }

        public ICollection<SkillRequiredToFix> SkillsRequiredToFix { get; set; }
    }
}
