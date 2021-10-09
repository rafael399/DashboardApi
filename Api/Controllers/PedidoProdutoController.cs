using Api.Autorizacao;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/pedidoProduto"), ApiController, Autorizacao]
    public class PedidoProdutoController : ControllerBase
    {
        private readonly IPedidoProdutoServico _pedidoProdutoServico;

        public PedidoProdutoController(IPedidoProdutoServico pedidoProdutoServico)
        {
            _pedidoProdutoServico = pedidoProdutoServico;
        }

        [HttpPost]
        public IActionResult CadastrarPedidoProduto(CadastrarPedidoProdutoViewModel model)
        {
            try
            {
                PedidoProduto pedidoProdutoCadastrado = _pedidoProdutoServico.CadastrarPedidoProduto(model);

                return Ok(pedidoProdutoCadastrado);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult ListarPedidoProduto()
        {
            try
            {
                List<PedidoProduto> pedidoProdutos = _pedidoProdutoServico.ListarPedidoProdutos();

                return Ok(pedidoProdutos);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("{idPedidoProduto}")]
        public IActionResult ObterPedidoProduto(short idPedidoProduto)
        {
            try
            {

                PedidoProduto pedidoProduto = _pedidoProdutoServico.ObterPedidoProdutoPorId(idPedidoProduto);

                return Ok(pedidoProduto);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
