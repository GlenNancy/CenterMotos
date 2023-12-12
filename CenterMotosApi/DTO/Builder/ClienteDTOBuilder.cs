using CenterMotosApi.Models;

namespace CenterMotosApi.DTO.Builder
{
    public class ClienteDTOBuilder
    {
        private ClienteDTO _clienteDTO = new ClienteDTO();

        public ClienteDTOBuilder WithId(int idcliente)
        {
            _clienteDTO.IdCliente = idcliente;
            return this;
        } 

        public ClienteDTOBuilder WithNomeCliente(string nomecliente)
        {
            _clienteDTO.NomeCliente = nomecliente;
            return this;
        }

        public ClienteDTOBuilder WithCarrinhoId(int? carrinhoid)
        {
            _clienteDTO.CarrinhoId = carrinhoid;
            return this;
        }

        public ClienteDTOBuilder WithComentarios(ICollection<Comentario> comentarios)
        {
            _clienteDTO.Comentarios = comentarios;
            return this;
        }

        public ClienteDTO Build()
        {
            return _clienteDTO;
        }
    }
}