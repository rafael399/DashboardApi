using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Contextos;
using System.Linq;

namespace Infra.Repositorios
{
    public class PedidoRepositorio : RepositorioGenerico<Pedido, short>, IPedidoRepositorio
    {
        public PedidoRepositorio(DashboardContexto context)
            : base(context)
        { }

        public IQueryable<Pedido> ObterPedidosOrdenadoPorDataCriacao()
        {
            return DbSet.OrderBy(pedido => pedido.DataCriacao);
        }
    }
}
