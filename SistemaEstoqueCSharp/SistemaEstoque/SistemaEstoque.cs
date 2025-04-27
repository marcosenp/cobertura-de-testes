using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEstoque
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
    }

    public class SistemaEstoque
    {
        private List<Produto> produtos = new List<Produto>();

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }

        public bool RemoverProduto(string nome)
        {
            var produto = produtos.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if (produto != null)
            {
                produtos.Remove(produto);
                return true;
            }
            return false;
        }

        public Produto BuscarProdutoPorNome(string nome)
        {
            return produtos.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        public double CalcularValorTotalEstoque()
        {
            return produtos.Sum(p => p.Preco * p.Quantidade);
        }

        public List<Produto> ListarProdutos()
        {
            return new List<Produto>(produtos);
        }
    }
}
