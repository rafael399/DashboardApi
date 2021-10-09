using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicos.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto CadastrarProduto(CadastrarProdutoViewModel model)
        {
            try
            {
                Produto novoProduto = new()
                {
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    Valor = model.Valor
                };

                _produtoRepositorio.Add(novoProduto);
                _produtoRepositorio.Commit();

                return novoProduto;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public List<Produto> ListarProdutos()
        {
            try
            {
                return _produtoRepositorio.ObterTodos().ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public Produto ObterProdutoPorId(short idProduto)
        {
            try
            {
                return _produtoRepositorio.ObterPorId(idProduto);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }
    }
}
