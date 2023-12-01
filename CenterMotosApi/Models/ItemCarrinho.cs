using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Models
{
    [Table("ItemCarrinho")]
    [PrimaryKey(nameof(Id))]
    public class ItemCarrinho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto? Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }

        [Required]
        [ForeignKey("Carrinho")]
        public int CarrinhoId { get; set; }
    }
}