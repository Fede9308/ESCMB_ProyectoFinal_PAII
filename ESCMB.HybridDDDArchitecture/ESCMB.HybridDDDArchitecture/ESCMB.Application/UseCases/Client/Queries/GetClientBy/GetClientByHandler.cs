using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.UseCases.Client.Queries.GetClientBy
{
    internal sealed class GetClientByHandler : IRequestQueryHandler<GetClientByQuery, ClientDTO>
    {

        private readonly IClientRepository _clientRepository;

        public GetClientByHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<ClientDTO> Handle(GetClientByQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Client entity = await _clientRepository.FindOneAsync(request.ClientId);

            if (entity is null) throw new EntityDoesNotExistException();

            return entity.To<ClientDTO>();  
           
        }
    }
}
