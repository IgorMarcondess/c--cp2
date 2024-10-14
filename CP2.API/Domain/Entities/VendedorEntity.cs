using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(8)]
        public int DataDeNascimento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "Telefone precisa ter no mínimo 9 caracteres")]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(8)]
        public DateTime DataContratacao { get; set; }

        [Required]
        public float ComissaoPercentual { get; set; }

        [Required]
        public float MetaMensal { get; set; }

        public DateTime CriadoEm { get; set; }

        //INCLUI AQ NO VENDEDORENTITY POIS ESTAVA RECLAMANDO NO VendedorApplicationService
        public decimal TotalVendas { get; set; }
    }
}
