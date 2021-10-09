using Dominio.DTOs;
using Dominio.Entidades;
using Dominio.ViewModel;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IEncomendaServico
    {
        EncomendaDTO CadastrarEncomenda(CadastrarEncomendaViewModel model);
        List<Encomenda> ListarEncomendas();
        Encomenda ObterEncomendaPorId(short idEncomenda);
    }
}
