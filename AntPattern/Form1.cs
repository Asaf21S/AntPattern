using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AntPattern
{
    public partial class Form1 : Form
    {
        int counter = 0;
        static Color[,] board = new Color[500, 500];
        int tick = 0;
        int n = 12;
        int startX = 500, startY = 500;
        string src = "n";
        static Node<Rules> p;
        public Form1()
        {
            InitializeComponent();
        }

        private static string SetUp()
        {
            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    board[i, j] = new Color();
                    board[i, j] = Color.White;
                }
            }
            Random rnd = new Random();
            
            
            Rules rules1 = new Rules(Color.White);
            Rules rules2 = new Rules(Color.Red);
            Rules rules3 = new Rules(Color.Green);
            Rules rules4 = new Rules(Color.Aqua);
            Rules rules5 = new Rules(Color.Yellow);
            Rules rules6 = new Rules(Color.Pink);
            Rules rules7 = new Rules(Color.Gray);
            Rules rules8 = new Rules(Color.Brown);
            Rules rules9 = new Rules(Color.DarkGreen);
            Rules rules10 = new Rules(Color.Blue);
            Rules rules11 = new Rules(Color.Purple);
            Rules rules12 = new Rules(Color.Orange);
            string ret = "1:" + (rules1.dir ? "R" : "L") + "  2:" + (rules2.dir ? "R" : "L") + "  3:" + (rules3.dir ? "R" : "L") + "  4:" + (rules4.dir ? "R" : "L") + "  5:" + (rules5.dir ? "R" : "L") + "  6:" + (rules6.dir ? "R" : "L") + "  7:" + (rules7.dir ? "R" : "L") + "  8:" + (rules8.dir ? "R" : "L") + "  9:" + (rules9.dir ? "R" : "L") + "  10:" + (rules10.dir ? "R" : "L") + "  11:" + (rules11.dir ? "R" : "L") + "  12:" + (rules12.dir ? "R" : "L");
            Node <Rules> first;
            p = new Node<Rules>(rules1);
            first = p;
            //
            p.SetNext(new Node<Rules>(rules2));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules3));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules4));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules5));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules6));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules7));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules8));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules9));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules10));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules11));
            p = p.GetNext();
            //
            p.SetNext(new Node<Rules>(rules12));
            p = p.GetNext();
            //
            p.SetNext(first);
            p = first;
            return ret;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tick == 0)
            {
                Graphics g = CreateGraphics();
                g.Clear(Color.White);
                string ret = SetUp();
                lbl3.Text = ret + "\nSeed: " + GetSeed();
            }
            Random rnd = new Random();
            lbl1.Text = "Steps: " + (tick + 1).ToString();
            for (int i = 0; i < 200; i++)
            {
                src = DrawStep(startX, startY, src);
                if (src == "n")
                {
                    startY -= 2;
                }
                else if (src == "s")
                {
                    startY += 2;
                }
                else if (src == "e")
                {
                    startX += 2;
                }
                else if (src == "w")
                {
                    startX -= 2;
                }
            }
            
            counter+= 200;
            tick+=200;
        }

        private string GetSeed()
        {
            int seed = 0;
            for (int i = 0; i < n; i++)
            {
                if (p.GetValue().dir) seed += (int)Math.Pow(2, i);
                p = p.GetNext();
            }
            return seed.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl2.Text = "steps per second: " + counter;
            counter = 0;
        }

        private void btnRnd_Click(object sender, EventArgs e)
        {
            tick = 0;
            startX = 500; startY = 500;
        }

        protected string DrawStep(int x, int y, string source)
        {
            Graphics g = CreateGraphics();
            if (x > this.Width - 4 || x < 4 || y > this.Height - 4 || y < 4)
            {
                tick = -200;
                startX = 500; startY = 500;
                return "n";
            }

            Color current = board[(int)x / 2, (int)y / 2];
            SolidBrush br = new SolidBrush(current);
            bool find = false;
            for (int i = 0; i < n && !find; i++)
            {
                if (p.GetValue().clr == current)
                {
                    p = p.GetNext();
                    find = true;
                }
                else
                    p = p.GetNext();
            }
            br.Color = p.GetValue().clr;
            g.FillRectangle(br, x, y, 2, 2);
            board[(int)x / 2, (int)y / 2] = p.GetValue().clr;
            switch (source)
            {
                case "n":
                    if (p.GetValue().dir)
                        return "e";
                    else
                        return "w";
                case "s":
                    if (p.GetValue().dir)
                        return "w";
                    else
                        return "e";
                case "e":
                    if (p.GetValue().dir)
                        return "s";
                    else
                        return "n";
                case "w":
                    if (p.GetValue().dir)
                        return "n";
                    else
                        return "s";
                default:
                    return "ERROR";
            }
        }

    }
}
