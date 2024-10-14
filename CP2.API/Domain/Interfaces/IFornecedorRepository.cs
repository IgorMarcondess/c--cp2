using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        FornecedorEntity ObterPorId(int id);
        IEnumerable<FornecedorEntity> ObterTodos();
        void Criar(FornecedorEntity fornecedor);
        void Atualizar(FornecedorEntity fornecedor);
        void DeletarDados(int id);
        bool ValidarFornecedor(FornecedorEntity fornecedor);
    }
}
