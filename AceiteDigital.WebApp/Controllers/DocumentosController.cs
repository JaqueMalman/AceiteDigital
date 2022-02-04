using AceiteDigital.Application.Documentos.Commands.AdicionarSignatario;
using AceiteDigital.Application.Documentos.Commands.AssinarDocumento;
using AceiteDigital.Application.Documentos.Commands.CriarDocumento;
using AceiteDigital.Application.Documentos.Commands.RecusarAssinaturaDocumento;
using AceiteDigital.Application.Documentos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AceiteDigital.WebApp.Controllers
{
    public class DocumentosController : ApiController
    {       

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetDocumentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{documentoId:long}")]
        public async Task<IActionResult> GetSync(long documentoId)
        {
            var query = new GetDocumentoQuery() { DocumentoId = documentoId };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarDocumentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

        [HttpPut("{documentoId:long}/adicionar-signatario")]
        public async Task<IActionResult> PutAdicionarSignatario(
            [FromRoute] long documentoId,
            [FromBody] AdicionarSignatarioCommand command)
        {
            if (documentoId != command.DocumentoId) return BadRequest();            

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{documentoId:long}/assinar")]
        public async Task<IActionResult> PutAssinarAsync(
            [FromRoute] long documentoId,
            [FromBody] AssinarDocumentoCommand command)
        {
            if (documentoId != command.DocumentoId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{documentoId:long}/recusar-assintura")]
        public async Task<IActionResult> PutRecusarAssinaturaAsync(
            [FromRoute] long documentoId,
            [FromBody] RecusarAssinaturaDocumentoCommand command)
        {
            if (documentoId != command.DocumentoId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
