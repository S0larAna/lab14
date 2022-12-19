using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lab14
{
    public class TreeNode
    {
        public int value;
        public TreeNode Left;
        public TreeNode Right;
        public int lvl;

        public TreeNode()
        {
            this.Left = null;
            this.Right = null;
            lvl = 0;
        }

        public void AddNode(int value)
        {
            if (this.value > value)
            {
                if (this.Left == null)
                {
                    TreeNode t = new TreeNode();
                    t.lvl = this.lvl + 1;
                    t.value = value;
                    this.Left = t;
                }
                else Left.AddNode(value);
            }
            else
            {
                if (this.Right == null)
                {
                    TreeNode t = new TreeNode();
                    t.lvl = this.lvl + 1;
                    t.value = value;
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
            else if (Left == null && Right != null) return value += Right.Sum();
            else if (Left != null && Right == null) return value += Left.Sum();
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
            if (this.value < m) value =-value;
            if (Left == null && Right == null) return;
            if (Left == null && Right != null) Right.ModifyTree(m);
            else if (Left != null && Right == null) Left.ModifyTree(m);
            else
            {
                Left.ModifyTree(m);
                Right.ModifyTree(m);
            }
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
            else if (Left == null && Right != null && lvl % 2 == 0) return value + Right.SumOdd();
            else if (Left == null && Right != null && lvl % 2 == 1) return Right.SumOdd();
            else if (Left != null && Right == null && lvl % 2 == 0) return value + Left.SumOdd();
            else if (Left != null && Right == null && lvl % 2 == 1) return Left.SumOdd();
            else if (lvl % 2 == 1) return Right.SumOdd() + Left.SumOdd();
            else return value + Right.SumOdd() + Left.SumOdd();
        }

        public void DrawNode(Graphics gr, float x, float y, float dx)
        {
            Pen myPen = new Pen(Color.Aquamarine, 5);
            SolidBrush aqua = new SolidBrush(Color.Aquamarine);
            SolidBrush black = new SolidBrush(Color.Black);
            Font font = new Font("Colibri", 8);
            //float dx = 100;
            //Rectangle r = new Rectangle(x, y, 25, 25);
            if (Left != null)
            {
                gr.DrawLine(myPen, x+6, y+14, x -dx*0.5f, y+50);
                Left.DrawNode(gr, x- dx*0.5f, y+50, dx*0.5f);
            }
            if (Right != null)
            {
                gr.DrawLine(myPen, x+6, y+14, x+dx*0.5f, y+50);
                Right.DrawNode(gr, x+dx*0.5f, y+50, dx*0.5f);
            }
            gr.DrawEllipse(myPen, x-14, y, 25, 25);
            gr.FillEllipse(aqua, x-14, y, 25, 25);
            gr.DrawString(Convert.ToString(this.value), font, black, x-8, y+5);
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
