using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    internal class DTO_DepartmentManager : DTO_Account, IDepartmentManager
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentID { get; set; }
        public int MaTK { get; set; }

        public DTO_DepartmentManager() { }
        public DTO_DepartmentManager(string id, string name, string email, string phoneNumber, string departmentID, string userName, string password)
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