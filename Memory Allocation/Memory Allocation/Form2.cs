using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * This form is allocate holes and old processes
 */

namespace Memory_Allocation
{
    public partial class Form2 : Form
    {
        int view_memory_button_entrance = 0; // needed to keep memory drawing as it is without addition of any extra weird thing
        int num_processes = 0;
        /*-------------------------------------------------------*/
        //public static System.Drawing.Color[] col = new System.Drawing.Color[5];
        public static Panel panels = new Panel();
        public static int u = 0;
        /*-------------------------------------------------------*/

        DataTable hole_table = new DataTable();
        List<int> hole_location = new List<int>();
        List<int> hole_size = new List<int>();
        List<int> old_process_size = new List<int>();
        List<int> old_process_location = new List<int>();

        List<int> chart_location = new List<int>();
        List<int> chart_size = new List<int>();
        List<string> chart_name = new List<string>();
        List<int> chart_id = new List<int>();

        List<int> chart_location1 = new List<int>();
        List<int> chart_size1 = new List<int>();
        List<string> chart_name1 = new List<string>();
        List<int> chart_id1 = new List<int>();

        int i;
        int memory_size;
        int flag = 0;
        public Form2(int mem_size)
        {
            InitializeComponent();
            memory_size = mem_size;

            /*-------------------------------------------------------*/
            //col[0] = Color.FromArgb(0, 0, 0);
            /*-------------------------------------------------------*/
        }
        
   
        /*-------------------------------------------------------*/
        void drawing_shape(int x)
        {
            panels = new Panel();
            //panels[index].Name = "q" + index.ToString();
            //panels[index].Text = "P" + index.ToString();
            panels.Height = x;
            panels.Width = 70;
            //panels[index].BackColor = col[index];
            //Random r = new Random();
            // int red = r.Next(0, 254);  // creates a number between 0 and 254 
            // int green = r.Next(0, 254);  // creates a number between 0 and 254 
            // int blue = r.Next(0, 254);  // creates a number between 0 and 254 

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
            panels.Width = 70;
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
            panels.Width = 70;
            //panels[index].BackColor = col[index];
            //Random r = new Random();
            panels.BackColor = Color.FromArgb(217, 166, 166);
            panels.Location = new System.Drawing.Point(150, u);
            u = u + x;
            this.Controls.Add(panels);
        }
       

