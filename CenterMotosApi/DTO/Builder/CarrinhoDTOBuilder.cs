using CenterMotosApi.Models;

namespace CenterMotosApi.DTO.Builder
{
    public class CarrinhoDTOBuilder
    {
        private CarrinhoDTO _carrinhoDTO = new CarrinhoDTO();

        public CarrinhoDTOBuilder WithId(int idcarrinho)
        {
            _carrinhoDTO.IdCarrinho = idcarrinho;
            return this;
        } 

        public CarrinhoDTOBuilder WithNomeCliente(string nomecliente)
        {
            _carrinhoDTO.NomeCliente = nomecliente;
            return this;
        }

        public CarrinhoDTOBuilder WithItensCarrinho(ICollection<ItemCarrinho> itemcarrinho)
        {
            _carrinhoDTO.ItemCarrinhos = itemcarrinho;
            return this;
        }

         public CarrinhoDTO Build()
        {
            return _carrinhoDTO;
        }

    }
}