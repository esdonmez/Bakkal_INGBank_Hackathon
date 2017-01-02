using BakkalAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bakkal.Client
{
    public class DataClient
    {
        private const string ApiURL = "http://146.185.147.162:80/";
        private HttpClient client = new HttpClient();


        public DataClient()
        {
            client.BaseAddress = new Uri(ApiURL);
        }


        public void SetToken(string token)
        {
            client.DefaultRequestHeaders.Add("Authorization", "JWT " + token);
        }

        public async Task<TokenModel> Register(RegisterModel model)
        {
            HttpResponseMessage req = await client.PostAsync("/users/", new FormUrlEncodedContent(
                new Dictionary<string, string>()
                {
                    { "Name", model.Name },
                    { "Email", model.Email },
                    { "Password", model.Password },
                    { "Phone", model.Phone }
                }));

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenModel>(data);
            }

            return null;
        }

        public async Task<TokenModel> Login(LoginModel model)
        {
            HttpResponseMessage req = await client.PostAsync("/users/login/", new FormUrlEncodedContent(
                new Dictionary<string, string>()
                {
                    { "Email", model.Email },
                    { "Password", model.Password },
                }));

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenModel>(data);
            }

            return null;
        }

        public async Task<UserModel> GetMe()
        {
            HttpResponseMessage req = await client.GetAsync("/users/me/");

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserModel>(data);
            }

            return null;
        }

        public async Task<List<BakkalModel>> Bakkals(string city, string latitude, string longitude)
        {
            HttpResponseMessage req = await client.GetAsync("/bakkals/");

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BakkalModel>>(data);
            }

            return null;
        }

        public async Task<List<BakkalModel>> GetAllBakkals()
        {
            HttpResponseMessage req = await client.GetAsync("/bakkals/");

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BakkalModel>>(data);
            }

            return null;
        }

        public async Task<List<ProductModel>> Products(string id)
        {
            HttpResponseMessage req = await client.GetAsync("/bakkals/products?id=" + id);

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductModel>>(data);
            }

            return null;
        }

        public async Task<ResultModel> Shopping(BucketModel model)
        {
            HttpResponseMessage req = await client.PostAsync("/adverts/sold/", new FormUrlEncodedContent(
                new Dictionary<string, string>()
                {
                    { "BakkalId", model.BakkalId },
                    //{ "products", model.products.ToString() },
                    { "TotalAmount", model.TotalAmount },
                }));

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResultModel>(data);
            }

            return null;
        }

        public async Task<List<NotificationModel>> Notifications()
        {
            HttpResponseMessage req = await client.GetAsync("/bakkals/notifications/");

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<NotificationModel>>(data);
            }

            return null;
        }  

        public async Task<ResultModel> Report(ReportModel model)
        {
            HttpResponseMessage req = await client.PostAsync("/bakkals/report/", new FormUrlEncodedContent(
            new Dictionary<string, string>()
            {
                   { "BakkalId", model.BakkalId },
                   { "Content", model.Content },
            }));

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResultModel>(data);
            }

            return null;
        }

        public async Task<List<VeresiyeModel>> Veresiye()
        {
            HttpResponseMessage req = await client.GetAsync("/users/me/");

            if (req != null && req.IsSuccessStatusCode)
            {
                var data = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<VeresiyeModel>>(data);
            }

            return null;
        }
    }
}