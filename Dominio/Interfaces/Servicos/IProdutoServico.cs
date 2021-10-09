using Dominio.Entidades;
using Dominio.ViewModel;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IProdutoServico
    {
        Produto CadastrarProduto(CadastrarProdutoViewModel model);
        List<Produto> ListarProdutos();
        Produto ObterProdutoPorId(short idProduto);
    }
}
