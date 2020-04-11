using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ImageBtn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         ImageList imageList1 = new ImageList();
         int x = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
           

            // The default image size is 16 x 16, which sets up a larger
            // image size. 
            imageList1.ImageSize = new Size(100, 100);
            //imageList1.TransparentColor = Color.White;

           

            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            imageList1.Images.Add(Image.FromFile(workingDirectory+@"\img\red.png"));
            imageList1.Images.Add(Image.FromFile(workingDirectory + @"\img\green.png"));

            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Image = imageList1.Images[0];
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {
                button1.Image = imageList1.Images[1];
                 x = 1;
            }
            else
            {
                button1.Image = imageList1.Images[0];
                x = 0;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
