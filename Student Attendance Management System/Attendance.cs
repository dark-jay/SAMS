using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Attendance_Management_System
{
    class Attendance
    {
        public string RollNo { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int TotalClass { get; set; }
        public int TotalAttended { get; set; }
        public int TotalMissed { get; set; }
    }
}
