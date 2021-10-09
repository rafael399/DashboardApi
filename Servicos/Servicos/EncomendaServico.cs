using Dominio.DTOs;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicos.Servicos
{
    public class EncomendaServico : IEncomendaServico
    {
        private readonly IEncomendaRepositorio _encomendaRepositorio;
        private readonly IEquipeRepositorio _equipeRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IPedidoProdutoRepositorio _pedidoProdutoRepositorio;

        public EncomendaServico(
            IEncomendaRepositorio encomendaRepositorio,
            IEquipeRepositorio equipeRepositorio,
            IProdutoRepositorio produtoRepositorio,
            IPedidoRepositorio pedidoRepositorio,
            IPedidoProdutoRepositorio pedidoProdutoRepositorio
            )
        {
            _encomendaRepositorio = encomendaRepositorio;
            _equipeRepositorio = equipeRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
            _pedidoProdutoRepositorio = pedidoProdutoRepositorio;
        }

        public EncomendaDTO CadastrarEncomenda(CadastrarEncomendaViewModel model)
        {
            try
            {
                if (model.IdProdutos.Count <= 0)
                    throw new ArgumentException("Por favor, informe os IDs dos produtos");

                Equipe equipe = _equipeRepositorio.ObterPorId(model.IdEquipe);

                if (equipe == null)
                    throw new ArgumentException("Equipe não encontrada com ID informado");

                List<short> idsValidos = _produtoRepositorio.ObterTodos().Select(x => x.Id).ToList();
                bool produtosExistem = model.IdProdutos.All(x => idsValidos.Contains(x));

                if (!produtosExistem)
                    throw new ArgumentException("Nem todos os IDs de produtos informados são válidos");

                Pedido pedido = new()
                {
                    DataCriacao = DateTime.Now,
                    Endereco = model.Endereço
                };
                _pedidoRepositorio.Add(pedido);
                _pedidoRepositorio.Commit();

                foreach(short idProduto in model.IdProdutos)
                {
                    PedidoProduto pedidoProduto = new()
                    {
                        IdPedido = pedido.Id,
                        IdProduto = idProduto
                    };
                    _pedidoProdutoRepositorio.Add(pedidoProduto);
                }
                _pedidoProdutoRepositorio.Commit();

                Encomenda encomenda = new()
                {
                    IdPedido = pedido.Id,
                    IdEquipe = model.IdEquipe,
                };
                _encomendaRepositorio.Add(encomenda);
                _encomendaRepositorio.Commit();

                EncomendaDTO retorno = new()
                {
                    Id = encomenda.Id,
                    IdEquipe = encomenda.IdEquipe,
                    IdPedido = encomenda.IdPedido
                };

                return retorno;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public List<Encomenda> ListarEncomendas()
        {
            try
            {
                return _encomendaRepositorio.ObterTodos().ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public Encomenda ObterEncomendaPorId(short idEncomenda)
        {
            try
            {
                return _encomendaRepositorio.ObterPorId(idEncomenda);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }
    }
}
