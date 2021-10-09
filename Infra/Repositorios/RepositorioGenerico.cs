using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra.Repositorios
{
    public class RepositorioGenerico<TEntity, TId> : IRepositorioGenerico<TEntity, TId>
        where TId : struct
        where TEntity : Entity<TEntity, TId>
    {
        protected DashboardContexto Db { get; private set; }

        protected DbSet<TEntity> DbSet { get; }

        public RepositorioGenerico(DashboardContexto context)
        {
            Db = context ?? throw new ArgumentException("Falha ao inicializar o repositório. Contexto inválido.");
            DbSet = Db.Set<TEntity>();
        }
        public IQueryable<TEntity> ObterTodos() => DbSet;

        public virtual TEntity ObterPorId(TId id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Added;
            DbSet.Add(entity);
        }

        public bool Commit()
        {
            return Db.Commit();
        }

        public void Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
