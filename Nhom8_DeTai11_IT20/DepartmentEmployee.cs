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
    public partial class DepartmentEmployee : Form
    {
        public string TK { get; set; }

        public DepartmentEmployee(string tk)
        {
            InitializeComponent();
            TK = tk;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = SystemColors.Control;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.DarkSeaGreen;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = SystemColors.Control;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.DarkSeaGreen;
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = SystemColors.Control;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.DarkSeaGreen;
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = SystemColors.Control;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.DarkSeaGreen;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            DepartmentEmployee_LichPhongVan lich = new DepartmentEmployee_LichPhongVan(TK);
            lich.Show();
            this.Hide();
            lich.FormClosed += (s, args) =>
            {
                this.Close();
            };
        }

        private void panel5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Click(object sender, EventArgs e)
        {
            DepartmentEmployee_DuyetHoSo hoso = new DepartmentEmployee_DuyetHoSo(TK);
            hoso.Show();
            this.Hide();
            hoso.FormClosed += (s, args) =>
            {
                this.Close();
            };
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang đồng ý đăng xuất?", "Đăng xuất", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
        }

        private void DepartmentEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
