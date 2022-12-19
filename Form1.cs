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

namespace lab14
{

    public partial class Form1 : Form
    {
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
            TreeNode tree = new TreeNode();
            //tree.AddNode(10);
            //tree.AddNode(-3);
            //tree.AddNode(-6);
            //tree.AddNode(5);
            //tree.AddNode(16);
            //tree.AddNode(15);
            //tree.AddNode(19);
            //tree.AddNode(20);
            tree.DrawNode(gr, 400, 5, 300);
            string seq = textBox2.Text;
            string[] nodes = seq.Split();
            for (int i=0; i<nodes.Length; i++)
            {
                tree.AddNode(Convert.ToInt32(nodes[i]));
            }
            tree.DrawNode(gr, 400, 5, 300);
        }

        private void Process_Click(object sender, EventArgs e)
        {
            TreeNode tree = new TreeNode();
            string seq = textBox2.Text;
            string[] nodes = seq.Split();
            for (int i = 0; i < nodes.Length; i++)
            {
                tree.AddNode(Convert.ToInt32(nodes[i]));
            }
            textBox1.Text = Convert.ToString(tree.SumOdd()-tree.SumEven());
        }
    }
}
