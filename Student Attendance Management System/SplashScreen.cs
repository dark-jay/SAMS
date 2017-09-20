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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timerSplashScreen_Tick(object sender, EventArgs e)
        {
            timerSplashScreen.Stop();
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timerSplashScreen.Start();
        }
    }
}
