using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    // Ứng viên (Applicant)
    public interface IApplicant : IUser
    {
         string Address { get; set; }
         string Status { get; set; } // Applied, Interviewing, Hired, Rejected

    }
}
