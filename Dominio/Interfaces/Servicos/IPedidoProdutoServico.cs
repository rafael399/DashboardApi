using Dominio.Entidades;
using Dominio.ViewModel;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IPedidoProdutoServico
    {
        PedidoProduto CadastrarPedidoProduto(CadastrarPedidoProdutoViewModel model);
        List<PedidoProduto> ListarPedidoProdutos();
        PedidoProduto ObterPedidoProdutoPorId(short idPedidoProduto);
    }
}
