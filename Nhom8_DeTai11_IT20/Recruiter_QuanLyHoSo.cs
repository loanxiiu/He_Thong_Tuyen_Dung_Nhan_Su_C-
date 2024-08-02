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
    public partial class Recruiter_QuanLyHoSo : Form
    {
        public string ConString = "Data Source=ACER;Initial Catalog=QLTD;Integrated Security=True;Encrypt=False";
        public Recruiter_QuanLyHoSo()
        {
            InitializeComponent();
        }

        public void LoadData1()
        {
            dataGridView1.Rows.Clear();
            string query = "select * from HoSo";

            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(
                    row["MaHoSo"],
                    row["MaUngVien"],
                    row["KyNang"],
                    row["KinhNghiem"],
                    row["HocVan"],
                    row["MaViTriTD"],
                    row["TrangThai"]
                );
            }
        }

        private void Recruiter_QuanLyHoSo_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("MaHoSo", "Mã hồ sơ");
            dataGridView1.Columns.Add("MaUngVien", "Mã ứng viên");
            dataGridView1.Columns.Add("KyNang", "Kỹ năng");
            dataGridView1.Columns.Add("KinhNghiem", "Kinh nghiệm");
            dataGridView1.Columns.Add("HocVan", "Học vấn");
            dataGridView1.Columns.Add("MaViTriTD", "Mã vị trí tuyển dụng");
            dataGridView1.Columns.Add("TrangThai", "Trạng thái hồ sơ");


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LoadData1();



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    if (cell.Value == null)
                    {
                        return;
                    }

                    MessageBox.Show($"Duyệt hồ sơ của ứng viên {cell.OwningRow.Cells[1].Value.ToString()}");
                    dataGridView1.Refresh();
                    string query = "update HoSo set TrangThai = @TrangThai where MaHoSo = @MaHoSo";

                    using (SqlConnection conn = new SqlConnection(ConString))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@MaHoSo", cell.OwningRow.Cells[0].Value.ToString());
                            command.Parameters.AddWithValue("@TrangThai", "Duyệt 1");
                            command.ExecuteNonQuery();
                        }

                        string query1 =
                            "INSERT INTO LichPhongVan (MaUngVien)\nSELECT U.MaUngVien\nFROM UngVien U\nJOIN HoSo H ON U.MaUngVien = H.MaUngVien\nWHERE H.MaHoSo = @MaHoSo;";
                        using (SqlCommand command = new SqlCommand(query1, conn))
                        {
                            command.Parameters.AddWithValue("@MaHoSo", cell.OwningRow.Cells[0].Value.ToString());
                            command.ExecuteNonQuery();
                        }
                    }
                    LoadData1();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    if (cell.Value == null)
                    {
                        return;
                    }

                    MessageBox.Show($"Hủy duyệt hồ sơ {cell.OwningRow.Cells[0].Value.ToString()}");
                    dataGridView1.Rows.Clear();
                    string query = "update HoSo set TrangThai = @TrangThai where MaHoSo = @MaHoSo";
                    using (SqlConnection conn = new SqlConnection(ConString))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@MaHoSo", cell.OwningRow.Cells[0].Value.ToString());
                            command.Parameters.AddWithValue("@TrangThai", "");
                            command.ExecuteNonQuery();
                        }

                        string query1 =
                            "UPDATE LichPhongVan\r\nSET MaUngVien = NULL\r\nFROM LichPhongVan L\r\nJOIN HoSo H ON L.MaUngVien = H.MaUngVien\r\nJOIN UngVien U ON H.MaUngVien = U.MaUngVien\r\nWHERE H.MaHoSo = @MaHoSo;";
                        using (SqlCommand command = new SqlCommand(query1, conn))
                        {
                            command.Parameters.AddWithValue("@MaHoSo", cell.OwningRow.Cells[0].Value.ToString());
                            command.ExecuteNonQuery();
                        }
                    }

                }
                LoadData1();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Recruiter_LienLac lienlac = new Recruiter_LienLac();
            lienlac.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recruiter_DangTin dangTin = new Recruiter_DangTin();
            dangTin.ShowDialog();
            this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recruiter nhanvien = new Recruiter();
            nhanvien.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
