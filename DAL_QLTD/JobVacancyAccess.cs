using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLTD;

namespace DAL_QLTD
{
    public class JobVacancyAccess : DAL_DatabaseAccess
    {
        public string InsertViTriTD(DTO_JobVacancy vitri)
        {
            string info = InsertViTriDTO(vitri);
            return info;
        }

        public string UpdateViTriTD(DTO_JobVacancy vitri)
        {
            string info = UpdateViTriDTO(vitri);
            return info;
        }
        public string DeleteViTriTD(DTO_JobVacancy vitri)
        {
            string info = DeleteViTriDTO(vitri);
            return info;
        }
    }
}