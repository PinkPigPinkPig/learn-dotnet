using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_model.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }
        [StringLength(100)]
        public string Name { set; get; }
        [Column(TypeName = "ntext")]
        public string Description { set; get; }
    }
}