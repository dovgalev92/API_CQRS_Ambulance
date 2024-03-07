using Ambulance_API_CQRS.Application.Common.Exceptions;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.DepartRepos;
using Ambulance_API_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambulance_API_CQRS.Infrastructure.ImplementationRepository
{
    public class DepartRepository : IDepartRepository
    {
        private readonly IApplicationDb _application;
        public DepartRepository(IApplicationDb application) => _application = application;

        public async Task CreateDepart(int id, AmbulanceDepart depart)
        {
            var queryId = _application.Callings.SingleOrDefault(x => x.Id == id) != null ? await _application.Departs.AddAsync(depart)
            : throw new NotFoundException(nameof(CallingAmbulance), id);
        }
        public async Task<AmbulanceDepart> GetDepartId(int id)
        {
            var queryId = id > 0 ?  await _application.Departs.SingleOrDefaultAsync(i => i.Id == id)
                : throw new NotFoundException($"Нет такого вызова{nameof(AmbulanceDepart)}", id);

            return new AmbulanceDepart
            {
                Id = queryId.Id,
                NumberAccident_AssistantSquad = queryId.NumberAccident_AssistantSquad,
                DateDepart = queryId.DateDepart,
                NameHospital = queryId.NameHospital,
                ResultDepart = queryId.ResultDepart,
                StartPatient = queryId.StartPatient,
                EndTimePatient = queryId.EndTimePatient,
                TimeDepart = queryId.TimeDepart,
            };
        }
        public async Task EditDepat(int id, AmbulanceDepart depart)
        {
            var queryEditDepartId = id > 0 ? await _application.Departs.SingleOrDefaultAsync(i => i.Id == id)
               : throw new NotFoundException($"Нет такого вызова{nameof(AmbulanceDepart)}", id);

            queryEditDepartId.StartPatient = depart.StartPatient;
            queryEditDepartId.EndTimePatient = depart.EndTimePatient;

            _application.Departs.Update(queryEditDepartId); 
        }
    }
}
