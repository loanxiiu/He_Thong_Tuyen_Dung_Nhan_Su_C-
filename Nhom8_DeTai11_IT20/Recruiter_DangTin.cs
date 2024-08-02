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
    public partial class Recruiter_DangTin : Form
    {
        public Recruiter_DangTin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recruiter nhanvien = new Recruiter();
            nhanvien.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recruiter_QuanLyHoSo hoso = new Recruiter_QuanLyHoSo();
            hoso.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Recruiter_LienLac lienlac = new Recruiter_LienLac();
            lienlac.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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