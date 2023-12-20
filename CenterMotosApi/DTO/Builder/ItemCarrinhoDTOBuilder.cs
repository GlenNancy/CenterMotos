using CenterMotosApi.Models;

namespace CenterMotosApi.DTO.Builder
{
    public class ItemCarrinhoDTOBuilder
    {
        private ItemCarrinhoDTO _itemCarrinhoDTO = new ItemCarrinhoDTO();

        public ItemCarrinhoDTOBuilder WithIdItemCarrinho(int idItemCarrinho)
        {
            _itemCarrinhoDTO.IdItemCarrinho = idItemCarrinho;
            return this;
        }

        public ItemCarrinhoDTOBuilder WithIdProduto(int idproduto)
        {
            _itemCarrinhoDTO.ProdutoId = idproduto;
            return this;
        }

        public ItemCarrinhoDTOBuilder WithNomeProduto(string nomeProduto)
        {
            _itemCarrinhoDTO.NomeProduto = nomeProduto;
            return this;
        }

        public ItemCarrinhoDTOBuilder WithQuantidade(int quantidade)
        {
            _itemCarrinhoDTO.Quantidade = quantidade;
            return this;
        }

        public ItemCarrinhoDTOBuilder WithPrecoUnitario(decimal precoUnitario)
        {
            _itemCarrinhoDTO.PrecoUnitario = precoUnitario;
            return this;
        }

        public ItemCarrinhoDTOBuilder WithPrecoTotal(decimal precoTotal)
        {
            _itemCarrinhoDTO.PrecoTotal = precoTotal;
            return this;
        }

        public ItemCarrinhoDTOBuilder WithIdCarrinho(int idCarinho)
        {
            _itemCarrinhoDTO.CarrinhoId = idCarinho;
            return this;
        }

        public ItemCarrinhoDTO Build()
        {
            return _itemCarrinhoDTO;
        }
    }
}