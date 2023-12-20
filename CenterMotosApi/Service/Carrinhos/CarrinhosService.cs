using CenterMotosApi.Models;
using CenterMotosApi.Repositories.Interfaces;
using CenterMotosApi.Repositories.UnitOfWork;
using CenterMotosApi.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using CenterMotosApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CenterMotosApi.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;
        private readonly ICarrinhosRepository _carrinhosRepository;

        public CarrinhoService(DataContext context, ICarrinhosRepository carrinhosRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            _carrinhosRepository = carrinhosRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Carrinho> GetCarrinhoByIdAsync(int id)
        {
            Carrinho carrinho = await _carrinhosRepository.GetCarrinhoByIdAsync(id);

            if (carrinho == null)
            {
                throw new NotFoundException("Carrinho não encontrado");
            }

            return carrinho;
        }

        public async Task<IEnumerable<Carrinho>> GetAllCarrinhoAsync()
        {
            IEnumerable<Carrinho> carrinhos = await _carrinhosRepository.GetAllCarrinhoAsync();

            if (!carrinhos.Any())
            {
                throw new NotFoundException("Nenhum carrinho encontrado.");
            }

            return carrinhos;
        }

        public async Task<Carrinho> CreateCarrinhoAsync(Carrinho carrinho)
        {
            if (carrinho == null)
            {
                throw new NotFoundException("O carrinho não pode ser nulo.");
            }

            // Verificar se o cliente já possui um carrinho
            Carrinho carrinhoExistente = await _context.Carrinhos.FirstOrDefaultAsync(c => c.ClienteId == carrinho.ClienteId);

            if (carrinhoExistente != null)
            {
                throw new NotFoundException("O cliente já possui um carrinho ativo.");
            }

            await _carrinhosRepository.CreateCarrinhoAsync(carrinho);
            await _unitOfWork.SaveChangesAsync();

            return carrinho;
        }

        public async Task<Carrinho> RemoveCarrinho(int id)
        {
            Carrinho carrinhoExistente = await _carrinhosRepository.GetCarrinhoByIdAsync(id);

            if (carrinhoExistente == null)
            {
                throw new NotFoundException("Carrinho não encontrado");
            }

            var clienteComCarrinho = await _context.Clientes.FirstOrDefaultAsync(c => c.CarrinhoId == id);

            if (clienteComCarrinho != null)
            {
                clienteComCarrinho.CarrinhoId = null;
            }

            await _carrinhosRepository.RemoveCarrinho(carrinhoExistente);
            await _unitOfWork.SaveChangesAsync();

            return carrinhoExistente;
        }

    }
}