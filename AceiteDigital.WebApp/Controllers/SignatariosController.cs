using AceiteDigital.Application.Signatarios.Commands.CriarSignatario;
using AceiteDigital.Application.Signatarios.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AceiteDigital.WebApp.Controllers
{
    public class SignatariosController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetSignatariosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarSignatarioCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}