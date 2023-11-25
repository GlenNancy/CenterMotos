using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Models
{
    [Table("Cliente")]
    [PrimaryKey(nameof(Id))]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int Id { get; set; }

        [ForeignKey("Comentario")]
        public int? ComentarioId { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required]
        [Column("CPF")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [ForeignKey("Carrinho")]
        public int? CarrinhoId { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}