namespace CP2.API.Application.Dtos
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
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
