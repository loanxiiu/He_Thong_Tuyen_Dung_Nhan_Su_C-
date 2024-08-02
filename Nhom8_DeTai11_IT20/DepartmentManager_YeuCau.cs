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
using BUS_QLTD;
using DTO_QLTD;

namespace Nhom8_DeTai11_IT20
{
    public partial class DepartmentManager_YeuCau : Form
    {
        DTO_RecruitmentDetails chitietTTTD = new DTO_RecruitmentDetails();
        BUS_RecruitmentDetails busChitietTTTD = new BUS_RecruitmentDetails();

        public DepartmentManager_YeuCau()
        {
            InitializeComponent();
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = SystemColors.Control;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = SystemColors.InactiveCaption;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = SystemColors.Control;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = SystemColors.InactiveCaption;

        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = SystemColors.Control;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = SystemColors.InactiveCaption;
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = SystemColors.Control;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = SystemColors.InactiveCaption;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            DepartmentManager quanly = new DepartmentManager();
            quanly.Show();
            this.Hide();
            quanly.FormClosed += (s, args) => { this.Close(); };
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            DepartmentManager_ViTriTD vitri = new DepartmentManager_ViTriTD();
            vitri.Show();
            this.Hide();
            vitri.FormClosed += (s, args) => { this.Close(); };
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            DepartmentManager_HoSo hoso = new DepartmentManager_HoSo();
            hoso.Show();
            this.Hide();
            hoso.FormClosed += (s, args) => { this.Close(); };
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

        public List<BoPhan> Data { get; set; } = new List<BoPhan>();

        public class BoPhan
        {
            public string MaVTTD { get; set; }
            public string TenBoPhan { get; set; }
        }

        private void DepartmentManager_YeuCau_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("MaCTTTTD", "MaCTTTTD");
            dataGridView1.Columns.Add("MaTTTD", "MaTTTD");
            dataGridView1.Columns.Add("TenViTriTD", "Tên vị trí TD");
            dataGridView1.Columns.Add("MucLuong", "Mức lương");
            dataGridView1.Columns.Add("HocVan", "Học vấn");
            dataGridView1.Columns.Add("KyNang", "Kỹ năng");
            dataGridView1.Columns.Add("KinhNghiem", "Kinh nghiệm");
            dataGridView1.Columns.Add("MoTaCongViec", "Mô tả công việc");
            dataGridView1.Columns.Add("ThoiHan", "Thời hạn");


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.InactiveCaption;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            LoadData();

            // ComboBoxValue
            string query = "Select * from ThongTinTuyenDung T join BoPhan B on T.MaBoPhan = B.MaBoPhan";
            using (SqlConnection conn = SqlConnectionData.Connection())
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        comboBox1.Items.Add(row["MaTTTD"].ToString());
                        BoPhan boPhan = new BoPhan();
                        boPhan.MaVTTD = row["MaTTTD"].ToString();
                        boPhan.TenBoPhan = row["TenBoPhan"].ToString();
                        Data.Add(boPhan);
                    }
                }
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (BoPhan bophan in Data)
            {
                if (comboBox1.Text == bophan.MaVTTD)
                {
                    textBox2.Text = bophan.TenBoPhan;
                }
            }
        }
        public void RefreshTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "";
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox3.Clear();
        }

        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            string query =
                "select * from ChiTietThongTinTuyenDung";

            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@TrangThai", "Duyệt");
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["MaCTTTTD"],
                        row["MaTTTD"],
                        row["TenViTriTD"],
                        row["MucLuong"],
                        row["HocVan"],
                        row["KyNang"],
                        row["KinhNghiem"],
                        row["MoTaCongViec"],
                        row["ThoiHan"]

                    );
                }
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            RefreshTextBox();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            chitietTTTD.MaCTTTTD = textBox1.Text;
            chitietTTTD.MaTTTD = comboBox1.Text;
            chitietTTTD.TenViTriTD = textBox3.Text;
            chitietTTTD.MucLuong = textBox4.Text;
            chitietTTTD.HocVan = textBox5.Text;
            chitietTTTD.KyNang = textBox6.Text;
            chitietTTTD.KinhNghiem = textBox7.Text;
            chitietTTTD.MoTaCongViec = textBox8.Text;
            chitietTTTD.ThoiHan = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            string insertInfo = busChitietTTTD.insertCTTT(chitietTTTD);
            switch (insertInfo)
            {
                case "Required_MaCTTTTD":
                    MessageBox.Show("Mã chi tiết thông tin tyển dụng không được để trống");
                    return;
                case "Required_MaTTTD":
                    MessageBox.Show("Mã thông tin tyển dụng không được để trống");
                    return;
                case "Required_MaViTriTD":
                    MessageBox.Show("M? v? tr? th?ng tin ty?n d?ng kh?ng ???c ?? tr?ng");
                    return;
            }

            MessageBox.Show("Thêm thành công");
            LoadData();
            RefreshTextBox();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (cell.OwningRow.Cells[0].Value?.ToString() != string.Empty)
                {
                    try
                    {
                        chitietTTTD.MaCTTTTD = cell.OwningRow.Cells[0].Value?.ToString() ?? string.Empty;
                        chitietTTTD.MaTTTD = cell.OwningRow.Cells[1].Value?.ToString() ?? string.Empty;
                        chitietTTTD.TenViTriTD = cell.OwningRow.Cells[2].Value?.ToString() ?? string.Empty;
                        chitietTTTD.MucLuong = cell.OwningRow.Cells[3].Value?.ToString() ?? string.Empty;
                        chitietTTTD.HocVan = cell.OwningRow.Cells[4].Value?.ToString() ?? string.Empty;
                        chitietTTTD.KyNang = cell.OwningRow.Cells[5].Value?.ToString() ?? string.Empty;
                        chitietTTTD.KinhNghiem = cell.OwningRow.Cells[6].Value?.ToString() ?? string.Empty;
                        chitietTTTD.MoTaCongViec = cell.OwningRow.Cells[7].Value?.ToString() ?? string.Empty;
                        chitietTTTD.ThoiHan = cell.OwningRow.Cells[8].Value?.ToString() ?? string.Empty;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"{exception.Message}");
                        continue;
                    }
                    string updateInfo = busChitietTTTD.updateCTTT(chitietTTTD);
                    switch (updateInfo)
                    {
                        case "Required_MaCTTTTD":
                            MessageBox.Show("Mã chi tiết thông tin tuyển dụng không thay đổi được");
                            LoadData();
                            return;
                        case "Required_MaTTTD":
                            MessageBox.Show("Mã Thông tin tuyển dụng không được bỏ trống");
                            return;
                        case "Required_MaViTriTD":
                            MessageBox.Show("Mã Vị trí tuyển dụng không được bỏ trống");
                            return;
                        case "Required_MucLuong":
                            MessageBox.Show("Mức lương không được bỏ trống");
                            return;
                        case "Required_HocVan":
                            MessageBox.Show("Học vấn không được bỏ trống");
                            return;
                        case "Required_KyNang":
                            MessageBox.Show("Kỹ năng không được bỏ trống");
                            return;
                        case "Required_KinhNghiem":
                            MessageBox.Show("Kinh nghiệm không được bỏ trống");
                            return;
                        case "Required_MoTaCongViec":
                            MessageBox.Show("Mô tả công việc không được bỏ trống");
                            return;
                        case "Required_ThoiHan":
                            MessageBox.Show("Thời hạn không được bỏ trống");
                            return;
                    }

                    MessageBox.Show("Sửa thành công");
                    LoadData();
                    break;
                }
                else
                {
                    return;
                }
            }
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    chitietTTTD.MaCTTTTD = cell.OwningRow.Cells[0].Value.ToString();
                    MessageBox.Show($"Xóa dòng {cell.RowIndex + 1} thành công");
                    busChitietTTTD.deleteCTTT(chitietTTTD);
                    LoadData();
                }
            }
            else{return;}
        }
    }
}
