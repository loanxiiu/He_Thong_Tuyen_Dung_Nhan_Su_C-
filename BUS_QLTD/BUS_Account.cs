using DAL_QLTD;
using DTO_QLTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLTD
{
    public class BUS_Account
    {
        AccountAccess tkAccess = new AccountAccess();
        public string CheckLogic(DTO_Account taikhoan)
        {
            if (taikhoan.UserName == "")
            {
                return "required_taikhoan";
            }
            if (taikhoan.Password == "")
            {
                return "required_password";
            }
            string info = tkAccess.CheckLogic(taikhoan);
            return info;
        }
    }
}