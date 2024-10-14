namespace CP2.API.Application.Dtos
{
    public class VendedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public decimal TotalVendas { get; set; }

        public VendedorDto() { }

        public VendedorDto(int id, string nome, string email, string telefone, decimal totalVendas)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TotalVendas = totalVendas;
        }
    }
}
