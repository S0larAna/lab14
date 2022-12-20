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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pen myPen = new Pen(Color.Black, 5);
                Graphics gr = Graphics.FromHwnd(pictureBox1.Handle);
                string seq = textBox2.Text;
                nodes = seq.Split(' ');
                if (nodes.Length == 0) throw new Exception("Empty String");
                TreeNode tree = new TreeNode(Convert.ToInt32(nodes[0]));
                for (int i = 1; i < nodes.Length; i++)
                {
                    tree.AddNode(Convert.ToInt32(nodes[i]));
                }
                tree.DrawNode(gr, 400, 5, 300);
                Debug.WriteLine(tree.CheckIfBST());
                myPen.Dispose();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Process_Click(object sender, EventArgs e)
        {
            try
            {
                Pen myPen = new Pen(Color.Black, 5);
                Graphics gr = Graphics.FromHwnd(pictureBox1.Handle);
                TreeNode tree = new TreeNode(Convert.ToInt32(nodes[0]));
                for (int i = 1; i < nodes.Length; i++)
                {
                    tree.AddNode(Convert.ToInt32(nodes[i]));
                }
                textBox1.Text = Convert.ToString(tree.SumOdd() - tree.SumEven());
                tree.ModifyTree(tree.Avg());
                textBox3.Text = $"Is the modified tree binary? {tree.CheckIfBST()}";
                tree.DrawNode(gr, 400, 5, 300);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(@"C:\Users\PC\source\repos\lab14_pull\tree\tree.res");
            StreamWriter writer = file.CreateText();
            TreeNode tree = new TreeNode(Convert.ToInt32(nodes[0]));
            for (int i = 1; i < nodes.Length; i++)
            {
                tree.AddNode(Convert.ToInt32(nodes[i]));
            }
            tree.SaveToFile(writer);
            writer.Close();
        }
    }
}
