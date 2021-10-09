using Api.Autorizacao;
using Dominio.DTOs;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/encomenda"), ApiController, Autorizacao]
    public class EncomendaController : ControllerBase
    {
        private readonly IEncomendaServico _encomendaServico;

        public EncomendaController(IEncomendaServico encomendaServico)
        {
            _encomendaServico = encomendaServico;
        }

        [HttpPost]
        public IActionResult CadastrarEncomenda(CadastrarEncomendaViewModel model)
        {
            try
            {
                EncomendaDTO encomendaCadastrada = _encomendaServico.CadastrarEncomenda(model);

                return Ok(encomendaCadastrada);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult ListarEncomendas()
        {
            try
            {
                List<Encomenda> encomendas = _encomendaServico.ListarEncomendas();

                return Ok(encomendas);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("{idEncomenda}")]
        public IActionResult ObterEncomenda(short idEncomenda)
        {
            try
            {
                Encomenda encomenda = _encomendaServico.ObterEncomendaPorId(idEncomenda);

                return Ok(encomenda);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
