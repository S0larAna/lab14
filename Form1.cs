using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            //gr.DrawRectangle(myPen, 10, 10, 50, 50);
            //gr.DrawLine(myPen, 10, 10, 60, 60);
            //gr.DrawLine(myPen, 10, 60, 60, 10);
            TreeNode tree = new TreeNode();
            tree.AddNode(10);
            tree.AddNode(-3);
            tree.AddNode(-6);
            tree.AddNode(5);
            tree.AddNode(16);
            tree.AddNode(15);
            tree.DrawNode(gr, 400, 5, 200);

        }
    }
}
