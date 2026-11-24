namespace ProjetoAutentificacaoBasica.Api.Models.DTOs
{
    public class VooDtos
    {
    }

    public class CriarVooDto
    {
        public int codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
    }

    public class ResumoVooDto
    {
        public int Id { get; set; }
        public int codigo { get; set; }
        public string Trajeto { get; set; }
    }

    public class PassageirosVooDto
    {
        public string Nome { get; set; }
        public string Assento { get; set; }
        
    }   

    public class VooManifestoDto
    {
        public int Id { get; set; }
        public int codigo { get; set; }
        public string Trajeto { get; set; }
        public List<PassageirosVooDto> Passageiro { get; set; }
    }
}

