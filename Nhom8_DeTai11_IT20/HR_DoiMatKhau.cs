using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLTD;
using DTO_QLTD;

namespace Nhom8_DeTai11_IT20
{
    public partial class HR_DoiMatKhau : Form
    {
        DTO_Account taikhoan = new DTO_Account();
        BUS_ChangePassword BUSTK = new BUS_ChangePassword();
        public string TK { get; set; }
        public HR_DoiMatKhau(string tk)
        {
            InitializeComponent();
            TK = tk;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void HR_DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            taikhoan.UserName = TK;
            taikhoan.Password = rjTextBox1.Texts;
            taikhoan.ConfirmPassword = rjTextBox2.Texts;
            taikhoan.NewPassword = rjTextBox3.Texts;

            string updateInfo = BUSTK.ChangePass(taikhoan);
            switch (updateInfo)
            {
                case "required_password":
                    MessageBox.Show("Vui lòng nhập mật khẩu cũ");
                    return;
                case "required_confirmpassword":
                    MessageBox.Show("Vui lòng nhập lại mật khẩu");
                    return;
                case "password_confirmation":
                    MessageBox.Show("Mật khẩu nhập lại không khớp");
                    return;
                case "required_newpassword":
                    MessageBox.Show("Vui lòng nhập mật khẩu mới");
                    return;
                case "Mật khẩu không chính xác":
                    MessageBox.Show("Mật khẩu không chính xác");
                    return;
            }

            MessageBox.Show("Đổi mật khẩu thành công");
        }
    }
}
