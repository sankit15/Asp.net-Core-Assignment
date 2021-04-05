using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public static class ConsumeApi
    {
        private static string Url = "https://localhost:44392/";
        public static IList<SupplierRate> GetAsync(int? id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url + "api/Suppliers/OverlappingSupplierRate/" + id);
            var getTask = client.GetAsync("");
            getTask.Wait();
            var result = getTask.Result;
            IList<SupplierRate> data = null;
            if (result.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<List<SupplierRate>>(result.Content.ReadAsStringAsync().Result);
            }
            return data;
        }

        public static IList<SupplierRate> GetApi()
        {
            WebClient client = new WebClient();
            string response = client.DownloadString(Url + "api/Suppliers/SupplierRate"); ;
            IList<SupplierRate> data = null;
            
            data = JsonConvert.DeserializeObject<List<SupplierRate>>(response);
            
            return data;
        }

    }


    
}
