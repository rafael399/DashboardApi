namespace Dominio.Entidades
{
    public class Entity<TEntity, TId>
        where TId : struct
        where TEntity : Entity<TEntity, TId>
    {
        public TId Id { get; set; }
    }
}
