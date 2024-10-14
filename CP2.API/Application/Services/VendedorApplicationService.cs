using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public VendedorDto? ObterVendedorPorId(int id)
        {
            var vendedor = _repository.ObterPorId(id);
            return vendedor != null ? ConverterParaDto(vendedor) : null;
        }

        public IEnumerable<VendedorDto> ObterTodosVendedores()
        {
            var vendedores = _repository.ObterTodos();
            return vendedores.Select(ConverterParaDto).ToList();
        }

        public VendedorDto SalvarDadosVendedor(VendedorDto vendedorDto)
        {
            var vendedorEntity = ConverterParaEntity(vendedorDto);
            _repository.Criar(vendedorEntity);
            return ConverterParaDto(vendedorEntity);
        }

        public VendedorDto? EditarDadosVendedor(int id, VendedorDto vendedorDto)
        {
            var vendedorExistente = _repository.ObterPorId(id);
            if (vendedorExistente == null) return null;

            vendedorExistente.Nome = vendedorDto.Nome;
            vendedorExistente.Email = vendedorDto.Email;
            vendedorExistente.Telefone = vendedorDto.Telefone;
            vendedorExistente.TotalVendas = vendedorDto.TotalVendas;

            _repository.Atualizar(vendedorExistente);
            return ConverterParaDto(vendedorExistente);
        }

        public bool DeletarDadosVendedor(int id)
        {
            var vendedor = _repository.ObterPorId(id);
            if (vendedor == null) return false;

            _repository.DeletarDados(id);
            return true;
        }

        private VendedorDto ConverterParaDto(VendedorEntity vendedor)
        {
            return new VendedorDto
            {
                Id = vendedor.Id,
                Nome = vendedor.Nome,
                Email = vendedor.Email,
                Telefone = vendedor.Telefone,
                TotalVendas = vendedor.TotalVendas
            };
        }

        private VendedorEntity ConverterParaEntity(VendedorDto vendedorDto)
        {
            return new VendedorEntity
            {
                Id = vendedorDto.Id,
                Nome = vendedorDto.Nome,
                Email = vendedorDto.Email,
                Telefone = vendedorDto.Telefone,
                TotalVendas = vendedorDto.TotalVendas
            };
        }
    }
}
