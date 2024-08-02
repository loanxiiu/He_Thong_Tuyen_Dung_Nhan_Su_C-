using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_DeTai11_IT20
{
    public partial class HR : Form
    {
        public string taiKhoan { set; get; }
        public HR(string tk)
        {
            InitializeComponent();
            taiKhoan = tk;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            HR_QuanLyViTriTuyenDung vitri = new HR_QuanLyViTriTuyenDung();
            vitri.Show();
            this.Hide();
            vitri.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HR_lichPhongVan lich = new HR_lichPhongVan();
            lich.Show();
            this.Hide();
            lich.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HR_QLHoSo hoso = new HR_QLHoSo();
            hoso.Show();
            this.Hide();
            hoso.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HR_DoiMatKhau MK = new HR_DoiMatKhau(taiKhoan);
            MK.Show();
            this.Hide();
            MK.FormClosed += (s, args) =>
            {
                this.Show();
            };
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang đồng ý đăng xuất?", "Đăng xuất", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
        }
    }
}
