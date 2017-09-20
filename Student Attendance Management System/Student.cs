using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Attendance_Management_System
{
    class Student
    {
        public string FirstName { get; set; } // not null
        public string LastName { get; set; } // not null
        public string MiddleName { get; set; }
        public string RollNo { get; set; } // not null
        public string Gender { get; set; } // not null
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public int FirstTermMarks { get; set; }
        public int MidTermMarks { get; set; }
        public int EndTermMarks { get; set; }
        public int ClassesAttended { get; set; } // this is not used
    }
}
