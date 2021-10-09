using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Contextos;
using System.Linq;

namespace Infra.Repositorios
{
    public class PedidoProdutoRepositorio : RepositorioGenerico<PedidoProduto, short>, IPedidoProdutoRepositorio
    {
        public PedidoProdutoRepositorio(DashboardContexto context)
            : base(context)
        {
        }

        public IQueryable<PedidoProduto> ObterPorIdPedidoIdProduto(short idPedido, short idProduto)
        {
            return DbSet.Where(pedidoProduto => pedidoProduto.IdPedido == idPedido && pedidoProduto.IdProduto == idProduto);
        }
    }
}
