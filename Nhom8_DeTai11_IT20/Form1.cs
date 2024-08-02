using BUS_QLTD;
using DAL_QLTD;
using DTO_QLTD;
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
    public partial class Form1 : Form
    {
        DTO_Account taikhoan = new DTO_Account();
        BUS_Account BUSTK = new BUS_Account();
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            taikhoan.UserName = textBox1.Text;
            taikhoan.Password = textBox2.Text;

            string getuser = BUSTK.CheckLogic(taikhoan);

            switch (getuser)
            {
                case "1": // admin
                    Admin admin = new Admin();
                    admin.Show();
                    this.Hide();
                    textBox1.Clear();
                    textBox2.Clear();
                    return;
                case "2":// QLBP
                    DepartmentManager departmentManager = new DepartmentManager();
                    departmentManager.Show();
                    this.Hide();
                    textBox1.Clear();
                    textBox2.Clear();
                    return;
                case "3":
                    HR hR = new HR(textBox1.Text);
                    hR.Show();
                    this.Hide();
                    textBox1.Clear();
                    textBox2.Clear();
                    return;
                case "4":
                    Recruiter recruiter = new Recruiter();
                    recruiter.Show();
                    this.Hide();
                    textBox1.Clear();
                    textBox2.Clear();
                    return;
                case "5":
                    string Taikhoan = "";
                    using (SqlConnection conn = SqlConnectionData.Connection())
                    {
                        conn.Open();
                        string query = "select * NhanVienBoPhan where MaTK = @MaTK";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@MaTK", taikhoan.MaTK);
                            command.ExecuteNonQuery();
                            command.Connection = conn;
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Taikhoan = reader.GetString(0);
                                }
                            }
                        }
                    }
                    DepartmentEmployee employee = new DepartmentEmployee(Taikhoan);
                    employee.Show();
                    this.Hide();
                    textBox1.Clear();
                    textBox2.Clear();
                    return;
                case "6": return;
                case "requeid_taikhoan":
                    MessageBox.Show("Tài khoản không được để trống");
                    return;

                case "requeid_password":
                    MessageBox.Show("Mật khẩu không được để trống");
                    return;

                case "Tài khoản hoặc mật khẩu không chính xác!":
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
                    return;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
