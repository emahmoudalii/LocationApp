using LocationApp.Helper;
using LocationApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LocationApp.RestClients
{
    public class EbClient
    {
        public async Task<HttpResponseMessage> RegisterUser(User user)
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = string.Format(Constant.AZURE);
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

         

            var ode = await response.Content.ReadAsStringAsync();

          var joko=  JObject.Parse(ode);

            var alao = joko["email"];


            return response;

            
        }


        public async Task<List<User>> GetUserAsync()
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var uri = "https://webapi20190325014427.azurewebsites.net/api/users";
            HttpResponseMessage response = null;
            response = await client.GetAsync(uri);
            var ode = await response.Content.ReadAsStringAsync();
            var joko = JsonConvert.DeserializeObject <List<User>>(ode);

            return joko;
                
           

        }


        public async Task<RootObject> LoginUser(User user)
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = string.Format(Constant.AZURE+"/loginuser");


            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);
           var ode= await response.Content.ReadAsStringAsync();
            var joko = JsonConvert.DeserializeObject<RootObject>(ode);

            return joko;
        }
    }
}
