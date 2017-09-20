using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;

namespace Student_Attendance_Management_System
{
    class StudentDb
    {
        public static SqlCeConnection getConnection()
        {
            string connStr = @"Data Source=SamsDbCe.sdf; Password=stayAwayNor1willKilly@";
            SqlCeConnection conn = new SqlCeConnection(connStr);
            return conn;
        }

        // Returns Entire Student Table
        public List<Student> GetStudent(string tblName)
        {
            List<Student> students = new List<Student>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [RollNo], [FirstName], [LastName], [MiddleName], [Gender], [EmailId], [PhoneNo], [FirstTermMarks], [MidTermMarks], [EndTermMarks], [ClassesAttended] FROM " + tblName;
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();

                    //s.Id = (int)reader["Id"];
                    s.RollNo = reader["RollNo"].ToString();
                    s.FirstName = reader["FirstName"].ToString();
                    s.LastName = reader["LastName"].ToString();
                    if (!reader.IsDBNull(3)) // 3 is the column index of MiddleName
                    {
                        s.MiddleName = reader["MiddleName"].ToString();
                    }
                    s.Gender = reader["Gender"].ToString();
                    if (!reader.IsDBNull(5))
                    {
                        s.EmailId = reader["EmailId"].ToString();
                    }
                    if (!reader.IsDBNull(6))
                    {
                        s.PhoneNo = reader["PhoneNo"].ToString();
                    }
                    if (!reader.IsDBNull(7))
                    {
                        s.FirstTermMarks = (int)reader["FirstTermMarks"];
                    }
                    if (!reader.IsDBNull(8))
                    {
                        s.MidTermMarks = (int)reader["MidTermMarks"];
                    }
                    if (!reader.IsDBNull(9))
                    {
                        s.EndTermMarks = (int)reader["EndTermMarks"];
                    }
                    if (!reader.IsDBNull(10))
                    {
                        s.ClassesAttended = (int)reader["ClassesAttended"];
                    }
                    students.Add(s);
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


            return students;
        }


