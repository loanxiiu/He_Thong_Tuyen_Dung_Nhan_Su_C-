using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLTD;

namespace DAL_QLTD
{
    public class SqlConnectionData
    {
        public static SqlConnection Connection()
        {
            string strcon = @"Data Source=ACER;Initial Catalog=QLTD;Integrated Security=True;Encrypt=False";
            SqlConnection conn = new SqlConnection(strcon);
            return conn;
        }
    }

    public class DAL_DatabaseAccess
    {
        public static string CheckLogicDTO(DTO_Account taikhoan)
        {
            string user = null;

            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            SqlCommand command = new SqlCommand("proc_logic", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@user", taikhoan.UserName);
            command.Parameters.AddWithValue("@pass", taikhoan.Password);

            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(1);
                    taikhoan.MaTK = reader.GetInt32(0);
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                return "Tài khoản hoặc mật khẩu không chính xác!";
            }
            return user;
        }

        public static string ChangePassword(DTO_Account taikhoan)
        {
            string user = null;
            int tmp = 0;
            using (SqlConnection conn = SqlConnectionData.Connection())
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("proc_logic", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@user", taikhoan.UserName);
                    command.Parameters.AddWithValue("@pass", taikhoan.Password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tmp = reader.GetInt32(0);
                            }
                        }
                    }
                }

