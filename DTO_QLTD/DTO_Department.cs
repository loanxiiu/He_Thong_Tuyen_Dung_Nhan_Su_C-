using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    // Kết tập (Aggregation)
    public class DTO_Department
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TotalEmployeesRecruitment { get; set; }
        public List<DTO_NewEmployee> Employees { get; set; }
        public DTO_Department() { }

        public DTO_Department(string departmentID, string departmentName, string email, string phoneNumber, string totalEmployeesRecruitment, List<DTO_NewEmployee> employees)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
            Email = email;
            PhoneNumber = phoneNumber;
            TotalEmployeesRecruitment = totalEmployeesRecruitment;
            Employees = employees;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}