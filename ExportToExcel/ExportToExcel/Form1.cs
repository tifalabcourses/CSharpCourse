using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExportToExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //Add Columns
            for (int x = 0; x < 5; x++)
            {

                dt.Columns.Add("Col"+x);
            }


            //Add Rows
            for (int i = 0; i < 10; i++)
            {

                dt.Rows.Add();
            }


            //Load Data
            for (int i = 0; i<dt.Rows.Count; i++)
            {
               
                for (int x = 0; x < dt.Columns.Count; x++)
                {
                
                    dt.Rows[i][x] = "Content" + i + x; 
                }
            }

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var workbook = new XLWorkbook())
            {

                DataTable dt = (DataTable)dataGridView1.DataSource;

                string fileName = "HelloWorld.xlsx";

                var worksheet = workbook.Worksheets.Add(dt,"Sample Sheet");
                //   worksheet.Worksheets.Add(dt, "WorksheetName");
                 //worksheet.Cell("A1").Value = "Hello World!";
                //worksheet.Cell("A2").FormulaA1 = "=MID(A1, 7, 5)";
                workbook.SaveAs(fileName);
              
                
                Process.Start(fileName);

           
            }
        }
    }
}
