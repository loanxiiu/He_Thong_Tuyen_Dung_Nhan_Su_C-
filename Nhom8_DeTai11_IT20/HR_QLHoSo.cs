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
    public partial class HR_QLHoSo : Form
    {
        public string ConString = "Data Source=ACER;Initial Catalog=QLTD;Integrated Security=True;Encrypt=False";
        public HR_QLHoSo()
        {
            InitializeComponent();
        }


        public void LoadData1()
        {
            dataGridView1.Rows.Clear();
            string query = "select * from HoSo where TrangThai = @TrangThai";
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@TrangThai", "Duyệt 3");

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
            string query = "select * from HoSo where TrangThai = @TrangThai";
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@TrangThai", "Tuyển dụng");

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
                            command.Parameters.AddWithValue("@TrangThai", "Tuyển dụng");
                            command.ExecuteNonQuery();
                        }
                    }
                    LoadData1();
                    LoadData2();
                }
            }
        }

        private void HR_QLHoSo_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("MaHoSo", "Mã hồ sơ");
            dataGridView1.Columns.Add("MaUngVien", "Mã ứng viên");
            dataGridView1.Columns.Add("KyNang", "Kỹ năng");
            dataGridView1.Columns.Add("KinhNghiem", "Kinh nghiệm");
            dataGridView1.Columns.Add("HocVan", "Học vấn");
            dataGridView1.Columns.Add("MaViTriTD", "Mã vị trí tuyển dụng");
            dataGridView1.Columns.Add("TrangThai", "Trạng thái hồ sơ");


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
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


            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LoadData2();
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
                            command.Parameters.AddWithValue("@TrangThai", "Duyệt 3");
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
