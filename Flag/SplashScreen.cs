using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flag
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        public static int counter = 0;
        System.Windows.Forms.Timer tmr; 
        private void SplashScreen_Load(object sender, EventArgs e)
        {
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            progressBar1.Value = counter * 5;
            // label2.Text = (5*counter).ToString();
            if (counter == 20)
            {
                timer1.Stop();
                Form2 ob = new Form2();
                this.Close();
                ob.Show();
            }
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            counter++;
            progressBar1.Value = counter * 5;
            //after 3 sec stop the timer
            if (counter == 20)
            {
                tmr.Stop();
                //display mainform
                Form2 mf = new Form2();
                mf.Show();
                //hide this form
                this.Hide();
            }
        }
        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new System.Windows.Forms.Timer();
            //set time interval 3 sec
      //      tmr.Interval = 3000;
            //starts the timer
            tmr.Start();
           
            tmr.Tick += tmr_Tick;
        }

        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
