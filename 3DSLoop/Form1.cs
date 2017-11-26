using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _3DSLoop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkBox1.Enabled = false;
            label1.Enabled = false;
            label2.Enabled = false;
            open.Filter = "BCSTM File (*.bcstm)|*.bcstm";
        }

        OpenFileDialog open = new OpenFileDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            open.ShowDialog();
            string OpenFile = open.FileName;

            if (DialogResult == DialogResult.None)
            {
                checkBox1.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;

                BinaryReader bnr = new BinaryReader(File.OpenRead(OpenFile));

                bnr.BaseStream.Position = 0x61;
                if (bnr.ReadByte() == (0))
                {
                    label2.Text = "False";
                }
                else
                {
                    label2.Text = "True";
                }

                bnr.Close();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                BinaryWriter bnw = new BinaryWriter(File.OpenWrite(open.FileName));

                bnw.BaseStream.Position = 0x61;
                int value = Convert.ToByte(1);
                bnw.Write(value);

                label2.Text = "True";
                bnw.Close();
            }
            else
            {
                BinaryWriter bnw = new BinaryWriter(File.OpenWrite(open.FileName));

                bnw.BaseStream.Position = 0x61;
                int value = Convert.ToByte(0);
                bnw.Write(value);

                label2.Text = "False";
                bnw.Close();
            }
        }
    }
}
