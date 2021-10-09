using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class PedidoProduto : Entity<PedidoProduto, short>
    {
        public short IdPedido { get; set; }
        public short IdProduto { get; set; }

        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido { get; set; }
        [ForeignKey("IdProduto")]
        public virtual Produto Produto { get; set; }
    }
}
