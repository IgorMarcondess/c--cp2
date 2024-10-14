using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("tb_fornecedor")]
    public class FornecedorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ precisa ter 14 caracteres")]
        public string CNPJ { get; set; } = null!;

        [MaxLength(200)]
        public string Endereco { get; set; } = null!;

        [Required]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "Telefone precisa ter no mínimo 9 caracteres")]
        public string Telefone { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public DateTime CriadoEm { get; set; }
    }
}
