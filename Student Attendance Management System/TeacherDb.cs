using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;

namespace Student_Attendance_Management_System
{
    class TeacherDb
    {
        public static SqlCeConnection getConnection()
        {
            string connStr = @"Data Source=SamsDbCe.sdf; Password=stayAwayNor1willKilly@";
            SqlCeConnection conn = new SqlCeConnection(connStr);
            return conn;
        }

        // returns single record by emailId and password
        public List<Teacher> GetSingleRecordByName(string emailId, string password)
        {
            List<Teacher> teachers = new List<Teacher>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT EmailId, FirstName, LastName, [Password] FROM tblTeacher " + "WHERE EmailId = @EmailId and Password = @Password";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = emailId;
            //command.Parameters.AddWithValue("EmailId", emailId);
            command.Parameters.Add("Password", SqlDbType.NVarChar, 50).Value = password;
            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Teacher t = new Teacher();

                    t.EmailId = reader["EmailId"].ToString();

                    if (!reader.IsDBNull(1)) // 1 is the column index of FirstName
                    {
                        t.FirstName = reader["FirstName"].ToString();
                    }
                    if (!reader.IsDBNull(2))
                    {
                        t.LastName = reader["LastName"].ToString();
                    }

                    t.Password = reader["password"].ToString();

                    teachers.Add(t);
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

            return teachers;
        }

        public int InsertTeacher(Teacher teachers)
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "INSERT INTO tblTeacher (EmailId, FirstName, LastName, Password) " + "VALUES (@EmailId, @FirstName, @LastName, @Password)";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = teachers.EmailId;

            object dbFirstName = teachers.FirstName;
            if (dbFirstName == null)
            {
                dbFirstName = DBNull.Value;
            }
            command.Parameters.Add("FirstName", SqlDbType.NVarChar, 50).Value = dbFirstName;

            object dbLastName = teachers.LastName;
            if (dbLastName == null)
            {
                dbLastName = DBNull.Value;
            }
            command.Parameters.Add("LastName", SqlDbType.NVarChar, 50).Value = dbLastName;

            command.Parameters.Add("Password", SqlDbType.NVarChar, 50).Value = teachers.Password;

            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
