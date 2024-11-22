using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PartName { get; set; }

        public bool ChargeableYn { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ChargeableAmount { get; set; }

        [MaxLength(500)]
        public string OtherPartDetails { get; set; }

        public ICollection<AssetPart> AssetParts { get; set; }
        public ICollection<FaultLogPart> FaultLogParts { get; set; }

    }
}
