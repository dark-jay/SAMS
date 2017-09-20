using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Attendance_Management_System
{
    public static class CurrentUserDetails
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string EmailId { get; set; }
        public static string TblName1 { get; set; } // Student table
        public static string TblName2 { get; set; } // Attendance table
        public static string TblName3 { get; set; } // ClassEvent table
        public static int CurrentYear { get; set; }
        public static int CurrentSemester { get; set; }
        public static string CurrentSubject { get; set; }

        public static void ResetAllProperties()
        {
            FirstName = null;
            LastName = null;
            EmailId = null;
            TblName1 = null;
            TblName2 = null;
            TblName3 = null;
            CurrentYear = 0;
            CurrentSemester = 0;
            CurrentSubject = null;
        }
    }
}
