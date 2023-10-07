using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Entities;
using ESCMB.Domain.Validators;
using static ESCMB.Domain.Enums;

namespace ESCMB.Domain.Entities
{
    public class Client : DomainEntity<ClientValidator>
    {

        public int Id { get; private set; } 

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }    

        public long DNI { get; private set; }

        public string Email {get; private set; }

        //public string Direccion { get; private set; }       

        //public User Usuario { get; private set; }

        public Client()
        {
            
        }

        public Client(string id, string nombre, string apellido, long dni, string email)
        {
            
        }



    }
}
