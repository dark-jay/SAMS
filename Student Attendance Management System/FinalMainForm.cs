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
    public partial class FinalMainForm : Form
    {
        int CenterWidth = 150;
        int CenterHeight = 110;
        StudentDb sdb;
        AttendanceDb adb;
        ClassEventDb cdb;
        int FlagForDGV = 0; // 0 means off
        int FlagForDGVofPrint = 0; // 0 means off
        int index; // this is for the btnArrow
        Bitmap bmp;
        public FinalMainForm()
        {
            InitializeComponent();
            sdb = new StudentDb();
            adb = new AttendanceDb();
            cdb = new ClassEventDb();
        }
        public Point Location { get; set; }
        public virtual AnchorStyles Anchor { get; set; }
        public Size size { get; set; }
        public int Width { get; set; }

        private void FinalMainForm_Load(object sender, EventArgs e)
        {
            timerDateTime.Start();
            //int CW = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (FinalMainForm.ActiveForm.Width / 2) - ((FinalMainForm.ActiveForm.Width / 2) / 2) - ((FinalMainForm.ActiveForm.Width / 2) / 2);
            //int CH = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (FinalMainForm.ActiveForm.Height / 2) - ((FinalMainForm.ActiveForm.Height / 2) / 2);
            //CenterWidth = CW;
            //CenterHeight = CH;
            LoadOnStartUp();
            LoadList();
            setAllToolTip();
        }

        private void setAllToolTip()
        {
            ToolTip tt1 = new ToolTip();
            tt1.SetToolTip(this.btnLogOutCurrentUser, "Log Out");
            ToolTip tt2 = new ToolTip();
            tt1.SetToolTip(this.btnExitWindow, "Close");
            ToolTip tt3 = new ToolTip();
            tt1.SetToolTip(this.btnFullScreen, "Full Screen");
            ToolTip tt4 = new ToolTip();
            tt1.SetToolTip(this.btnMaximize, "Maximize");
            ToolTip tt5 = new ToolTip();
            tt1.SetToolTip(this.btnMinimize, "Minimize");
            ToolTip tt6 = new ToolTip();
            tt1.SetToolTip(this.btnMenu, "Navigation Menu");
            ToolTip tt7 = new ToolTip();
            tt1.SetToolTip(this.btnAddNewStudent, "Add New Student");
            ToolTip tt8 = new ToolTip();
            tt1.SetToolTip(this.btnUpdateStudent, "Update Student");
            ToolTip tt9 = new ToolTip();
            tt1.SetToolTip(this.btnRemoveStudent, "Delete Student");
            ToolTip tt10 = new ToolTip();
            tt1.SetToolTip(this.btnSettings, "Settings");
            ToolTip tt11 = new ToolTip();
            tt1.SetToolTip(this.btnTakeAttendance, "Take Attendance");
            ToolTip tt12 = new ToolTip();
            tt1.SetToolTip(this.btnPrintShow, "Print Attendance Sheet");
        }

        private void labelFontChangeWithMaxNFullScreenBtn()
        {
            // GP1 sets in row wise manner
            label4.Font = new Font("Microsoft Sans Serif", 12F);
            label4.Location = new Point(5, 40);
            lblAttended.Font = new Font("Microsoft Sans Serif", 12F);
            lblAttended.Location = new Point(84, 40); // +20
            label5.Font = new Font("Microsoft Sans Serif", 12F);
            label5.Location = new Point(195, 40); // +70
            lblMissed.Font = new Font("Microsoft Sans Serif", 12F);
            lblMissed.Location = new Point(254, 40); // +70 + 10 = 80
            label6.Font = new Font("Microsoft Sans Serif", 12F);
            label6.Location = new Point(350, 40); // +125
            lblTotalAttendance.Font = new Font("Microsoft Sans Serif", 12F);
            lblTotalAttendance.Location = new Point(400, 40); // +125 + 10 = 135

            // GP2 sets in row wise manner
            // R1
            label9.Font = new Font("Microsoft Sans Serif", 12F);
            label9.Location = new Point(120, 40); // + 20
            label10.Font = new Font("Microsoft Sans Serif", 12F);
            label10.Location = new Point(245, 40); // +80 //original = 165
            label11.Font = new Font("Microsoft Sans Serif", 12F);
            label11.Location = new Point(355, 40); // +125
            // R2
            label7.Font = new Font("Microsoft Sans Serif", 12F);
            label7.Location = new Point(5, 70); // height + 10
            lblFirstTermObtain.Font = new Font("Microsoft Sans Serif", 12F);
            lblFirstTermObtain.Location = new Point(145, 70); // +30 // height + 10
            lblMidTermObtain.Font = new Font("Microsoft Sans Serif", 12F);
            lblMidTermObtain.Location = new Point(270, 70); // +90 // height + 10
            lblEndTermObtain.Font = new Font("Microsoft Sans Serif", 12F);
            lblEndTermObtain.Location = new Point(380, 70); // +135 // height + 10
            // R3
            label8.Font = new Font("Microsoft Sans Serif", 12F);
            label8.Location = new Point(5, 90); // height + 10
            lblFirstTermTotal.Font = new Font("Microsoft Sans Serif", 12F);
            lblFirstTermTotal.Location = new Point(145, 90); // +30 // height + 10
            lblMidTermTotal.Font = new Font("Microsoft Sans Serif", 12F);
            lblMidTermTotal.Location = new Point(270, 90); // +90 // height + 10
            lblEndTermTotal.Font = new Font("Microsoft Sans Serif", 12F);
            lblEndTermTotal.Location = new Point(380, 90); // +135 // height + 10

            CpAttendance.Size = new Size(70, 70);
            CpFirstTerm.Size = new Size(70, 70);
            CpMidTerm.Size = new Size(70, 70);
            CpEndTerm.Size = new Size(70, 70);

            CpAttendance.Location = new Point(CpAttendance.Location.X + 5, CpAttendance.Location.Y - 5);
            CpFirstTerm.Location = new Point(CpFirstTerm.Location.X + 34, CpFirstTerm.Location.Y);
            CpMidTerm.Location = new Point(CpMidTerm.Location.X + 25, CpMidTerm.Location.Y);
            CpEndTerm.Location = new Point(CpEndTerm.Location.X + 2, CpEndTerm.Location.Y);

            // GP3
            //r1
            label12.Font = new Font("Microsoft Sans Serif", 12F);
            lblName.Font = new Font("Microsoft Sans Serif", 12F);
            //r2
            label47.Font = new Font("Microsoft Sans Serif", 12F);
            lblRollNo.Font = new Font("Microsoft Sans Serif", 12F);
            //r3
            label49.Font = new Font("Microsoft Sans Serif", 12F);
            lblGender.Font = new Font("Microsoft Sans Serif", 12F);
            //r4
            label51.Font = new Font("Microsoft Sans Serif", 12F);
            lblEmailId.Font = new Font("Microsoft Sans Serif", 12F);
            //r5
            label53.Font = new Font("Microsoft Sans Serif", 12F);
            lblPhoneNo.Font = new Font("Microsoft Sans Serif", 12F);
        }
        private void labelFontChangeWithMaxNFullScreenBtnToOriginal()
        {   
            // GP1 sets in row wise manner
            label4.Font = new Font("Microsoft Sans Serif", 8.25F);
            label4.Location = new Point(5, 40);
            lblAttended.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblAttended.Location = new Point(64, 40);
            label5.Font = new Font("Microsoft Sans Serif", 8.25F);
            label5.Location = new Point(125, 40);
            lblMissed.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblMissed.Location = new Point(174, 40);
            label6.Font = new Font("Microsoft Sans Serif", 8.25F);
            label6.Location = new Point(225, 40);
            lblTotalAttendance.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblTotalAttendance.Location = new Point(265, 40);

            // GP2 sets in row wise manner
            // R1
            label9.Font = new Font("Microsoft Sans Serif", 8.25F);
            label9.Location = new Point(100, 40);
            label10.Font = new Font("Microsoft Sans Serif", 8.25F);
            label10.Location = new Point(165, 40);
            label11.Font = new Font("Microsoft Sans Serif", 8.25F);
            label11.Location = new Point(230, 40);
            // R2
            label7.Font = new Font("Microsoft Sans Serif", 8.25F);
            label7.Location = new Point(5, 60);
            lblFirstTermObtain.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblFirstTermObtain.Location = new Point(115, 60);
            lblMidTermObtain.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblMidTermObtain.Location = new Point(180, 60);
            lblEndTermObtain.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblEndTermObtain.Location = new Point(245, 60);
            // R3
            label8.Font = new Font("Microsoft Sans Serif", 8.25F);
            label8.Location = new Point(5, 80);
            lblFirstTermTotal.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblFirstTermTotal.Location = new Point(115, 80);
            lblMidTermTotal.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblMidTermTotal.Location = new Point(180, 80);
            lblEndTermTotal.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblEndTermTotal.Location = new Point(245, 80);

            // cp
            CpAttendance.Location = new Point(5, 57);
            CpFirstTerm.Location = new Point(86, 110);
            CpMidTerm.Location = new Point(154, 110);
            CpEndTerm.Location = new Point(221, 110);

            CpAttendance.Size = new Size(67, 67);
            CpFirstTerm.Size = new Size(67,67);
            CpMidTerm.Size = new Size(67, 67);
            CpEndTerm.Size = new Size(67,67);

            // GP3
            //r1
            label12.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblName.Font = new Font("Microsoft Sans Serif", 9.75F);
            //r2
            label47.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblRollNo.Font = new Font("Microsoft Sans Serif", 9.75F);
            //r3
            label49.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblGender.Font = new Font("Microsoft Sans Serif", 9.75F);
            //r4
            label51.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblEmailId.Font = new Font("Microsoft Sans Serif", 9.75F);
            //r5
            label53.Font = new Font("Microsoft Sans Serif", 9.75F);
            lblPhoneNo.Font = new Font("Microsoft Sans Serif", 9.75F);
        }

        private void btnExitWindow_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name != "FinalMainForm")
                    f.Close();
            }
            this.Close();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)  // this will make the form normal(smaller)
            {
                //FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                //TopMost = true;
                Form1.ActiveForm.SetDesktopBounds(CenterWidth, CenterHeight, 931, 516);
                Form1.ActiveForm.StartPosition = FormStartPosition.CenterScreen;

                
                // Change The size and location of Right gradient panels (back to original(small))
                GradientPanelRight1.Width -= 140;
                GradientPanelRight1.Height -= 30;
                GradientPanelRight1.Location = new Point(622, 87); // back to original Location 
                bunifuSeparator1.Width -= 140;

                GradientPanelRight2.Width -= 140;
                GradientPanelRight2.Height -= 30;
                GradientPanelRight2.Location = new Point(622, 222); // back to original Location 
                bunifuSeparator2.Width -= 140;

                GradientPanelRight3.Width -= 140;
                GradientPanelRight3.Location = new Point(622, 419); // back to original Location 
                bunifuSeparator3.Width -= 140;
                GradientPanelRight3.Height -= 160; 

                listViewStudentDetailPrimary.Height -= 220;
                listViewStudentDetailPrimary.Width -= 150;

                columnHeaderRollNo.Width -= 75;
                columnHeaderName.Width -= 75;

                panelTakeAttendance.Height -= 220;
                panelTakeAttendance.Width -= 150;

                btnAttendanceSubmit.Location = new Point(450, 456);
                dateTimePicker1.Location = new Point(243, 456);

                btnArrowLeft.Location = new Point(240, 454);
                btnArrowRight.Location = new Point(314, 454);

                panelPrintWrapper.Width -= 220;
                panelPrintWrapper.Height -= 200;

                labelFontChangeWithMaxNFullScreenBtnToOriginal();

                panelLogOut.Height -= 220;
                panelLogOut.Width -= 150;
                
            }
            else if (Form1.ActiveForm.Width == Screen.PrimaryScreen.WorkingArea.Width && Form1.ActiveForm.Height == Screen.PrimaryScreen.WorkingArea.Height)
            {
                this.WindowState = FormWindowState.Maximized;
                //TopMost = true;
            }
            else
            {
                //FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                //TopMost = true; this results in print preview kick back, huge problem trust me

                
                // Change The size and location of Right gradient panels
                GradientPanelRight1.Width += 140; // 297 + 50 = 347
                GradientPanelRight1.Height += 30;
                GradientPanelRight1.Location = new Point(918, 87); // 1362-347=1015
                bunifuSeparator1.Width += 140;

                GradientPanelRight2.Width += 140;                   // original 100 (here original means in ealier codes which has modified)
                GradientPanelRight2.Height += 30;
                GradientPanelRight2.Location = new Point(918, 252); // original 958, 222
                bunifuSeparator2.Width += 140;

                GradientPanelRight3.Width += 140;
                GradientPanelRight3.Location = new Point(918, 479);
                bunifuSeparator3.Width += 140;
                GradientPanelRight3.Height += 160;

                listViewStudentDetailPrimary.Height += 220;
                listViewStudentDetailPrimary.Width += 150;

                columnHeaderRollNo.Width += 75;
                columnHeaderName.Width += 75;

                panelTakeAttendance.Height += 220;
                panelTakeAttendance.Width += 150;

                btnAttendanceSubmit.Location = new Point(450 + 150, 456 + 220);
                dateTimePicker1.Location = new Point(243 + 150, 456 + 220);

                btnArrowLeft.Location = new Point(240 + 50, 454 + 220);
                btnArrowRight.Location = new Point(314 + 50, 454 + 220);

                panelPrintWrapper.Width += 220;
                panelPrintWrapper.Height += 200;

                labelFontChangeWithMaxNFullScreenBtn();

                panelLogOut.Height += 220;
                panelLogOut.Width += 150;
                
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (FinalMainForm.ActiveForm.Width == 931 && FinalMainForm.ActiveForm.Height == 516)
            {
                FinalMainForm.ActiveForm.SetDesktopBounds(1, 2, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

                
                GradientPanelRight1.Width += 140; // 297 + 50 = 347
                GradientPanelRight1.Height += 30;
                GradientPanelRight1.Location = new Point(918, 87); // 1362-347=1015
                bunifuSeparator1.Width += 140;

                GradientPanelRight2.Width += 140;                   // original 100 (here original means in ealier codes which has modified)
                GradientPanelRight2.Height += 30;
                GradientPanelRight2.Location = new Point(918, 252); // original 958, 222
                bunifuSeparator2.Width += 140;

                GradientPanelRight3.Width += 140;
                GradientPanelRight3.Location = new Point(918, 479);
                bunifuSeparator3.Width += 140;
                GradientPanelRight3.Height += 160; // previouslly 220, since adding 50 to other 2 gPanels. so 220-50 = 170

                listViewStudentDetailPrimary.Height += 220;
                listViewStudentDetailPrimary.Width += 150;

                columnHeaderRollNo.Width += 75;
                columnHeaderName.Width += 75;

                panelTakeAttendance.Height += 220;
                panelTakeAttendance.Width += 150;

                btnAttendanceSubmit.Location = new Point(450 + 150, 456 + 220);
                dateTimePicker1.Location = new Point(243 + 150, 456 + 220);

                btnArrowLeft.Location = new Point(240 + 50, 454 + 220);
                btnArrowRight.Location = new Point(314 + 50, 454 + 220);

                panelPrintWrapper.Width += 220;
                panelPrintWrapper.Height += 200;

                labelFontChangeWithMaxNFullScreenBtn();

                panelLogOut.Height += 220;
                panelLogOut.Width += 150;
                
            }
            else if (FinalMainForm.ActiveForm.Width == Screen.PrimaryScreen.WorkingArea.Width && FinalMainForm.ActiveForm.Height == Screen.PrimaryScreen.WorkingArea.Height)
            {
                //750, 450
                FinalMainForm.ActiveForm.SetDesktopBounds(CenterWidth, CenterHeight, 931, 516);
                FinalMainForm.ActiveForm.StartPosition = FormStartPosition.CenterScreen;

                
                GradientPanelRight1.Width -= 140;
                GradientPanelRight1.Height -= 30;
                GradientPanelRight1.Location = new Point(622, 87); // back to original Location 
                bunifuSeparator1.Width -= 140;

                GradientPanelRight2.Width -= 140;
                GradientPanelRight2.Height -= 30;
                GradientPanelRight2.Location = new Point(622, 222); // back to original Location 
                bunifuSeparator2.Width -= 140;

                GradientPanelRight3.Width -= 140;
                GradientPanelRight3.Location = new Point(622, 419); // back to original Location 
                bunifuSeparator3.Width -= 140;
                GradientPanelRight3.Height -= 160; // back to original Location 

                listViewStudentDetailPrimary.Height -= 220;
                listViewStudentDetailPrimary.Width -= 150;

                columnHeaderRollNo.Width -= 75;
                columnHeaderName.Width -= 75;

                panelTakeAttendance.Height -= 220;
                panelTakeAttendance.Width -= 150;

                btnAttendanceSubmit.Location = new Point(450, 456);
                dateTimePicker1.Location = new Point(243, 456);

                btnArrowLeft.Location = new Point(240, 454);
                btnArrowRight.Location = new Point(314, 454);

                panelPrintWrapper.Width -= 220;
                panelPrintWrapper.Height -= 200;

                labelFontChangeWithMaxNFullScreenBtnToOriginal();

                panelLogOut.Height -= 220;
                panelLogOut.Width -= 150;
                
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                FinalMainForm.ActiveForm.SetDesktopBounds(CenterWidth, CenterHeight, 931, 516);
                FinalMainForm.ActiveForm.StartPosition = FormStartPosition.CenterScreen;


                GradientPanelRight1.Width -= 140;
                GradientPanelRight1.Height -= 30;
                GradientPanelRight1.Location = new Point(622, 87); // back to original Location 
                bunifuSeparator1.Width -= 140;

                GradientPanelRight2.Width -= 140;
                GradientPanelRight2.Height -= 30;
                GradientPanelRight2.Location = new Point(622, 222); // back to original Location 
                bunifuSeparator2.Width -= 140;

                GradientPanelRight3.Width -= 140;
                GradientPanelRight3.Location = new Point(622, 419); // back to original Location 
                bunifuSeparator3.Width -= 140;
                GradientPanelRight3.Height -= 160; 

                listViewStudentDetailPrimary.Height -= 220;
                listViewStudentDetailPrimary.Width -= 150;

                columnHeaderRollNo.Width -= 75;
                columnHeaderName.Width -= 75;

                panelTakeAttendance.Height -= 220;
                panelTakeAttendance.Width -= 150;

                btnAttendanceSubmit.Location = new Point(450, 456);
                dateTimePicker1.Location = new Point(243, 456);

                btnArrowLeft.Location = new Point(240, 454);
                btnArrowRight.Location = new Point(314, 454);

                panelPrintWrapper.Width -= 220;
                panelPrintWrapper.Height -= 200;

                labelFontChangeWithMaxNFullScreenBtnToOriginal();

                panelLogOut.Height -= 220;
                panelLogOut.Width -= 150;
                
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            string dateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            lblDateTime.Text = dateTime.ToString();
        }

        // This method is just to load the labels of current user and semester
        public void LoadOnStartUp()
        {
            // Active User/Teacher Name
            lblCurrentUserName.Text = CurrentUserDetails.FirstName + " " + CurrentUserDetails.LastName;

            // Active Semester Detail
            lblCurrentYearOfStuTble.Text = CurrentUserDetails.CurrentYear.ToString();
            lblCurrentSemOfStuTbl.Text = CurrentUserDetails.CurrentSemester.ToString();
            lblCurrentSubOfStuTbl.Text = CurrentUserDetails.CurrentSubject.ToUpper();

            lblAttended.Text = "0";
            lblMissed.Text = "0";
            lblTotalAttendance.Text = "0";
            CpAttendance.Value = 0;

            lblFirstTermObtain.Text = "0";
            lblFirstTermTotal.Text = "0";
            CpFirstTerm.Value = 0;
            lblMidTermObtain.Text = "0";
            lblMidTermTotal.Text = "0";
            CpMidTerm.Value = 0;
            lblEndTermObtain.Text = "0";
            lblEndTermTotal.Text = "0";
            CpEndTerm.Value = 0;

            loadSettingsPanelLabels();
        }

        public void LoadList()
        {
            listViewStudentDetailPrimary.Items.Clear();
            List<Student> students;

            try
            {
                students = sdb.GetStudent(CurrentUserDetails.TblName1);
                if (students.Count > 0)
                {
                    Student s;
                    for (int i = 0; i < students.Count; i++)
                    {
                        s = students[i];
                        listViewStudentDetailPrimary.Items.Add(s.RollNo);
                        if (s.MiddleName == "")
                            listViewStudentDetailPrimary.Items[i].SubItems.Add(s.FirstName + " " + s.LastName);
                        else
                            listViewStudentDetailPrimary.Items[i].SubItems.Add(s.FirstName + " " + s.MiddleName + " " + s.LastName);
                    }
                }
                else
                {
                    //MessageBox.Show("There are no person", "Alert");
                }
                listViewStudentDetailPrimary.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, ex.GetType().ToString());
                // if i dont make the above line comment, when the user will creat a new semester, the student table will completelly  empty at first, so it thow an sql exception as an messagebox
            }
        }

        private void loadSettingsPanelLabels()
        {
            // load the each term current total marks in settings panel
            List<ClassEvent> cv = new List<ClassEvent>();
            cv = cdb.GetTotalMarksOfEachTerm(CurrentUserDetails.EmailId, CurrentUserDetails.TblName3);

            lblSettings1stTerm.Text = cv[0].FirstTermTotal.ToString();
            lblSettings2ndTerm.Text = cv[0].MidTermTotal.ToString();
            lblSettings3rdTerm.Text = cv[0].EndTermTotal.ToString();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }
        
        private void btnMenuRightExpanded_Click(object sender, EventArgs e)
        {
            timerLeftNavigationPanelSlideBack.Start();

            btnAddNewStudent.selected = false;
            btnUpdateStudent.selected = false;
            btnSettings.selected = false;

            btnAddNewStudent.Enabled = true;
            btnUpdateStudent.Enabled = true;
            btnSettings.Enabled = true;
            btnRemoveStudent.Enabled = true;

            btnMenu.Visible = true;

            btnTakeAttendance.Enabled = true;
            btnPrintShow.Enabled = true;
            btnArrowLeft.Visible = true;
            btnArrowRight.Visible = true;

            lblLeftNavInnerPanelName.Text = "";

            panelAddNewStudentExpanded.Visible = false;
            panelUpdateStudent.Visible = false;
            panelSettings.Visible = false;

            btnSubmitStudentDetails.Visible = false;
            btnUpdateStudentSubmitToDb.Visible = false;
            btnSettingsSubmit.Visible = false;
        }

        private void timerLeftNavigationPanelSlide_Tick(object sender, EventArgs e)
        {
            if (panelLeftNavigation.Width == 395)
            {
                timerLeftNavigationPanelSlide.Stop();
            }
            panelLeftNavigation.Width += 10;
        }
        private void timerLeftNavigationPanelSlideBack_Tick(object sender, EventArgs e)
        {
            if (panelLeftNavigation.Width == 45)
            {
                timerLeftNavigationPanelSlideBack.Stop();
            }
            panelLeftNavigation.Width -= 10;
        }

        // left navigation add new student button
        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            btnMenu.Visible = false;
            lblLeftNavInnerPanelName.Text = "Add New Student";
            lblLeftNavInnerPanelName.Visible = true;
            btnAddNewStudent.selected = true;
            btnAddNewStudent.Enabled = false;
            panelAddNewStudentExpanded.Visible = true;
            btnSubmitStudentDetails.Visible = true;
            lblAddStudentAddingStatus.Text = "";
            timerLeftNavigationPanelSlide.Start();

            btnUpdateStudent.Enabled = false;
            btnSettings.Enabled = false;
            btnRemoveStudent.Enabled = false;
            btnTakeAttendance.Enabled = false;
            btnPrintShow.Enabled = false;
            btnArrowLeft.Visible = false;
            btnArrowRight.Visible = false;
        }

        // left navigation update button
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            btnMenu.Visible = false;
            lblLeftNavInnerPanelName.Text = "Update Student Detail";
            lblLeftNavInnerPanelName.Visible = true;
            btnUpdateStudent.selected = true;
            btnUpdateStudent.Enabled = false;
            panelUpdateStudent.Visible = true;
            btnUpdateStudentSubmitToDb.Visible = true;
            lblAddStudentAddingStatus.Text = "";
            timerLeftNavigationPanelSlide.Start();

            btnAddNewStudent.Enabled = false;
            btnSettings.Enabled = false;
            btnRemoveStudent.Enabled = false;
            btnTakeAttendance.Enabled = false;
            btnPrintShow.Enabled = false;
            btnArrowLeft.Visible = false;
            btnArrowRight.Visible = false;
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            
            string RollNo;
            //List<Student> students;
            if (listViewStudentDetailPrimary.SelectedItems.Count != 0)
            {
                //lblFirstNameByName.Text = lvOneSingleListView.SelectedItems[0].SubItems[1].Text;
                RollNo = listViewStudentDetailPrimary.SelectedItems[0].SubItems[0].Text; // here subItems[0]: index 0 means first column
                //students = sdb.GetSingleRecordByRollNo(RollNo, CurrentUserDetails.TblName1);
                if (MessageBox.Show("Are you sure to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sdb.DeleteStudent(RollNo, CurrentUserDetails.TblName1);
                    MessageBox.Show("Record Deleted Successfully", "Alert");
                    LoadList();
                }

            }
        }


        // left navigation settings button
        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnMenu.Visible = false;
            lblLeftNavInnerPanelName.Text = "Declare Exam Details";
            lblLeftNavInnerPanelName.Visible = true;
            btnSettings.selected = true;
            btnSettings.Enabled = false;
            panelSettings.Visible = true;
            btnSettingsSubmit.Visible = true;
            lblAddStudentAddingStatus.Text = "";
            timerLeftNavigationPanelSlide.Start();

            btnAddNewStudent.Enabled = false;
            btnUpdateStudent.Enabled = false;
            btnRemoveStudent.Enabled = false;
            btnTakeAttendance.Enabled = false;
            btnPrintShow.Enabled = false;
            btnArrowLeft.Visible = false;
            btnArrowRight.Visible = false;
        }


        // This method will add new student in database
        private void btnSubmitStudentDetails_Click(object sender, EventArgs e)
        {
            Student s = new Student();

            if (txtStudentFirstName.Text != "" && txtStudentLastName.Text != "" && txtStudentRollNo.Text != "" && comboBoxStudentGender.Text != "")
            {
                if (txtStudentPhone.Text.Length > 12)
                    MessageBox.Show("Cannot enter more than 12 digit in phone number field", "Alert");
                else
                {
                    s.RollNo = txtStudentRollNo.Text.ToUpper();
                    s.FirstName = txtStudentFirstName.Text.ToUpper();
                    s.LastName = txtStudentLastName.Text.ToUpper();
                    s.MiddleName = txtStudentMiddleName.Text.ToUpper();
                    s.Gender = comboBoxStudentGender.Text.ToUpper();
                    s.EmailId = txtStudentEmailId.Text;
                    s.PhoneNo = txtStudentPhone.Text;
                    if (txtStudentFirstTermMark.Text == "")
                        s.FirstTermMarks = 0;
                    else
                        s.FirstTermMarks = Convert.ToInt32(txtStudentFirstTermMark.Text);
                    if (txtStudentMidTermMark.Text == "")
                        s.MidTermMarks = 0;
                    else
                        s.MidTermMarks = Convert.ToInt32(txtStudentMidTermMark.Text);
                    if (txtStudentEndTermMark.Text == "")
                        s.EndTermMarks = 0;
                    else
                        s.EndTermMarks = Convert.ToInt32(txtStudentEndTermMark.Text);

                    try
                    {
                        sdb.InsertStudent(s, CurrentUserDetails.TblName1); // tblName1 = student,  tblName2 = Attendance
                        lblAddStudentAddingStatus.Visible = true;
                        lblAddStudentAddingStatus.ForeColor = System.Drawing.Color.SeaGreen;
                        lblAddStudentAddingStatus.Text = "Succesfully added";
                        timerSuccessFullyAdded.Start();
                        resetAddStudentFormTextBoxes();
                        LoadList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot input same Roll Number more than once.", "Alert");
                    }
                }
            }
            else
            {
                lblAddStudentAddingStatus.Visible = true;
                lblAddStudentAddingStatus.ForeColor = System.Drawing.Color.Maroon;
                lblAddStudentAddingStatus.Text = "Please fill the required boxes";
                timerSuccessFullyAdded.Start();
            }
            
        }

        private void timerSuccessFullyAdded_Tick(object sender, EventArgs e)
        {
            timerSuccessFullyAdded.Stop();
            lblAddStudentAddingStatus.Visible = false;
        }

        private void resetAddStudentFormTextBoxes()
        {
            txtStudentRollNo.Text = "";
            txtStudentFirstName.Text = "";
            txtStudentLastName.Text = "";
            txtStudentMiddleName.Text = "";
            //comboBoxStudentGender.Text.ToUpper();
            txtStudentEmailId.Text = "";
            txtStudentPhone.Text = "";
            txtStudentFirstTermMark.Text = "";
            txtStudentMidTermMark.Text = "";
            txtStudentEndTermMark.Text = "";
        }

        // this method will update old student details
        private void btnUpdateStudentSubmitToDb_Click(object sender, EventArgs e)
        {
            Student s = new Student();

            if (txtUpdateFirstName.Text != "" && txtUpdateLastName.Text != "" && txtUpdateRollNo.Text != "" && comboBoxUpdateGender.Text != "")
            {
                if (txtUpdatePhoneNo.Text.Length > 12)
                {
                    MessageBox.Show("Cannot enter more than 12 digit in phone number field", "Alert");
                }
                else
                {
                    s.RollNo = txtUpdateRollNo.Text.ToUpper();
                    s.FirstName = txtUpdateFirstName.Text.ToUpper();
                    s.LastName = txtUpdateLastName.Text.ToUpper();
                    s.MiddleName = txtUpdateMiddleName.Text.ToUpper();
                    s.Gender = comboBoxUpdateGender.Text.ToUpper();
                    s.EmailId = txtUpdateEmailId.Text.ToUpper();
                    s.PhoneNo = txtUpdatePhoneNo.Text;
                    s.FirstTermMarks = Convert.ToInt32(txtUpdate1stTermMarks.Text);
                    s.MidTermMarks = Convert.ToInt32(txtUpdate2ndTermMarks.Text);
                    s.EndTermMarks = Convert.ToInt32(txtUpdate3rdTermMarks.Text);

                    sdb.UpdateStudent(s, CurrentUserDetails.TblName1);
                    lblAddStudentAddingStatus.Visible = true;
                    lblAddStudentAddingStatus.ForeColor = System.Drawing.Color.SeaGreen;
                    lblAddStudentAddingStatus.Text = "Succesfully Updated";
                    timerSuccessFullyAdded.Start();
                    LoadList();

                    // When a particular record is updated, display the updated details as soon as clicked
                    if (s.MiddleName == "")
                        lblName.Text = s.FirstName + " " + s.LastName;
                    else
                        lblName.Text = s.FirstName + " " + s.MiddleName + " " + s.LastName;
                    lblRollNo.Text = s.RollNo;
                    lblEmailId.Text = s.EmailId;
                    lblPhoneNo.Text = s.PhoneNo;
                    lblGender.Text = s.Gender;

                    getSetAllInfoOfaRecordBasedOnSearched(s.RollNo, CurrentUserDetails.EmailId);
                }
            }
            else
            {
                lblAddStudentAddingStatus.ForeColor = System.Drawing.Color.Maroon;
                lblAddStudentAddingStatus.Text = "Please fill the required boxes";
            }
        }


        // this method will declare exam details
        private void btnSettingsSubmit_Click(object sender, EventArgs e)
        {
            ClassEvent cv = new ClassEvent(); // to hold the old total marks
            List<ClassEvent> cvList = new List<ClassEvent>();
            cvList = cdb.GetTotalMarksOfEachTerm(CurrentUserDetails.EmailId, CurrentUserDetails.TblName3);

            cv.FirstTermTotal = cvList[0].FirstTermTotal;
            cv.MidTermTotal = cvList[0].MidTermTotal;
            cv.EndTermTotal = cvList[0].EndTermTotal;

            ClassEvent newCv = new ClassEvent(); // this value are to be pass into the db methode 

            if (txtSettings1stTerm.Text == "")
                newCv.FirstTermTotal = cv.FirstTermTotal;
            else
                newCv.FirstTermTotal = Convert.ToInt32(txtSettings1stTerm.Text);

            if (txtSettings2ndTerm.Text == "")
                newCv.MidTermTotal = cv.MidTermTotal;
            else
                newCv.MidTermTotal = Convert.ToInt32(txtSettings2ndTerm.Text);

            if (txtSettings3rdTerm.Text == "")
                newCv.EndTermTotal = cv.EndTermTotal;
            else
                newCv.EndTermTotal = Convert.ToInt32(txtSettings3rdTerm.Text);

            cdb.UpdateTermTotalMarks(newCv.FirstTermTotal, newCv.MidTermTotal, newCv.EndTermTotal, CurrentUserDetails.TblName3);


            lblAddStudentAddingStatus.Text = "Succesfully added";
            LoadList();
            loadSettingsPanelLabels();
        }

        // this method will update the text boxes of updateStudent in real time
        public void UpdateTextBoxesOfPanelUpdate()
        {
            string RollNo;
            List<Student> students;
            if (listViewStudentDetailPrimary.SelectedItems.Count != 0)
            {
                //lblFirstNameByName.Text = lvOneSingleListView.SelectedItems[0].SubItems[1].Text;
                RollNo = listViewStudentDetailPrimary.SelectedItems[0].SubItems[0].Text; // here subItems[0]: index 0 means first column
                students = sdb.GetSingleRecordByRollNo(RollNo, CurrentUserDetails.TblName1);
                if (students.Count != 0)
                {
                    Student s;
                    s = students[0];

                    txtUpdateFirstName.Text = s.FirstName;
                    txtUpdateMiddleName.Text = s.MiddleName;
                    txtUpdateLastName.Text = s.LastName;
                    txtUpdateRollNo.Text = s.RollNo;
                    if (s.Gender == "MALE")
                        comboBoxUpdateGender.Text = comboBoxUpdateGender.Items[0].ToString();
                    else
                        comboBoxUpdateGender.Text = comboBoxUpdateGender.Items[1].ToString();
                    txtUpdateEmailId.Text = s.EmailId;
                    txtUpdatePhoneNo.Text = s.PhoneNo;
                    txtUpdate1stTermMarks.Text = s.FirstTermMarks.ToString();
                    txtUpdate2ndTermMarks.Text = s.MidTermMarks.ToString();
                    txtUpdate3rdTermMarks.Text = s.EndTermMarks.ToString();
                }
            }
        }

        public void SetsRightPanelAttendanceData()
        {
            string RollNo;
            string EmailId;
            List<Attendance> attendancesAttended;
            List<Attendance> attendancesTotalClass;
            int TotalClass;
            int AttendedClass;
            float PercentageOfAttendance;

            if (listViewStudentDetailPrimary.SelectedItems.Count != 0)
            {
                //lblFirstNameByName.Text = lvOneSingleListView.SelectedItems[0].SubItems[1].Text;
                RollNo = listViewStudentDetailPrimary.SelectedItems[0].SubItems[0].Text; // here subItems[0]: index 0 means first column which is roll no
                EmailId = CurrentUserDetails.EmailId;
                attendancesAttended = adb.GetAttendance(RollNo, CurrentUserDetails.TblName2);
                attendancesTotalClass = adb.GetTotalClass(EmailId, CurrentUserDetails.TblName3);

                // sets the right panel attendance values to zero
                lblAttended.Text = "0";
                lblMissed.Text = "0";
                lblTotalAttendance.Text = "0";
                CpAttendance.Value = 0;

                if (attendancesAttended.Count != 0)
                {
                    Attendance aAttended;
                    Attendance aTotalClass;
                    aAttended = attendancesAttended[0];
                    aTotalClass = attendancesTotalClass[0];

                    TotalClass = aTotalClass.TotalClass;
                    AttendedClass = attendancesAttended.Count;
                    PercentageOfAttendance = (float)((float)AttendedClass / (float)TotalClass) * 100;

                    lblAttended.Text = AttendedClass.ToString();
                    lblMissed.Text = (TotalClass - AttendedClass).ToString();
                    lblTotalAttendance.Text = TotalClass.ToString();
                    CpAttendance.Value = Convert.ToInt32(PercentageOfAttendance);
                    if (PercentageOfAttendance >= 75)
                    {
                        btnGood.Visible = true;
                    }
                    else if (PercentageOfAttendance >= 60 && PercentageOfAttendance < 75)
                    {
                        btnGood.Visible = false;
                        btnNC.Visible = true;
                    }
                    else if (PercentageOfAttendance < 60)
                    {
                        btnNC.Visible = false;
                        btnGood.Visible = false;
                        btnDC.Visible = true;
                    }
                }
                else
                {
                    //Attendance aAttended;
                    Attendance aTotalClass;
                    //aAttended = attendancesAttended[0];
                    aTotalClass = attendancesTotalClass[0];

                    TotalClass = aTotalClass.TotalClass;
                    AttendedClass = 0;
                    PercentageOfAttendance = 0;

                    lblAttended.Text = AttendedClass.ToString();
                    lblMissed.Text = (TotalClass - AttendedClass).ToString();
                    lblTotalAttendance.Text = TotalClass.ToString();
                    CpAttendance.Value = Convert.ToInt32(PercentageOfAttendance);
                    if (PercentageOfAttendance >= 75)
                    {
                        btnGood.Visible = true;
                    }
                    else if (PercentageOfAttendance >= 60 && PercentageOfAttendance < 75)
                    {
                        btnGood.Visible = false;
                        btnNC.Visible = true;
                    }
                    else if (PercentageOfAttendance < 60)
                    {
                        btnNC.Visible = false;
                        btnGood.Visible = false;
                        btnDC.Visible = true;
                    }
                }
            }
        }

        public void SetsRightPanelEachTermsMarksData()
        {
            string RollNo;
            string EmailId;
            List<Student> students;
            List<ClassEvent> classEvents;
            int FirstTermObtain, MidTermObtain, EndTermObtain;
            int FirstTermTotal, MidTermTotal, EndTermTotal;
            float PercentageOfFirstTerm, PercentageOfMidTerm, PercentageOfEndTerm;

            if (listViewStudentDetailPrimary.SelectedItems.Count != 0)
            {
                //lblFirstNameByName.Text = lvOneSingleListView.SelectedItems[0].SubItems[1].Text;
                RollNo = listViewStudentDetailPrimary.SelectedItems[0].SubItems[0].Text; // here subItems[0]: index 0 means first column
                EmailId = CurrentUserDetails.EmailId;
                students = sdb.GetSingleRecordByRollNo(RollNo, CurrentUserDetails.TblName1);
                classEvents = cdb.GetTotalMarksOfEachTerm(EmailId, CurrentUserDetails.TblName3);

                // sets the right panel marks to zero
                lblFirstTermObtain.Text = "0";
                lblFirstTermTotal.Text = "0";
                CpFirstTerm.Value = 0;
                lblMidTermObtain.Text = "0";
                lblMidTermTotal.Text = "0";
                CpMidTerm.Value = 0;
                lblEndTermObtain.Text = "0";
                lblEndTermTotal.Text = "0";
                CpEndTerm.Value = 0;

                if (students.Count != 0)
                {
                    Student s;
                    ClassEvent c;
                    s = students[0];
                    c = classEvents[0];

                    FirstTermTotal = c.FirstTermTotal;
                    MidTermTotal = c.MidTermTotal;
                    EndTermTotal = c.EndTermTotal;
                    FirstTermObtain = s.FirstTermMarks;
                    MidTermObtain = s.MidTermMarks;
                    EndTermObtain = s.EndTermMarks;
                    PercentageOfFirstTerm = (float)((float)FirstTermObtain / (float)FirstTermTotal) * 100;
                    PercentageOfMidTerm = (float)((float)MidTermObtain / (float)MidTermTotal) * 100;
                    PercentageOfEndTerm = (float)((float)EndTermObtain / (float)EndTermTotal) * 100;

                    lblFirstTermObtain.Text = FirstTermObtain.ToString();
                    lblFirstTermTotal.Text = FirstTermTotal.ToString();
                    CpFirstTerm.Value = Convert.ToInt32(PercentageOfFirstTerm);
                    lblMidTermObtain.Text = MidTermObtain.ToString();
                    lblMidTermTotal.Text = MidTermTotal.ToString();
                    CpMidTerm.Value = Convert.ToInt32(PercentageOfMidTerm);
                    lblEndTermObtain.Text = EndTermObtain.ToString();
                    lblEndTermTotal.Text = EndTermTotal.ToString();
                    CpEndTerm.Value = Convert.ToInt32(PercentageOfEndTerm);
                }
            }
        }

        // whenever user will select a new student, status will updated by this method
        private void listViewStudentDetailPrimary_SelectedIndexChanged(object sender, EventArgs e)
        {
            string RollNo;
            List<Student> students;
            if (listViewStudentDetailPrimary.SelectedItems.Count != 0)
            {
                //lblFirstNameByName.Text = lvOneSingleListView.SelectedItems[0].SubItems[1].Text;
                RollNo = listViewStudentDetailPrimary.SelectedItems[0].SubItems[0].Text; // here subItems[0]: index 0 means first column
                students = sdb.GetSingleRecordByRollNo(RollNo, CurrentUserDetails.TblName1);
                if (students.Count != 0)
                {
                    Student s;
                    s = students[0];

                    if (s.MiddleName == "")
                        lblName.Text = s.FirstName + " " + s.LastName;
                    else
                        lblName.Text = s.FirstName + " " + s.MiddleName + " " + s.LastName;
                    lblRollNo.Text = s.RollNo;
                    lblEmailId.Text = s.EmailId;
                    lblPhoneNo.Text = s.PhoneNo;
                    lblGender.Text = s.Gender;

                    UpdateTextBoxesOfPanelUpdate();
                    SetsRightPanelAttendanceData();
                    SetsRightPanelEachTermsMarksData();
                }
            }
        }

        private void btnTakeAttendance_Click(object sender, EventArgs e)
        {
            dataGridViewTakeAttendance.Rows.Clear();
            if (FlagForDGV == 0)
            {
                panelTakeAttendance.Visible = true;
                loadDatagridForAttendance();
                listViewStudentDetailPrimary.Visible = false;
                btnArrowRight.Visible = false;
                btnArrowLeft.Visible = false;
                btnTakeAttendance.selected = true;
                btnAttendanceSubmit.Visible = true;
                dateTimePicker1.Visible = true;
                FlagForDGV = 1; // means turned on

                btnAddNewStudent.Enabled = false;
                btnUpdateStudent.Enabled = false;
                btnRemoveStudent.Enabled = false;
                btnPrintShow.Enabled = false;
                btnSettings.Enabled = false;
            }
            else
            {
                panelTakeAttendance.Visible = false;
                listViewStudentDetailPrimary.Visible = true;
                btnArrowRight.Visible = true;
                btnArrowLeft.Visible = true;
                btnTakeAttendance.selected = false;
                btnAttendanceSubmit.Visible = false;
                dateTimePicker1.Visible = false;
                FlagForDGV = 0;

                btnAddNewStudent.Enabled = true;
                btnUpdateStudent.Enabled = true;
                btnRemoveStudent.Enabled = true;
                btnPrintShow.Enabled = true;
                btnSettings.Enabled = true;
            }
        }

        private void loadDatagridForAttendance()
        {
            List<Student> students;

            try
            {
                students = sdb.GetStudent(CurrentUserDetails.TblName1);
                if (students.Count > 0)
                {
                    Student s;
                    for (int i = 0; i < students.Count; i++) // i=row of datagridview
                    {
                        dataGridViewTakeAttendance.Rows.Add();
                        s = students[i];
                        for (int j = 0; j < 4; j++) // j=column of datagridview
                        {
                            if (j == 0)
                                dataGridViewTakeAttendance.Rows[i].Cells[j].Value = (i+1).ToString();
                            else if (j == 1)
                                dataGridViewTakeAttendance.Rows[i].Cells[j].Value = s.RollNo;
                            else if (j == 2)
                            {
                                if (s.MiddleName == "")
                                    dataGridViewTakeAttendance.Rows[i].Cells[j].Value = s.FirstName + " " + s.LastName;
                                else
                                    dataGridViewTakeAttendance.Rows[i].Cells[j].Value = s.FirstName + " " + s.MiddleName + " " + s.LastName;
                            }
                        }
                        
                    }
                }
                else
                {
                    //MessageBox.Show("There are no person", "Alert");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnAttendanceSubmit_Click(object sender, EventArgs e)
        {
            string rollNo; // we dont have to literaly use this var, we can do without it, but im doing it, keboz, im daaaa Programmer, not u!!! :)
            string emailId = CurrentUserDetails.EmailId;

            List<Attendance> tempTotalAttendance = new List<Attendance>(); // this will hold the attendance list returned by the getTotalClass methode. i Have to make this a list because earlier i created the method as list(i could do this in a simple way, but now i realize it and i dont wanna write it again, -by jay)
            tempTotalAttendance = adb.GetTotalClass(emailId, CurrentUserDetails.TblName3); // total class is in Class Event Table which is in fact Tblname3
            int totalClass = tempTotalAttendance[0].TotalClass;
            
            if (MessageBox.Show("Are you sure to submit the Attendance ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewTakeAttendance.Rows)
                {
                    Attendance a = new Attendance();
                    if (row.Cells[3].Value != null)
                    {
                        if ((Boolean)row.Cells[3].Value == true)
                        {
                            rollNo = row.Cells[1].Value.ToString().ToUpper();
                            a.RollNo = rollNo;
                            a.Status = "P";
                            //string dateTime = DateTime.Now.ToString("yyyy/MM/dd");
                            //a.Date = Convert.ToDateTime(dateTime);
                            a.Date = dateTimePicker1.Value;
                        }
                        else
                        {
                            rollNo = row.Cells[1].Value.ToString().ToUpper();
                            a.RollNo = rollNo;
                            a.Status = "A";
                            a.Date = dateTimePicker1.Value;
                        }
                        adb.InsertAttendanceIntoDb(a, CurrentUserDetails.TblName2); // tblName2 = attendance table
                    }
                    else
                    {
                        rollNo = row.Cells[1].Value.ToString().ToUpper();
                        a.RollNo = rollNo;
                        a.Status = "A";
                        a.Date = dateTimePicker1.Value;

                        adb.InsertAttendanceIntoDb(a, CurrentUserDetails.TblName2); // tblName2 = attendance table
                    }
                }

                totalClass++;
                cdb.UpdateTotalClass(totalClass, CurrentUserDetails.TblName3); // tblName3 = class event table table
                MessageBox.Show("Attendance Submitted Successfully", "Alert");
            }
        }

        private void btnArrowRight_Click(object sender, EventArgs e)
        {
            if (index < listViewStudentDetailPrimary.Items.Count - 1) // lets say count=2, but index counting is from zero, i.e. 0, 1 so < count-1 
            {
                index = listViewStudentDetailPrimary.SelectedIndices[0];
                index++;
                this.listViewStudentDetailPrimary.Items[index].Selected = true;
            }
        }

        private void btnArrowLeft_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index = listViewStudentDetailPrimary.SelectedIndices[0];
                index--;
                this.listViewStudentDetailPrimary.Items[index].Selected = true;
            }
        }

        private void btnPrintShow_Click(object sender, EventArgs e)
        {
            dataGridViewPrint.Rows.Clear();
            if (FlagForDGVofPrint == 0)
            {
                panelPrintWrapper.Visible = true;
                loadDataGridForPrint();
                FlagForDGVofPrint = 1; // means turned on

                btnAddNewStudent.Enabled = false;
                btnUpdateStudent.Enabled = false;
                btnRemoveStudent.Enabled = false;
                btnTakeAttendance.Enabled = false;
                btnSettings.Enabled = false;
            }
            else
            {
                panelPrintWrapper.Visible = false;
                FlagForDGVofPrint = 0;

                btnAddNewStudent.Enabled = true;
                btnUpdateStudent.Enabled = true;
                btnRemoveStudent.Enabled = true;
                btnTakeAttendance.Enabled = true;
                btnSettings.Enabled = true;
            }
        }

        private void loadDataGridForPrint()
        {
            List<Student> students;
            string RollNo;
            string EmailId;
            List<Attendance> attendancesAttended;
            List<Attendance> attendancesTotalClass;
            int TotalClass;
            int AttendedClass;
            float PercentageOfAttendance;

            EmailId = CurrentUserDetails.EmailId;
            //attendancesAttended = adb.GetAttendance(RollNo, CurrentUserDetails.TblName2);
            attendancesTotalClass = adb.GetTotalClass(EmailId, CurrentUserDetails.TblName3);
            TotalClass = attendancesTotalClass[0].TotalClass;

            lblAttendanceReportTitlePrint.Text = "Attendance Report of " + CurrentUserDetails.CurrentSemester.ToString() + " semester, " + CurrentUserDetails.CurrentYear.ToString();
            
            try
            {
                students = sdb.GetStudent(CurrentUserDetails.TblName1);
                if (students.Count > 0)
                {
                    Student s;
                    for (int i = 0; i < students.Count; i++) // i=row of datagridview
                    {
                        dataGridViewPrint.Rows.Add();
                        s = students[i];

                        RollNo = s.RollNo;
                        attendancesAttended = adb.GetAttendance(RollNo, CurrentUserDetails.TblName2);
                        AttendedClass = attendancesAttended.Count;
                        PercentageOfAttendance = (float)((float)AttendedClass / (float)TotalClass) * 100;

                        for (int j = 0; j < 4; j++) // j=column of datagridview
                        {
                            if (j == 0)
                                dataGridViewPrint.Rows[i].Cells[j].Value = (i + 1).ToString();
                            else if (j == 2)
                                dataGridViewPrint.Rows[i].Cells[j].Value = s.RollNo;
                            else if (j == 1)
                            {
                                if (s.MiddleName == "")
                                    dataGridViewPrint.Rows[i].Cells[j].Value = s.FirstName + " " + s.LastName;
                                else
                                    dataGridViewPrint.Rows[i].Cells[j].Value = s.FirstName + " " + s.MiddleName + " " + s.LastName;
                            }
                            else if (j == 3)
                            {
                                dataGridViewPrint.Rows[i].Cells[j].Value = Convert.ToInt32(PercentageOfAttendance) + "%";
                            }
                        }

                    }
                }
                else
                {
                    //MessageBox.Show("There are no person", "Alert");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnPrintTheAttendanceSheet_Click(object sender, EventArgs e)
        {
            int pHeight = panelInnerMainPrint.Height; // panel original height
            int pWidth = panelInnerMainPrint.Width; // panel original width
            int dgHeight = dataGridViewPrint.Height; // data grid original height
            int dgWidth = dataGridViewPrint.Width; // data grid original width

            dataGridViewPrint.Height = dataGridViewPrint.RowCount * dataGridViewPrint.RowTemplate.Height;
            if (FinalMainForm.ActiveForm.Width <= 931)
                panelInnerMainPrint.Width += 250;
            else if (FinalMainForm.ActiveForm.Width >= 931)
                panelInnerMainPrint.Width += 45;
            panelInnerMainPrint.Height += dataGridViewPrint.Height;
            lblAttendanceReportTitlePrint.Location = new Point(260, 21); // original 186, 21
            bmp = new Bitmap(panelInnerMainPrint.Width, panelInnerMainPrint.Height);
            panelInnerMainPrint.DrawToBitmap(bmp, new Rectangle(0, 0, panelInnerMainPrint.Width, panelInnerMainPrint.Height));

            printPreviewDialog1.ShowDialog();

            panelInnerMainPrint.Height = pHeight; // panel original height
            panelInnerMainPrint.Width = pWidth; // panel original width
            dataGridViewPrint.Height = dgHeight; // data grid original height
            dataGridViewPrint.Width = dgWidth;

            if (FinalMainForm.ActiveForm.Width <= 931)
                lblAttendanceReportTitlePrint.Location = new Point(186, 21);
            else if (FinalMainForm.ActiveForm.Width >= 931)
                lblAttendanceReportTitlePrint.Location = new Point(0, 21);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 50, 0);
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            if (txtSearchByName.Text != "")
            {
                string st = txtSearchByName.Text.ToUpper();
                string[] a = st.Split(' ');

                string firstName = "", middleName = "", lastName = "";
                for (int i = 0; i < a.Length; i++)
                {
                    if (a.Length == 1)
                    {
                        if (i == 0)
                            firstName = a[i];
                    }
                    else if (a.Length == 2)
                    {
                        if (i == 0)
                            firstName = a[i];
                        if (i == 1)
                            lastName = a[i];
                    }
                    else if (a.Length == 3)
                    {
                        if (i == 0)
                            firstName = a[i];
                        if (i == 1)
                            middleName = a[i];
                        if (i == 2)
                            lastName = a[i];
                    }
                }

                if (firstName != "" && middleName == "" && lastName == "")
                {
                    //lblFirst.Text = firstName;
                    List<Student> students;
                    try
                    {
                        students = sdb.GetSingleRecordByName(firstName, CurrentUserDetails.TblName1);
                        if (students.Count == 1)
                        {
                            Student s;
                            s = students[0];

                            // If found then select that record in listview
                            if (s.MiddleName == "")
                                lblName.Text = s.FirstName + " " + s.LastName;
                            else
                                lblName.Text = s.FirstName + " " + s.MiddleName + " " + s.LastName;
                            lblRollNo.Text = s.RollNo;
                            lblEmailId.Text = s.EmailId;
                            lblPhoneNo.Text = s.PhoneNo;
                            lblGender.Text = s.Gender;

                            // sets the value of right side panel
                            getSetAllInfoOfaRecordBasedOnSearched(s.RollNo, CurrentUserDetails.EmailId);

                        }
                        else if (students.Count > 1)
                        {
                            //lblSelectNameByIdStatus.Text = students.Count.ToString() + " results found, Select from the list";
                            btnSelectSingleName.Visible = true;
                            comboSelectSingleName.Visible = true;
                            Student s;
                            comboSelectSingleName.Items.Clear();
                            for (int i = 0; i < students.Count; i++)
                            {
                                s = students[i];
                                comboSelectSingleName.Items.Add(s.RollNo);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There are no Student by this name", "Alert");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }

                }
                if (firstName != "" && middleName != "" && lastName != "")
                {
                    //lblMiddle.Text = middleName;
                    List<Student> students;
                    try
                    {
                        students = sdb.GetSingleRecordByFirstAndMiddleAndLastName(firstName, middleName, lastName, CurrentUserDetails.TblName1);
                        if (students.Count == 1)
                        {
                            Student s;
                            s = students[0];

                            // If found then select that record in listview
                            if (s.MiddleName == "")
                                lblName.Text = s.FirstName + " " + s.LastName;
                            else
                                lblName.Text = s.FirstName + " " + s.MiddleName + " " + s.LastName;
                            lblRollNo.Text = s.RollNo;
                            lblEmailId.Text = s.EmailId;
                            lblPhoneNo.Text = s.PhoneNo;
                            lblGender.Text = s.Gender;

                            // sets the value of right side panel
                            getSetAllInfoOfaRecordBasedOnSearched(s.RollNo, CurrentUserDetails.EmailId);

                        }
                        else if (students.Count > 1)
                        {
                            //lblSelectNameByIdStatus.Text = students.Count.ToString() + " results found, Select from the list";
                            btnSelectSingleName.Visible = true;
                            comboSelectSingleName.Visible = true;
                            Student s;
                            comboSelectSingleName.Items.Clear();
                            for (int i = 0; i < students.Count; i++)
                            {
                                s = students[i];
                                comboSelectSingleName.Items.Add(s.RollNo);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There are no Student by this name", "Alert");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                if (firstName != "" && middleName == "" && lastName != "")
                {
                    //lblLast.Text = lastName;
                    List<Student> students;
                    try
                    {
                        students = sdb.GetSingleRecordByFirstAndLastName(firstName, lastName, CurrentUserDetails.TblName1);
                        if (students.Count == 1)
                        {
                            Student s;
                            s = students[0];

                            // If found then select that record in listview
                            if (s.MiddleName == "")
                                lblName.Text = s.FirstName + " " + s.LastName;
                            else
                                lblName.Text = s.FirstName + " " + s.MiddleName + " " + s.LastName;
                            lblRollNo.Text = s.RollNo;
                            lblEmailId.Text = s.EmailId;
                            lblPhoneNo.Text = s.PhoneNo;
                            lblGender.Text = s.Gender;

                            // sets the value of right side panel
                            getSetAllInfoOfaRecordBasedOnSearched(s.RollNo, CurrentUserDetails.EmailId);

                        }
                        else if (students.Count > 1)
                        {
                            //lblSelectNameByIdStatus.Text = students.Count.ToString() + " results found, Select from the list";
                            btnSelectSingleName.Visible = true;
                            comboSelectSingleName.Visible = true;
                            Student s;
                            comboSelectSingleName.Items.Clear();
                            for (int i = 0; i < students.Count; i++)
                            {
                                s = students[i];
                                comboSelectSingleName.Items.Add(s.RollNo);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There are no Student by this name", "Alert");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

        // If The searched name results in multiple record then this button will search from combobox
        private void btnSelectSingleName_Click(object sender, EventArgs e)
        {
            //lblSelectNameByIdStatus.Text = "Search By FirstName (returns entire single record)";
            btnSelectSingleName.Visible = false;
            comboSelectSingleName.Visible = false;

            string rollNo = comboSelectSingleName.Text;

            List<Student> students;
            try
            {
                students = sdb.GetSingleRecordByRollNo(rollNo, CurrentUserDetails.TblName1);
                if (students.Count > 0)
                {
                    Student s;
                    s = students[0];

                    // If found then select that record in listview
                    if (s.MiddleName == "")
                        lblName.Text = s.FirstName + " " + s.LastName;
                    else
                        lblName.Text = s.FirstName + " " + s.MiddleName + " " + s.LastName;
                    lblRollNo.Text = s.RollNo;
                    lblEmailId.Text = s.EmailId;
                    lblPhoneNo.Text = s.PhoneNo;
                    lblGender.Text = s.Gender;

                    // sets the value of right side panel
                    getSetAllInfoOfaRecordBasedOnSearched(s.RollNo, CurrentUserDetails.EmailId);
                    
                }
                else
                {
                    MessageBox.Show("There are no Student by this name", "Alert");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void getSetAllInfoOfaRecordBasedOnSearched(string RollNo, string EmailId)
        {
            // These fields for Attendance
            List<Attendance> attendancesAttended;
            List<Attendance> attendancesTotalClass;
            int TotalClass;
            int AttendedClass;
            float PercentageOfAttendance;

            // These fields for Marks
            List<Student> stu;
            List<ClassEvent> classEvents;
            int FirstTermObtain, MidTermObtain, EndTermObtain;
            int FirstTermTotal, MidTermTotal, EndTermTotal;
            float PercentageOfFirstTerm, PercentageOfMidTerm, PercentageOfEndTerm;

            //RollNo = s.RollNo; // i will get the values from parameter
            //EmailId = CurrentUserDetails.EmailId; // i will get the values from parameter

            // For Attendance
            attendancesAttended = adb.GetAttendance(RollNo, CurrentUserDetails.TblName2);
            attendancesTotalClass = adb.GetTotalClass(EmailId, CurrentUserDetails.TblName3);
            // sets the right panel attendance values to zero
            lblAttended.Text = "0";
            lblMissed.Text = "0";
            lblTotalAttendance.Text = "0";
            CpAttendance.Value = 0;

            if (attendancesAttended.Count != 0)
            {
                Attendance aAttended;
                Attendance aTotalClass;
                aAttended = attendancesAttended[0];
                aTotalClass = attendancesTotalClass[0];

                TotalClass = aTotalClass.TotalClass;
                AttendedClass = attendancesAttended.Count;
                PercentageOfAttendance = (float)((float)AttendedClass / (float)TotalClass) * 100;

                lblAttended.Text = AttendedClass.ToString();
                lblMissed.Text = (TotalClass - AttendedClass).ToString();
                lblTotalAttendance.Text = TotalClass.ToString();
                CpAttendance.Value = Convert.ToInt32(PercentageOfAttendance);
                if (PercentageOfAttendance >= 75)
                {
                    btnGood.Visible = true;
                }
                else if (PercentageOfAttendance >= 60 && PercentageOfAttendance < 75)
                {
                    btnGood.Visible = false;
                    btnNC.Visible = true;
                }
                else if (PercentageOfAttendance < 60)
                {
                    btnNC.Visible = false;
                    btnGood.Visible = false;
                    btnDC.Visible = true;
                }
            }

            // For Marks
            stu = sdb.GetSingleRecordByRollNo(RollNo, CurrentUserDetails.TblName1);
            classEvents = cdb.GetTotalMarksOfEachTerm(EmailId, CurrentUserDetails.TblName3);

            // sets the right panel marks to zero
            lblFirstTermObtain.Text = "0";
            lblFirstTermTotal.Text = "0";
            CpFirstTerm.Value = 0;
            lblMidTermObtain.Text = "0";
            lblMidTermTotal.Text = "0";
            CpMidTerm.Value = 0;
            lblEndTermObtain.Text = "0";
            lblEndTermTotal.Text = "0";
            CpEndTerm.Value = 0;

            if (stu.Count != 0)
            {
                Student ss;
                ClassEvent c;
                ss = stu[0];
                c = classEvents[0];

                FirstTermTotal = c.FirstTermTotal;
                MidTermTotal = c.MidTermTotal;
                EndTermTotal = c.EndTermTotal;
                FirstTermObtain = ss.FirstTermMarks;
                MidTermObtain = ss.MidTermMarks;
                EndTermObtain = ss.EndTermMarks;
                PercentageOfFirstTerm = (float)((float)FirstTermObtain / (float)FirstTermTotal) * 100;
                PercentageOfMidTerm = (float)((float)MidTermObtain / (float)MidTermTotal) * 100;
                PercentageOfEndTerm = (float)((float)EndTermObtain / (float)EndTermTotal) * 100;

                lblFirstTermObtain.Text = FirstTermObtain.ToString();
                lblFirstTermTotal.Text = FirstTermTotal.ToString();
                CpFirstTerm.Value = Convert.ToInt32(PercentageOfFirstTerm);
                lblMidTermObtain.Text = MidTermObtain.ToString();
                lblMidTermTotal.Text = MidTermTotal.ToString();
                CpMidTerm.Value = Convert.ToInt32(PercentageOfMidTerm);
                lblEndTermObtain.Text = EndTermObtain.ToString();
                lblEndTermTotal.Text = EndTermTotal.ToString();
                CpEndTerm.Value = Convert.ToInt32(PercentageOfEndTerm);
            }
        }

        // Timer for Circular progressbar animation
        int dir = 1;
        private void timerLoading_Tick(object sender, EventArgs e)
        {
            if (cpLoadingLogOut.Value == 90)
            {
                dir -= 1;
                cpLoadingLogOut.animationIterval = 4;
            }
            else if (cpLoadingLogOut.Value == 10)
            {
                dir += 1;
                cpLoadingLogOut.animationIterval = 2;
            }
            
            cpLoadingLogOut.Value += dir;
        }

        private void btnLogOutCurrentUser_Click(object sender, EventArgs e)
        {
            panelLogOut.Visible = true;
            timerLoading.Start();
            timerLogOutWrapper.Start();
        }
        private void timerLogOutWrapper_Tick(object sender, EventArgs e)
        {
            timerLoading.Stop();
            timerLogOutWrapper.Stop();
            
            // REset the Current User Data to null
            CurrentUserDetails.FirstName = "";
            CurrentUserDetails.LastName = "";
            CurrentUserDetails.EmailId = "";
            CurrentUserDetails.CurrentYear = 0;
            CurrentUserDetails.CurrentSemester = 0;
            CurrentUserDetails.CurrentSubject = "";
            CurrentUserDetails.TblName1 = "";
            CurrentUserDetails.TblName2 = "";
            CurrentUserDetails.TblName3 = "";

            //SemesterLoginForm slm = new SemesterLoginForm();
            //slm.Show();
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void btnChangeSemester_Click(object sender, EventArgs e)
        {
            panelLogOut.Visible = true;
            timerLoading.Start();
            timerChangeSemester.Start();
        }

        private void timerChangeSemester_Tick(object sender, EventArgs e)
        {
            timerLoading.Stop();
            timerChangeSemester.Stop();

            // REset the Current User Data to null
            CurrentUserDetails.CurrentYear = 0;
            CurrentUserDetails.CurrentSemester = 0;
            CurrentUserDetails.CurrentSubject = "";
            CurrentUserDetails.TblName1 = "";
            CurrentUserDetails.TblName2 = "";
            CurrentUserDetails.TblName3 = "";

            SemesterLoginForm slm = new SemesterLoginForm();
            this.Close();
            slm.Show();
        }

        private void btnAboutMe_Click(object sender, EventArgs e)
        {
            AboutMe am = new AboutMe();
            am.Show();
        }

    }
}
