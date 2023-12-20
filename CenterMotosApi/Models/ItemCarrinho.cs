using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using CenterMotosApi.DTO;
using CenterMotosApi.DTO.Builder;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Models
{
    [Table("ItemCarrinho")]
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

        public ItemCarrinhoDTO ToItemCarrinho()
        {
            string nomeProduto = Produto != null ? Produto.Nome : "Nome Desconhecido"; //criado para não precisar adicionar um novo atributo

            ItemCarrinhoDTO itemCarrinhoDTO = new ItemCarrinhoDTOBuilder()
                .WithIdItemCarrinho(Id)
                .WithIdProduto(ProdutoId)
                .WithNomeProduto(nomeProduto)
                .WithQuantidade(Quantidade)
                .WithPrecoUnitario(PrecoUnitario)
                .WithPrecoTotal(PrecoUnitario * Quantidade)
                .WithIdCarrinho(CarrinhoId)
                .Build();

            return itemCarrinhoDTO;
        }
    }
}