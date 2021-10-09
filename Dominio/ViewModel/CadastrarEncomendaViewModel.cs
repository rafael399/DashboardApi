using System.Collections.Generic;

namespace Dominio.ViewModel
{
    public class CadastrarEncomendaViewModel
    {
        public short IdEquipe { get; set; }
        public List<short> IdProdutos { get; set; }
        public string Endereço { get; set; }
    }
}
