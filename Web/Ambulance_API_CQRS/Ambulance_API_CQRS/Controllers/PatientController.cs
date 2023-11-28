using Ambulance_API_CQRS.Application.Patients.Command.CreatePatient;
using Ambulance_API_CQRS.Models.DTO.PatientDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ambulance_API_CQRS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PatientController : BaseController
    {
        private readonly IMapper _mapper;
        public PatientController(IMapper mapper) => _mapper = mapper;

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create(int id, [FromBody] CreatePatientDto create)
        {
            create.CallingAmbulanceId = id; // продумать альтернативу. Код следует доработать
            var map = _mapper.Map<CreatePatientCommand>(create);
            var patientId = await Mediator.Send(map);

            return Ok(patientId);
        }
    }
}
