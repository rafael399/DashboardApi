using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dominio.Entidades
{
    public class Pedido : Entity<Pedido, short>
    {
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; }
        public virtual ICollection<Encomenda> Encomendas { get; set; }

        public virtual string DataCriacaoFormatada => DataCriacao.ToString("dd/MM/yyyy");
        public virtual string DataEntregaFormatada => DataEntrega?.ToString("dd/MM/yyyy");

        [NotMapped]
        public virtual List<Produto> Produtos
        {
            get
            {
                if (PedidoProdutos?.Count > 0)
                {
                    return PedidoProdutos.Select(pedidoProduto => pedidoProduto.Produto).ToList();
                }

                return new List<Produto>();
            }
        }

        [NotMapped]
        public virtual Equipe Equipe
        {
            get
            {
                if (Encomendas?.Count > 0)
                {
                    return Encomendas.Select(encomenda => encomenda.Equipe).SingleOrDefault();
                }

                return null;
            }
        }

        [NotMapped]
        public virtual string ListaProdutosFormatada
        {
            get
            {
                if (Produtos?.Count > 0)
                {
                    string listaFormatada = "";

                    for (int index = 0; index < Produtos.Count; index++)
                    {
                        listaFormatada += Produtos[index].Nome;

                        if (index < Produtos.Count - 1)
                            listaFormatada += ", ";
                    }

                    return listaFormatada;
                }

                return "";
            }
        }

        [NotMapped]
        public virtual string TotalDoPedidoFormatado
        {
            get
            {
                float total = 0;

                if (Produtos?.Count > 0)
                {
                    total = Produtos.Select(produto => produto.Valor).Sum();
                }

                return total.ToString("C");
            }
        }
    }
}
