using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;

namespace Student_Attendance_Management_System
{
    class CreatTable
    {
        public static SqlCeConnection getConnection()
        {
            string connStr = @"Data Source=SamsDbCe.sdf; Password=stayAwayNor1willKilly@";
            SqlCeConnection conn = new SqlCeConnection(connStr);
            return conn;
        }

        public void CreatStudentTable(string tblName1)
        {
            SqlCeConnection connection = getConnection(); //  'table1') " +
            string selectStatement = "create table [" + tblName1 + "] " +
                                        "( " +
                                        "[RollNo] nvarchar(50) not null primary key, " +
                                        "[FirstName] nvarchar(50) not null, " +
                                        "[LastName] nvarchar(50) not null, " +
                                        "[MiddleName] nvarchar(50) null, " +
                                        "[Gender] nvarchar(10) not null, " +
                                        "[EmailId] nvarchar(256) null, " +
                                        "[PhoneNo] nvarchar(12) null, " +
                                        "[FirstTermMarks] int null, " +
                                        "[MidTermMarks] int null, " +
                                        "[EndTermMarks] int null, " +
                                        "[ClassesAttended] int null " +
                                        ")"; //+
                                        //"GO " +
                                        //"ALTER TABLE " + tblName1 + " ADD CONSTRAINT PK_" + tblName1 + " PRIMARY KEY (RollNo); " +
                                        //"GO";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            try
            {
                connection.Open();
                //System.Windows.Forms.MessageBox.Show("Im gonna create the student table");
                command.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("Succesfully Created The Table"); //no need, user will get annoyed if it pops up that hey You have created the table :(
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
        public void CreatAttendancetable(string tblName1, string tblName2) // tblName1=tblStudent tblAttendance=tblName2
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "create table [" + tblName2 + "] " +
                                        "( " +
                                        "[Id] int identity(1,1) not null primary key, " +
                                        "[RollNo] nvarchar(50) not null references [" + tblName1 + "] ([RollNo]), " +
                                        "[Date] datetime not null, " +
                                        "[Status] nvarchar(1) not null " +
                                        ")"; //+
                                        //"GO " +
                                        //"ALTER TABLE [" + tblName2 + "] ADD CONSTRAINT [PK_" + tblName2 + "] PRIMARY KEY ([Id]); " +
                                        //"GO " +
                                        //"ALTER TABLE[" + tblName2 + "] ADD CONSTRAINT [FK_" + tblName2 + "_" + tblName1 + "] FOREIGN KEY ([RollNo]) REFERENCES [" + tblName1 + "] ([RollNo]) ON DELETE NO ACTION ON UPDATE NO ACTION;" +
                                        //"GO";
                                        //"alter table " + tblName2 + " add constraint FK_" + tblName2 + "_" + tblName1 + " foreign key (RollNo) references " + tblName1 + "(RollNo)";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            try
            {
                connection.Open();
                //System.Windows.Forms.MessageBox.Show("Im gonna create the Attendance table");
                command.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("Succesfully Created The Table");
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
        
        public void CreateClassEventTable(string tblName4) // tblName1=tblStudent tblAttendance=tblName2
        {
            SqlCeConnection connection = getConnection();
            string selectStatement = "create table [" + tblName4 + "] " +
                                        "( " +
                                        "[Id] int identity(1,1) not null primary key, " +
                                        "[EmailId] nvarchar(256) not null references [tblTeacher] ([EmailId]), " +
                                        "[TotalClass] int null, " +
                                        "[FirstTermTotalMarks] int null, " +
                                        "[MidTermTotalMarks] int null, " +
                                        "[EndTermTotalMarks] int null " +
                                        ")"; //+
                                        //"GO " +
                                        //"ALTER TABLE [" + tblName4 + "] ADD CONSTRAINT [PK_" + tblName4 + "] PRIMARY KEY ([Id]) " +
                                        //"GO " +
                                        //"ALTER TABLE[" + tblName4 + "] ADD CONSTRAINT [FK_" + tblName4 + "_tblTeacher] FOREIGN KEY ([EmailId]) REFERENCES [tblTeacher] ([EmailId]) ON DELETE NO ACTION ON UPDATE NO ACTION;" +
                                        //"GO";
                                        //alter table " + tblName4 + " add constraint FK_" + tblName4 + "_tblTeacher foreign key (EmailId) references tblTeacher(EmailId)";
            SqlCeCommand command = new SqlCeCommand(selectStatement, connection);

            try
            {
                connection.Open();
                //System.Windows.Forms.MessageBox.Show("Im gonna create the class event table");
                command.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("Succesfully Created The Table");
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

    }
}
