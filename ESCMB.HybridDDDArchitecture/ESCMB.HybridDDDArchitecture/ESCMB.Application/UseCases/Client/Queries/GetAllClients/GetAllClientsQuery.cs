using Common.Application.Commands;
using ESCMB.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Queries.GetAllClients
{
    public class GetAllClientsQuery : QueryRequestCommand<QueryResult<ClientDTO>>
    {
    }
}
