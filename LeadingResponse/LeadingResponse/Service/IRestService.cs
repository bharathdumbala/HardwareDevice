using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeadingResponse.Service
{
    public interface IRestService
    {
        Task<string> Post(HttpRequestMessage request);
    }
}
