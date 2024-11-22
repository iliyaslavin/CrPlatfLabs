using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public class MaintenanceContract
    {
        [Key]
        public int MaintenanceContractId { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [MaxLength(500)]
        public string OtherContractDetails { get; set; }

        [Required]
        public int MaintenanceContractCompanyId { get; set; }

        [ForeignKey("MaintenanceContractCompanyId")]
        public ThirdPartyCompany MaintenanceContractCompany { get; set; }
    }
}
