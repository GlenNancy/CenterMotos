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

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [Column("CPF")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF precisa ter 11 dígitos")]
        public string Cpf { get; set; }

        [Required]
        [StringLength(30)]
        public string Senha { get; set; }
        
        [ForeignKey("Carrinho")]
        public int? CarrinhoId { get; set; }

        public Carrinho? Carrinho { get; set; }

        public ICollection<Comentario>? Comentarios { get; set; }
    }
}