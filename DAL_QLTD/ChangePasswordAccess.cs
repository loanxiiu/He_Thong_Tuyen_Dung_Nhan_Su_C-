using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLTD;

namespace DAL_QLTD
{
    public class ChangePasswordAccess : DAL_DatabaseAccess
    {
        public string ChangePass(DTO_Account taikhoan)
        {
            string info = ChangePassword(taikhoan);
            return info;
        }
    }
}