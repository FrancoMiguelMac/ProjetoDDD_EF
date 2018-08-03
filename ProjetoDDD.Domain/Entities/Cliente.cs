using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public virtual ICollection<Produto> Produtos { get; private set; }

        /// <summary>
        /// Instance of the object.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cpf"></param>
        public Cliente(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataCadastro = DateTime.Now;
        }

        public Cliente()
        {

        }

        public void RemoveAllProdutos()
        {
            var produtos = this.Produtos.ToList();

            foreach (var produto in produtos)
            {
                this.Produtos.Remove(produto);
            }
        }

        public void AddProduto(Produto produto)
        {
            if (this.Produtos.Any(p => p.Nome == produto.Nome))
                throw new ArgumentException("Esse produto já foi cadastrado para esse cliente.");

            this.Produtos.Add(produto);
        }
    }
}
