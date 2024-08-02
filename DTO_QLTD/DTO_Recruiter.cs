using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    internal class DTO_Recruiter : DTO_Account, IRecruiter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int MaTK { get; set; }

        public DTO_Recruiter() { }
        public DTO_Recruiter(string id, string name, string email, string phoneNumber, string userName, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            UserName = userName;
            Password = password;
        }
    }
}