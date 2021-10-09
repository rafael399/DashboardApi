using Dominio.DTOs;
using Dominio.ViewModel;

namespace Dominio.Interfaces.Servicos
{
    public interface IPedidoServico
    {
        ObterPedidosViewModel ListarPedidos(short pagina, short quantidadePorPagina);
        PedidoDTO AtualizarParaEntregue(short idPedido);
    }
}
