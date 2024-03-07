using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambulance_API_CQRS.Models.DTO.DepartDto;
using Ambulance_API_CQRS.Application.Depart.Command;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using Ambulance_API_CQRS.Application.Depart.Command.EditDepart;
using Ambulance_API_CQRS.Application.Depart.Query;

namespace Ambulance_API_CQRS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DepartController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public DepartController(IMapper mapper, ILoggerManager logger) => (_mapper, _logger) = (mapper, logger);

        // api/Depart/5/CreateDepart
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
        // api/Depart/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EditDepartTime (int id, [FromBody] EditDepartModel dto)
        {
            _logger.LogInfo($"depart update process {id}");

            await Mediator.Send(new EditDepartCommand()
            {
                DepartId = id,
                StartPatient = dto.StartPatient,
                EndTimePatient = dto.EndPatient,
            });

            return Content("Обновление произошло успешно");
        }
        // api/Depart/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DepartDetailDto>> DetailsDepart(int id)
        {
            _logger.LogInfo($"depart details process {id}");

            return Ok(await Mediator.Send(new DepartIdQuery() {Id = id }));
        }
    }
}
