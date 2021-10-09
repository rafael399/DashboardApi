using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Contextos;
using System.Linq;

namespace Infra.Repositorios
{
    public class EncomendaRepositorio : RepositorioGenerico<Encomenda, short>, IEncomendaRepositorio
    {
        public EncomendaRepositorio(DashboardContexto context)
            : base(context)
        {
        }

        public IQueryable<Encomenda> ObterPorIdPedido(short idPedido)
        {
            return DbSet.Where(encomenda => encomenda.IdPedido == idPedido);
        }
    }
}
