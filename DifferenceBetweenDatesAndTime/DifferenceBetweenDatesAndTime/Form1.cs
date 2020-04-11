using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DifferenceBetweenDatesAndTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //
        DateTime startDate ;
        DateTime endDate ;
    
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";

        }

        void t_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = endDate.Subtract(DateTime.Now);
            label1.Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startDate = dateTimePicker1.Value;
            endDate = dateTimePicker2.Value;
          
            
            // Dayes Difference
            label2.Text = ((endDate.Date - startDate.Date).TotalDays).ToString();




            //Timer
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);

            TimeSpan ts = endDate.Subtract(DateTime.Now);
            label1.Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");

            t.Start();

        }
    }
}
