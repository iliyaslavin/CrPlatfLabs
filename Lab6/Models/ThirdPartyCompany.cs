using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class ThirdPartyCompany
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(200)]
        public string CompanyAddress { get; set; }

        [MaxLength(500)]
        public string OtherCompanyDetails { get; set; }

        [Required]
        public int CompanyTypeCode { get; set; }

        [ForeignKey("CompanyTypeCode")]
        public RefCompanyType CompanyType { get; set; }


        public ICollection<MaintenanceContract> MaintenanceContracts { get; set; }
        public ICollection<Asset> Assets { get; set; }
        public ICollection<MaintenanceEngineer> MaintenanceEngineers { get; set; }

    }
}
