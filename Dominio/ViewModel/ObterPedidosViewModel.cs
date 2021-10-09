using Dominio.DTOs;
using System.Collections.Generic;

namespace Dominio.ViewModel
{
    public class ObterPedidosViewModel
    {
        public int QuantidadeDePedidos { get; set; }
        public List<PedidoDTO> Pedidos { get; set; }
    }
}
