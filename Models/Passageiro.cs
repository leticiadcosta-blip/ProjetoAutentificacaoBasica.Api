namespace ProjetoAutentificacaoBasica.Api.Models
{
    public class Passageiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public ICollection<passagem> Passagens = new List<passagem>();
    }
}
