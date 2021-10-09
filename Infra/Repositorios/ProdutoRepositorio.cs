using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Contextos;

namespace Infra.Repositorios
{
    public class ProdutoRepositorio : RepositorioGenerico<Produto, short>, IProdutoRepositorio
    {
        public ProdutoRepositorio(DashboardContexto context)
            : base(context)
        {
        }
    }
}