        // Insert Record into student table
        public int InsertStudent(Student students, string tblName)
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "INSERT INTO " + tblName + " ([RollNo], [FirstName], [LastName], [MiddleName], [Gender], [EmailId], [PhoneNo], [FirstTermMarks], [MidTermMarks], [EndTermMarks]) " + "VALUES (@RollNo, @FirstName, @LastName, @MiddleName, @Gender, @EmailId, @PhoneNo, @FirstTermMarks, @MidTermMarks, @EndTermMarks)";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            try
            {
                command.Parameters.Add("RollNo", SqlDbType.NVarChar, 50).Value = students.RollNo;
                command.Parameters.Add("FirstName", SqlDbType.NVarChar, 50).Value = students.FirstName;
                command.Parameters.Add("LastName", SqlDbType.NVarChar, 50).Value = students.LastName;

                object dbMiddleName = students.MiddleName;
                if (dbMiddleName == null)
                {
                    dbMiddleName = DBNull.Value;
                }
                command.Parameters.Add("MiddleName", SqlDbType.NVarChar, 50).Value = dbMiddleName;

                command.Parameters.Add("Gender", SqlDbType.NVarChar, 10).Value = students.Gender;

                object dbEmailId = students.EmailId;
                if (dbEmailId == null)
                {
                    dbEmailId = DBNull.Value;
                }
                command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = dbEmailId;

                object dbPhoneNo = students.PhoneNo;
                if (dbPhoneNo == null)
                {
                    dbPhoneNo = DBNull.Value;
                }
                command.Parameters.Add("PhoneNo", SqlDbType.NVarChar, 12).Value = dbPhoneNo;

                object dbFirstTermMarks = students.FirstTermMarks;
                if (dbFirstTermMarks == null)
                {
                    dbFirstTermMarks = DBNull.Value;
                }
                command.Parameters.Add("FirstTermMarks", SqlDbType.Int).Value = dbFirstTermMarks;

                object dbMidTermMarks = students.MidTermMarks;
                if (dbMidTermMarks == null)
                {
                    dbMidTermMarks = DBNull.Value;
                }
                command.Parameters.Add("MidTermMarks", SqlDbType.Int).Value = dbMidTermMarks;

                object dbEndTermMarks = students.EndTermMarks;
                if (dbEndTermMarks == null)
                {
                    dbEndTermMarks = DBNull.Value;
                }
                command.Parameters.Add("EndTermMarks", SqlDbType.Int).Value = dbEndTermMarks;
                /*
                object dbClassesAttended = students.ClassesAttended;
                if (dbClassesAttended == null)
                {
                    dbClassesAttended = DBNull.Value;
                }
                command.Parameters.Add("ClassesAttended", SqlDbType.Int).Value = dbClassesAttended;
                */
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        // This Method will return the entire record of a student based on first name
        public List<Student> GetSingleRecordByName(string firstName, string tblName)
        {
            List<Student> students = new List<Student>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [RollNo], [FirstName], [LastName], [MiddleName], [Gender], [EmailId], [PhoneNo], [FirstTermMarks], [MidTermMarks], [EndTermMarks], [ClassesAttended] FROM " + tblName + " " + "WHERE FirstName = @FirstName";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            //command.Parameters.AddWithValue("FirstName", firstName);
            command.Parameters.Add("FirstName", SqlDbType.NVarChar, 50).Value = firstName;
            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();

                    s.RollNo = reader["RollNo"].ToString();
                    s.FirstName = reader["FirstName"].ToString();
                    s.LastName = reader["LastName"].ToString();
                    if (!reader.IsDBNull(3)) // 3 is the column index of MiddleName
                    {
                        s.MiddleName = reader["MiddleName"].ToString();
                    }
                    s.Gender = reader["Gender"].ToString();
                    if (!reader.IsDBNull(5))
                    {
                        s.EmailId = reader["EmailId"].ToString();
                    }
                    if (!reader.IsDBNull(6))
                    {
                        s.PhoneNo = reader["PhoneNo"].ToString();
                    }
                    if (!reader.IsDBNull(7))
                    {
                        s.FirstTermMarks = (int)reader["FirstTermMarks"];
                    }
                    if (!reader.IsDBNull(8))
                    {
                        s.MidTermMarks = (int)reader["MidTermMarks"];
                    }
                    if (!reader.IsDBNull(9))
                    {
                        s.EndTermMarks = (int)reader["EndTermMarks"];
                    }
                    if (!reader.IsDBNull(10))
                    {
                        s.ClassesAttended = (int)reader["ClassesAttended"];
                    }
                    students.Add(s);
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

            return students;
        }

        // This Method will return the entire record of a student based on first name and last name
        public List<Student> GetSingleRecordByFirstAndLastName(string firstName, string lastName, string tblName)
        {
            List<Student> students = new List<Student>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [RollNo], [FirstName], [LastName], [MiddleName], [Gender], [EmailId], [PhoneNo], [FirstTermMarks], [MidTermMarks], [EndTermMarks], [ClassesAttended] FROM " + tblName + " " + "WHERE FirstName = @FirstName AND LastName = @LastName";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            //command.Parameters.AddWithValue("FirstName", firstName);
            command.Parameters.Add("FirstName", SqlDbType.NVarChar, 50).Value = firstName;
            command.Parameters.Add("LastName", SqlDbType.NVarChar, 50).Value = lastName;
            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();

                    s.RollNo = reader["RollNo"].ToString();
                    s.FirstName = reader["FirstName"].ToString();
                    s.LastName = reader["LastName"].ToString();
                    if (!reader.IsDBNull(3)) // 3 is the column index of MiddleName
                    {
                        s.MiddleName = reader["MiddleName"].ToString();
                    }
                    s.Gender = reader["Gender"].ToString();
                    if (!reader.IsDBNull(5))
                    {
                        s.EmailId = reader["EmailId"].ToString();
                    }
                    if (!reader.IsDBNull(6))
                    {
                        s.PhoneNo = reader["PhoneNo"].ToString();
                    }
                    if (!reader.IsDBNull(7))
                    {
                        s.FirstTermMarks = (int)reader["FirstTermMarks"];
                    }
                    if (!reader.IsDBNull(8))
                    {
                        s.MidTermMarks = (int)reader["MidTermMarks"];
                    }
                    if (!reader.IsDBNull(9))
                    {
                        s.EndTermMarks = (int)reader["EndTermMarks"];
                    }
                    if (!reader.IsDBNull(10))
                    {
                        s.ClassesAttended = (int)reader["ClassesAttended"];
                    }
                    students.Add(s);
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

            return students;
        }

        // This Method will return the entire record of a student based on first name, middle name and last name
        public List<Student> GetSingleRecordByFirstAndMiddleAndLastName(string firstName, string middleName, string lastName, string tblName)
        {
            List<Student> students = new List<Student>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [RollNo], [FirstName], [LastName], [MiddleName], [Gender], [EmailId], [PhoneNo], [FirstTermMarks], [MidTermMarks], [EndTermMarks], [ClassesAttended] FROM " + tblName + " " + "WHERE FirstName = @FirstName AND MiddleName = @MiddleName AND LastName = @LastName";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            //command.Parameters.AddWithValue("FirstName", firstName);
            command.Parameters.Add("FirstName", SqlDbType.NVarChar, 50).Value = firstName;
            command.Parameters.Add("MiddleName", SqlDbType.NVarChar, 50).Value = middleName;
            command.Parameters.Add("LastName", SqlDbType.NVarChar, 50).Value = lastName;
            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();

                    s.RollNo = reader["RollNo"].ToString();
                    s.FirstName = reader["FirstName"].ToString();
                    s.LastName = reader["LastName"].ToString();
                    if (!reader.IsDBNull(3)) // 3 is the column index of MiddleName
                    {
                        s.MiddleName = reader["MiddleName"].ToString();
                    }
                    s.Gender = reader["Gender"].ToString();
                    if (!reader.IsDBNull(5))
                    {
                        s.EmailId = reader["EmailId"].ToString();
                    }
                    if (!reader.IsDBNull(6))
                    {
                        s.PhoneNo = reader["PhoneNo"].ToString();
                    }
                    if (!reader.IsDBNull(7))
                    {
                        s.FirstTermMarks = (int)reader["FirstTermMarks"];
                    }
                    if (!reader.IsDBNull(8))
                    {
                        s.MidTermMarks = (int)reader["MidTermMarks"];
                    }
                    if (!reader.IsDBNull(9))
                    {
                        s.EndTermMarks = (int)reader["EndTermMarks"];
                    }
                    if (!reader.IsDBNull(10))
                    {
                        s.ClassesAttended = (int)reader["ClassesAttended"];
                    }
                    students.Add(s);
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

            return students;
        }

        // This Method will return the entire record of a student based on Roll Number
        public List<Student> GetSingleRecordByRollNo(string rollNo, string tblName)
        {
            List<Student> students = new List<Student>();

            SqlCeConnection connection = getConnection();
            string selectStatement = "SELECT [RollNo], [FirstName], [LastName], [MiddleName], [Gender], [EmailId], [PhoneNo], [FirstTermMarks], [MidTermMarks], [EndTermMarks], [ClassesAttended] FROM " + tblName + " " + "WHERE RollNo = @RollNo";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            //command.Parameters.AddWithValue("FirstName", firstName);
            command.Parameters.Add("RollNo", SqlDbType.NVarChar, 50).Value = rollNo;
            try
            {
                connection.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();

                    s.RollNo = reader["RollNo"].ToString();
                    s.FirstName = reader["FirstName"].ToString();
                    s.LastName = reader["LastName"].ToString();
                    if (!reader.IsDBNull(3)) // 3 is the column index of MiddleName
                    {
                        s.MiddleName = reader["MiddleName"].ToString();
                    }
                    s.Gender = reader["Gender"].ToString();
                    if (!reader.IsDBNull(5))
                    {
                        s.EmailId = reader["EmailId"].ToString();
                    }
                    if (!reader.IsDBNull(6))
                    {
                        s.PhoneNo = reader["PhoneNo"].ToString();
                    }
                    if (!reader.IsDBNull(7))
                    {
                        s.FirstTermMarks = (int)reader["FirstTermMarks"];
                    }
                    if (!reader.IsDBNull(8))
                    {
                        s.MidTermMarks = (int)reader["MidTermMarks"];
                    }
                    if (!reader.IsDBNull(9))
                    {
                        s.EndTermMarks = (int)reader["EndTermMarks"];
                    }
                    if (!reader.IsDBNull(10))
                    {
                        s.ClassesAttended = (int)reader["ClassesAttended"];
                    }
                    students.Add(s);
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

            return students;
        }

        // Update old Student details
        public int UpdateStudent(Student students, string tblName)
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "UPDATE " + tblName + " SET [FirstName] = @FirstName," + " [MiddleName] = @MiddleName," + " [LastName] = @LastName," + " [Gender] = @Gender," + " [EmailId] = @EmailId," + " [PhoneNo] = @PhoneNo," + " [FirstTermMarks] = @FirstTermMarks," + " [MidTermMarks] = @MidTermMarks," + " [EndTermMarks] = @EndTermMarks" + " WHERE [RollNo] = @RollNo";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("RollNo", SqlDbType.NVarChar, 50).Value = students.RollNo;
            command.Parameters.Add("FirstName", SqlDbType.NVarChar, 50).Value = students.FirstName;
            command.Parameters.Add("LastName", SqlDbType.NVarChar, 50).Value = students.LastName;

            object dbMiddleName = students.MiddleName;
            if (dbMiddleName == null)
            {
                dbMiddleName = DBNull.Value;
            }
            command.Parameters.Add("MiddleName", SqlDbType.NVarChar, 50).Value = dbMiddleName;

            command.Parameters.Add("Gender", SqlDbType.NVarChar, 10).Value = students.Gender;

            object dbEmailId = students.EmailId;
            if (dbEmailId == null)
            {
                dbEmailId = DBNull.Value;
            }
            command.Parameters.Add("EmailId", SqlDbType.NVarChar, 256).Value = dbEmailId;

            object dbPhoneNo = students.PhoneNo;
            if (dbPhoneNo == null)
            {
                dbPhoneNo = DBNull.Value;
            }
            command.Parameters.Add("PhoneNo", SqlDbType.NVarChar, 12).Value = dbPhoneNo;

            object dbFirstTermMarks = students.FirstTermMarks;
            if (dbFirstTermMarks == null)
            {
                dbFirstTermMarks = DBNull.Value;
            }
            command.Parameters.Add("FirstTermMarks", SqlDbType.Int).Value = dbFirstTermMarks;

            object dbMidTermMarks = students.MidTermMarks;
            if (dbMidTermMarks == null)
            {
                dbMidTermMarks = DBNull.Value;
            }
            command.Parameters.Add("MidTermMarks", SqlDbType.Int).Value = dbMidTermMarks;

            object dbEndTermMarks = students.EndTermMarks;
            if (dbEndTermMarks == null)
            {
                dbEndTermMarks = DBNull.Value;
            }
            command.Parameters.Add("EndTermMarks", SqlDbType.Int).Value = dbEndTermMarks;

            connection.Open();
            return command.ExecuteNonQuery();
        }

        public int DeleteStudent(string rollNo, string tblName)
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "DELETE FROM " + tblName + " WHERE RollNo = @RollNo";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            command.Parameters.Add("RollNo", SqlDbType.NVarChar, 50).Value = rollNo;
            connection.Open();
            return command.ExecuteNonQuery();
        }

    }
}
