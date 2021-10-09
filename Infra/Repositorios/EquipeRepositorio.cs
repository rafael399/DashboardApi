using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Contextos;
using System.Linq;

namespace Infra.Repositorios
{
    public class EquipeRepositorio : RepositorioGenerico<Equipe, short>, IEquipeRepositorio
    {
        public EquipeRepositorio(DashboardContexto context)
            : base(context)
        {
        }

        public IQueryable<Equipe> ObterPorNome(string nome)
        {
            return DbSet.Where(equipe => equipe.Nome == nome);
        }
    }
}
