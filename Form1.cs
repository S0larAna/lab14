using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab14
{
    public partial class Form1 : Form
    {
        public string[] nodes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 5);
            Graphics gr = Graphics.FromHwnd(pictureBox1.Handle);
            string seq = textBox2.Text;
            string[] nodes = seq.Split();
            TreeNode tree = new TreeNode(Convert.ToInt32(nodes[0]));
            for (int i=1; i<nodes.Length; i++)
            {
                tree.AddNode(Convert.ToInt32(nodes[i]));
            }
            tree.DrawNode(gr, 400, 5, 300);
            Debug.WriteLine(tree.CheckIfBST());
        }

        private void Process_Click(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 5);
            Graphics gr = Graphics.FromHwnd(pictureBox1.Handle);
            string seq = textBox2.Text;
            string[] nodes = seq.Split();
            TreeNode tree = new TreeNode(Convert.ToInt32(nodes[0]));
            for (int i = 1; i < nodes.Length; i++)
            {
                tree.AddNode(Convert.ToInt32(nodes[i]));
            }
            textBox1.Text = Convert.ToString(tree.SumOdd() - tree.SumEven());
            tree.ModifyTree(tree.Avg());
            tree.DrawNode(gr, 400, 5, 300);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //
        }
    }
}
