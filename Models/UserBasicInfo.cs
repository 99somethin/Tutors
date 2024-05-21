using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorsBro.Models
{
    public class UserBasicInfo
    {
        public string FullName { get; set; }

        public string Role {  get; set; }

        public int RoleId { get; set; }

        public string Email { get; set; } 
    }

    public enum RoleType
    {
        Student = 1,
        Teacher,
        Admin, 
    }
}
