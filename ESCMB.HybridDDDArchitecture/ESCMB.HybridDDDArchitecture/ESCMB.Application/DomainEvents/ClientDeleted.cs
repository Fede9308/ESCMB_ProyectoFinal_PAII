using Common.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.DomainEvents
{
    internal sealed class ClientDeleted : DomainEvent
    {
        public int ClientId { get; set; }

        public string ClientNombre { get; set; }

        public string ClientApellido { get; set; }  

        public long CLientDNI { get; set; }

        public ClientDeleted(int id, string nombre, string apellido, long dni)
        {
            ClientId = id;
            ClientNombre = nombre;  
            ClientApellido = apellido;
            CLientDNI = dni;
        }
    }
}
