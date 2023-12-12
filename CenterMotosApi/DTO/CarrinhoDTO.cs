using CenterMotosApi.DTO.Builder;
using CenterMotosApi.Migrations;
using CenterMotosApi.Models;

namespace CenterMotosApi.DTO
{
    public class CarrinhoDTO
    {
        public int IdCarrinho {  get; set; }
        public string NomeCliente { get; set; }
        public ICollection<ItemCarrinho>? ItemCarrinhos {get; set; }
    }
}