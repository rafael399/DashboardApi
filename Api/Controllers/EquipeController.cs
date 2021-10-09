using Api.Autorizacao;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/equipe"), ApiController, Autorizacao]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeServico _equipeServico;

        public EquipeController(IEquipeServico equipeServico)
        {
            _equipeServico = equipeServico;
        }

        [HttpPost]
        public IActionResult CadastrarEquipe(CadastrarEquipeViewModel model)
        {
            try
            {
                Equipe equipeCadastrada = _equipeServico.CadastrarEquipe(model);

                return Ok(equipeCadastrada);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult ListarEquipes()
        {
            try
            {
                List<Equipe> equipes = _equipeServico.ListarEquipes();

                return Ok(equipes);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("{idEquipe}")]
        public IActionResult ObterEquipe(short idEquipe)
        {
            try
            {
                Equipe equipe = _equipeServico.ObterEquipePorId(idEquipe);

                return Ok(equipe);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
