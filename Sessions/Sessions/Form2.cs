using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sessions
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = Sessions.Model.MySessions.username;
            label4.Text = Sessions.Model.MySessions.role;



            label6.Text = Sessions.Model.MySessions.username;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
