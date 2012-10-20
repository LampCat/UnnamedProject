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
        private ImageData EmptyImg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EmptyImg.id = 5000;
            EmptyImg.Name = "";
            EmptyImg.Location = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)// File>Open
        {
           
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.Filter = "*.png|*.jpg";
            if (ofd.FileName != "")
            {

                SetDisplayImage(ofd.FileName);
                string[] empty = new string[3];
                empty[0] = "test";
                empty[1] = "lampcat";
                empty[2] = "git";
                LoadImage(ofd.FileName, ofd.SafeFileName, empty);
            }
        }
        private void SetDisplayImage(string ImagePath)
        {
            Bitmap b = new Bitmap(ImagePath);
            pictureBox1.Image = b;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void LoadImage(string FilePath, string FileName, string[] tags)
        {
            ImageData Idata = new ImageData();
            Idata.id = 0;//Just for now
            Idata.Location = FilePath;
            Idata.Name = FileName;
            Idata.Tags = new List<string>();
            foreach (string s in tags)
            {
                Idata.Tags.Add(s);
            }
            Images.Add(Idata);
            AddToRows(FileName, FilePath, tags.ToString());//Fix tags
        }
        private void AddToList()
        {

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private ImageData Search(string tag)
        {
            List<ImageData> tempList = new List<ImageData>();
            tempList.AddRange(Images);
            ImageData tempPlayer = EmptyImg; bool returnNull = false;

            foreach (ImageData p in tempList)
            {
                foreach (string s in p.Tags)
                {
                    if (s.ToLower() == tag)
                    {
                        return p;
                    }
                    else
                    {
                        returnNull = true;
                    }
                }
            }
            if (returnNull == true) return EmptyImg;
            return EmptyImg;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ImageData Idata = new ImageData();
            Idata = Search(textBox1.Text);
            if (Idata.id != 5000)
            {
                AddToRows(Idata.Name, Idata.Location, Idata.Tags.ToString());//Fix tags
            }
            else
            {
                MessageBox.Show("No Images found.");
            }
        }
        private void AddToRows(string name, string path, string tags)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(AddToList));
            else
                dataGridView1.Rows.Add(name, path, tags);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Images[e.RowIndex].id != EmptyImg.id)
            {
                SetDisplayImage(Images[e.RowIndex].Location);
            }
        }
    }
}
