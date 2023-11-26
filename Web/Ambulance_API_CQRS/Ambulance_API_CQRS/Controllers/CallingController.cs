using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambulance_API_CQRS.Models.DTO;
using Ambulance_API_CQRS.Application.Calling.Command.CreateCalling;

namespace Ambulance_API_CQRS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CallingController : BaseController
    {
        private readonly IMapper _mapper;

        public CallingController(IMapper mapper) => _mapper = mapper;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreateCallingDto dto)
        {
            var command = _mapper.Map<CreateCallingCommand>(dto);

            var callingId = await Mediator.Send(command);

            return Ok(callingId);
        }
    }
}
