using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.DTOs
{
    public class PedidoDTO
    {
        public short Id { get; set; }
        public string Endereco { get; set; }
        public List<Produto> Produtos { get; set; }
        public EquipeDTO Equipe { get; set; }
        public string DataCriacaoFormatada { get; set; }
        public string DataEntregaFormatada { get; set; }
        public string ListaProdutosFormatada { get; set; }
        public string TotalDoPedidoFormatado { get; set; }
    }
}
