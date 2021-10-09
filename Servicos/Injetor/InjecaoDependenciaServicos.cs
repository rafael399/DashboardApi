using Microsoft.Extensions.DependencyInjection;
using Dominio.Interfaces.Servicos;
using Servicos.Servicos;

namespace Servicos.Injetor
{
    public static class InjecaoDependenciaServicos
    {
        public static IServiceCollection AddServicos(this IServiceCollection services)
        {
            services.AddScoped<IEncomendaServico, EncomendaServico>();
            services.AddScoped<IEquipeServico, EquipeServico>();
            services.AddScoped<IPedidoProdutoServico, PedidoProdutoServico>();
            services.AddScoped<IPedidoServico, PedidoServico>();
            services.AddScoped<IProdutoServico, ProdutoServico>();

            return services;
        }
    }
}