        /*-------------------------------------------------------*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            hole_table.Columns.Add("Location", typeof(int));
            hole_table.Columns.Add("Size", typeof(int));
            dataGridView1.DataSource = hole_table;
        }

        // Random r;
        int mem_flag = 0;
        int op_id = 0;
        private void gotosegments_Click(object sender, EventArgs e) // view memory button
        {
            if(view_memory_button_entrance == 0)
            {
                int rowCount = hole_table.Rows.Count; // Count number of rows in data grid
                                                      // textBox1.Text = rowCount.ToString();
                u = 0;
                int hole_size_sum = 0;
                for (i = 0; i < rowCount; i++)
                {
                    var loc = dataGridView1.Rows[i].Cells[0].Value; // take value of cell
                    string Location;
                    Location = loc.ToString(); // change it to string
                    var si = dataGridView1.Rows[i].Cells[1].Value; // take value of cell
                    string size;
                    size = si.ToString();// change it to string

                    if (!((Int32.Parse(Location) < 0 || Int32.Parse(Location) >= memory_size) || (Int32.Parse(size) < 0 || Int32.Parse(size) > memory_size)))
                    {
                        if (Int32.Parse(Location) > mem_flag)
                        {
                            //draw_old((Int32.Parse(Location) - mem_flag) % 300); // draw old process
                            Label lbl = new Label();
                            lbl.Font = new Font("Arial", 8, FontStyle.Bold);
                            lbl.Text = "OP" + op_id.ToString() + " " + (Int32.Parse(Location) - mem_flag).ToString() + "KB";
                            panels.Controls.Add(lbl);
                            old_process_size.Add((Int32.Parse(Location) - mem_flag)); // add old process to size list
                            old_process_location.Add(mem_flag);

                            chart_location.Add(mem_flag);
                            chart_size.Add((Int32.Parse(Location) - mem_flag));
                            chart_name.Add("P");
                            chart_id.Add(op_id);
                            op_id++;
                            //draw_hole((Int32.Parse(size)) % 300); // draw hole
                            Label lbl2 = new Label();
                            lbl2.Font = new Font("Arial", 8, FontStyle.Bold);
                            lbl2.Text = "H" + i.ToString() + (Int32.Parse(size)).ToString() + "KB";
                            panels.Controls.Add(lbl2);
                            if (i == 0)
                            {
                                mem_flag = mem_flag + Int32.Parse(Location) + Int32.Parse(size);
                            }
                            else
                            {
                                mem_flag = Int32.Parse(Location) + Int32.Parse(size);
                            }
                        }
                        else if (Int32.Parse(Location) == mem_flag)
                        {
                            //draw_hole((Int32.Parse(size)) % 300);
                            Label lbl3 = new Label();
                            lbl3.Font = new Font("Arial", 8, FontStyle.Bold);
                            lbl3.Text = "H" + i.ToString() + " " + (Int32.Parse(size)).ToString() + "KB";
                            panels.Controls.Add(lbl3);
                            mem_flag = mem_flag + Int32.Parse(size);
                        }

                        hole_size_sum += Int32.Parse(size);
                        hole_location.Add(Int32.Parse(Location));
                        //textBox1.Text = hole_location[0].ToString();

                        hole_size.Add(Int32.Parse(size));

                        chart_location.Add(Int32.Parse(Location));
                        chart_size.Add(Int32.Parse(size));
                        chart_name.Add("H");
                        chart_id.Add(i);
                        //textBox2.Text = hole_size[0].ToString();

                        // draw_hole(Int32.Parse(size));
                    }
                    else
                    {
                        flag = 0;
                        string message = "Hole " + i.ToString() + " is not valid";
                        MessageBox.Show(message);
                    }
                }
                if (memory_size > mem_flag)
                {
                    //draw_old((memory_size - mem_flag)%300);
                    Label lbl4 = new Label();
                    lbl4.Font = new Font("Arial", 8, FontStyle.Bold);
                    lbl4.Text = "OP" + op_id.ToString() + " " + (memory_size - mem_flag).ToString() + "KB";
                    old_process_size.Add((memory_size - mem_flag)); // add old process to size list
                    old_process_location.Add(mem_flag);

                    chart_location.Add(mem_flag);
                    chart_size.Add(memory_size - mem_flag);
                    chart_name.Add("P");
                    chart_id.Add(op_id);

                    op_id++;
                    panels.Controls.Add(lbl4);
                    mem_flag = memory_size - 1;
                }

                if (hole_size_sum > memory_size)
                {
                    string message = "Total size of Holes are larger than memory size";
                    MessageBox.Show(message);
                }
                view_memory_button_entrance = 1;
            }
           

            Form4 F4 = new Form4(chart_location, chart_size, chart_name, chart_id , memory_size);
            //Form4 F4 = new Form4();
            F4.ShowDialog();

          
        } // end of button gotosegments (view memory)

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int counter_elle=0;
            mem_flag = 0;

                int rowCount = hole_table.Rows.Count; // Count number of rows in data grid
            op_id = 0;                                    // textBox1.Text = rowCount.ToString();
            u = 0;
            int hole_size_sum = 0;
            for (i = 0; i < rowCount; i++)
            {
                var loc1 = dataGridView1.Rows[i].Cells[0].Value; // take value of cell
                string Location1;
                Location1 = loc1.ToString(); // change it to string
                var si1 = dataGridView1.Rows[i].Cells[1].Value; // take value of cell
                string size1;
                size1 = si1.ToString();// change it to string

                if (!((Int32.Parse(Location1) < 0 || Int32.Parse(Location1) >= memory_size) || (Int32.Parse(size1) < 0 || Int32.Parse(size1) > memory_size)))
                {
                    if (Int32.Parse(Location1) > mem_flag)
                    {
                        //draw_old((Int32.Parse(Location) - mem_flag) % 300); // draw old process
                        Label lbl = new Label();
                        lbl.Font = new Font("Arial", 8, FontStyle.Bold);
                        lbl.Text = "OP" + op_id.ToString() + " " + (Int32.Parse(Location1) - mem_flag).ToString() + "KB";
                        panels.Controls.Add(lbl);
                        counter_elle++;
                        old_process_size.Add((Int32.Parse(Location1) - mem_flag)); // add old process to size list
                        old_process_location.Add(mem_flag);

                        chart_location1.Add(mem_flag);

                       

                        chart_size1.Add((Int32.Parse(Location1) - mem_flag));

                        chart_name1.Add("P");
                        chart_id1.Add(op_id);
                        op_id++;
                        //draw_hole((Int32.Parse(size)) % 300); // draw hole
                        Label lbl2 = new Label();
                        lbl2.Font = new Font("Arial", 8, FontStyle.Bold);
                        lbl2.Text = "H" + i.ToString() + (Int32.Parse(size1)).ToString() + "KB";
                        panels.Controls.Add(lbl2);
                        if (i == 0)
                        {
                            mem_flag = mem_flag + Int32.Parse(Location1) + Int32.Parse(size1);
                        }
                        else
                        {
                            mem_flag = Int32.Parse(Location1) + Int32.Parse(size1);
                        }
                    }
                    else if (Int32.Parse(Location1) == mem_flag)
                    {
                        //draw_hole((Int32.Parse(size)) % 300);
                        Label lbl3 = new Label();
                        lbl3.Font = new Font("Arial", 8, FontStyle.Bold);
                        lbl3.Text = "H" + i.ToString() + " " + (Int32.Parse(size1)).ToString() + "KB";
                        panels.Controls.Add(lbl3);
                        mem_flag = mem_flag + Int32.Parse(size1);
                    }

                    hole_size_sum += Int32.Parse(size1);
                    hole_location.Add(Int32.Parse(Location1));
                    //textBox1.Text = hole_location[0].ToString();

                    hole_size.Add(Int32.Parse(size1));
                    counter_elle++;
                    chart_location1.Add(Int32.Parse(Location1));
                    chart_size1.Add(Int32.Parse(size1));
                    chart_name1.Add("H");
                    chart_id1.Add(i);
                    //textBox2.Text = hole_size[0].ToString();

                    // draw_hole(Int32.Parse(size));
                }
                else
                {
                    flag = 0;
                    string message = "Hole " + i.ToString() + " is not valid";
                    MessageBox.Show(message);
                }
            }
            if (memory_size > mem_flag)
            {
                //draw_old((memory_size - mem_flag)%300);
                Label lbl4 = new Label();
                lbl4.Font = new Font("Arial", 8, FontStyle.Bold);
                lbl4.Text = "OP" + op_id.ToString() + " " + (memory_size - mem_flag).ToString() + "KB";
                old_process_size.Add((memory_size - mem_flag)); // add old process to size list
                old_process_location.Add(mem_flag);

                chart_location1.Add(mem_flag);
                chart_size1.Add(memory_size - mem_flag);
                chart_name1.Add("P");
                chart_id1.Add(op_id);

                op_id++;
                panels.Controls.Add(lbl4);
                mem_flag = memory_size - 1;
            }

            if (hole_size_sum > memory_size)
            {
                string message = "Total size of Holes are larger than memory size";
                MessageBox.Show(message);
            }
            //view_memory_button_entrance = 1;
        

        num_processes++;
            
            Form3 F3 = new Form3(chart_location1, chart_size1, chart_name1, chart_id1, num_processes , memory_size);
            //Form3 F3 = new Form3();
            F3.ShowDialog();

            
        }
        
    
    }
}
