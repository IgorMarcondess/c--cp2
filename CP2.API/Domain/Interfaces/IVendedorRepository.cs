using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        VendedorEntity ObterPorId(int id);
        IEnumerable<VendedorEntity> ObterTodos();
        void Criar(VendedorEntity vendedor);
        void Atualizar(VendedorEntity vendedor);
        void DeletarDados(int id);

    }
}
