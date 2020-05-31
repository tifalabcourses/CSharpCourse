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
    public partial class ViewerForm : Form
    {
        public ViewerForm()
        {
            InitializeComponent();
        }

        private void ViewerForm_Load(object sender, EventArgs e)
        {
            string user = Sessions.Model.MySessions.username;
            string role = Sessions.Model.MySessions.role;


            button1.Visible = false;
            comboBox1.Visible = false;
            richTextBox1.Visible = false;


            if (role == "Guest")
            {
                button1.Visible = true;
            }

            if (role == "User")
            {
                comboBox1.Visible = true;
            }

            if (role == "Admin")
            {
                richTextBox1.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
