using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLTD;

namespace DAL_QLTD
{
    public class InterviewScheduleAccess : DAL_DatabaseAccess
    {
        public string InsertLichPV(DTO_InterviewSchedule lichphongvan)
        {
            string info = InsertLichPhongVan(lichphongvan);
            return info;
        }

        public string UpdateLichPV(DTO_InterviewSchedule lichphongvan)
        {
            string info = UpdateLichPhongVan(lichphongvan);
            return info;
        }

        public string DeleteLichPV(DTO_InterviewSchedule lichphongvan)
        {
            string info = DeleteLichPhongVan(lichphongvan);
            return info;
        }
    }
}