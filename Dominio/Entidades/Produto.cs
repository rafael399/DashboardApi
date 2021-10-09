namespace Dominio.Entidades
{
    public class Produto : Entity<Produto, short>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
    }
}
