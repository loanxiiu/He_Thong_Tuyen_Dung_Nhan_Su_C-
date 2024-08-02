using DAL_QLTD;
using DTO_QLTD;
using BUS_QLTD;
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
using System.Collections;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Nhom8_DeTai11_IT20
{
    public partial class HR_QuanLyViTriTuyenDung : Form
    {
        DTO_JobVacancy vitri = new DTO_JobVacancy();
        BUS_JobVacancy busViTri = new BUS_JobVacancy();
        public HR_QuanLyViTriTuyenDung()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query = "select * from ViTriTD";

            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(
                    row["MaViTriTD"],
                    row["TenViTriTD"],
                    row["SoLuong"],
                    row["MaBoPhan"]
                );
            }
        }

        public void RefreshTextBox()
        {
            textBox1.Clear();
            comboBox2.Text = "";
            textBox3.Clear();
            comboBox1.Text = "";
        }

        private void HR_QuanLyViTriTuyenDung_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Ma", "Mã");
            dataGridView1.Columns.Add("ViTri", "Vị trí");
            dataGridView1.Columns.Add("SoLuong", "Số lượng");
            dataGridView1.Columns.Add("MaBoPhan", "Mã bộ phận");

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LoadData();

            // comboBox1 Value

            using (SqlConnection conn = SqlConnectionData.Connection())
            {
                conn.Open();
                string query = "select * from BoPhan";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        comboBox1.Items.Add(row[0].ToString() + " : " + row[1].ToString());
                    }
                }
            }

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string[] ttbophan = comboBox1.Text.Split(':');

            using (SqlConnection conn = SqlConnectionData.Connection())
            {
                conn.Open();
                //comboBox2 Value
                string query = "select * from ChiTietThongTinTuyenDung C join ThongTinTuyenDung T on C.MaTTTD = T.MaTTTD Where MaBoPhan = @MaBoPhan";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaBoPhan", ttbophan[0].Trim());
                    command.ExecuteNonQuery();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox2.Items.Add(row["TenViTriTD"].ToString());
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] ttbophan = comboBox1.Text.Split(':');

            vitri.MaBoPhan = ttbophan[0].Trim();
            vitri.MaVT = textBox1.Text;
            vitri.TenVT = comboBox2.Text;
            vitri.SoLuong = textBox3.Text;

            string insertInfo = busViTri.InsertVitiTD(vitri);
            switch (insertInfo)
            {
                case "required_mavitri":
                    MessageBox.Show("Mã vị trí không được để trống");
                    return;
                case "required_tenvitri":
                    MessageBox.Show("Tên vị trí không được để trống");
                    return;
                case "required_soluong":
                    MessageBox.Show("Số lượng không được để trống");
                    return;
            }
            MessageBox.Show("Thêm thành công");
            LoadData();
            RefreshTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value?.ToString() != string.Empty)
                {
                    try
                    {
                        vitri.MaVT = row.Cells[0].Value?.ToString() ?? string.Empty;
                        vitri.TenVT = row.Cells[1].Value?.ToString() ?? string.Empty;
                        vitri.SoLuong = row.Cells[2].Value?.ToString() ?? string.Empty;
                        vitri.MaBoPhan = row.Cells[3].Value?.ToString() ?? string.Empty;

                    }
                    catch (Exception ec)
                    {
                        MessageBox.Show($"{ec.Message}");
                        continue;
                    }

                    string updateInfo = busViTri.UpdateVitiTD(vitri);
                    //row.Cells[0].Value = tmp;

                    switch (updateInfo)
                    {
                        case "required_mavitri":
                            MessageBox.Show("Mã vị trí không sửa được");
                            LoadData();
                            return;
                        case "required_tenvitri":
                            MessageBox.Show("Tên vị trí không được để trống");
                            return;
                        case "required_soluong":
                            MessageBox.Show("Số lượng không được để trống");
                            return;
                        case "required_mabophan":
                            MessageBox.Show("Mã bộ phận không được để trống");
                            return;
                    }

                    MessageBox.Show("Sửa thành công");
                    break;
                    LoadData();
                }
                else
                {
                    return;

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    vitri.MaVT = cell.OwningRow.Cells[0].Value.ToString();
                    MessageBox.Show($"Xóa dòng {cell.RowIndex + 1} thành công");
                    busViTri.DeleteViTriTD(vitri);
                    LoadData();
                }
            }
            else { return; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshTextBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                bool found = false;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Selected = false;

                    if (row.IsNewRow) continue; // Bỏ qua hàng mới trống

                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        comboBox2.Text = row.Cells[1].Value?.ToString();
                        textBox3.Text = row.Cells[2].Value?.ToString();
                        row.Selected = true;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    MessageBox.Show($"Ma vi tri {textBox1.Text} khong ton tai");
                }
            }
            else
            {
                return;
            }
        }



    }
}
