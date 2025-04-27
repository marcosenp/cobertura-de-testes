using Xunit;
using SistemaEstoque;
using System.Linq;

namespace SistemaEstoque.Tests
{
    public class SistemaEstoqueTests
    {
        [Fact]
        public void AdicionarProduto_DeveAdicionarCorretamente()
        {
            var estoque = new SistemaEstoque();
            var produto = new Produto("Mouse", 100.0, 10);

            estoque.AdicionarProduto(produto);

            var resultado = estoque.ListarProdutos();
            Assert.Single(resultado);
            Assert.Equal("Mouse", resultado[0].Nome);
        }

        [Fact]
        public void RemoverProduto_DeveRemoverProdutoExistente()
        {
            var estoque = new SistemaEstoque();
            estoque.AdicionarProduto(new Produto("Teclado", 150.0, 5));

            var resultado = estoque.RemoverProduto("Teclado");

            Assert.True(resultado);
            Assert.Empty(estoque.ListarProdutos());
        }

        [Fact]
        public void RemoverProduto_DeveRetornarFalsoParaProdutoInexistente()
        {
            var estoque = new SistemaEstoque();

            var resultado = estoque.RemoverProduto("Monitor");

            Assert.False(resultado);
        }

        [Fact]
        public void BuscarProdutoPorNome_DeveEncontrarProduto()
        {
            var estoque = new SistemaEstoque();
            estoque.AdicionarProduto(new Produto("Monitor", 500.0, 2));

            var produto = estoque.BuscarProdutoPorNome("Monitor");

            Assert.NotNull(produto);
            Assert.Equal(500.0, produto.Preco);
        }

        [Fact]
        public void CalcularValorTotalEstoque_DeveCalcularCorretamente()
        {
            var estoque = new SistemaEstoque();
            estoque.AdicionarProduto(new Produto("Notebook", 3000.0, 1));
            estoque.AdicionarProduto(new Produto("Headset", 200.0, 2));

            var total = estoque.CalcularValorTotalEstoque();

            Assert.Equal(3400.0, total);
        }
    }
}
