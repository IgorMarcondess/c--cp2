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
        public string Nome { get; set; }

        [Required]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [MaxLength(200)]
        public string Endereco { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
