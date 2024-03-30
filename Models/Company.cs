using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public DateTime? OperationStartTime { get; set; } = DateTime.MinValue;
        public DateTime? OperationEndTime { get; set; } = DateTime.MinValue;
        public bool IsValid { get; set; }
        public string? Description { get; set; } = null;
        public Company() { }
    }
}
