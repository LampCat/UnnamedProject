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
        private List<ImageData> Images = new List<ImageData>();

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
                string[] empty = new string[3];
                empty[0] = "test";
                empty[1] = "lampcat";
                empty[2] = "git";
                LoadImage(ofd.FileName, ofd.SafeFileName, empty);
            }
        }
        private void LoadImage(string FilePath, string FileName, string[] tags)
        {
            ImageData Idata = new ImageData();
            Idata.id = 0;//Just for now
            Idata.Location = FilePath;
            Idata.Name = FileName;
            foreach (string s in tags)
            {
                Idata.Tags.Add(s);
            }
            Images.Add(Idata);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
