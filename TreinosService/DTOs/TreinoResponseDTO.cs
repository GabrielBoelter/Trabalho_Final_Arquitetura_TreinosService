namespace TreinosService.DTOs
{
    public class TreinoResponseDTO
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Objetivo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}