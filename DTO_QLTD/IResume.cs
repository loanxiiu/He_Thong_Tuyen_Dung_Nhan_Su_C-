using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    // Interface cho CV
    public interface IResume
    {
        string ResumeId { get; set; }
        string ApplicantId { get; set; } // Link to IApplicant
        string Education { get; set; }
        string Experience { get; set; }
        string Skills { get; set; }
    }
}
