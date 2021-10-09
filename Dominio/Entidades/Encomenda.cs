using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Encomenda : Entity<Encomenda, short>
    {
        public short IdPedido { get; set; }
        public short IdEquipe { get; set; }

        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido { get; set; }
        [ForeignKey("IdEquipe")]
        public virtual Equipe Equipe { get; set; }
    }
}
