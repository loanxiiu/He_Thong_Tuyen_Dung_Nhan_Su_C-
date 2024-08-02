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
using BUS_QLTD;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Web;
using DAL_QLTD;
using DTO_QLTD;

namespace Nhom8_DeTai11_IT20
{
    public partial class HR_lichPhongVan : Form
    {
        DTO_InterviewSchedule lich = new DTO_InterviewSchedule();
        BUS_InterviewSchedule busLich = new BUS_InterviewSchedule();
        public HR_lichPhongVan()
        {
            InitializeComponent();
        }

        private void HR_lichPhongVan_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("MaPhongVan", "Mã phỏng vấn");
            dataGridView1.Columns.Add("MaUngVien", "Mã ứng viên");
            dataGridView1.Columns.Add("MaViTriTD", "Mã vị trí TD");
            dataGridView1.Columns.Add("MaNVPV", "Mã nhân viên phỏng vấn");
            dataGridView1.Columns.Add("NgayPhongVan", "Ngày phỏng vấn");
            dataGridView1.Columns.Add("ThoiGianPV", "Thời gian");
            dataGridView1.Columns.Add("DiaDiem", "Địa điểm");

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            LoadData();
            string query = "select * from NhanVienBoPhan";
            using (SqlConnection conn = SqlConnectionData.Connection())
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        comboBox1.Items.Add(row["MaNVPV"].ToString() + " : " + row["TenNV"].ToString());
                    }
                }
            }
        }

        public void LoadData()
        {
            dataGridView1.Rows.Clear();

            using (SqlConnection conn = SqlConnectionData.Connection())
            {
                string query2 = "select * from LichPhongVan L join UngVien U on L.MaUngVien = U.MaUngVien join HoSo H on U.MaUngVien = H.MaUngVien";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query2, conn))
                {
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
                            row["DiaDiem"]
                        );
                    }
                    conn.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Mã nhân viên phòng ván không được để trống");
                    return;
                }
                else
                {
                    string[] chuoi = comboBox1.Text.Split(':');
                    lich.DepartmentEmployeeID = chuoi[0].Trim();
                }
                lich.InterviewID = Convert.ToInt32(cell.OwningRow.Cells[0].Value.ToString());
                lich.InterviewDate = textBox1.Text;
                lich.InterviewTime = textBox2.Text;
                lich.Location = textBox3.Text;
                string insertInfo = busLich.InsertlichPV(lich);
                switch (insertInfo)
                {
                    case "required_DepartmentEmployeeID":
                        MessageBox.Show("Mã nhân viên phòng ván không được để trống");
                        return;
                    case "required_InterviewDate":
                        MessageBox.Show("Ngày phỏng vấn không được để trống");
                        return;
                    case "required_InterviewTime":
                        MessageBox.Show("Thời gian phỏng vấn không được để trống");
                        return;
                    case "required_Location":
                        MessageBox.Show("Địa điểm phỏng vấn không được để trống");
                        return;
                }
                MessageBox.Show("Thêm thành công");
                LoadData();
                RefreshTextBox();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (string.IsNullOrEmpty(cell.OwningRow.Cells[0].Value?.ToString()))
                {
                    return;
                }
                else
                {
                    try
                    {
                        lich.InterviewID = Convert.ToInt32(cell.OwningRow.Cells[0].Value?.ToString() ?? "0");
                        lich.ApplicantID = Convert.ToInt32(cell.OwningRow.Cells[1].Value?.ToString() ?? "0");
                        lich.DepartmentEmployeeID = cell.OwningRow.Cells[3].Value?.ToString() ?? string.Empty;
                        lich.InterviewDate = cell.OwningRow.Cells[4].Value?.ToString() ?? string.Empty;
                        lich.InterviewTime = cell.OwningRow.Cells[5].Value?.ToString() ?? string.Empty;
                        lich.Location = cell.OwningRow.Cells[6].Value?.ToString() ?? string.Empty;
                    }
                    catch (Exception ec)
                    {
                        MessageBox.Show($"{ec.Message}");
                        continue;
                    }

                    string updateInfo = busLich.UpdateLichPV(lich);
                    //MessageBox.Show($"{updateInfo}");

                    switch (updateInfo)
                    {
                        case "required_DepartmentEmployeeID":
                            MessageBox.Show("Mã nhân viên phỏng vấn không được để trống");
                            LoadData();
                            return;
                        case "required_InterviewDate":
                            MessageBox.Show("Ngày phỏng vấn không được để trống");
                            return;
                        case "required_InterviewTime":
                            MessageBox.Show("Thời gian phỏng vấn không được để trống");
                            return;
                        case "required_Location":
                            MessageBox.Show("Địa điểm phỏng vấn không được để trống");
                            return;

                    }
                    MessageBox.Show("Sửa thành công");
                    break;
                }
            }
            LoadData();
        }
        public void RefreshTextBox()
        {
            comboBox1.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Items.Clear(); // Clear existing items
            if (e.RowIndex >= 0)
            {
                using (SqlConnection conn = SqlConnectionData.Connection())
                {
                    conn.Open();
                    DataGridViewRow rowSelect = dataGridView1.Rows[e.RowIndex];

                    // Retrieve the MaViTriTD value from the selected row
                    string maViTriTD = rowSelect.Cells[2].Value?.ToString();

                    if (!string.IsNullOrEmpty(maViTriTD))
                    {
                        // Define the query to get the necessary data
                        string query = @"
                    select N.MaNVPV, N.TenNV 
                    from NhanVienBoPhan N 
                    join BoPhan B on N.MaBoPhan = B.MaBoPhan 
                    join ViTriTD V on B.MaBoPhan = V.MaBoPhan
                    where V.MaViTriTD = @MaViTriTD";

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            // Add parameter to the query
                            command.Parameters.AddWithValue("@MaViTriTD", maViTriTD);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                comboBox1.Items.Clear(); // Clear existing items

                                while (reader.Read())
                                {
                                    comboBox1.Items.Add(reader["MaNVPV"].ToString() + " : " + reader["TenNV"].ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Text;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                MessageBox.Show("Cột này không sửa được");
                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    lich.InterviewID = Convert.ToInt32(cell.OwningRow.Cells[0].Value?.ToString() ?? "0");
                    busLich.DeleteLichPV(lich);
                    LoadData();
                    MessageBox.Show($"Xóa lịch thành công");
                }
            }
            else { return; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintReport print = new PrintReport();
            print.ShowDialog();
        }
    }
}
