using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsBro.Models;

namespace TutorsBro.Services
{
    public interface ILoginRepository
    {
        Task<User> Authenticate(string email, string password);
    }
}