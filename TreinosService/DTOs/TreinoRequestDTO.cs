using System.ComponentModel.DataAnnotations;

namespace TreinosService.DTOs
{
    public class TreinoRequestDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Nome deve ter entre 2 e 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s0-9]+$", ErrorMessage = "Nome contém caracteres inválidos")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Objetivo é obrigatório")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Objetivo deve ter entre 5 e 500 caracteres")]
        public required string Objetivo { get; set; }
    }
}
