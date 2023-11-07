using Common.Application.Commands;
using ESCMB.Application.ApplicationServices;
using ESCMB.Application.Common;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.RegisterClient
{
    internal sealed class RegisterClientHandler : IRequestCommandHandler<RegisterClientCommand, string>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClientRepository _clientRepository;
        public RegisterClientHandler(IEventPublisher eventPublisher, IClientRepository clientRepository)
        {
            _eventPublisher = eventPublisher?? throw new ArgumentNullException(nameof(eventPublisher));
            _clientRepository = clientRepository?? throw new ArgumentNullException(nameof(clientRepository));
        }
        public async Task<string> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Client entity =  new Domain.Entities.Client(request.Nombre, request.Apellido, request.DNI, request.Email);

            if (!entity.IsValid) throw new InvalidEntityDataException(entity.ValidationErrors);

            if (_clientRepository.ClientExist(entity.Id)) throw new EntityDoesExistException();
            try
            {
                string createdId = await _clientRepository.AddOneAsync(entity);

                await _eventPublisher.Publish(entity.To<ClientRegistered>(), cancellationToken);

                return createdId;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }

        }
    }
}
