using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.DTO
{
    public class DTO
    {
        public string ticker { get; set; }
        public int queryCount { get; set; }
        public int resultsCount { get; set; }
        public bool adjusted { get; set; }
        public List<DTOResult> results { get; set; }
    }
    public class DTOResult
    {
        public string v { get; set; }
        public string vw { get; set; }
        public string o { get; set; }
        public string c { get; set; }
        public string h { get; set; }
        public string l { get; set; }
        public string t { get; set; }
        public string n { get; set; }
    }
}
