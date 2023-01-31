using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLee.Models
{
    public class DLLinformation
    {
        public string filename = "";

        public bool HasDebuggableAttribute = false;
        public bool IsJITOptimized = false;
        public bool IsJITTrackingEnabled = false;
        public string BuildType = "";
        public string DebugOutput = "";

        public bool x86 = false;
        public string procArch = "";
        public bool CodeSigned = false;
        public string CodeSignerName = "";

        //public bool Signed = false;
        //public string CertificateSigner = "";

        public int SizeInKB = 0;

        public string exception_info = "";//error message when info failure occurs.
    }
}
