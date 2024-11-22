using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class FaultLogPart
    {
        [Required]
        public int FaultLogEntryId { get; set; }

        [ForeignKey("FaultLogEntryId")]
        public FaultLog FaultLog { get; set; }

        [Required]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }

        [Required]
        public int FaultStatusCode { get; set; }

        [ForeignKey("FaultStatusCode")]
        public RefFaultStatus FaultStatus { get; set; }
    }
}
