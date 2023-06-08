using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ef_model.Models;

namespace ef.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column("Tensanpham",TypeName = "ntext")]
        public string Name { get; set; }

        [Column("Giasanpham",TypeName = "money")]
        public decimal Price { get; set; }

        public int CateId { get; set; }

        [ForeignKey("CateId")]
        public virtual Category Category { get; set; } // Foreign Key

        // public int? CateI2 { get; set; }
        // [ForeignKey("CateId2")]
        // [InverseProperty("Products")]
        // public virtual Category Category2 { get; set; } // Foreign Key

        public void PrintInfo() => Console.WriteLine($"{ProductId} - {Name} - {Price} - {CateId}");
    }
}