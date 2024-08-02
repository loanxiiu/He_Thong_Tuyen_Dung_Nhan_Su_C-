using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    public interface INewEmployee : IUser
    {
        string DepartmentID { get; set; }
    }
}
