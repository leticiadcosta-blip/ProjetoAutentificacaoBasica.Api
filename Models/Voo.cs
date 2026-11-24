namespace ProjetoAutentificacaoBasica.Api.Models
{
    public class voo
    {
        public int Id { get; set; }
        public int codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }

        public ICollection<passagem> Passagens = new List<passagem>();

    }
}
