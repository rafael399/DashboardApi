using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Equipe : Entity<Equipe, short>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PlacaVeiculo { get; set; }

        public virtual ICollection<Encomenda> Encomendas { get; set; }
    }
}
