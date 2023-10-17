using Common.Application.Commands;
using ESCMB.Application.UseCases.Client.Commands.DeleteClient;
using ESCMB.Application.UseCases.Client.Commands.RegisterClient;
using ESCMB.Application.UseCases.Client.Commands.UpdateClient;
using ESCMB.Application.UseCases.Client.Queries.GetAllClients;
using ESCMB.Application.UseCases.Client.Queries.GetClientBy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESCMB.API.Controllers
{
    [ApiController]
    public class ClientsController: BaseController
    {
        private readonly IEventPublisher _commandQueryBus;

        public ClientsController(IEventPublisher commmandQueryBus)
        {
            _commandQueryBus = commmandQueryBus?? throw new ArgumentNullException(nameof(commmandQueryBus));
        }


        [HttpGet("api/v1/[Controller]")]
        public async Task<IActionResult> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            var entities = await _commandQueryBus.Send(new GetAllClientsQuery() { PageIndex = pageIndex, PageSize = pageSize });

            return Ok(entities);
        }

        [HttpGet("api/v1/[Controller]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var entity = await _commandQueryBus.Send(new GetClientByQuery() { ClientId = id });

            return Ok(entity);
        }

        [HttpPost("api/v1/[controller]")]
        public async Task<IActionResult> RegisterClient(RegisterClientCommand command)
        {
            if (command is null) return BadRequest();

            var id = await _commandQueryBus.Send(command);

            return Created($"api/[Controller]/{id}", new { Id = id });
        }

        [HttpPut("api/v1/[Controller]")]
        public async Task<IActionResult> Update(UpdateClientCommand command)
        {
            if (command is null) return BadRequest();

            await _commandQueryBus.Send(command);

            return NoContent();
        }

        [HttpDelete("api/v1/[Controller]/{id}")]
        public async Task<IActionResult> Delete(int id, string nombre, string apellido, long dni)
        {
            if (id <= 0) return BadRequest();

            await _commandQueryBus.Send(new DeleteClientCommand { CLientId = id , CLientNombre = nombre, ClientApellido = apellido, ClientDNI = dni });

            return NoContent();
        }

    }


}