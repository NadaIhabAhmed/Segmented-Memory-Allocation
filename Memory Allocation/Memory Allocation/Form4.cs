﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * This form is for memory viewing
 */

namespace Memory_Allocation
{
    public partial class Form4 : Form
    {
        /*-------------------------------------------------------*/
        //public static System.Drawing.Color[] col = new System.Drawing.Color[5];
        public static Panel panels = new Panel();
        public static int u = 0;
        /*-------------------------------------------------------*/

        List<int> chart_location = new List<int>();
        List<int> chart_size = new List<int>();
        List<string> chart_name = new List<string>();
        List<int> chart_id = new List<int>();
        /*-------------------------------------------------------*/

        int mem_size;
        void draw_legend(int x)
        {
            Random r = new Random();

            panels = new Panel();
            panels.Height = 20;
            panels.Width = 20;
            if (x == 0)
            {
                panels.BackColor = Color.FromArgb(128, 223, 255);//hole
                panels.Location = new System.Drawing.Point(10, 250);
                this.Controls.Add(panels);

            }
            else if (x == 1)
            {
                panels.BackColor = Color.FromArgb(217, 166, 166);//old process
                panels.Location = new System.Drawing.Point(10, 280);
                this.Controls.Add(panels);
            }
            else if (x == 2)
            {
                //int red = r.Next(0, 254);  // creates a number between 0 and 254 
                //int green = r.Next(0, 254);  // creates a number between 0 and 254 
                //int blue = r.Next(0, 102);  // creates a number between 0 and 254 

                panels.BackColor = Color.FromArgb(255, 255, 102);
                panels.Location = new System.Drawing.Point(10, 310);
                this.Controls.Add(panels);
            }

        }

        void drawing_shape(int x)
        {
            // Random r = new Random();
            panels = new Panel();
            //panels[index].Name = "q" + index.ToString();
            //panels[index].Text = "P" + index.ToString();
            panels.Height = x;
            panels.Width = 150;
            //panels[index].BackColor = col[index];
            //Random r = new Random();
            // int red = r.Next(0, 254);  // creates a number between 0 and 254 
            // int green = r.Next(0, 254);  // creates a number between 0 and 254 
            //int blue = r.Next(0, 254);  // creates a number between 0 and 254 

            panels.BackColor = Color.FromArgb(255, 255, 102);
            panels.Location = new System.Drawing.Point(150, u);
            u = u + x;
            this.Controls.Add(panels);
        }
        void draw_hole(int x)
        {
            panels = new Panel();
            //panels[index].Name = "q" + index.ToString();
            //panels[index].Text = "P" + index.ToString();
            panels.Height = x;
            panels.Width = 150;
            //panels[index].BackColor = col[index];
            //Random r = new Random();
            panels.BackColor = Color.FromArgb(128, 223, 255);

            panels.Location = new System.Drawing.Point(150, u);
            u = u + x;
            this.Controls.Add(panels);
        }

        void draw_old(int x)
        {
            panels = new Panel();
            //panels[index].Name = "q" + index.ToString();
            //panels[index].Text = "P" + index.ToString();
            panels.Height = x;
            panels.Width = 150;
            //panels[index].BackColor = col[index];
            //Random r = new Random();
            panels.BackColor = Color.FromArgb(217, 166, 166);
            panels.Location = new System.Drawing.Point(150, u);
            u = u + x;
            this.Controls.Add(panels);
        }

        /*-------------------------------------------------------*/

        public Form4(List<int> loc, List<int> si, List<string> name, List<int> id, int mem)
        {
            u = 0;
            InitializeComponent();
            chart_location = loc;
            chart_size = si;
            chart_name = name;
            chart_id = id;

            mem_size = mem;
            //Drawing Loop
            for (int s = 0; s < chart_size.Count(); s++)
            {
                //nada += (chart_size[u].ToString() + " ");
                //textBox1.Text = nada;
                if (chart_name[s] == "P")
                {
                    draw_old(chart_size[s] * 500 / mem_size);
                    Label lbl = new Label();
                    lbl.Font = new Font("Arial", 6, FontStyle.Bold);
                    lbl.Text = "loc: " + chart_location[s] + "          OP " + chart_id[s].ToString() + "     " + chart_size[s].ToString() + "KB";
                    panels.Controls.Add(lbl);
                }
                else if (chart_name[s] == "H")
                {
                    draw_hole(chart_size[s] * 500 / mem_size);
                    Label lbl3 = new Label();
                    lbl3.Font = new Font("Arial", 6, FontStyle.Bold);
                    lbl3.Text = "loc: " + chart_location[s] + "          H " + chart_id[s].ToString() + "     " + chart_size[s].ToString() + "KB";
                    panels.Controls.Add(lbl3);
                }
                else
                {
                    drawing_shape(chart_size[s] * 500 / mem_size);
                    Label lbl4 = new Label();
                    lbl4.Font = new Font("Arial", 6, FontStyle.Bold);
                    lbl4.Text = "loc: " + chart_location[s] + "      " + chart_name[s] + "      " + chart_size[s].ToString() + "KB";
                    panels.Controls.Add(lbl4);
                }
            }


            draw_legend(0);
            draw_legend(1);
            draw_legend(2);

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
