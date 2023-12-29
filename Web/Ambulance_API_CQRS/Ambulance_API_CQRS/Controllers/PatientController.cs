using Ambulance_API_CQRS.Application.Patients.Command.CreatePatient;
using Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient;
using Ambulance_API_CQRS.Application.Patients.Queries.GetPatientDetails;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreatePatientDto create)
        {
            var map = _mapper.Map<CreatePatientCommand>(create);
            var patientId = await Mediator.Send(map);

            return Ok(patientId);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAllPatientVm>> GetPatient()
        {
            var query = new GetAllPatientsQuery();

            return Ok(await Mediator.Send(query));

        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetPatientDetailsDto>> GetPatientId(int id)
        {
            var query = new GetPatientDetailsQuery()
            {
                Id = id
            };
            return Ok(await Mediator.Send(query));

        }

    }
}
