using Common.Application.Commands;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.DeleteClient
{
    internal sealed class DeleteClientHandler : IRequestCommandHandler<DeleteClientCommand>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClientRepository _clientRepository;


        public DeleteClientHandler(IEventPublisher eventPublisher, IClientRepository clientRepository)
        {
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {

            try
            {
                _clientRepository.Remove(request.CLientId, request.CLientNombre, request.ClientApellido, request.ClientDNI);
                _eventPublisher.Publish(new ClientDeleted(request.CLientId, request.CLientNombre, request.ClientApellido, request.ClientDNI), cancellationToken);

                return Unit.Task;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }

        }
    }
}
