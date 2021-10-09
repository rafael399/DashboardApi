using Dominio.Entidades;
using System.Linq;

namespace Dominio.Interfaces.Repositorios
{
    public interface IPedidoRepositorio : IRepositorioGenerico<Pedido, short>
    {
        IQueryable<Pedido> ObterPedidosOrdenadoPorDataCriacao();
    }
}
