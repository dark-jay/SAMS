using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;

namespace Student_Attendance_Management_System
{
    class ClassEventDb
    {
        public static SqlCeConnection getConnection()
        {
            string connStr = @"Data Source=SamsDbCe.sdf; Password=stayAwayNor1willKilly@";
            SqlCeConnection conn = new SqlCeConnection(connStr);
            return conn;
        }

        // Returns The FirstTermTotal, MidTermTotal and EndTermTotal where EmailId = EmailId 
        public List<ClassEvent> GetTotalMarksOfEachTerm(string emailId, string tblName)
        {
            List<ClassEvent> classEvents = new List<ClassEvent>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [FirstTermTotalMarks], [MidTermTotalMarks], [EndTermTotalMarks] FROM " + tblName + " where [EmailId] = @EmailId";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = emailId;
            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ClassEvent c = new ClassEvent();

                    c.FirstTermTotal = (int)reader["FirstTermTotalMarks"];
                    c.MidTermTotal = (int)reader["MidTermTotalMarks"];
                    c.EndTermTotal = (int)reader["EndTermTotalMarks"];

                    classEvents.Add(c);
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

            return classEvents;
        }

        // update the total class in class event database
        public int UpdateTotalClass(int totalClass, string tblName) // tblName3 = class event table
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "UPDATE " + tblName + " SET [TotalClass] = @TotalClass" + " WHERE [EmailId] = @EmailId";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = CurrentUserDetails.EmailId;
            command.Parameters.Add("TotalClass", SqlDbType.Int).Value = totalClass;

            connection.Open();
            return command.ExecuteNonQuery();
        }

        // update 1st, 2nd and 3rd term total marks
        public int UpdateTermTotalMarks(int firstTermTotalMarks, int midTermTotalMarks, int endTermTotalMarks, string tblName) // tblName3 = class event table
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "UPDATE " + tblName + " SET [FirstTermTotalMarks] = @FirstTermTotalMarks," + " [MidTermTotalMarks] = @MidTermTotalMarks," + " [EndTermTotalMarks] = @EndTermTotalMarks" + " WHERE [EmailId] = @EmailId";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = CurrentUserDetails.EmailId;
            command.Parameters.Add("FirstTermTotalMarks", SqlDbType.Int).Value = firstTermTotalMarks;
            command.Parameters.Add("MidTermTotalMarks", SqlDbType.Int).Value = midTermTotalMarks;
            command.Parameters.Add("EndTermTotalMarks", SqlDbType.Int).Value = endTermTotalMarks;

            connection.Open();
            return command.ExecuteNonQuery();
        }

        // Insert Only one single record in class event table automatically by grabbing the EmailId from current user
        public int InsertSingleClassEventRecord(string tblName)
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "INSERT INTO " + tblName + " (EmailId, TotalClass, FirstTermTotalMarks, MidTermTotalMarks, EndTermTotalMarks) " + "VALUES (@EmailId, @TotalClass, @FirstTermTotalMarks, @MidTermTotalMarks, @EndTermTotalMarks)";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = CurrentUserDetails.EmailId;

            command.Parameters.Add("TotalClass", SqlDbType.Int).Value = 0;

            command.Parameters.Add("FirstTermTotalMarks", SqlDbType.Int).Value = 20;

            command.Parameters.Add("MidTermTotalMarks", SqlDbType.Int).Value = 20;

            command.Parameters.Add("EndTermTotalMarks", SqlDbType.Int).Value = 20;

            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
