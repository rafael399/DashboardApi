using Dominio.Entidades;
using System.Linq;

namespace Dominio.Interfaces.Repositorios
{
    public interface IEquipeRepositorio : IRepositorioGenerico<Equipe, short>
    {
        IQueryable<Equipe> ObterPorNome(string nome);
    }
}
