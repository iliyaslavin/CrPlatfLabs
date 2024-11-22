using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AssetName { get; set; }

        [MaxLength(50)]
        public string AssetMake { get; set; }

        [MaxLength(50)]
        public string AssetModel { get; set; }

        public DateTime AssetAcquiredDate { get; set; }

        public DateTime? AssetDisposedDate { get; set; }

        [MaxLength(500)]
        public string OtherAssetDetails { get; set; }

        [Required]
        public int SupplierCompanyId { get; set; }

        [ForeignKey("SupplierCompanyId")]
        public ThirdPartyCompany SupplierCompany { get; set; }

        public int? ParentAssetId { get; set; }

        [ForeignKey("ParentAssetId")]
        public Asset ParentAsset { get; set; }

        public ICollection<AssetPart> AssetParts { get; set; }
        public ICollection<FaultLog> FaultLogs { get; set; }
    }
}
