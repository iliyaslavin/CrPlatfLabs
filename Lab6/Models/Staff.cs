using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        [MaxLength(100)]
        public string StaffName { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(500)]
        public string OtherStaffDetails { get; set; }

        public ICollection<FaultLog> FaultLogs { get; set; }
    }
}
