namespace ProjetoAutentificacaoBasica.Api.Models
{
    public class passagem
    {
        public int Id { get; set; }
        public int VooId { get; set; }
        public int UsuarioId { get; set; }

        public int Assento { get; set; }
        public  voo? Voo { get; set; }
        public Passageiro? Passageiro { get; set; }

    }
}
