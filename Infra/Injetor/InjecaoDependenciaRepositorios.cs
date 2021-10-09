using Infra.Contextos;
using Microsoft.Extensions.DependencyInjection;
using Dominio.Interfaces.Repositorios;
using Infra.Repositorios;

namespace Infra.Injetor
{
    public static class InjecaoDependenciaRepositorios
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            services.AddDbContext<DashboardContexto>();

            //Repositorios
            services.AddScoped<IEncomendaRepositorio, EncomendaRepositorio>();
            services.AddScoped<IEquipeRepositorio, EquipeRepositorio>();
            services.AddScoped<IPedidoProdutoRepositorio, PedidoProdutoRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            return services;
        }
    }
}
