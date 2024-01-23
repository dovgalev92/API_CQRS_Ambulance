using Ambulance_API_CQRS.Application.Patients;
using Ambulance_API_CQRS.Application.Patients.Command.CreatePatient;
using Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient;
using Ambulance_API_CQRS.Application.Patients.Queries.GetPatientDetails;
using Ambulance_API_CQRS.Application.Patients.Queries.GetPatientId;
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

            return CreatedAtAction(nameof(GetPatientId), new { id = patientId }, map);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPatient([FromQuery] PatientParametrDto parametr)
        {
            var patientParametr = _mapper.Map<PatientParametr>(parametr);
            var query = await Mediator.Send(new GetAllPatientsQuery() { Parametr = patientParametr });
            Response.Headers.Add("X-Pagination", query.GetMetadate());

            var result = _mapper.Map<IEnumerable<GetAllPatientDto>>(query);

            return Ok(result);

        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetPatientDetailsDto>> GetPatientDetails(int id)
        {
            var query = new GetPatientDetailsQuery()
            {
                Id = id
            };
            return Ok(await Mediator.Send(query));

        }
        [HttpGet("get-patient-id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ActionName(nameof(GetPatientId))]
        public async Task<ActionResult<GetPatientIdDto>> GetPatientId(int id)
        {
            var query = new GetPatientIdQuery() { Id = id };
            var send = await Mediator.Send(query);
            return Ok(send);

        }

    }
}
