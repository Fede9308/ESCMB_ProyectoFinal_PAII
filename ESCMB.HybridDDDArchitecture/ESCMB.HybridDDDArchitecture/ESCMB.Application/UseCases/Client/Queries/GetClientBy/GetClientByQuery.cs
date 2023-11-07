using Common.Application.Commands;
using ESCMB.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Queries.GetClientBy
{
    public class GetClientByQuery : IRequestQuery<ClientDTO>
    {
        [Required]
        public int ClientId { get; set; }

        public GetClientByQuery()
        {
            
        }
    }
}
