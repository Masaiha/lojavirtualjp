using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._3_FM.lojavirtual.Infra.WebApi.Interfaces
{
    public interface IHttpGenericCall
    {
        Task<TResult> CallMethod<TResult>(HttpMethod typeMethod, string methodToCall, CancellationToken cancellationToken,
            Dictionary<string, object> paramsToQuery = null, object paramsToBody = null, string jwtToken = null,
            string jsonParam = null, string baseUrl = null);

        Task CallMethod(HttpMethod typeMethod, string methodToCall, CancellationToken cancellationToken,
                                     Dictionary<string, object> paramsToQuery = null, object paramsToBody = null, string jwtToken = null);
    }
}
