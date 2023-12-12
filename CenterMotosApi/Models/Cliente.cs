using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using CenterMotosApi.DTO;
using CenterMotosApi.DTO.Builder;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public ClienteDTO ToCliente()
        {
            ClienteDTO clienteDTO = new ClienteDTOBuilder()
            .WithId(Id)
            .WithNomeCliente(Nome)
            .WithCarrinhoId(CarrinhoId)
            .WithComentarios(Comentarios)
            .Build();

            return clienteDTO;
        }
    }
}