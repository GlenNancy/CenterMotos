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
    public class ProdutosService : IProdutosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosService(DataContext context, IProdutosRepository produtosRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            _produtosRepository = produtosRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            Produto produto = await _produtosRepository.GetProdutoByIdAsync(id);

            if (produto == null)
            {
                throw new NotFoundException("Produto não encontrado");
            }

            return produto;
        }

        public async Task<IEnumerable<Produto>> GetAllProdutoAsync()
        {
            IEnumerable<Produto> produtos = await _produtosRepository.GetAllProdutoAsync();

            if (!produtos.Any())
            {
                throw new NotFoundException("Nenhum produto encontrado.");
            }

            return produtos;
        }

        public async Task<Produto> CreateProdutoAsync(Produto produto)
        {
            if (produto == null)
            {
                throw new NotFoundException("O objeto de produto enviado é nulo.");
            }

            if (string.IsNullOrEmpty(produto.Nome) || produto.Nome.Length > 40)
            {
                throw new NotFoundException("O campo Nome deve ter entre 1 e 40 caracteres.");
            }

            if (string.IsNullOrEmpty(produto.Descricao) || produto.Descricao.Length > 255)
            {
                throw new NotFoundException("O campo Descrição deve ter entre 1 e 255 caracteres.");
            }

            if (produto.Preco <= 0)
            {
                throw new NotFoundException("O campo Preço deve ser maior que zero.");
            }

            await _produtosRepository.CreateProdutoAsync(produto);
            await _unitOfWork.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> UpdateProdutoAsync(int id, Produto produto)
        {
            Produto produtoExistente = await _produtosRepository.GetProdutoByIdAsync(id);

            if (produtoExistente == null)
            {
                throw new NotFoundException("Produto não encontrado");
            }

            if (produto == null)
            {
                throw new NotFoundException("O objeto de produto atualizado é nulo.");
            }

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Preco = produto.Preco;

            await _unitOfWork.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> RemoveProduto(int id)
        {
            Produto produtoExistente = await _produtosRepository.GetProdutoByIdAsync(id);

            if (produtoExistente == null)
            {
                throw new NotFoundException("Produto não encontrado");
            }

            await _produtosRepository.RemoveProduto(produtoExistente);
            await _unitOfWork.SaveChangesAsync();

            return produtoExistente;
        }
    }
}