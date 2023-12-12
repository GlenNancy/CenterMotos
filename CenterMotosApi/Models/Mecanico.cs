using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using CenterMotosApi.DTO;
using CenterMotosApi.DTO.Builder;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Models
{
    [Table("Mecanico")]
    public class Mecanico
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
        public string Cpf { get; set; }

        [Required]
        [StringLength(30)] 
        public string Senha { get; set; }

        public MecanicoDTO ToMecanico()
        {
            MecanicoDTO mecanicoDTO = new MecanicoDTOBuilder()
            .WithId(Id)
            .WithNomeMecanico(Nome)
            .Build();

            return mecanicoDTO;
        }
    }
}
