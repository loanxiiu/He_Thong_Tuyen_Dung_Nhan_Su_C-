using DAL_QLTD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Nhom8_DeTai11_IT20
{
    public partial class Recruiter : Form
    {
        public string ConString = "Data Source=ACER;Initial Catalog=QLTD;Integrated Security=True;Encrypt=False";
        public Recruiter()
        {
            InitializeComponent();
        }

        private void Recruiter_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recruiter_DangTin dangTin = new Recruiter_DangTin();
            dangTin.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recruiter_QuanLyHoSo quanlyhoso = new Recruiter_QuanLyHoSo();
            quanlyhoso.Show();
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