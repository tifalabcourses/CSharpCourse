using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SavePdfToDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }


        //
        SqlConnection cnn;

        string connetionString;
        //

        private void chooseFileBtn_Click(object sender, EventArgs e)
        {

     
            openFileDialog1.InitialDirectory = @"C:\";
           

            openFileDialog1.Filter = "Word Files|*.docx;*.doc";
            openFileDialog1.Filter += "|PDF Files|*.pdf";
            openFileDialog1.Filter += "|Excels Files|*.xls;*.xlsx";
            openFileDialog1.Filter += "|Image Files |*.jpg;*.png;*.gif;";
            openFileDialog1.Filter += "|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Choose Attachment Files";
               

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            
            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // connetionString = @"Data Source=TIFALAB\MSSQL16;Initial Catalog=School;Trusted_Connection=false;User ID=UserName;Password=Password";
                connetionString = @"Data Source=TIFALAB\MSSQL16;Initial Catalog=School;Trusted_Connection=true;";
                cnn = new SqlConnection(connetionString);

                loadAttachTable();

            }catch(Exception ex){
              
            }
          
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string filepath = textBox1.Text;
            string filename  = Path.GetFileName(filepath);
            string extension = Path.GetExtension(filepath);
            byte[] imageByte = System.IO.File.ReadAllBytes(filepath);

            cnn.Open();

            string commandText = "Insert into attachments values (@filename,@file,getdate(),@extension)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.Add("@file", SqlDbType.VarBinary);
            cmd.Parameters["@file"].Value = imageByte;

            cmd.Parameters.Add("@filename", SqlDbType.NVarChar);
            cmd.Parameters["@filename"].Value = filename;

            cmd.Parameters.Add("@extension", SqlDbType.VarChar);
            cmd.Parameters["@extension"].Value = extension;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cnn.Close();

            MessageBox.Show("Saved");
            loadAttachTable();
        }
       public void loadAttachTable()
        {
             
        SqlCommand cmd = new SqlCommand("SELECT * FROM Attachments", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          
            DataSet ds = new DataSet();
            da.Fill(ds, "Attachments");

            
            dataGridView1.DataSource = ds.Tables["Attachments"];
            this.dataGridView1.Columns["attachment"].Visible = false;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            
           
            //Get  The Id Of Row 
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string id = Convert.ToString(selectedRow.Cells["id"].Value);

            try
            {
                string commandText = "Delete FROM Attachments WHERE ID = @id";


                cnn.Open();
                SqlCommand cmd = new SqlCommand(commandText, cnn);



                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

               
                loadAttachTable();
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
        private static readonly Encoding LocalEncoding = Encoding.UTF8;
        private void showBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;

            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string filetype = Convert.ToString(selectedRow.Cells["filetype"].Value);
             
            if (filetype == ".pdf")
            {
                try
                {
                    string pdffilename = selectedRow.Cells["attachName"].Value.ToString();
                    byte[] fileContent = (byte[])dt.Rows[selectedrowindex]["attachment"];
                    System.IO.File.WriteAllBytes(pdffilename, fileContent);
                    
                     System.Diagnostics.Process.Start(pdffilename);
                }
                catch (System.IO.IOException ex)
                {

                }
              
            }
            else if (filetype == ".png" || filetype == ".jpg")
            {
                byte[] imgData = (byte[])dt.Rows[selectedrowindex]["attachment"];
                MemoryStream stream = new MemoryStream(imgData);
                pictureBox1.Image = Image.FromStream(stream);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {

            }

          
        }
    }
}
