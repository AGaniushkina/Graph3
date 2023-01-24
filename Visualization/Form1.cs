using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualization
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        
        Point click;
        Graphics g;
       // RichTextBox textBox = new RichTextBox();
        int countElem = 0;
        List<Point> poi = new List<Point>();
        //Dictionary<int, List<int>> nodes = new Dictionary<int, List<int>>();
        Dictionary<string, List<string>> nodes = new Dictionary<string, List<string>>();
        bool directed;
        bool weighted;
        Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();

        //List<string> gorod = new List<string>() { "Engels", "Saratov", "Voronezh", "Moscow", "vladivostok", "Volgograd", "Rostov", "Magadan", "Khabarovsk" };
        List<string> gorod = new List<string>() { };
        private void Form1_Load(object sender, EventArgs e)
        {
            //nodes.Add(0, new List<int>());
            //nodes[0].Add(1);

            //nodes.Add(1, new List<int>());
            //nodes[1].Add(2);
            //nodes[1].Add(3);
            //nodes.Add(5, new List<int>());
            //nodes[5].Add(1);
            //nodes[5].Add(6);

            //nodes.Add(8, new List<int>());
            //nodes[8].Add(4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Magenta, 5);
            foreach (string k in nodes.Keys)
            {
                foreach (string l in nodes[k])
                {
                    if (gorod.IndexOf(k) < poi.Count && gorod.IndexOf(l) < poi.Count)
                    {
                        if (directed)
                        {
                            pen.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                            g.DrawLine(pen, poi[gorod.IndexOf(k)].X, poi[gorod.IndexOf(k)].Y, poi[gorod.IndexOf(l)].X, poi[gorod.IndexOf(l)].Y); //g.Draw
                        }
                        else
                        {
                            g.DrawLine(pen, poi[gorod.IndexOf(k)].X, poi[gorod.IndexOf(k)].Y, poi[gorod.IndexOf(l)].X, poi[gorod.IndexOf(l)].Y);
                        }
                    }
                }
            }
            ////for ( int i = 0; i < poi.Count - 1; i++ )
            ////{
            ////    g.DrawLine(Pens.Magenta, poi[i].X, poi[i].Y, poi[i + 1].X, poi[i + 1].Y);
            ////}
            //foreach (int k in nodes.Keys)
            //{
            //    foreach (int l in nodes[k])
            //    {
            //        if (k < poi.Count && l < poi.Count)
            //        {
            //            g.DrawLine(Pens.Magenta, poi[k].X, poi[k].Y, poi[l].X, poi[l].Y);
            //            //g.Draw
            //        }
            //    }
            //}
            ////}
            ////for (int i = 0; i < poi.Count; i++)
            ////{
            ////    if (nodes[i] < poi.Count)
            ////    {
            ////        g.DrawLine(Pens.Magenta, poi[i].X, poi[i].Y, poi[nodes[i]].X, poi[nodes[i]].Y);
            ////    }

            ////}
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            g.Clear(Color.Azure);
            
            //textBox.Dock = DockStyle.Fill;
            //Controls.Add(textBox);
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;
            Pen pen = new Pen(Color.Black, 10);
            g.DrawEllipse(pen, click.X - 30, click.Y - 30, 60, 60);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            click = e.Location;

            TextBox tx = new TextBox();
            tx.Name = "tex" + countElem;
            tx.Location = new Point(click.X - 20, click.Y);
            tx.Size = new Size(40, 20);
            //tx.Text = "";
            if (countElem < gorod.Count)
            {
                tx.Text = gorod[countElem];
            }
            else
            {
                tx.Text = "";
            }
            tx.TabIndex = countElem;
            this.Controls.Add(tx);
            countElem++;

            //textBox.Text = new Text();
            //tx.Name = "tex" + countElem;
            //tx.Location = new Point(click.X - 20, click.Y);
            //tx.Size = new Size(40, 20);
            //tx.Text = "";
            //tx.TabIndex = countElem;
            //this.Controls.Add(tx);
            //countElem++;

            g.DrawEllipse(Pens.Black, click.X - 30, click.Y - 30, 60, 60);
            
            poi.Add(click);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            click = new Point(e.X, e.Y);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader fileIn = new StreamReader(fileStream))
                    {
                        nodes.Clear();
                        gorod.Clear();
                        


                        string prm = fileIn.ReadLine();
                        string[] prms = prm.Split();
                        directed = bool.Parse(prms[0]);
                        weighted = bool.Parse(prms[1]);
                        var dict = new Dictionary<string, Dictionary<string, double>>();
                        int n = int.Parse(fileIn.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            string line = fileIn.ReadLine();
                            string[] data = line.Split();
                            if (weighted)
                            {
                                if (data.Length == 1)
                                {
                                    if (!dict.ContainsKey(data[0]))
                                    {
                                        dict.Add(data[0], new Dictionary<string, double>());
                                        gorod.Add(data[0]);
                                        nodes.Add(data[0], new List<string>());

                                    }
                                }
                                else if (data.Length == 3)
                                {
                                    if (directed)
                                    {
                                        Dictionary<string, double> value = new Dictionary<string, double>();
                                        double weight = double.Parse(data[2]);
                                        value.Add(data[1], weight);
                                        if (!dict.ContainsKey(data[0]))
                                        {
                                            dict.Add(data[0], value);
                                            gorod.Add(data[0]);
                                            nodes.Add(data[0], new List<string>());
                                            nodes[data[0]].Add(data[1]);
                                            if (!dict.ContainsKey(data[1]) && dict.ContainsKey(data[0]))
                                            {
                                                dict.Add(data[1], new Dictionary<string, double>());
                                                gorod.Add(data[1]);
                                                nodes.Add(data[1], new List<string>());
                                            }
                                        }
                                        else
                                        {
                                            dict[data[0]].Add(data[1], weight);
                                            nodes[data[0]].Add(data[1]);
                                            if (!dict.ContainsKey(data[1]) && dict.ContainsKey(data[0]))
                                            {
                                                dict.Add(data[1], new Dictionary<string, double>());
                                                gorod.Add(data[1]);
                                                nodes.Add(data[1], new List<string>());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Dictionary<string, double> value = new Dictionary<string, double>();
                                        double weight = double.Parse(data[2]);
                                        value.Add(data[1], weight);
                                        if (!dict.ContainsKey(data[0]))
                                        {
                                            dict.Add(data[0], value);
                                            gorod.Add(data[0]);
                                            nodes.Add(data[0], new List<string>());
                                            nodes[data[0]].Add(data[1]);
                                        }
                                        else
                                        {
                                            dict[data[0]].Add(data[1], weight);
                                            nodes[data[0]].Add(data[1]);
                                        }

                                        Dictionary<string, double> value2 = new Dictionary<string, double>();
                                        value2.Add(data[0], weight);
                                        if (!dict.ContainsKey(data[1]))
                                        {
                                            dict.Add(data[1], value2);
                                            gorod.Add(data[1]);
                                            nodes.Add(data[1], new List<string>());
                                            nodes[data[1]].Add(data[0]);
                                        }
                                        else
                                        {
                                            dict[data[1]].Add(data[0], weight);
                                            
                                            nodes[data[1]].Add(data[0]);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Неверное количество аргументов");
                                }
                            }
                            else
                            {
                                if (data.Length == 1)
                                {
                                    if (!dict.ContainsKey(data[0]))
                                    {
                                        dict.Add(data[0], new Dictionary<string, double>());
                                        gorod.Add(data[0]);
                                        nodes.Add(data[0], new List<string>());
                                    }
                                }
                                else if (data.Length == 2)
                                {
                                    if (directed)
                                    {
                                        Dictionary<string, double> value = new Dictionary<string, double>();
                                        double weight = 0;
                                        value.Add(data[1], weight);
                                        if (!dict.ContainsKey(data[0]))
                                        {
                                            dict.Add(data[0], value);
                                            gorod.Add(data[0]);
                                            nodes.Add(data[0], new List<string>());
                                            if (!dict.ContainsKey(data[1]) && dict.ContainsKey(data[0]))
                                            {
                                                dict.Add(data[1], new Dictionary<string, double>());
                                                gorod.Add(data[1]);
                                                nodes.Add(data[1], new List<string>());
                                            }
                                        }
                                        else
                                        {
                                            if (!dict.ContainsKey(data[1]))
                                            {
                                                dict.Add(data[1], new Dictionary<string, double>());
                                                gorod.Add(data[1]);
                                                nodes.Add(data[1], new List<string>());
                                            }
                                            dict[data[0]].Add(data[1], weight);
                                            nodes[data[0]].Add(data[1]);
                                        }
                                    }
                                    else
                                    {
                                        Dictionary<string, double> value = new Dictionary<string, double>();
                                        double weight = 0;
                                        value.Add(data[1], weight);
                                        if (!dict.ContainsKey(data[0]))
                                        {
                                            dict.Add(data[0], value);
                                            gorod.Add(data[0]);
                                            nodes.Add(data[0], new List<string>());

                                            if (!dict.ContainsKey(data[1]) && dict.ContainsKey(data[0]))
                                            {
                                                gorod.Add(data[1]);
                                                dict.Add(data[1], new Dictionary<string, double>());
                                                nodes.Add(data[1], new List<string>());
                                            }
                                        }
                                        else
                                        {
                                            if (!dict.ContainsKey(data[1]))
                                            {
                                                gorod.Add(data[1]);
                                                dict.Add(data[1], new Dictionary<string, double>());
                                                nodes.Add(data[1], new List<string>());
                                            }
                                            dict[data[0]].Add(data[1], weight);
                                            
                                            nodes[data[0]].Add(data[1]);
                                        }

                                        Dictionary<string, double> value2 = new Dictionary<string, double>();
                                        value2.Add(data[0], weight);
                                        if (!dict.ContainsKey(data[1]))
                                        {
                                            dict.Add(data[1], value2);
                                            gorod.Add(data[1]);
                                            nodes[data[1]].Add(data[0]);
                                        }
                                        else
                                        {
                                            dict[data[1]].Add(data[0], weight);
                                            nodes[data[1]].Add(data[0]);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Неверное количество аргументов");
                                }
                            }
                        }
                        graph = new Dictionary<string, Dictionary<string, double>> (dict);
                        
                    }
                    
                }
            }
        }
    }
}
