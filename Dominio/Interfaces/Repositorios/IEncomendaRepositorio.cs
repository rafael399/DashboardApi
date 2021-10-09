using Dominio.Entidades;
using System.Linq;

namespace Dominio.Interfaces.Repositorios
{
    public interface IEncomendaRepositorio : IRepositorioGenerico<Encomenda, short>
    {
        IQueryable<Encomenda> ObterPorIdPedido(short idPedido);
    }
}
