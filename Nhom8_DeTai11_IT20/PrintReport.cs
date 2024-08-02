using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Nhom8_DeTai11_IT20;

namespace Nhom8_DeTai11_IT20
{
    public partial class PrintReport : Form
    {
        public PrintReport()
        {
            InitializeComponent();
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=ACER;Initial Catalog=QLTD;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaPhongVan, MaUngVien, MaNVPV, NgayPhongVan, ThoiGianPV, DiaDiem FROM LichPhongVan", conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Ensure that the DataTable has rows
                        if (dataTable.Rows.Count > 0)
                        {
                            // Load the Crystal Report
                            CrystalReport1 report = new CrystalReport1();
                            report.Database.Tables["LichPhongVan"].SetDataSource(dataTable);

                            // Set the report source for the viewer
                            crystalReportViewer1.ReportSource = report;
                            crystalReportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("No data available for the report.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // This method can be used to perform additional tasks when the viewer loads
        }
    }
}
