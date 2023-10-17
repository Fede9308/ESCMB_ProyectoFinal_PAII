using Common.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.DomainEvents
{
    internal class ClientUpdated : DomainEvent
    {
        public int CLientId { get; set; }

        public string ClientNombre { get; set; }

        public string CLientApellido { get; set; }

        public long ClientDNI { get; set; }

        public string ClientEmail { get; set; }
    }
}
