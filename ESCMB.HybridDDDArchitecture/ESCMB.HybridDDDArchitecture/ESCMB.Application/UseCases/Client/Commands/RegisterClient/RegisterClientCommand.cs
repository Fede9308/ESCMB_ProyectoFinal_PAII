﻿using Common.Application.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.RegisterClient
{
    public class RegisterClientCommand : IRequestCommand<string>
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public long DNI { get; set; }

        [Required]
        public string Email { get; set; }



        public RegisterClientCommand() { }
    }
}
