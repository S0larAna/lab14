 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace lab14
{
    public class TreeNode
    {
        public int value;
        public TreeNode Left;
        public TreeNode Right;
        public int lvl;
        public sbyte flag;

        public TreeNode()
        {
            this.Left = null;
            this.Right = null;
            lvl = 0;
            flag = 0;
        }
        public TreeNode(int root_value)
        {
            this.value = root_value;
            this.Left = null;
            this.Right = null;
            lvl = 0;
            flag = 0;
        }

        public void AddNode(int value)
        {
            if (this.value > value)
            {
                if (this.Left == null)
                {
                    TreeNode t = new TreeNode();
                    t.lvl = lvl + 1;
                    t.value = value;
                    t.flag = -1;
                    this.Left = t;
                }
                else Left.AddNode(value);
            }
            else
            {
                if (this.Right == null)
                {
                    TreeNode t = new TreeNode();
                    t.lvl = lvl + 1;
                    t.value = value;
                    t.flag = 1;
                    this.Right = t;
                }
                else Right.AddNode(value);
            }
        }
        public int Sum()
        {
            if (Left == null && Right == null)
            {
                return value;
            }
            else if (Left == null && Right != null) return value + Right.Sum();
            else if (Left != null && Right == null) return value + Left.Sum();
            else
            {
                return value + Left.Sum() + Right.Sum();
            }
        }

        public int CountNodes()
        {
            if (Left == null && Right == null) return 1;
            else if (Left == null && Right != null) return 1 + Right.CountNodes();
            else if (Left != null && Right == null) return 1 + Left.CountNodes();
            else return 1 + Right.CountNodes() + Left.CountNodes();
        }

        public float Avg()
        {
            return this.Sum() / this.CountNodes();
        }

        public void ModifyTree(float m)
        {
            if (this.value < m) this.value =-value;
            if (Left == null && Right == null) return;
            if (Right != null) Right.ModifyTree(m);
            if (Left != null) Left.ModifyTree(m);
        }

        public int SumOdd()
        {
            if (Left == null && Right == null && lvl % 2 == 1) return value;
            else if (Left == null && Right == null && lvl % 2 == 0) return 0;
            else if (Left == null && Right != null && lvl % 2 == 1) return value + Right.SumOdd();
            else if (Left == null && Right != null && lvl % 2 == 0) return Right.SumOdd();
            else if (Left != null && Right == null && lvl % 2 == 1) return value + Left.SumOdd();
            else if (Left != null && Right == null && lvl % 2 == 0) return Left.SumOdd();
            else if (lvl % 2 == 0) return Right.SumOdd() + Left.SumOdd();
            else return value + Right.SumOdd() + Left.SumOdd();

        }

        public int SumEven()
        {
            if (Left == null && Right == null && lvl % 2 == 0) return value;
            else if (Left == null && Right == null && lvl % 2 == 1) return 0;
            else if (Left == null && Right != null && lvl % 2 == 0) return value + Right.SumEven();
            else if (Left == null && Right != null && lvl % 2 == 1) return Right.SumEven();
            else if (Left != null && Right == null && lvl % 2 == 0) return value + Left.SumEven();
            else if (Left != null && Right == null && lvl % 2 == 1) return Left.SumEven();
            else if (lvl % 2 == 1) return Right.SumEven() + Left.SumEven();
            else return value + Right.SumEven() + Left.SumEven();
        }

        public bool CheckIfBST()
        {
            if (Left != null && Right!=null)
            {
                if (value <= Left.value || value > Right.value) return false;
                else return true & Left.CheckIfBST() & Right.CheckIfBST();
            }
            if (Left!= null && Right == null)
            {
                if (value <= Left.value) return false;
                else return true & Left.CheckIfBST();
            }
            if (Left == null && Right != null)
            {
                if (value > Right.value) return false;
                else return true & Right.CheckIfBST();
            }
            else return true;
        }

        public void SaveToFile(StreamWriter writer)
        {
            writer.Write(value + " ");
            if (Left != null) Left.SaveToFile(writer);
            if (Right != null) Right.SaveToFile(writer);
        }

        public void TreeToArray(int[] n, int i)
        {
            n[i] = value;
            if (Left != null) Left.TreeToArray(n, i+1);
            if (Right != null) Right.TreeToArray(n, i + 1);
        }

        public void DrawNode(Graphics gr, float x, float y, float dx)
        {
            Color color;
            if (lvl == 0) color = Color.DarkBlue;
            else if (flag == -1) color = Color.SeaGreen;
            else color = Color.Orange;
            Pen myPen = new Pen(color, 5);
            SolidBrush aqua = new SolidBrush(color);
            SolidBrush white = new SolidBrush(Color.White);
            Pen Lines = new Pen(Color.DarkBlue, 5);
            Font font = new Font("Colibri", 8);
            if (Left != null)
            {
                gr.DrawLine(Lines, x+6, y+14, x -dx*0.5f, y+50);
                Left.DrawNode(gr, x- dx*0.5f, y+50, dx*0.5f);
            }
            if (Right != null)
            {
                gr.DrawLine(Lines, x+6, y+14, x+dx*0.5f, y+50);
                Right.DrawNode(gr, x+dx*0.5f, y+50, dx*0.5f);
            }
            gr.DrawEllipse(myPen, x-14, y, 25, 25);
            gr.FillEllipse(aqua, x-14, y, 25, 25);
            gr.DrawString(Convert.ToString(this.value), font, white, x-8, y+5);
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
