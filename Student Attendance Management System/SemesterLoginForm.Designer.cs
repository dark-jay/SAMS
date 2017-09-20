namespace Student_Attendance_Management_System
{
    partial class SemesterLoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SemesterLoginForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnExitSemLogin = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnSemesterLogIn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panelAddNewSemester = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblStatusOfNewSemAdd = new System.Windows.Forms.Label();
            this.txtSubjectNewSem = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtSemesterNewSem = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtYearNewSem = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnAddNewSemester = new Bunifu.Framework.UI.BunifuThinButton2();
            this.timerAddNewSemPanel = new System.Windows.Forms.Timer(this.components);
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.comboBoxSemester = new System.Windows.Forms.ComboBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnExitSemLogin)).BeginInit();
            this.panelAddNewSemester.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btnExitSemLogin
            // 
            this.btnExitSemLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitSemLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnExitSemLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnExitSemLogin.Image")));
            this.btnExitSemLogin.ImageActive = null;
            this.btnExitSemLogin.Location = new System.Drawing.Point(637, 12);
            this.btnExitSemLogin.Name = "btnExitSemLogin";
            this.btnExitSemLogin.Size = new System.Drawing.Size(24, 24);
            this.btnExitSemLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExitSemLogin.TabIndex = 0;
            this.btnExitSemLogin.TabStop = false;
            this.btnExitSemLogin.Zoom = 10;
            this.btnExitSemLogin.Click += new System.EventHandler(this.btnExitSemLogin_Click);
            // 
            // btnSemesterLogIn
            // 
            this.btnSemesterLogIn.ActiveBorderThickness = 1;
            this.btnSemesterLogIn.ActiveCornerRadius = 1;
            this.btnSemesterLogIn.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnSemesterLogIn.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnSemesterLogIn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnSemesterLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSemesterLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.btnSemesterLogIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSemesterLogIn.BackgroundImage")));
            this.btnSemesterLogIn.ButtonText = "LogIn";
            this.btnSemesterLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSemesterLogIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSemesterLogIn.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnSemesterLogIn.IdleBorderThickness = 1;
            this.btnSemesterLogIn.IdleCornerRadius = 1;
            this.btnSemesterLogIn.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnSemesterLogIn.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnSemesterLogIn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnSemesterLogIn.Location = new System.Drawing.Point(254, 176);
            this.btnSemesterLogIn.Margin = new System.Windows.Forms.Padding(5);
            this.btnSemesterLogIn.Name = "btnSemesterLogIn";
            this.btnSemesterLogIn.Size = new System.Drawing.Size(175, 41);
            this.btnSemesterLogIn.TabIndex = 4;
            this.btnSemesterLogIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSemesterLogIn.Click += new System.EventHandler(this.btnSemesterLogIn_Click);
            // 
            // panelAddNewSemester
            // 
            this.panelAddNewSemester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.panelAddNewSemester.Controls.Add(this.btnAdd);
            this.panelAddNewSemester.Controls.Add(this.lblStatusOfNewSemAdd);
            this.panelAddNewSemester.Controls.Add(this.txtSubjectNewSem);
            this.panelAddNewSemester.Controls.Add(this.txtSemesterNewSem);
            this.panelAddNewSemester.Controls.Add(this.txtYearNewSem);
            this.panelAddNewSemester.Location = new System.Drawing.Point(48, 280);
            this.panelAddNewSemester.Name = "panelAddNewSemester";
            this.panelAddNewSemester.Size = new System.Drawing.Size(580, 0);
            this.panelAddNewSemester.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.Silver;
            this.btnAdd.Location = new System.Drawing.Point(206, 66);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(175, 41);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblStatusOfNewSemAdd
            // 
            this.lblStatusOfNewSemAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusOfNewSemAdd.AutoSize = true;
            this.lblStatusOfNewSemAdd.ForeColor = System.Drawing.Color.White;
            this.lblStatusOfNewSemAdd.Location = new System.Drawing.Point(211, -20);
            this.lblStatusOfNewSemAdd.Name = "lblStatusOfNewSemAdd";
            this.lblStatusOfNewSemAdd.Size = new System.Drawing.Size(0, 13);
            this.lblStatusOfNewSemAdd.TabIndex = 9;
            // 
            // txtSubjectNewSem
            // 
            this.txtSubjectNewSem.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtSubjectNewSem.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSubjectNewSem.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtSubjectNewSem.BorderThickness = 3;
            this.txtSubjectNewSem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSubjectNewSem.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtSubjectNewSem.ForeColor = System.Drawing.Color.Silver;
            this.txtSubjectNewSem.isPassword = false;
            this.txtSubjectNewSem.Location = new System.Drawing.Point(399, 14);
            this.txtSubjectNewSem.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubjectNewSem.Name = "txtSubjectNewSem";
            this.txtSubjectNewSem.Size = new System.Drawing.Size(175, 44);
            this.txtSubjectNewSem.TabIndex = 8;
            this.txtSubjectNewSem.Text = "Subject";
            this.txtSubjectNewSem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtSemesterNewSem
            // 
            this.txtSemesterNewSem.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtSemesterNewSem.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSemesterNewSem.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtSemesterNewSem.BorderThickness = 3;
            this.txtSemesterNewSem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSemesterNewSem.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtSemesterNewSem.ForeColor = System.Drawing.Color.Silver;
            this.txtSemesterNewSem.isPassword = false;
            this.txtSemesterNewSem.Location = new System.Drawing.Point(206, 14);
            this.txtSemesterNewSem.Margin = new System.Windows.Forms.Padding(4);
            this.txtSemesterNewSem.Name = "txtSemesterNewSem";
            this.txtSemesterNewSem.Size = new System.Drawing.Size(175, 44);
            this.txtSemesterNewSem.TabIndex = 7;
            this.txtSemesterNewSem.Text = "Semester e.g: 5";
            this.txtSemesterNewSem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtYearNewSem
            // 
            this.txtYearNewSem.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtYearNewSem.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtYearNewSem.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtYearNewSem.BorderThickness = 3;
            this.txtYearNewSem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYearNewSem.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtYearNewSem.ForeColor = System.Drawing.Color.Silver;
            this.txtYearNewSem.isPassword = false;
            this.txtYearNewSem.Location = new System.Drawing.Point(10, 14);
            this.txtYearNewSem.Margin = new System.Windows.Forms.Padding(4);
            this.txtYearNewSem.Name = "txtYearNewSem";
            this.txtYearNewSem.Size = new System.Drawing.Size(175, 44);
            this.txtYearNewSem.TabIndex = 6;
            this.txtYearNewSem.Text = "Year";
            this.txtYearNewSem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnAddNewSemester
            // 
            this.btnAddNewSemester.ActiveBorderThickness = 1;
            this.btnAddNewSemester.ActiveCornerRadius = 1;
            this.btnAddNewSemester.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnAddNewSemester.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnAddNewSemester.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddNewSemester.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewSemester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.btnAddNewSemester.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddNewSemester.BackgroundImage")));
            this.btnAddNewSemester.ButtonText = "Add New Semester";
            this.btnAddNewSemester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewSemester.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewSemester.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAddNewSemester.IdleBorderThickness = 1;
            this.btnAddNewSemester.IdleCornerRadius = 1;
            this.btnAddNewSemester.IdleFillColor = System.Drawing.Color.Transparent;
            this.btnAddNewSemester.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnAddNewSemester.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnAddNewSemester.Location = new System.Drawing.Point(254, 222);
            this.btnAddNewSemester.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddNewSemester.Name = "btnAddNewSemester";
            this.btnAddNewSemester.Size = new System.Drawing.Size(175, 41);
            this.btnAddNewSemester.TabIndex = 6;
            this.btnAddNewSemester.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddNewSemester.Click += new System.EventHandler(this.btnAddNewSemester_Click_1);
            // 
            // timerAddNewSemPanel
            // 
            this.timerAddNewSemPanel.Interval = 1;
            this.timerAddNewSemPanel.Tick += new System.EventHandler(this.timerAddNewSemPanel_Tick);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxYear.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxYear.ForeColor = System.Drawing.Color.White;
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(58, 131);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(175, 26);
            this.comboBoxYear.TabIndex = 8;
            // 
            // comboBoxSemester
            // 
            this.comboBoxSemester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.comboBoxSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSemester.Font = new System.Drawing.Font("Verdana", 12F);
            this.comboBoxSemester.ForeColor = System.Drawing.Color.White;
            this.comboBoxSemester.FormattingEnabled = true;
            this.comboBoxSemester.Location = new System.Drawing.Point(254, 131);
            this.comboBoxSemester.Name = "comboBoxSemester";
            this.comboBoxSemester.Size = new System.Drawing.Size(175, 26);
            this.comboBoxSemester.TabIndex = 9;
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.comboBoxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSubject.Font = new System.Drawing.Font("Verdana", 12F);
            this.comboBoxSubject.ForeColor = System.Drawing.Color.White;
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(447, 131);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(175, 26);
            this.comboBoxSubject.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(54, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(250, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Semester";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(443, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Subject";
            // 
            // SemesterLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(16)))), ((int)(((byte)(13)))));
            this.ClientSize = new System.Drawing.Size(673, 432);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.comboBoxSemester);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.btnAddNewSemester);
            this.Controls.Add(this.panelAddNewSemester);
            this.Controls.Add(this.btnSemesterLogIn);
            this.Controls.Add(this.btnExitSemLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SemesterLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SemesterLoginForm";
            this.Load += new System.EventHandler(this.SemesterLoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExitSemLogin)).EndInit();
            this.panelAddNewSemester.ResumeLayout(false);
            this.panelAddNewSemester.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton btnExitSemLogin;
        private Bunifu.Framework.UI.BunifuThinButton2 btnSemesterLogIn;
        private System.Windows.Forms.Panel panelAddNewSemester;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddNewSemester;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtSubjectNewSem;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtSemesterNewSem;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtYearNewSem;
        private System.Windows.Forms.Label lblStatusOfNewSemAdd;
        private System.Windows.Forms.Timer timerAddNewSemPanel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.ComboBox comboBoxSemester;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}