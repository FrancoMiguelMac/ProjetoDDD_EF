using System.Collections.Generic;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;

namespace ProjetoDDD.Application
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IClienteRepository clienteRepository;

        public ProdutoAppService(IProdutoRepository produtoRepository, IClienteRepository clienteRepository)
        {
            this.produtoRepository = produtoRepository;
            this.clienteRepository = clienteRepository;
        }

        public void Add(Produto produto)
        {
            try
            {
                var cliente = clienteRepository.GetById(produto.ClienteId);
                cliente.AddProduto(produto);
                clienteRepository.Update(cliente);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Produto> GetAllByClienteId(int clienteId)
        {
            return produtoRepository.GetAllByClienteId(clienteId);
        }

        public Produto GetById(int id)
        {
            return produtoRepository.GetById(id);
        }

        public void Update(Produto produto)
        {
            try
            {
                produtoRepository.Update(produto);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(Produto produto)
        {
            try
            {
                produtoRepository.Remove(produto);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
