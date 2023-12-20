using CenterMotosApi.Models;
using CenterMotosApi.Repositories.Interfaces;
using CenterMotosApi.Repositories.UnitOfWork;
using CenterMotosApi.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using CenterMotosApi.Data;
using Microsoft.EntityFrameworkCore;
using CenterMotosApi.DTO;

namespace CenterMotosApi.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;
        private readonly IClientesRepository _clientesRepository;

        public ClientesService(DataContext context, IClientesRepository clientesRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            _clientesRepository = clientesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            Cliente cliente = await _clientesRepository.GetClienteByIdAsync(id);

            if (cliente == null)
            {
                throw new NotFoundException("Cliente não encontrado");
            }

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteAsync()
        {
            IEnumerable<Cliente> clientes = await _clientesRepository.GetAllClienteAsync();

            if (!clientes.Any())
            {
                throw new NotFoundException("Nenhum cliente encontrado.");
            }

            return clientes;
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            Cliente clienteExistente = await _clientesRepository.GetClienteByCPFAsync(cliente.Cpf);

            if (cliente == null)
            {
                throw new NotFoundException("O cliente enviado é nulo.");
            }

            if (clienteExistente != null)
            {
                throw new NotFoundException("O usuario com este CPF já existe");
            }

            if (cliente.Cpf.Length != 11)
            {
                throw new NotFoundException("O CPF precisa ter 11 caracteres");
            }

            if (cliente.Nome.Length <= 2)
            {
                throw new NotFoundException("O nome deve ter no mínimo 3 caracteres.");
            }

            if (await _context.Clientes.AnyAsync(p => p.Nome == cliente.Nome))
            {
                throw new NotFoundException("O usuario com este Nome já existe");
            }

            if (cliente.Senha.Length < 6)
            {
                throw new NotFoundException("A senha deve ter pelo menos 6 caracteres");
            }

            if (!cliente.Senha.Any(char.IsDigit))
            {
                throw new NotFoundException("A senha deve conter pelo menos um número");
            }

            if (!cliente.Senha.Any(char.IsLetter))
            {
                throw new NotFoundException("A senha deve conter pelo menos uma letra");
            }

            await _clientesRepository.CreateClienteAsync(cliente);
            await _unitOfWork.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(int id, Cliente cliente)
        {
            Cliente clienteExistente = await _clientesRepository.GetClienteByIdAsync(id);

            if (clienteExistente == null)
            {
                throw new NotFoundException("Cliente não encontrado");
            }

            if (cliente == null)
            {
                throw new NotFoundException("O objeto de cliente é nulo.");
            }

            clienteExistente.Nome = cliente.Nome;

            // Atualizar o nome em todos os comentários associados ao cliente
            List<Comentario> lista = await _context.Comentarios
                .Where(c => c.ClienteId == id)
                .ToListAsync();

            foreach (var comentario in lista)
            {
                comentario.Nome = cliente.Nome;
            }

            await _unitOfWork.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> UpdatePasswordClienteAsync(int id, Cliente cliente)
        {
            Cliente clienteExistente = await _clientesRepository.GetClienteByIdAsync(id);

            if (clienteExistente == null)
            {
                throw new NotFoundException("Cliente não encontrado");
            }

            if (clienteExistente.Senha == cliente.Senha)
            {
                throw new Exception("A senha não pode ser igual a senha atual");
            }

            clienteExistente.Senha = cliente.Senha;

            await _unitOfWork.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> RemoveCliente(int id)
        {
            Cliente clienteExistente = await _clientesRepository.GetClienteByIdAsync(id);

            if (clienteExistente == null)
            {
                throw new NotFoundException("Cliente não encontrado");
            }

            await _clientesRepository.RemoveCliente(clienteExistente);
            await _unitOfWork.SaveChangesAsync();

            return clienteExistente;
        }
    }
}