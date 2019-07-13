using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Web.ServiceHelper
{
    internal abstract class ServiceHelper
    {
        private string _serviceUrl;

        public string ServiceUrl
        {
            get
            {
                return _serviceUrl;
            }
            private set
            {
                _serviceUrl = value;
            }
        }

        public ServiceHelper()
        {
            ServiceUrl = ConfigurationManager.AppSettings["ServiceUrl"].ToString();
        }

        public async Task<T> GetServiceDataAsync<T>(string serviceName)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServiceUrl);
                HttpResponseMessage res = await client.GetAsync(serviceName);
                if (res.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await res.Content.ReadAsStringAsync());
                }

                return default(T);
            }
        }


    }
}