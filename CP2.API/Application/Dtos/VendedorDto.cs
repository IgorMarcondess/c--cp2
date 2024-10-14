using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class VendedorDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "Telefone precisa ter no mínimo 9 caracteres")]
        public string Telefone { get; set; }
        public decimal TotalVendas { get; set; }

        public VendedorDto() { }

        public VendedorDto(string nome, string email, string telefone, decimal totalVendas)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TotalVendas = totalVendas;
        }
    }
}
