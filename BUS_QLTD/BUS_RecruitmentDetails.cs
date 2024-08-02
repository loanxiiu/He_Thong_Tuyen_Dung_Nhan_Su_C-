using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLTD;
using DTO_QLTD;

namespace BUS_QLTD
{
    public class BUS_RecruitmentDetails
    {
        RecruitmentDetailAccess detailAccess = new RecruitmentDetailAccess();

        public string insertCTTT(DTO_RecruitmentDetails recruitmentDetails)
        {
            if (string.IsNullOrEmpty(recruitmentDetails.MaCTTTTD))
            {
                return "Required_MaCTTTTD";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.MaTTTD))
            {
                return "Required_MaTTTD";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.TenViTriTD))
            {
                return "Required_MaViTriTD";
            }

            string info = detailAccess.InsertCTTT(recruitmentDetails);
            return info;
        }

        public string updateCTTT(DTO_RecruitmentDetails recruitmentDetails)
        {
            if (string.IsNullOrEmpty(recruitmentDetails.MaCTTTTD))
            {
                return "Required_MaCTTTTD";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.MaTTTD))
            {
                return "Required_MaTTTD";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.TenViTriTD))
            {
                return "Required_MaViTriTD";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.MucLuong))
            {
                return "Required_MucLuong";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.HocVan))
            {
                return "Required_HocVan";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.KyNang))
            {
                return "Required_KyNang";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.KinhNghiem))
            {
                return "Required_KinhNghiem";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.MoTaCongViec))
            {
                return "Required_MoTaCongViec";
            }

            if (string.IsNullOrEmpty(recruitmentDetails.ThoiHan))
            {
                return "Required_ThoiHan";
            }

            string info = detailAccess.updateCTTT(recruitmentDetails);
            return info;
        }

        public string deleteCTTT(DTO_RecruitmentDetails recruitmentDetails)
        {
            string info = detailAccess.deleteCTTT(recruitmentDetails);
            return info;
        }
    }
}
