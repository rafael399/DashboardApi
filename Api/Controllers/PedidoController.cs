using Api.Autorizacao;
using Dominio.DTOs;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/pedido"), ApiController, Autorizacao]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoServico _produtoServico;

        public PedidoController(IPedidoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        /// <summary>
        /// Endpoint principal da aplicação
        /// </summary>
        /// <returns>Lista de pedidos ordenados por data de criação e paginado</returns>
        [HttpGet]
        public IActionResult ListarPedidos(short pagina, short quantidadePorPagina = 20)
        {
            try
            {
                ObterPedidosViewModel retorno = _produtoServico.ListarPedidos(pagina, quantidadePorPagina);

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPatch("{idPedido}")]
        public IActionResult AtualizarParaEntregue(short idPedido)
        {
            try
            {
                PedidoDTO pedido = _produtoServico.AtualizarParaEntregue(idPedido);

                return Ok(pedido);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
