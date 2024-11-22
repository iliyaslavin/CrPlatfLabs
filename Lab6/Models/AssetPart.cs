using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class AssetPart
    {
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        [ForeignKey("Part")]
        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}
