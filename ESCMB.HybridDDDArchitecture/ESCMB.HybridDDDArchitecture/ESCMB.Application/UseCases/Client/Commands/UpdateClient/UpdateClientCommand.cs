using Common.Application.Commands;
using System.ComponentModel.DataAnnotations;


namespace ESCMB.Application.UseCases.Client.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequestCommand
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public long DNI { get; set; }

        [Required]
        public string Email { get; set; }



        public UpdateClientCommand()
        {
        }

    }
}
