using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsBro.Models;

namespace TutorsBro.Services
{
    public interface IUserRegistration
    {
        Task<User> RegisterUser(User user);
    }
}
