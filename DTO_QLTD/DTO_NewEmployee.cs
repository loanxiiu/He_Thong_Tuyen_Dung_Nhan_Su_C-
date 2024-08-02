using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    public class DTO_NewEmployee : DTO_Account, INewEmployee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentID { get; set; }
        public int MaTK { get; set; }
        public DTO_NewEmployee() { }
        public DTO_NewEmployee(string id, string name, string email, string phoneNumber, string departmentID, string userName, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            DepartmentID = departmentID;
            UserName = userName;
            Password = password;
        }
    }
}