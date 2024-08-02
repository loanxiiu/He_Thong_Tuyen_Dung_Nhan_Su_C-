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
    public partial class DepartmentEmployee_DuyetHoSo : Form
    {
        public string TK { get; set; }

        public DepartmentEmployee_DuyetHoSo(string tk)
        {
            InitializeComponent();
            TK = tk;

        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = SystemColors.Control;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.DarkSeaGreen;
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
            panel6.BackColor = SystemColors.Control;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.DarkSeaGreen;
        }


        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = SystemColors.Control;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.DarkSeaGreen;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            DepartmentEmployee employee = new DepartmentEmployee(TK);
            employee.Show();
            this.Hide();
            employee.FormClosed += (s, args) =>
            {
                this.Close();
            };
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            DepartmentEmployee_LichPhongVan lich = new DepartmentEmployee_LichPhongVan(TK);
            lich.Show();
            lich.FormClosed += (s, args) =>
            {
                this.Close();
            };
        }

        private void panel5_Click(object sender, EventArgs e)
        {

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

        public void LoadData1()
        {
            dataGridView1.Rows.Clear();
            string query = "select * from HoSo H join UngVien U on H.MaUngVien = U.MaUngVien join LichPhongVan L on U.MaUngVien = L.MaUngVien where H.TrangThai = @TrangThai and L.MaNVPV = @MaNVPV";
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@TrangThai", "Duyệt 1");
                command.Parameters.AddWithValue("@MaNVPV", TK);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
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
        }

        public void LoadData2()
        {
            dataGridView2.Rows.Clear();
            string query = "select * from HoSo H join UngVien U on H.MaUngVien = U.MaUngVien join LichPhongVan L on U.MaUngVien = L.MaUngVien where H.TrangThai = @TrangThai and L.MaNVPV = @MaNVPV";
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@TrangThai", "Duyệt 2");
                command.Parameters.AddWithValue("@MaNVPV", TK);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView2.Rows.Add(
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
        }

        private void DepartmentEmployee_DuyetHoSo_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("MaHoSo", "Mã hồ sơ");
            dataGridView1.Columns.Add("MaUngVien", "Mã ứng viên");
            dataGridView1.Columns.Add("KyNang", "Kỹ năng");
            dataGridView1.Columns.Add("KinhNghiem", "Kinh nghiệm");
            dataGridView1.Columns.Add("HocVan", "Học vấn");
            dataGridView1.Columns.Add("MaViTriTD", "Mã vị trí tuyển dụng");
            dataGridView1.Columns.Add("TrangThai", "Trạng thái hồ sơ");


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LoadData1();

            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("MaHoSo", "Mã hồ sơ");
            dataGridView2.Columns.Add("MaUngVien", "Mã ứng viên");
            dataGridView2.Columns.Add("KyNang", "Kỹ năng");
            dataGridView2.Columns.Add("KinhNghiem", "Kinh nghiệm");
            dataGridView2.Columns.Add("HocVan", "Học vấn");
            dataGridView2.Columns.Add("MaViTriTD", "Mã vị trí tuyển dụng");
            dataGridView2.Columns.Add("TrangThai", "Trạng thái hồ sơ");


            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LoadData2();
        }

        public string ConString = "Data Source=ACER;Initial Catalog=QLTD;Integrated Security=True;Encrypt=False";

        private void rjButton1_Click(object sender, EventArgs e)
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
                            command.Parameters.AddWithValue("@TrangThai", "Duyệt 2");
                            command.ExecuteNonQuery();
                        }
                    }
                    LoadData1();
                    LoadData2();
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
                {
                    if (cell.Value == null)
                    {
                        return;
                    }

                    MessageBox.Show($"Hủy duyệt hồ sơ {cell.OwningRow.Cells[0].Value.ToString()}");
                    dataGridView2.Rows.Clear();
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
                    }
                }
                LoadData2();
                LoadData1();
            }
        }
    }
}
