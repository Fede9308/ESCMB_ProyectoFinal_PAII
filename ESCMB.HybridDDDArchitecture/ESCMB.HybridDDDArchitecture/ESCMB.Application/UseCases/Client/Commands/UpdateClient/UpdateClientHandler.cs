using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.UpdateClient
{
    internal sealed class UpdateClientHandler : IRequestCommandHandler<UpdateClientCommand>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClientRepository _clientRepository;

        public UpdateClientHandler(IEventPublisher eventPublisher, IClientRepository clientRepository)
        {
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));

        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Client entity = await _clientRepository.FindOneAsync(request.Id);

            if (entity is null) throw new EntityDoesNotExistException();

            entity.SetClientNombre(request.Nombre);
            entity.SetClientApellido(request.Apellido);
            entity.SetClientDNI(request.DNI);
            entity.SetClientEmail(request.Email);

            try
            {
                _clientRepository.Update(entity);
                await _eventPublisher.Publish(entity.To<ClientUpdated>(), cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }

            
        }
    }
}
