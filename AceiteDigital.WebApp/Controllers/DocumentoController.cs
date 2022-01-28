using AceiteDigital.Application.Documentos.Commands.CriarDocumento;
using AceiteDigital.Application.Documentos.Queries;
using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AceiteDigital.WebApp.Controllers
{
    public class DocumentoController : ApiController
    {       

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetDocumentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarDocumentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
