using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreinosService.Models
{
    [Table("Treinos")]
    public class Treino
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "TEXT")]
        public required string Nome { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "TEXT")]
        public required string Objetivo { get; set; }


        [Required]
        [Column(TypeName = "TEXT")] // SQLite armazena datas como TEXT
        public DateTime DataCriacao { get; set; }

        public Treino()
        {
            DataCriacao = DateTime.UtcNow;
        }

 
        /// <param name="nome">Nome do treino</param>
        /// <param name="objetivo">Objetivo do treino</param>
        public Treino(string nome, string objetivo) : this()
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Objetivo = objetivo ?? throw new ArgumentNullException(nameof(objetivo));
        }
    }
}