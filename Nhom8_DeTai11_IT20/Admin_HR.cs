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
    public partial class Admin_HR : Form
    {
        public Admin_HR()
        {
            InitializeComponent();
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = SystemColors.Control;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Lavender;
        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            panel8.BackColor = SystemColors.Control;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Lavender;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = SystemColors.Control;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Lavender;
        }
        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = SystemColors.Control;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Lavender;
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = SystemColors.Control;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Lavender;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Hide();
            ad.FormClosed += (s, args) => { this.Close(); };
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Admin_NVTD nvtd = new Admin_NVTD();
            nvtd.Show();
            this.Hide();
            nvtd.FormClosed += (s, args) => { this.Close(); };
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Admin_NVBP nvbp = new Admin_NVBP();
            nvbp.Show();
            this.Hide();
            nvbp.FormClosed += (s, args) => { this.Close(); };
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Admin_QLBP qlbp = new Admin_QLBP();
            qlbp.Show();
            this.Hide();
            qlbp.FormClosed += (s, args) => { this.Close(); };
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đang đồng ý đăng xuất?", "Đăng xuất", MessageBoxButtons.OKCancel) ==
                DialogResult.OK)
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
        }
    }
}
