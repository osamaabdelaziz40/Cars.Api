using Cars.DomainHelper.Interfaces;
using Cars.DomainHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Services
{
    public class CallHttpRequest : ICallHttpRequest
    {
        public ResultVM Res = new ResultVM();
        public ResultVM GET(string FullPath)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(FullPath);
                //HTTP GET
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<object>();
                    readTask.Wait();
                    var Res = JsonConvert.DeserializeObject<ResultVM>(readTask.Result.ToString());
                    return Res;
                }
                else //web api sent error response 
                {
                }
                return Res;
            }
        }
    }
}
