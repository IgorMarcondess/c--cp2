 using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IVendedorApplicationService
    {
        VendedorDto? ObterVendedorPorId(int id);
        IEnumerable<VendedorDto> ObterTodosVendedores();
        VendedorDto SalvarDadosVendedor(VendedorDto vendedorDto);
        VendedorDto? EditarDadosVendedor(int id, VendedorDto vendedorDto);
        bool DeletarDadosVendedor(int id);
    }
}
