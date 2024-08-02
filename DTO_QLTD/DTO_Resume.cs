using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTD
{
    public class DTO_Resume : IResume
    {
        public string ResumeId { get; set; }
        public string ApplicantId { get; set; } // Link to IApplicant
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
    }
}