using Dominio.Entidades;
using System.Linq;

namespace Dominio.Interfaces.Repositorios
{
    public interface IRepositorioGenerico<TEntity, TId>
        where TEntity : Entity<TEntity, TId>
        where TId : struct
    {
        IQueryable<TEntity> ObterTodos();
        TEntity ObterPorId(TId id);
        void Add(TEntity entity);
        bool Commit();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

