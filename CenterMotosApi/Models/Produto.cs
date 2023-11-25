using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Models
{
    [Table("Produto")]
    [PrimaryKey(nameof(Id))]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [Column("Nome_Produto")]
        public string Nome { get; set; }

        [Column("Foto_Produto")]
        public string? Foto { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Descricao_Produto")]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
