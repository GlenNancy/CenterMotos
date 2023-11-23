using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Models
{
    [Table("Comentario")]
    [PrimaryKey(nameof(Id))]
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int Id { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required]
        [StringLength(20)]
        [NotNull]
        public string Nome { get; set; }

        [Required]
        [MaxLength(255)]
        [NotNull]
        public string DescricaoComentario { get; set; }
    }
}