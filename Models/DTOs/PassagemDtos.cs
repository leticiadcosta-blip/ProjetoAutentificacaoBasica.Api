namespace ProjetoAutentificacaoBasica.Api.Models.DTOs
{
    public class PassagemDtos
    {
    }
    public class EmitirPassagemDto
    {
        public int VooId { get; set; }
        public int UsuarioId { get; set; }
        public int Assento { get; set; }
    }
    public class PassagemDetalheDto
    {
        public int Id { get; set; }
        public int CodigoVoo { get; set; }
        public string Trajeto { get; set; }
        public string NomePassageiro { get; set; }
        public int Assento { get; set; }
    }
}
