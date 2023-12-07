using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambulance_API_CQRS.Models.DTO.DepartDto;
using Ambulance_API_CQRS.Application.Depart.Command;

namespace Ambulance_API_CQRS.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DepartController : BaseController
    {
        private readonly IMapper _mapper;
        public DepartController(IMapper mapper) => (_mapper) = (mapper);

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(int id, [FromBody] DepartCreateDto dto)
        {
            var depart = _mapper.Map<CreateDepartCommand>(dto) with
            {
                CallingAmbulanceId = id
            };
            await Mediator.Send(depart);
            return Content("операция произведена успешно");
        }
        
    }
}
