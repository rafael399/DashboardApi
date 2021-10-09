using Dominio.Entidades;
using Dominio.ViewModel;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IEquipeServico
    {
        Equipe CadastrarEquipe(CadastrarEquipeViewModel model);
        List<Equipe> ListarEquipes();
        Equipe ObterEquipePorId(short idProduto);
    }
}
