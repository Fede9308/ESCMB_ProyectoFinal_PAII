using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.DataTransferObjects
{
    public class ClientDTO
    {
        public int Id {get; set;}
        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string Email { get; private set; }
    }
}
