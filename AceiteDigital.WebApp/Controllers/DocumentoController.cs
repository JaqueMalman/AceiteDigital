using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AceiteDigital.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentoController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public DocumentoController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var repositoryDocumento =
                _unitOfWork.GetRepository<Documento>();

            var documentos = repositoryDocumento.GetAll();
            return Ok(documentos);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            DocumentoDto documentoDto)
        {
            var documentoInserir = new Documento(
                documentoDto.Titulo,
                documentoDto.Descricao);

            var repositoryDocumento =
                _unitOfWork.GetRepository<Documento>();

            repositoryDocumento.Add(documentoInserir);

            await _unitOfWork.CommitAsync();

            return Created($"id={documentoInserir.Id}", documentoInserir);
        }

    }
}
