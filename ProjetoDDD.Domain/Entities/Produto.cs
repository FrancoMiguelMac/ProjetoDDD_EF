using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public int ClienteId { get; private set; }

        public virtual Cliente Cliente { get; set; }

        /// <summary>
        /// Instance of the object.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="valor"></param>
        /// <param name="clienteId"></param>
        public Produto(string nome, decimal valor, int clienteId)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.ClienteId = clienteId;
        }

        public Produto()
        {

        }
    }
}
