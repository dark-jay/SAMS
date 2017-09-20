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
    public partial class AboutMe : Form
    {
        int a=0;
        public AboutMe()
        {
            InitializeComponent();
        }

        private void btnAboutClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            a++;
            if (a == 14)
                picMe.Show();
        }
    }
}
