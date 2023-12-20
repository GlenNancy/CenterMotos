using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CenterMotosApi.DTO;
using CenterMotosApi.DTO.Builder;

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

        public CarrinhoDTO ToCarrinho()
        {
            CarrinhoDTO carrinhoDTO = new CarrinhoDTOBuilder()
            .WithId(Id)
            .WithItensCarrinho(ItensCarrinho)
            .WithNomeCliente(Cliente.Nome)
            .Build();

            return carrinhoDTO;
        }
    }
}
