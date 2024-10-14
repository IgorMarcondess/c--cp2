using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
            private readonly IFornecedorRepository _repository;

            public FornecedorApplicationService(IFornecedorRepository repository)
            {
                _repository = repository;
            }

            public FornecedorDto? ObterFornecedorPorId(int id)
            {
                var fornecedor = _repository.ObterPorId(id);
                return fornecedor != null ? ConverterParaDto(fornecedor) : null;
            }

            public IEnumerable<FornecedorDto> ObterTodosFornecedores()
            {
                var fornecedores = _repository.ObterTodos();
                return fornecedores.Select(ConverterParaDto);
            }

            public FornecedorDto SalvarDadosFornecedor(FornecedorDto fornecedorDto)
            {
                var fornecedorEntity = ConverterParaEntity(fornecedorDto);
                _repository.Criar(fornecedorEntity);
                return ConverterParaDto(fornecedorEntity);
            }

            public FornecedorDto? EditarDadosFornecedor(int id, FornecedorDto fornecedorDto)
            {
                var fornecedorExistente = _repository.ObterPorId(id);
                if (fornecedorExistente == null) return null;

                fornecedorExistente.Nome = fornecedorDto.Nome;
                fornecedorExistente.CNPJ = fornecedorDto.Cnpj;
                fornecedorExistente.Endereco = fornecedorDto.Endereco;
                fornecedorExistente.Telefone = fornecedorDto.Telefone;

                _repository.Atualizar(fornecedorExistente);
                return ConverterParaDto(fornecedorExistente);
            }

            public bool DeletarDadosFornecedor(int id)
            {
                var fornecedor = _repository.ObterPorId(id);
                if (fornecedor == null) return false;

                _repository.DeletarDados(id);
                return true;
            }

            private FornecedorDto ConverterParaDto(FornecedorEntity fornecedor)
            {
                return new FornecedorDto(
                    fornecedor.Id,
                    fornecedor.Nome,
                    fornecedor.CNPJ,
                    fornecedor.Endereco,
                    fornecedor.Telefone
                );
            }

            private FornecedorEntity ConverterParaEntity(FornecedorDto fornecedorDto)
            {
                return new FornecedorEntity
                {
                    Id = fornecedorDto.Id,
                    Nome = fornecedorDto.Nome,
                    CNPJ = fornecedorDto.Cnpj,
                    Endereco = fornecedorDto.Endereco,
                    Telefone = fornecedorDto.Telefone,
                    CriadoEm = DateTime.Now
                };
            }

        }
}
