using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLTD;
using DTO_QLTD;

namespace BUS_QLTD
{
    public class BUS_JobVacancy
    {
        JobVacancyAccess vitriAccess = new JobVacancyAccess();
        public string InsertVitiTD(DTO_JobVacancy vitri)
        {
            if (vitri.MaVT == "")
            {
                return "required_mavitri";
            }
            if (vitri.TenVT == "")
            {
                return "required_tenvitri";
            }
            if (vitri.SoLuong == "")
            {
                return "required_soluong";
            }
            string info = vitriAccess.InsertViTriTD(vitri);
            return info;
        }
        public string UpdateVitiTD(DTO_JobVacancy vitri)
        {
            if (vitri.MaVT == "")
            {
                return "required_mavitri";
            }
            if (vitri.TenVT == "")
            {
                return "required_tenvitri";
            }
            if (vitri.SoLuong == "")
            {
                return "required_soluong";
            }

            if (vitri.SoLuong == "")
            {
                return "required_mabophan";
            }
            string info = vitriAccess.UpdateViTriTD(vitri);
            return info;
        }

        public string DeleteViTriTD(DTO_JobVacancy vitri)
        {
            string info = vitriAccess.DeleteViTriTD((vitri));
            return info;
        }
    }
}