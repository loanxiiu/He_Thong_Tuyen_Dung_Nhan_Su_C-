using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    // Lịch phỏng vấn (InterviewSchedule)
    public class DTO_InterviewSchedule
    {
        public int InterviewID { get; set; }
        public int ApplicantID { get; set; }
        public string DepartmentEmployeeID { get; set; }
        public string InterviewDate { get; set; }
        public string InterviewTime { get; set; }
        public string Location { get; set; }
    }
}