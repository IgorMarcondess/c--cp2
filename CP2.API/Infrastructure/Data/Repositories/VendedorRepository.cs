using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public VendedorEntity ObterPorId(int id)
        {
            return _context.Set<VendedorEntity>().Find(id);
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            return _context.Set<VendedorEntity>().ToList();
        }

        public void Criar(VendedorEntity vendedor)
        {
                _context.Set<VendedorEntity>().Add(vendedor);
                _context.SaveChanges();
        }

        public void Atualizar(VendedorEntity vendedor)
        {
                _context.Set<VendedorEntity>().Update(vendedor);
                _context.SaveChanges();
        }

        public void DeletarDados(int id)
        {
            var vendedor = ObterPorId(id);
            if (vendedor != null)
            {
                _context.Set<VendedorEntity>().Remove(vendedor);
                _context.SaveChanges();
            }
        }

        private bool ValidarVendedor(VendedorEntity vendedor)
        {
            var validationContext = new ValidationContext(vendedor, null, null);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                vendedor, validationContext, validationResults, true);

            if (!isValid)
            {
                foreach (var validationResult in validationResults)
                {
                    // Exibir ou registrar erros de validação
                    System.Console.WriteLine(validationResult.ErrorMessage);
                }
            }

            return isValid;
        }
    }
}
