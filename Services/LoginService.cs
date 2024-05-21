using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TutorsBro.Models;

namespace TutorsBro.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<User> Authenticate(string email, string password)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"http://10.0.2.2:5274/api/User/{email}/{password}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        User user = await response.Content.ReadFromJsonAsync<User>();
                        return user;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
