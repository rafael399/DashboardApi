using Dominio.DTOs;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using System;
using System.Linq;

namespace Servicos.Servicos
{
    public class PedidoServico : IPedidoServico
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoServico(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public ObterPedidosViewModel ListarPedidos(short pagina, short quantidadePorPagina)
        {
            try
            {
                pagina = pagina > 0 ? pagina : (short)1;
                quantidadePorPagina = quantidadePorPagina > 0 ? quantidadePorPagina : (short)20;
                int skip = (pagina - 1) * quantidadePorPagina;

                IQueryable<Pedido> pedidos = _pedidoRepositorio.ObterPedidosOrdenadoPorDataCriacao();
                IQueryable<Pedido> pedidosFiltrados = pedidos.Skip(skip).Take(quantidadePorPagina);

                ObterPedidosViewModel retorno = new()
                {
                    QuantidadeDePedidos = pedidos.Count(),
                    Pedidos = pedidosFiltrados.Select(pedido => new PedidoDTO()
                    {
                        Id = pedido.Id,
                        Endereco = pedido.Endereco,
                        Produtos = pedido.Produtos,
                        Equipe = pedido.Equipe == null ? null : new EquipeDTO() {
                            Nome = pedido.Equipe.Nome,
                            Descricao = pedido.Equipe.Descricao,
                            PlacaVeiculo = pedido.Equipe.PlacaVeiculo
                        },
                        DataCriacaoFormatada = pedido.DataCriacaoFormatada,
                        DataEntregaFormatada = pedido.DataEntregaFormatada,
                        ListaProdutosFormatada = pedido.ListaProdutosFormatada,
                        TotalDoPedidoFormatado = pedido.TotalDoPedidoFormatado
                    }).ToList()
                };

                return retorno;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public PedidoDTO AtualizarParaEntregue(short idPedido)
        {
            try
            {
                Pedido pedido = _pedidoRepositorio.ObterPorId(idPedido);

                if (pedido == null)
                    throw new ArgumentException("Pedido não encontrado com ID informado.");

                if (pedido.DataEntrega != null)
                    throw new ArgumentException("O pedido informado já foi entregue.");

                pedido.DataEntrega = DateTime.Now;
                _pedidoRepositorio.Commit();

                PedidoDTO retorno = new()
                {
                    Endereco = pedido.Endereco,
                    Produtos = pedido.Produtos,
                    Equipe = pedido.Equipe == null ? null : new EquipeDTO()
                    {
                        Nome = pedido.Equipe.Nome,
                        Descricao = pedido.Equipe.Descricao,
                        PlacaVeiculo = pedido.Equipe.PlacaVeiculo
                    },
                    DataCriacaoFormatada = pedido.DataCriacaoFormatada,
                    DataEntregaFormatada = pedido.DataEntregaFormatada
                };

                return retorno;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }
    }
}
