using CenterMotosApi.DTO.Builder;
using CenterMotosApi.Migrations;
using CenterMotosApi.Models;

namespace CenterMotosApi.DTO
{
    public class ItemCarrinhoDTO
    {
        public int IdItemCarrinho { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
        public int CarrinhoId { get; set; } 
    }
}