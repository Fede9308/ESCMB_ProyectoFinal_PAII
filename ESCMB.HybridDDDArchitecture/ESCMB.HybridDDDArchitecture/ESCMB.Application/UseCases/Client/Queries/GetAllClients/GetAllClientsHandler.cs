using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Repositories.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Queries.GetAllClients
{
    internal sealed class GetAllClientsHandler : IRequestQueryHandler<GetAllClientsQuery, QueryResult<ClientDTO>>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientsHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<QueryResult<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            IList<Domain.Entities.Client> entities = await _clientRepository.FindAllAsync();

            return new QueryResult<ClientDTO>(entities.To<ClientDTO>(), entities.Count, request.PageIndex, request.PageSize);

            //throw new NotImplementedException();
        }
    }
}
