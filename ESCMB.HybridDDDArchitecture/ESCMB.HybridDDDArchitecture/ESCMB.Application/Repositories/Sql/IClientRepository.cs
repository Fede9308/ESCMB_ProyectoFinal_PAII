using Common.Application.Repositories.Sql;
using ESCMB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.Repositories.Sql
{
    internal interface IClientRepository : IRepository<Client>
    {
    }
}
