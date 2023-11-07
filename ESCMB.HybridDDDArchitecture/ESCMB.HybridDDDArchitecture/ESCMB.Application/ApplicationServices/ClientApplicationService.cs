using ESCMB.Application.Repositories.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.ApplicationServices
{
    internal static class ClientApplicationService
    {

        public static bool ClientExist(this IClientRepository contex, object value)
        {
            contex = contex ?? throw new ArgumentNullException(nameof(contex));
            value = value ?? throw new ArgumentNullException(nameof(value));

            var response = contex.FindOne(value);

            return response != null;

        }

    }
}
