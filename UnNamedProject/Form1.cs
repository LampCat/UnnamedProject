using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnNamedProject
{
    public partial class Form1 : Form
    {
        struct ImageData
        {
            public int id;
            public string Name;
            public string Location;
            public List<string> Tags;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)// File>Open
        {
           
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.Filter = "*.png|*.jpg";
            if (ofd.FileName != "")
            {
                
                Bitmap b = new Bitmap(ofd.FileName);
                pictureBox1.Image = b;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
