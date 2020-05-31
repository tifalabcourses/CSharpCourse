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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        { 
            Sessions.Model.MySessions.username = textBox1.Text;
            Sessions.Model.MySessions.role = comboBox1.Text;
     
            Form1 frm = new Form1();
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
