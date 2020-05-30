using GlobalConnectionInApp1.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlobalConnectionInApp1
{
    public partial class Form1 : Form
    {

        static SqlConnection con;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = DbHelper.getCon();
            loadAttachTable();
        }
        public void loadAttachTable()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM Attachments2", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Attachments2");


            dataGridView1.DataSource = ds.Tables["Attachments2"];
         
        }
        /**/
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
                frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
