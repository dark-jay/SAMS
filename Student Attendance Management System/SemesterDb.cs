using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;

namespace Student_Attendance_Management_System
{
    class SemesterDb
    {
        public static SqlCeConnection getConnection()
        {
            string connStr = @"Data Source=SamsDbCe.sdf; Password=stayAwayNor1willKilly@";
            SqlCeConnection conn = new SqlCeConnection(connStr);
            return conn;
        }

        // Returns entire tblSemester match EmailId Records, if there is any,
        public List<Semester> GetSemester()
        {
            List<Semester> semestersList = new List<Semester>(); // in earlier saved projects, semeseterList is called semesters

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [Year], [Semester], [Subject] FROM tblSemester where [EmailId] = '" + CurrentUserDetails.EmailId + "'";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Semester s = new Semester();

                    //s.Id = (int)reader["Id"]; // identity spec is true

                    // there is an error with the below if condition, fix it while rest of the project is done
                    // don't forget jay, whos jay???? ohh its me :) !!!!

                    //if (!reader.IsDBNull(2)) // 2 is the column index of Year
                    //{
                        s.Year = (int)reader["Year"];
                    //}
                    //if (!reader.IsDBNull(3))
                    //{
                        s.MySemester = (int)reader["Semester"];
                    //}
                    //if (!reader.IsDBNull(4))
                    //{
                        s.Subject = reader["Subject"].ToString();
                    //}
                    semestersList.Add(s);
                }
                reader.Close();
            }
            catch (SqlCeException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return semestersList;
        }

        public int InsertSemester(Semester semesters)
        {
            //CurrentUserDetails cu = new CurrentUserDetails(); we dont need any new object since it has now become static

            SqlCeConnection connection = getConnection();
            string selectStatement = "INSERT INTO tblSemester ([EmailId], [Year], [Semester], [Subject]) " + "VALUES (@EmailId, @Year, @Semester, @Subject)";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = CurrentUserDetails.EmailId;
            command.Parameters.Add("Year", SqlDbType.Int).Value = semesters.Year;
            command.Parameters.Add("Semester", SqlDbType.Int).Value = semesters.MySemester;
            command.Parameters.Add("Subject", SqlDbType.NVarChar, 50).Value = semesters.Subject;

            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
