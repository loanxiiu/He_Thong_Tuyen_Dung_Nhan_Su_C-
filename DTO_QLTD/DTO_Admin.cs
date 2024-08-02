using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    internal class DTO_Admin : DTO_Account, IAdmin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DTO_Admin() { }
        public DTO_Admin(string id, string name, string email, string phoneNumber, string userName, string password)
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