using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class EngineerVisit
    {
        [Key]
        public int EngineerVisitId { get; set; }

        public DateTime VisitStartDateTime { get; set; }
        public DateTime? VisitEndDateTime { get; set; }

        [MaxLength(500)]
        public string OtherVisitDetails { get; set; }

        [Required]
        public int ContactStaffId { get; set; }

        [ForeignKey("ContactStaffId")]
        public Staff ContactStaff { get; set; }

        [Required]
        public int EngineerId { get; set; }

        [ForeignKey("EngineerId")]
        public MaintenanceEngineer Engineer { get; set; }
    }
}
