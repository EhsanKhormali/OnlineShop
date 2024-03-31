using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int Stock { get; set; }
        [Column(TypeName = "decimal(,2)")]
        public decimal Price { get; set; }
    }
}
