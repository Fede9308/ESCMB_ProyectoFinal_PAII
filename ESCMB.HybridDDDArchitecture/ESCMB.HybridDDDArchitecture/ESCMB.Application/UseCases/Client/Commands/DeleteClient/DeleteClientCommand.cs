using Common.Application.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequestCommand
    {
        [Required]
        public int CLientId { get; set; }

        [Required]
        public string CLientNombre { get; set; }

        [Required]
        public string ClientApellido { get; set; }

        [Required]
        public long ClientDNI { get; set; } 

        public DeleteClientCommand()
        {
        }

    }
}
