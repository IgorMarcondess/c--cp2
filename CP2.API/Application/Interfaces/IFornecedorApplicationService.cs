using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IFornecedorApplicationService
    {
        FornecedorDto? ObterFornecedorPorId(int id);
        IEnumerable<FornecedorDto> ObterTodosFornecedores();
        FornecedorDto SalvarDadosFornecedor(FornecedorDto fornecedorDto);
        FornecedorDto? EditarDadosFornecedor(int id, FornecedorDto fornecedorDto);
        bool DeletarDadosFornecedor(int id);
    }
}
