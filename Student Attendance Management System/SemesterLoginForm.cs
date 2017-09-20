using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Attendance_Management_System
{
    public partial class SemesterLoginForm : Form
    {
        SemesterDb sdb;
        CreatTable ct;
        ClassEventDb cdb;
        public SemesterLoginForm()
        {
            InitializeComponent();
            sdb = new SemesterDb();
            ct = new CreatTable();
            cdb = new ClassEventDb();
        }
        public Size size { get; set; }

        private void btnExitSemLogin_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name != "SemesterLoginForm")
                    f.Close();
            }
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Semester s = new Semester();
            lblStatusOfNewSemAdd.Text = "";

            string tblName1;
            string tblName2;
            string tblName3;

            if (txtYearNewSem.Text != "" && txtSemesterNewSem.Text != "" && txtSubjectNewSem.Text != "")
            {
                s.Year = Convert.ToInt32(txtYearNewSem.Text);
                s.MySemester = Convert.ToInt32(txtSemesterNewSem.Text);
                s.Subject = txtSubjectNewSem.Text;
                sdb.InsertSemester(s);

                // load the recently added semester details in combo box
                LoadSemestersFromDb();

                // give the name of the tables to the table name variables
                tblName1 = "tblStudent_" + s.Year.ToString() + "_" + s.MySemester.ToString() + "_" + s.Subject;
                tblName2 = "tblAttendance_" + s.Year.ToString() + "_" + s.MySemester.ToString() + "_" + s.Subject;
                tblName3 = "tblClassEvent_" + s.Year.ToString() + "_" + s.MySemester.ToString() + "_" + s.Subject;

                // Create the table
                ct.CreatStudentTable(tblName1);
                ct.CreatAttendancetable(tblName1, tblName2);
                ct.CreateClassEventTable(tblName3);

                // Insert the one and only single record into the class event table amongs three tables
                cdb.InsertSingleClassEventRecord(tblName3);

                // Final Status by the mighty jay that table has created
                lblStatusOfNewSemAdd.Text = "Successfully Added the Semester";
            }
            else
            {
                lblStatusOfNewSemAdd.Text = "Please fill all the box :)";
            }
        }

        private void timerAddNewSemPanel_Tick(object sender, EventArgs e)
        {
            if (panelAddNewSemester.Height == 130)
            {
                timerAddNewSemPanel.Stop();
            }
            panelAddNewSemester.Height += 2;
        }

        private void btnAddNewSemester_Click_1(object sender, EventArgs e)
        {
            timerAddNewSemPanel.Start();
        }

        // This method will directly take us to the main window
        // when this method is called, it will sets the current user detail's table name according to it
        private void btnSemesterLogIn_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (comboBoxYear.Text != "" && comboBoxSemester.Text != "" && comboBoxSubject.Text != "")
            {
                List<Semester> semestersList;

                semestersList = sdb.GetSemester();
                if (semestersList.Count > 0)
                {
                    Semester s;
                    for (int i = 0; i < semestersList.Count; i++)
                    {
                        s = semestersList[i];
                        if (comboBoxYear.Text == s.Year.ToString() && comboBoxSemester.Text == s.MySemester.ToString() && comboBoxSubject.Text == s.Subject)
                        {
                            flag = 1;
                        }
                    }
                }

                if (flag == 1)
                {
                    CurrentUserDetails.CurrentYear = Convert.ToInt32(comboBoxYear.Text);
                    CurrentUserDetails.CurrentSemester = Convert.ToInt32(comboBoxSemester.Text);
                    CurrentUserDetails.CurrentSubject = comboBoxSubject.Text;

                    CurrentUserDetails.TblName1 = "tblStudent_" + CurrentUserDetails.CurrentYear.ToString() + "_" + CurrentUserDetails.CurrentSemester.ToString() + "_" + CurrentUserDetails.CurrentSubject;
                    CurrentUserDetails.TblName2 = "tblAttendance_" + CurrentUserDetails.CurrentYear.ToString() + "_" + CurrentUserDetails.CurrentSemester.ToString() + "_" + CurrentUserDetails.CurrentSubject;
                    CurrentUserDetails.TblName3 = "tblClassEvent_" + CurrentUserDetails.CurrentYear.ToString() + "_" + CurrentUserDetails.CurrentSemester.ToString() + "_" + CurrentUserDetails.CurrentSubject;

                    this.Hide();
                    FinalMainForm finalMainForm = new FinalMainForm();
                    finalMainForm.Show();
                }
                else
                    MessageBox.Show("Selected semester details does not esists", "Alert");
            }
        }

        private void SemesterLoginForm_Load(object sender, EventArgs e)
        {
            // this will load semester names in the comboBox
            LoadSemestersFromDb();
        }

        public void LoadSemestersFromDb()
        {
            comboBoxYear.Text = "";
            comboBoxSemester.Text = "";
            comboBoxSubject.Text = "";
            comboBoxYear.Items.Clear();
            comboBoxSemester.Items.Clear();
            comboBoxSubject.Items.Clear();
            List<Semester> semestersList;

            try
            {
                semestersList = sdb.GetSemester();
                if (semestersList.Count > 0)
                {
                    Semester s;
                    for (int i = 0; i < semestersList.Count; i++)
                    {
                        s = semestersList[i];
                        comboBoxYear.Items.Add(s.Year);
                        comboBoxSemester.Items.Add(s.MySemester);
                        comboBoxSubject.Items.Add(s.Subject);
                    }
                }
                //else  // this else part really sucks when the semester table is empty
                //{
                    //MessageBox.Show("There are no semesters", "Alert");
                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, ex.GetType().ToString());
                // if we didnt comment the above line, when user will login for the first time, since there will be no semester has created yet, so an sql error will pop up 
            }
        }
    }
}
