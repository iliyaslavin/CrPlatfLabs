using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class RefCompanyType
    {
        [Key]
        public int CompanyTypeCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public ICollection<ThirdPartyCompany> ThirdPartyCompanies { get; set; }
    }
}
