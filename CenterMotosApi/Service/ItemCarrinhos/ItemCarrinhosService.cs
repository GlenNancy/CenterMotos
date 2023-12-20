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
    public class ItemCarrinhosService : IItemCarrinhosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;
        private readonly IItemCarrinhosRepository _itemCarrinhosRepository;
        //private readonly IProdutosRepository _protudosRepository;

        public ItemCarrinhosService(DataContext context, IItemCarrinhosRepository itemCarrinhosRepository, IUnitOfWork unitOfWork/*,IProdutosRepository produtosRepository*/)
        {
            _context = context;
            _itemCarrinhosRepository = itemCarrinhosRepository;
            _unitOfWork = unitOfWork;
            //_produtosRepository = produtosRepository;
        }

        public async Task<ItemCarrinho> GetItemCarrinhoByIdAsync(int id)
        {
            ItemCarrinho itemCarrinho = await _itemCarrinhosRepository.GetItemCarrinhoByIdAsync(id);

            if (itemCarrinho == null)
            {
                throw new NotFoundException("Item não encontrado");
            }

            return itemCarrinho;
        }
        public async Task<IEnumerable<ItemCarrinho>> GetAllItemCarrinhoAsync()
        {
            IEnumerable<ItemCarrinho> itemCarrinho = await _itemCarrinhosRepository.GetAllItemCarrinhoAsync();

            if (!itemCarrinho.Any())
            {
                throw new NotFoundException("Nenhum Item encontrado.");
            }

            return itemCarrinho;
        }

        public async Task<ItemCarrinho> CreateItemCarrinhoAsync(ItemCarrinho itemCarrinho)
        {
            Produto produto = await _context.Produtos.FindAsync(itemCarrinho.ProdutoId);

            if (itemCarrinho == null)
            {
                throw new NotFoundException("O item não pode ser nulo.");
            }

            if (itemCarrinho.Quantidade <= 0)
            {
                throw new NotFoundException("Deve ser especificada a quantidade.");
            }

            if (produto == null)
            {
                throw new NotFoundException("Produto não encontrado");
            }

            itemCarrinho.PrecoUnitario = produto.Preco;

            await _itemCarrinhosRepository.CreateItemCarrinhoAsync(itemCarrinho);
            await _unitOfWork.SaveChangesAsync();

            return itemCarrinho;
        }

        public async Task<ItemCarrinho> RemoveItemCarrinho(int id)
        {
            ItemCarrinho itemCarrinhoExistente = await _itemCarrinhosRepository.GetItemCarrinhoByIdAsync(id);

            if (itemCarrinhoExistente == null)
            {
                throw new NotFoundException("Produto não encontrado");
            }

            await _itemCarrinhosRepository.RemoveItemCarrinho(itemCarrinhoExistente);
            await _unitOfWork.SaveChangesAsync();

            return itemCarrinhoExistente;
        }
    }
}