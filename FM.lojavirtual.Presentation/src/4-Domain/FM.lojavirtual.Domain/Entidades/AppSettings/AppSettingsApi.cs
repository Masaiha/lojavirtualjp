using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.lojavirtual.Domain.Entidades.AppSettings
{
    public class AppSettingsApi
    {
        public string TokenValidationBaseUrl { get; set; }
        public string SecretKeyJWT { get; set; }
        public string TokenExpirationTime { get; set; }
    }
}
