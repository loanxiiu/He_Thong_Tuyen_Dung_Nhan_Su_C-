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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nhom8_DeTai11_IT20
{
    public partial class DepartmentEmployee_LichPhongVan : Form
    {
        public string TK { get; set; }

        public DepartmentEmployee_LichPhongVan(string tk)
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

        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query =
                "select * from LichPhongVan L join UngVien U on L.MaUngVien = U.MaUngVien join HoSo H on U.MaUngVien = H.MaUngVien where H.TrangThai = @TrangThai and MaNVPV =@MaNVPV";

            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@TrangThai", "Duyệt 1");
                command.Parameters.AddWithValue("@MaNVPV", TK);
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["MaPhongVan"],
                        row["MaUngVien"],
                        row["MaViTriTD"],
                        row["MaNVPV"],
                        row["NgayPhongVan"],
                        row["ThoiGianPV"],
                        row["DiaDiem"],
                        row["TrangThai"]
                    );
                }
            }
        }

        private void DepartmentEmployee_LichPhongVan_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("MaPhongVan", "Mã phỏng vấn");
            dataGridView1.Columns.Add("MaUngVien", "Mã ứng viên");
            dataGridView1.Columns.Add("MaViTriTD", "Mã vị trí TD");
            dataGridView1.Columns.Add("MaNVPV", "Mã nhân viên phỏng vấn");
            dataGridView1.Columns.Add("NgayPhongVan", "Ngày phỏng vấn");
            dataGridView1.Columns.Add("ThoiGianPV", "Thời gian");
            dataGridView1.Columns.Add("DiaDiem", "Địa điểm");
            dataGridView1.Columns.Add("TrangThai", "Trạng thái");


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            LoadData();
        }

        public string ConString = "Data Source=ACER;Initial Catalog=QLTD;Integrated Security=True;Encrypt=False";

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {

                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    if (string.IsNullOrEmpty(cell.OwningRow.Cells[7].Value.ToString()))
                    {
                        MessageBox.Show($"Duyệt lịch {cell.OwningRow.Cells[0].Value.ToString()}");
                        dataGridView1.Rows.Clear();
                        string query = "update LichPhongVan set TrangThai = @TrangThai where MaPhongVan = @MaPhongVan";

                        using (SqlConnection conn = new SqlConnection(ConString))
                        {
                            conn.Open();
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("@MaPhongVan", cell.OwningRow.Cells[0].Value.ToString());
                                command.Parameters.AddWithValue("@TrangThai", "Đồng ý");
                                command.ExecuteNonQuery();
                            }
                        }
                        LoadData();
                    }
                    else
                    {
                        if (cell.Value == null)
                        {
                            return;
                        }

                        MessageBox.Show($"Hủy duyệt lịch {cell.OwningRow.Cells[0].Value.ToString()}");
                        dataGridView1.Rows.Clear();
                        string query = "update LichPhongVan set TrangThai = @TrangThai where MaPhongVan = @MaPhongVan";

                        using (SqlConnection conn = new SqlConnection(ConString))
                        {
                            conn.Open();
                            using (SqlCommand command = new SqlCommand(query, conn))
                            {
                                command.Parameters.AddWithValue("@MaPhongVan", cell.OwningRow.Cells[0].Value.ToString());
                                command.Parameters.AddWithValue("@TrangThai", "");
                                command.ExecuteNonQuery();
                            }
                        }
                        LoadData();
                    }
                }
            }
        }
    }
}
