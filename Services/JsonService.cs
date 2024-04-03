using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TriviaApp.Models;

namespace TriviaApp.Services
{
    public class JsonService
    {
        HttpClient httpClient;//אובייקט לשליחת בקשות וקבלת תשובות מהשרת

        JsonSerializerOptions options;//פרמטרים שישמשו אותנו להגדרות הjson

        const string URL = $@"https://qsc714b9-7128.euw.devtunnels.ms/swagger/index.html";//כתובת השרת

        public JsonService()
        {
            //http client
            httpClient = new HttpClient();

            //options when doing serialization/deserialization
            options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public async Task<User> LoginSuc(User u)
        {
            User playerEmailPass = new User();
            { playerEmailPass.Email = u.Email; playerEmailPass.Password = u.Password; }
            string jsonString = JsonSerializer.Serialize(u,options);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{URL}/TriviaApi/Login", content);

            if ( response.IsSuccessStatusCode )
            {
                return u;
            }

            return null;
        }   

        public async Task<bool> Register(User user)
        {
            string jsonString  = 
        }
    }
}
