using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class MaintenanceEngineer
    {
        [Key]
        public int EngineerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string OtherDetails { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public ThirdPartyCompany Company { get; set; }

        public ICollection<EngineerSkill> EngineerSkills { get; set; }
    }
}
