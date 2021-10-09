using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicos.Servicos
{
    public class EquipeServico : IEquipeServico
    {
        private readonly IEquipeRepositorio _equipeRepositorio;

        public EquipeServico(IEquipeRepositorio equipeRepositorio)
        {
            _equipeRepositorio = equipeRepositorio;
        }

        public Equipe CadastrarEquipe(CadastrarEquipeViewModel model)
        {
            try
            {
                Equipe equipeExistente = _equipeRepositorio.ObterPorNome(model.Nome).FirstOrDefault();

                if (equipeExistente != null)
                    throw new ArgumentException("Já existe uma equipe com o nome informado");

                Equipe novaEquipe = new()
                {
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    PlacaVeiculo = model.PlacaVeiculo
                };

                _equipeRepositorio.Add(novaEquipe);
                _equipeRepositorio.Commit();

                return novaEquipe;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public List<Equipe> ListarEquipes()
        {
            try
            {
                return _equipeRepositorio.ObterTodos().ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }

        public Equipe ObterEquipePorId(short idEquipe)
        {
            try
            {
                return _equipeRepositorio.ObterPorId(idEquipe);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message, e);
            }
        }
    }
}
