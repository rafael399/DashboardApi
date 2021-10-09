using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicos.Servicos
{
    public class PedidoProdutoServico : IPedidoProdutoServico
    {
        private readonly IPedidoProdutoRepositorio _pedidoProdutoRepositorio;

        public PedidoProdutoServico(IPedidoProdutoRepositorio pedidoProdutoRepositorio)
        {
            _pedidoProdutoRepositorio = pedidoProdutoRepositorio;
        }

        public PedidoProduto CadastrarPedidoProduto(CadastrarPedidoProdutoViewModel model)
        {
            try
            {
                PedidoProduto pedidoProdutoExistente = _pedidoProdutoRepositorio.ObterPorIdPedidoIdProduto(model.IdPedido, model.IdProduto).FirstOrDefault();

                if (pedidoProdutoExistente != null)
                    throw new ArgumentException("Este produto já foi cadastrado no pedido informado");

                PedidoProduto novoPedidoProduto = new()
                {
                    IdPedido = model.IdPedido,
                    IdProduto = model.IdProduto
                };

                _pedidoProdutoRepositorio.Add(novoPedidoProduto);
                _pedidoProdutoRepositorio.Commit();

                return novoPedidoProduto;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public List<PedidoProduto> ListarPedidoProdutos()
        {
            try
            {
                return _pedidoProdutoRepositorio.ObterTodos().ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public PedidoProduto ObterPedidoProdutoPorId(short idEquipe)
        {
            try
            {
                return _pedidoProdutoRepositorio.ObterPorId(idEquipe);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }
    }
}
