using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class FornecedorDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ precisa ter 14 caracteres")]
        public string Cnpj { get; set; }
        [MaxLength(200)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "Telefone precisa ter no mínimo 9 caracteres")]
        public string Telefone { get; set; }

        public FornecedorDto() { }

        public FornecedorDto(int id, string nome, string cnpj, string endereco, string telefone)
        {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
            Endereco = endereco;
            Telefone = telefone;
        }

    }
}
