using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambulance_API_CQRS.Models.DTO.DepartDto;
using Ambulance_API_CQRS.Application.Depart.Command;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;

namespace Ambulance_API_CQRS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DepartController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public DepartController(IMapper mapper, ILoggerManager logger) => (_mapper, _logger) = (mapper, logger);

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(int id, [FromBody] DepartCreateDto dto)
        {
            _logger.LogInfo($"depart creation process {dto.CallingAmbulanceId} {nameof(DepartController)}");
            var depart = _mapper.Map<CreateDepartCommand>(dto) with
            {
                CallingAmbulanceId = id
            };
            await Mediator.Send(depart);
            return Content("операция произведена успешно");
        }
        
    }
}
