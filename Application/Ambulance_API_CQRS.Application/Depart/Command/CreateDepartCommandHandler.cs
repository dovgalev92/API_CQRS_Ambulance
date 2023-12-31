﻿using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.DepartRepos;
using MediatR;
using Ambulance_API_CQRS.Domain.Entities;


namespace Ambulance_API_CQRS.Application.Depart.Command
{
    public class CreateDepartCommandHandler : IRequestHandler<CreateDepartCommand>
    {
        private readonly IApplicationDb _application;
        private readonly IDepartRepository _repository;
        public CreateDepartCommandHandler(IApplicationDb application, IDepartRepository repository) 
            => (_application, _repository) = (application, repository);
        
        public async Task Handle(CreateDepartCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateDepart(request.CallingAmbulanceId, new AmbulanceDepart
            {
                NumberAccident_AssistantSquad = request.NumberAccident_AssistantSquad,
                DateDepart = DateTime.Now.Date,
                TimeDepart = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                NameHospital = request.NameHospital,
                ResultDepart = request.ResultDepart,
                CallingAmbulanceId = request.CallingAmbulanceId
            });
            await _application.SaveChangesAsync(cancellationToken);
        }
    }
}
