using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os vendedores", Description = "Este endpoint retorna uma lista completa de todos os vendedores cadastrados.")]
        [Produces<IEnumerable<VendedorEntity>>]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosVendedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterVendedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpPost]
        [Produces<VendedorEntity>]
        public IActionResult Post([FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosVendedor(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpPut("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosVendedor(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }


        [HttpDelete("{id}")]
        [Produces<VendedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosVendedor(id);

            if (objModel != null)
                return Ok(objModel);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
