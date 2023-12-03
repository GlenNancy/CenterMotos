using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CenterMotosApi.Models
{
    [Table("Carrinho")]
    public class Carrinho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public ICollection<ItemCarrinho>? ItensCarrinho { get; set; }
    }
}
