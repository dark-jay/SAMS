using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;

namespace Student_Attendance_Management_System
{
    class AttendanceDb
    {
        public static SqlCeConnection getConnection()
        {
            string connStr = @"Data Source=SamsDbCe.sdf; Password=stayAwayNor1willKilly@";
            SqlCeConnection conn = new SqlCeConnection(connStr);
            return conn;
        }

        // Get all record only for single student where RollNo = rollNo and Status = P
        public List<Attendance> GetAttendance(string rollNo, string tblName)
        {
            List<Attendance> attendances = new List<Attendance>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [RollNo], [Date], [Status] FROM " + tblName + " where [RollNo] = @RollNo and [Status] = 'P'";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("RollNo", SqlDbType.NVarChar, 50).Value = rollNo;
            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Attendance a = new Attendance();

                    //s.Id = (int)reader["Id"];
                    a.RollNo = reader["RollNo"].ToString();
                    a.Date = (DateTime)reader["Date"];
                    a.Status = reader["Status"].ToString();
                    
                    attendances.Add(a);
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

            return attendances;
        }

        // returns the attendance list with only one value, TotalClass where EmailId = EmailId (Teacher's EmailId)
        public List<Attendance> GetTotalClass(string emailId, string tblName)
        {
            List<Attendance> attendances = new List<Attendance>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [TotalClass] FROM " + tblName + " where [EmailId] = @EmailId";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = emailId;
            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Attendance a = new Attendance();

                    a.TotalClass = (int)reader["TotalClass"];
                    
                    attendances.Add(a);
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

            return attendances;
        }

        // Insert Attendance into database // this method has some issue with inserting data into db
        // so im commenting it
        /*
        public int InsertAttendance(List<Attendance> attendances, string tblName) //tbName = tblname2(it should be in case u forgot jay)
        {
            int i;
            Attendance a;
            SqlConnection connection = getConnection();
            string selectStatement = "INSERT INTO dbo." + tblName + " ([RollNo], [Date], [Status]) " + "VALUES (@RollNo, @Date, @Status)";
            SqlCommand command = new SqlCommand(selectStatement, connection);

            for (i = 0; i < attendances.Count; i++)
            {
                a = attendances[i];
                command.Parameters.Add("RollNo", SqlDbType.VarChar, 50).Value = a.RollNo;
                command.Parameters.Add("Date", SqlDbType.Date).Value = a.Date;
                command.Parameters.Add("Status", SqlDbType.VarChar, 1).Value = a.Status;

                connection.Open();
                return command.ExecuteNonQuery();
            }

            // this is for the last record, because if we wrap it in above loop, stupid c# through an error that every value should return something
            // so i just cut the last record into outside the loop
            
            a = attendances[i];
            command.Parameters.Add("RollNo", SqlDbType.VarChar, 50).Value = a.RollNo;
            command.Parameters.Add("Date", SqlDbType.Date).Value = a.Date;
            command.Parameters.Add("Status", SqlDbType.VarChar, 1).Value = a.Status;

            connection.Open();
            return command.ExecuteNonQuery();
            
        }
        */

        public int InsertAttendanceIntoDb(Attendance attendances, string tblName)
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "INSERT INTO " + tblName + " ([RollNo], [Date], [Status]) " + "VALUES (@RollNo, @Date, @Status)";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("RollNo", SqlDbType.NVarChar, 50).Value = attendances.RollNo;
            command.Parameters.Add("Date", SqlDbType.DateTime).Value = attendances.Date;
            command.Parameters.Add("Status", SqlDbType.NVarChar, 1).Value = attendances.Status;

            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
