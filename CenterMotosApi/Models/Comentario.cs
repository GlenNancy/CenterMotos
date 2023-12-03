using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using CenterMotosApi.Models;

namespace CenterMotosApi.Models
{
    [Table("Comentario")]
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int Id { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome_Produto { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(255)]
        public string DescricaoComentario { get; set; }
    }
}
