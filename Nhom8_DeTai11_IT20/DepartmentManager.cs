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
    public partial class DepartmentManager : Form
    {
        public DepartmentManager()
        {
            InitializeComponent();
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = SystemColors.Control;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = SystemColors.InactiveCaption;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = SystemColors.Control;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = SystemColors.InactiveCaption;

        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = SystemColors.Control;

        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = SystemColors.InactiveCaption;

        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = SystemColors.Control;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = SystemColors.InactiveCaption;

        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = SystemColors.Control;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = SystemColors.InactiveCaption;

        }
        private void DepartmentManager_Load(object sender, EventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            DepartmentManager_YeuCau yeucau = new DepartmentManager_YeuCau();
            yeucau.Show();
            this.Hide();
            yeucau.FormClosed += (s, args) =>
            {
                this.Close();
            };
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            DepartmentManager_HoSo hoso = new DepartmentManager_HoSo();
            hoso.Show();
            this.Hide();
            hoso.FormClosed += (s, args) =>
            {
                this.Close();
            };
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            DepartmentManager_ViTriTD vitri = new DepartmentManager_ViTriTD();
            vitri.Show();
            this.Hide();
            vitri.FormClosed += (s, args) =>
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
    }
}
