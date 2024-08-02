using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLTD;
using DTO_QLTD;

namespace BUS_QLTD
{
    public class BUS_ChangePassword
    {
        ChangePasswordAccess passAccess = new ChangePasswordAccess();
        public string ChangePass(DTO_Account taikhoan)
        {
            if (taikhoan.Password == "")
            {
                return "required_password";
            }

            if (taikhoan.ConfirmPassword == "")
            {
                return "required_confirmpassword";
            }
            if (taikhoan.Password != taikhoan.ConfirmPassword)
            {
                return "password_confirmation";
            }
            if (taikhoan.NewPassword == "")
            {
                return "required_newpassword";
            }
            string info = passAccess.ChangePass(taikhoan);
            return info;
        }
    }
}