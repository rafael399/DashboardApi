using Api.Autorizacao;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/produto"), ApiController, Autorizacao]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        [HttpPost]
        public IActionResult CadastrarProduto(CadastrarProdutoViewModel model)
        {
            try
            {
                Produto produtoCadastrado = _produtoServico.CadastrarProduto(model);

                return Ok(produtoCadastrado);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult ListarProdutos()
        {
            try
            {
                List<Produto> produtos = _produtoServico.ListarProdutos();

                return Ok(produtos);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("{idProduto}")]
        public IActionResult ObterProduto(short idProduto)
        {
            try
            {
                Produto produto = _produtoServico.ObterProdutoPorId(idProduto);

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
