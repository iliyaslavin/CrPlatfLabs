using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class FaultLog
    {
        [Key]
        public int FaultLogEntryId { get; set; }

        [Required]
        [MaxLength(500)]
        public string FaultDescription { get; set; }

        [Required]
        public DateTime RecordedDate { get; set; }

        [Required]
        public int AssetId { get; set; }

        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }

        [Required]
        public int RecordedByStaffId { get; set; }

        [ForeignKey("RecordedByStaffId")]
        public Staff RecordedByStaff { get; set; }

        public ICollection<FaultLogPart> FaultLogParts { get; set; }
    }
}
