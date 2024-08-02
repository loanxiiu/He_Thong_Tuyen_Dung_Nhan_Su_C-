using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    internal class DTO_Applicant : DTO_Account, IApplicant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; } // Applied, Interviewing, Hired, Rejected

        public DTO_Applicant() { }
        public DTO_Applicant(string id, string name, string email, string phoneNumber, string userName, string password)
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