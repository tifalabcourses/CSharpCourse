using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sessions.Model;
namespace Sessions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

            btnAdmin.Enabled = false;
            btnGuest.Enabled = false;
            btnUser.Enabled = false;


            if (Sessions.Model.MySessions.role == "Admin")
            {
               btnAdmin.Enabled = true;
            }
          
            if (Sessions.Model.MySessions.role == "User")
            {
                btnUser.Enabled = true;
            }

            if (Sessions.Model.MySessions.role == "Guest")
            {
              
               btnGuest.Enabled = true;
            }
               
           

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ViewerForm frm = new ViewerForm();
            frm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ViewerForm frm = new ViewerForm();
            frm.Show();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            ViewerForm frm = new ViewerForm();
            frm.Show();
        }
    }
}
