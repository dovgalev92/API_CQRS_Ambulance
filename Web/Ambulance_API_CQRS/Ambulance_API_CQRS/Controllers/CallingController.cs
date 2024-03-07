using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambulance_API_CQRS.Models.DTO;
using Ambulance_API_CQRS.Application.Calling.Command.CreateCalling;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;


namespace Ambulance_API_CQRS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CallingController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        
        public CallingController(IMapper mapper,ILoggerManager logger) => (_mapper,_logger ) = (mapper, logger);

        // api/Calling/5/CreateCalling
        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(int id, [FromBody] CreateCallingDto dto)
        {
            _logger.LogInfo($"call creation process {nameof(CallingController)}");
            var command = _mapper.Map<CreateCallingCommand>(dto) with
            {
                PatientId = id
            };

            await Mediator.Send(command);

            return Content("Операция произведена успешно");
        }
    }
}
