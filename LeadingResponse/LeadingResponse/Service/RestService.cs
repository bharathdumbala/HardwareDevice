using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeadingResponse.Service
{
    public class RestService : IRestService
    {
        HttpClient client = null;
        public string username = "admin";
        public string password = "Rk2iK4tZm5I3";
        public RestService() {

            RestServiceWithOutCertificate();
        }

        public void RestServiceWithOutCertificate()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
           (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);

            string authData = string.Format("{0}:{1}", username, password);
            string authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }
        public async Task<string> Get(string url)
            {
                string getRes = null;
                try
                {
                    Debug.WriteLine(" ************** GET CALL START ********************** ");

                    Debug.WriteLine($"URL ::\n {url}");


                    //Debug.WriteLine($"Request ::\n {request.Content.ReadAsStringAsync().Result}");

                    HttpResponseMessage httpResponse = await client.GetAsync(url);

                    // Debug.WriteLine($"Total Response ::\n {httpResponse}");

                    Debug.WriteLine($"Status Code ::\n {httpResponse.StatusCode}");

                    string response = await httpResponse.Content.ReadAsStringAsync();

                    Debug.WriteLine($"Response ::\n {response}");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        getRes = response;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Get call Exception ::\n {e.Message}");
                }

                Debug.WriteLine(@" ************** Get CALL END ********************** ");

                return getRes;

            }

            public async Task<string> Post(HttpRequestMessage request)
            {
                string postRes = null;
                try
                {
                    Debug.WriteLine(" ************** POST CALL START ********************** ");

                    Debug.WriteLine($"URL ::\n {request.RequestUri}");


                    Debug.WriteLine($"Request ::\n {request.Content.ReadAsStringAsync().Result}");

                    HttpResponseMessage httpResponse = await client.PostAsync(request.RequestUri, request.Content);

                    // Debug.WriteLine($"Total Response ::\n {httpResponse}");

                    Debug.WriteLine($"Status Code ::\n {httpResponse.StatusCode}");

                    string response = await httpResponse.Content.ReadAsStringAsync();

                    Debug.WriteLine($"Response ::\n {response}");

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        postRes = response;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Post call Exception ::\n {e.Message}");
                }

                Debug.WriteLine(@" ************** POST CALL END ********************** ");

                return postRes;

            }
        
    }
}