using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Models
{
    [Table("Mecanico")]
    [PrimaryKey(nameof(Id))]
    public class Mecanico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [NotNull]
        public string Nome { get; set; }

        [Required]
        [Column("CPF")]
        [StringLength(11)]
        [NotNull]
        public string Cpf { get; set; }

        [Required]
        [StringLength(30)] 
        [NotNull]
        public string Senha { get; set; }
    }
}
