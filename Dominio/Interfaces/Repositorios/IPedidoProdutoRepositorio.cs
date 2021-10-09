using Dominio.Entidades;
using System.Linq;

namespace Dominio.Interfaces.Repositorios
{
    public interface IPedidoProdutoRepositorio : IRepositorioGenerico<PedidoProduto, short>
    {
        IQueryable<PedidoProduto> ObterPorIdPedidoIdProduto(short idPedido, short idProduto);
    }
}
