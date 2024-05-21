using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TutorsBro.Models;

namespace TutorsBro.Services
{
    class UserRegistration : IUserRegistration
    {
        public async Task<User> RegisterUser(User user)
        {
            try
            {
                var _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri("http://10.0.2.2:5274/api/User");


                var json = System.Text.Json.JsonSerializer.Serialize(user);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("User", data);

                if (response.IsSuccessStatusCode)
                {
                    User users = await response.Content.ReadFromJsonAsync<User>();
                    return users;
                }
                else
                {
                    throw new Exception("Failed to register user");
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
