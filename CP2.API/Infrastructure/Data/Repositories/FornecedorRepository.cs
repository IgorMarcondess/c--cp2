using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public FornecedorEntity ObterPorId(int id)
        {
            return _context.Set<FornecedorEntity>().Find(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            return _context.Set<FornecedorEntity>().ToList();
        }

        public void Criar(FornecedorEntity fornecedor)
        {
            if (ValidarFornecedor(fornecedor))
            {
                _context.Set<FornecedorEntity>().Add(fornecedor);
                _context.SaveChanges();
            }
        }

        public void Atualizar(FornecedorEntity fornecedor)
        {
            if (ValidarFornecedor(fornecedor))
            {
                _context.Set<FornecedorEntity>().Update(fornecedor);
                _context.SaveChanges();
            }
        }

        public void DeletarDados(int id)
        {
            var fornecedor = ObterPorId(id);
            if (fornecedor != null)
            {
                _context.Set<FornecedorEntity>().Remove(fornecedor);
                _context.SaveChanges();
            }
        }

        public bool ValidarFornecedor(FornecedorEntity fornecedor)
        {
            var validationContext = new ValidationContext(fornecedor, null, null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                fornecedor, validationContext, validationResults, true);

            if (!isValid)
            {
                foreach (var validationResult in validationResults)
                {
                    System.Console.WriteLine(validationResult.ErrorMessage);
                }
            }

            return isValid;
        }
    }
}
