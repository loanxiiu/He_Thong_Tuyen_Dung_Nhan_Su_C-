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

namespace Nhom8_DeTai11_IT20
{
    public partial class Recruiter_LienLac : Form
    {
        public Recruiter_LienLac()
        {
            InitializeComponent();
        }

        private void Recruiter_LienLac_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("MaUngVien", "Mã ứng viên");
            dataGridView1.Columns.Add("TenUngVien", "Tên ứng viên");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("SDT", "Số điện thoại");
            dataGridView1.Columns.Add("DiaChi", "Địa chỉ");
            dataGridView1.Columns.Add("Anh", "Ảnh");


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LoadData2();
        }
        public void LoadData2()
        {
            dataGridView1.Rows.Clear();
            string query = "select * from UngVien";

            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(
                    row["MaUngVien"],
                    row["TenUngVien"],
                    row["Email"],
                    row["SDT"],
                    row["DiaChi"],
                    row["Anh"]
                );
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Recruiter_DangTin dangTin = new Recruiter_DangTin();
            dangTin.ShowDialog();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recruiter_QuanLyHoSo quanlyhoso = new Recruiter_QuanLyHoSo();
            quanlyhoso.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recruiter nhanvien = new Recruiter();
            nhanvien.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
