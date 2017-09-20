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
    public partial class Form1 : Form
    {
        //int flag = 0;
        TeacherDb tb;
        //CurrentUserDetails cu; no need
        public Form1()
        {
            InitializeComponent();
            tb = new TeacherDb();
            //cu = new CurrentUserDetails(); no need
        }
        public Point Location { get; set; }

        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name != "Form1")
                    f.Close();
            }
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            panelSignIn.Enabled = false;
            panelSignIn.Visible = false;
            panelSignUp.Visible = true;
            panelSignUp.Enabled = true;

            bunifuSeparatorSignIn.Visible = false;
            bunifuSeparatorSignUp.Visible = true;

            btnFinalSignInSubmit.Visible = false;
            btnFinalSignInSubmit.Enabled = false;
            btnSignUpButtom.Visible = true;
            btnSignUpButtom.Enabled = true;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            panelSignUp.Enabled = false;
            panelSignUp.Visible = false;
            panelSignIn.Visible = true;
            panelSignIn.Enabled = true;

            bunifuSeparatorSignUp.Visible = false;
            bunifuSeparatorSignIn.Visible = true;

            btnSignUpButtom.Visible = false;
            btnSignUpButtom.Enabled = false;
            btnFinalSignInSubmit.Visible = true;
            btnFinalSignInSubmit.Enabled = true;
        }

        // this method will add a new record in Teacher table
        private void btnFinalSignUpSubmit_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher();
            lblSignUpWarning.ForeColor = System.Drawing.Color.IndianRed;
            lblSignUpWarning.Text = "";
            try
            {
                if (txtSignUpEmailId.Text != "" && txtSignUpPassword.Text != "")
                {
                    t.EmailId = txtSignUpEmailId.Text;
                    t.Password = txtSignUpPassword.Text;


                    t.FirstName = txtSignUpFirstName.Text;
                    t.LastName = txtSignUpLastName.Text;
                    tb.InsertTeacher(t);

                    lblSignUpWarning.ForeColor = System.Drawing.Color.SeaGreen;
                    lblSignUpWarning.Text = "Successfully Signed Up";
                }
                else
                {
                    lblSignUpWarning.Text = "Please Complete the form";
                }
            }
            catch
            {
                MessageBox.Show("Same EmailID and Password detected", "Alert");
            }
        }

        // this method will retrieve all record from Teacher table and if it match, open a new window
        private void btnFinalSignInSubmit_Click(object sender, EventArgs e)
        {
            List<Teacher> teachers;
            string emailId = txtSignInEmailId.Text;
            string password = txtSignInPassword.Text;

            try
            {
                teachers = tb.GetSingleRecordByName(emailId, password);
                if (teachers.Count != 0)
                {
                    Teacher t;

                    for (int i = 0; i < teachers.Count; i++)
                    {
                        // in this loop, we have close the login form and open the next form
                        t = teachers[0];
                        lblSignInWarning.Text = "";
                        //MessageBox.Show("Succesfully LogIn by " + t.FirstName);

                        // Current user details
                        CurrentUserDetails.FirstName = t.FirstName;
                        CurrentUserDetails.LastName = t.LastName;
                        CurrentUserDetails.EmailId = t.EmailId;

                        // hide the current form and display the next semester login form
                        this.Hide(); // maybe i should close it instead of hiding it, fix it later
                        SemesterLoginForm semesterLoginForm = new SemesterLoginForm();
                        semesterLoginForm.Show();
                    }
                }
                else
                {
                    lblSignInWarning.Text = "Invalid user";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


    }
}