                if (tmp != 0)
                {
                    using (SqlConnection conn1 = SqlConnectionData.Connection())
                    {
                        conn1.Open();
                        using (SqlCommand command1 = new SqlCommand("proc_changePassword", conn1))
                        {
                            command1.CommandType = CommandType.StoredProcedure;
                            command1.Parameters.AddWithValue("@maTK", tmp);
                            command1.Parameters.AddWithValue("@newPassword", taikhoan.NewPassword);

                            command1.ExecuteNonQuery();
                            user = "Đổi mật khẩu thành công";
                        }
                    }
                }
                else
                {
                    user = "Mật khẩu không chính xác";
                }
                return user;
            }

        }


        public static string InsertViTriDTO(DTO_JobVacancy vitriTD)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query = "insert into ViTriTD values(@MaViTri, @TenViTri, @SoLuong, @MaBoPhan)";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaViTri", vitriTD.MaVT);
                command.Parameters.AddWithValue("@TenViTri", vitriTD.TenVT);
                command.Parameters.AddWithValue("@SoLuong", vitriTD.SoLuong);
                command.Parameters.AddWithValue("@MaBoPhan", vitriTD.MaBoPhan);
                command.ExecuteNonQuery();
                conn.Close();
                text = "Thêm thành công!";
                return text;
            }
        }

        public static string UpdateViTriDTO(DTO_JobVacancy vitriTD)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query = "update ViTriTD set TenViTriTD = @TenViTri, SoLuong = @SoLuong, MaBoPhan = @MaBoPhan where MaViTriTD = @MaViTri";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaViTri", vitriTD.MaVT);
                command.Parameters.AddWithValue("@TenViTri", vitriTD.TenVT);
                command.Parameters.AddWithValue("@SoLuong", vitriTD.SoLuong);
                command.Parameters.AddWithValue("@MaBoPhan", vitriTD.MaBoPhan);
                command.ExecuteNonQuery();
                conn.Close();
                text = "Sửa thành công!";
                return text;
            }
        }

        public static string DeleteViTriDTO(DTO_JobVacancy vitriTD)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query = "delete from ViTriTD where MaViTriTD = @MaViTri";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaViTri", vitriTD.MaVT);
                command.ExecuteNonQuery();
                conn.Close();
                text = "Xóa thành công!";
                return text;
            }
        }

        public static string InsertLichPhongVan(DTO_InterviewSchedule lichPhongVan)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query = "update LichPhongVan set MaNVPV = @DepartmentEmployeeID, NgayPhongVan = @InterviewDate, ThoiGianPV = @InterviewTime, DiaDiem = @Location where MaPhongVan = @MaPV";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaPV", lichPhongVan.InterviewID);
                command.Parameters.AddWithValue("@DepartmentEmployeeID", lichPhongVan.DepartmentEmployeeID);
                command.Parameters.AddWithValue("@InterviewDate", lichPhongVan.InterviewDate);
                command.Parameters.AddWithValue("@InterviewTime", lichPhongVan.InterviewTime);
                command.Parameters.AddWithValue("@Location", lichPhongVan.Location);
                command.ExecuteNonQuery();
                conn.Close();
                text = "Thêm thành công";
                return text;
            }
        }

        public static string UpdateLichPhongVan(DTO_InterviewSchedule lichPhongVan)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query = "update LichPhongVan set MaNVPV = @DepartmentEmployeeID, NgayPhongVan = @InterviewDate, ThoiGianPV = @InterviewTime, DiaDiem = @Location where MaPhongVan = @MaPV";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaPV", lichPhongVan.InterviewID);
                command.Parameters.AddWithValue("@DepartmentEmployeeID", lichPhongVan.DepartmentEmployeeID);
                command.Parameters.AddWithValue("@InterviewDate", lichPhongVan.InterviewDate);
                command.Parameters.AddWithValue("@InterviewTime", lichPhongVan.InterviewTime);
                command.Parameters.AddWithValue("@Location", lichPhongVan.Location);
                command.ExecuteNonQuery();
                conn.Close();
                text = "Sửa thành công!";
                return text;
            }
        }

        public static string DeleteLichPhongVan(DTO_InterviewSchedule lichPhongVan)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query = "update LichPhongVan set MaNVPV = @DepartmentEmployeeID, NgayPhongVan = @InterviewDate, ThoiGianPV = @InterviewTime, DiaDiem = @Location where MaPhongVan = @MaPV";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaPV", lichPhongVan.InterviewID);
                command.Parameters.AddWithValue("@DepartmentEmployeeID", (object)DBNull.Value);
                command.Parameters.AddWithValue("@InterviewDate", "");
                command.Parameters.AddWithValue("@InterviewTime", "");
                command.Parameters.AddWithValue("@Location", "");
                command.ExecuteNonQuery();
                conn.Close();
                text = "Xóa thành công";
                return text;
            }

        }
        public static string InsertCTTTTD(DTO_RecruitmentDetails recruitmentDetails)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query =
                "insert into ChiTietThongTinTuyenDung values (@MaCTTTTD, @MaTTTD, @TenViTriTD, @MucLuong, @HocVan, @KyNang, @KinhNghiem, @MoTaCongViec, @ThoiHan)";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaCTTTTD", recruitmentDetails.MaCTTTTD);
                command.Parameters.AddWithValue("@MaTTTD", recruitmentDetails.MaTTTD);
                command.Parameters.AddWithValue("@MaViTriTD", recruitmentDetails.TenViTriTD);
                command.Parameters.AddWithValue("@MucLuong", recruitmentDetails.MucLuong);
                command.Parameters.AddWithValue("@HocVan", recruitmentDetails.HocVan);
                command.Parameters.AddWithValue("@KyNang", recruitmentDetails.KyNang);
                command.Parameters.AddWithValue("@KinhNghiem", recruitmentDetails.KinhNghiem);
                command.Parameters.AddWithValue("@MoTaCongViec", recruitmentDetails.MoTaCongViec);
                command.Parameters.AddWithValue("@ThoiHan", recruitmentDetails.ThoiHan);
                command.ExecuteNonQuery();
                conn.Close();
                text = "Thêm thành công!";
                return text;
            }
        }

        public static string updateCTTTTD(DTO_RecruitmentDetails recruitmentDetails)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query =
                "update ChiTietThongTinTuyenDung set MaTTTD = @MaTTTD, TenViTriTD = @TenViTriTD, MucLuong = @MucLuong, HocVan = @HocVan, KyNang = @KyNang, KinhNghiem = @KinhNghiem, MoTaCongViec = @MoTaCongViec, ThoiHan = @ThoiHan where MaCTTTTD = @MaCTTTTD";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaCTTTTD", recruitmentDetails.MaCTTTTD);
                command.Parameters.AddWithValue("@MaTTTD", recruitmentDetails.MaTTTD);
                command.Parameters.AddWithValue("@MaViTriTD", recruitmentDetails.TenViTriTD);
                command.Parameters.AddWithValue("@MucLuong", recruitmentDetails.MucLuong);
                command.Parameters.AddWithValue("@HocVan", recruitmentDetails.HocVan);
                command.Parameters.AddWithValue("@KyNang", recruitmentDetails.KyNang);
                command.Parameters.AddWithValue("@KinhNghiem", recruitmentDetails.KinhNghiem);
                command.Parameters.AddWithValue("@MoTaCongViec", recruitmentDetails.MoTaCongViec);
                command.Parameters.AddWithValue("@ThoiHan", recruitmentDetails.ThoiHan);
                command.ExecuteNonQuery();
                conn.Close();
                text = "Sửa thành công!";
                return text;
            }
        }

        public static string deleteCTTTTD(DTO_RecruitmentDetails recruitmentDetails)
        {
            string text = null;
            SqlConnection conn = SqlConnectionData.Connection();
            conn.Open();
            string query = "delete from ChiTietThongTinTuyenDung where MaCTTTTD = @MaCTTTTD";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@MaCTTTTD", recruitmentDetails.MaCTTTTD);
                command.ExecuteNonQuery();
                conn.Close();
                text = "Xóa thành công!";
                return text;
            }
        }
    }
}
