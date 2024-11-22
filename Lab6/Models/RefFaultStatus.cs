using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefFaultStatus
    {
        [Key]
        public int FaultStatusCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string FaultStatusDescription { get; set; }

        public ICollection<FaultLogPart> FaultLogParts { get; set; }
    }
}
