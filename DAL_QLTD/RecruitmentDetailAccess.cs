using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLTD;

namespace DAL_QLTD
{
    public class RecruitmentDetailAccess : DAL_DatabaseAccess
    {
        public string InsertCTTT(DTO_RecruitmentDetails cttttd)
        {
            string info = InsertCTTTTD(cttttd);
            return info;
        }

        public string updateCTTT(DTO_RecruitmentDetails cttttd)
        {
            string info = updateCTTTTD(cttttd);
            return info;
        }

        public string deleteCTTT(DTO_RecruitmentDetails cttttd)
        {
            string info = deleteCTTTTD(cttttd);
            return info;
        }
    }
}