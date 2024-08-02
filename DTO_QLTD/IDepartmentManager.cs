using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    // Người quản lý bộ phận (DepartmentManager)
    public interface IDepartmentManager : IUser
    {
        string DepartmentID { get; set; }
    }
}
