using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.Info
{
    public class UserInfo
    {
        public string B64finger { get; set; }
        public int MachineNumber { get; set; }
        public string EnrollNumber { get; set; }
        public string Name { get; set; }
        public int FingerIndex { get; set; }
        public string TmpData { get; set; }
        public int Privelage { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public string iFlag { get; set; }
        public List<FingerUser> Fingers { get; set; }
    }
}
