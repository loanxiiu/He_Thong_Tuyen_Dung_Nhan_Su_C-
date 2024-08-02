using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLTD;
using DTO_QLTD;

namespace BUS_QLTD
{
    public class BUS_InterviewSchedule
    {
        InterviewScheduleAccess lichAccess = new InterviewScheduleAccess();

        public string InsertlichPV(DTO_InterviewSchedule lich)
        {
            if (lich.DepartmentEmployeeID == null)
            {
                return "required_DepartmentEmployeeID";
            }

            if (lich.InterviewDate == "")
            {
                return "required_InterviewDate";
            }
            if (lich.InterviewTime == "")
            {
                return "required_InterviewTime";
            }
            if (lich.Location == "")
            {
                return "required_Location";
            }
            string info = lichAccess.InsertLichPV(lich);
            return info;
        }

        public string UpdateLichPV(DTO_InterviewSchedule lich)
        {

            if (lich.DepartmentEmployeeID == "")
            {
                return "required_DepartmentEmployeeID";
            }

            if (lich.InterviewDate == "")
            {
                return "required_InterviewDate";
            }
            if (lich.InterviewTime == "")
            {
                return "required_InterviewTime";
            }
            if (lich.Location == "")
            {
                return "required_Location";
            }
            string info = lichAccess.UpdateLichPV(lich);
            return info;
        }

        public string DeleteLichPV(DTO_InterviewSchedule lich)
        {
            string info = lichAccess.DeleteLichPV(lich);
            return info;
        }
    }
}