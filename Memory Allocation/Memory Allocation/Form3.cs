using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Allocation
{

    public partial class Form3 : Form
    {
        int num_processes; // number of processes, will increase if we press on (Allocate new process) button
        /*-------------------------------------------------------*/
        //public static System.Drawing.Color[] col = new System.Drawing.Color[5];
        public static Panel panels = new Panel();
        public static int u = 0;
        /*-------------------------------------------------------*/
        List<int> chart_location = new List<int>();
        List<int> chart_size = new List<int>();
        List<string> chart_name = new List<string>();
        List<int> chart_id = new List<int>();

        /*For checking if all segments will be allocated or not*/
        List<int> temp_location = new List<int>();
        List<int> temp_size = new List<int>();
        List<string> temp_name = new List<string>();
        List<int> temp_id = new List<int>();
        
        List<string> seg_name = new List<string>();
        List<int> seg_size = new List<int>();
        List<int> seg_id = new List<int>();

        public static int pro_count = 0;
        int min_valid = 320000;
        int min_id;
        int mem_size;
        DataTable seg_table = new DataTable();
        //int fl;
        public Form3(List<int> loc, List<int> si, List<string> name, List<int> id, int num_proc , int mem)
        {
            InitializeComponent();
            /*
            chart_location = loc;
            chart_size = si;
            chart_name = name;
            chart_id = id;
            */
            
            temp_location = loc;
            temp_size = si;
            temp_name = name;
            temp_id = id;
            pro_count = num_proc;
            num_processes = num_proc;
            for (int iii = 0; iii < temp_id.Count();iii++)
            {
                chart_id.Add(temp_id[iii]);
                chart_name.Add(temp_name[iii]);
                chart_location.Add(temp_location[iii]);
                chart_size.Add(temp_size[iii]);
            }

            mem_size = mem;
        }

        void drawing_shape(int x)
        {
            Random r = new Random();
            panels = new Panel();
            //panels[index].Name = "q" + index.ToString();
            //panels[index].Text = "P" + index.ToString();
            panels.Height = x;
            panels.Width = 70;
            //panels[index].BackColor = col[index];
            //Random r = new Random();
            int red = r.Next(0, 254);  // creates a number between 0 and 254 
            int green = r.Next(0, 254);  // creates a number between 0 and 254 
            int blue = r.Next(0, 254);  // creates a number between 0 and 254 

            panels.BackColor = Color.FromArgb(red, green, blue);
            panels.Location = new System.Drawing.Point(500, u);
            u = u + x;
            this.Controls.Add(panels);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            seg_table.Columns.Add("name", typeof(string));
            seg_table.Columns.Add("Size", typeof(int));
            dataGridView1.DataSource = seg_table;
        }
        //int seg_id = 0; // segment ID
        private void button1_Click(object sender, EventArgs e) // view memory button
        {
            if (int.TryParse(textBox1.Text, out int num_of_seg))
            {
                /*------------------------------FIRST FIT--------------------------------------*/
                if (first_fit.Checked == true)
                {
                    int counter = temp_id.Count();
                    //num_processes++;
                    //int num_of_seg = Int32.Parse(textBox1.Text);

                    //double mem_size = 0;

                    //textBox1.Text = fl.ToString();
                    int rowCount = seg_table.Rows.Count; // Count number of rows in data grid
                    for (int i = 0; i < num_of_seg; i++)
                    {
                        var name = dataGridView1.Rows[i].Cells[0].Value; // take value of cell
                        string name_str;
                        name_str = name.ToString(); // change it to string
                        seg_name.Add("P" + num_processes.ToString() + name_str); // Add segment name
                        var size = dataGridView1.Rows[i].Cells[1].Value; // take value of cell
                        string size_str;
                        size_str = size.ToString();// change it to string
                        seg_size.Add(Int32.Parse(size_str)); // add segment size

                        seg_id.Add(num_processes); // add segment id which is process id, this id will be the same for all the segments of the same process

                        //seg_id++;
                    }

                    /*--------------------------------------------------------------------*/
                    //Allocating Segments of process i (process ID == num_process)
                    int num_of_allocated_seg = 0;
                    for (int n = 0; n < num_of_seg; n++)
                    {
                        for (int h = 0; h < temp_size.Count(); h++)
                        {
                            if ((seg_size[n] < temp_size[h]) && (temp_name[h] == "H"))
                            {
                                num_of_allocated_seg++;
                                int tloc = temp_location[h];

                                temp_size[h] = temp_size[h] - seg_size[n]; // update hole size (what's left from the hole)
                                                                           //insert segmnet
                                temp_location[h] = temp_location[h] + temp_location[n];
                                temp_name.Insert(h, seg_name[n]); // S means segment
                                temp_size.Insert(h, seg_size[n]); // size of segment
                                temp_id.Insert(h, num_processes);
                                temp_location.Insert(h, tloc); // Wrong

                                break;
                            }
                            else if ((seg_size[n] == temp_size[h]) && (chart_name[h] == "H"))
                            {
                                num_of_allocated_seg++;

                                temp_name.RemoveAt(h); // update the name as they are the same size
                                temp_name.Insert(h, seg_name[n]); // S means segment
                                                                  //temp_size.RemoveAt(h); // size of segment

                                temp_id.RemoveAt(h);// update the id as they are the same size
                                                    //temp_size.Insert(h, seg_size[n]); // size of segment
                                temp_id.Insert(h, num_processes);

                                break;
                            }
                        }
                    }

                    if (num_of_allocated_seg == num_of_seg) // process is allocated 
                    {
                        pro_count++;
                        chart_name = temp_name;
                        chart_id = temp_id;
                        chart_location = temp_location;
                        chart_size = temp_size;
                        /*
                        chart_name.RemoveRange(0, chart_name.Count());
                        chart_id.RemoveRange(0, chart_id.Count());
                        chart_location.RemoveRange(0, chart_location.Count());
                        chart_size.RemoveRange(0, chart_size.Count());
                        for(int p = 0; p < temp_id.Count(); p++)
                        {

                            chart_id.Add(temp_id[p]);
                            chart_name.Add(temp_name[p]);
                            chart_location.Add(temp_location[p]);
                            chart_size.Add(temp_size[p]);
                        }*/
                        num_of_allocated_seg = 0; // reset number of segments
                                                  //Go to form4 (view memory) to draw segments
                        Form4 F4 = new Form4(chart_location, chart_size, chart_name, chart_id , mem_size);
                        //Form4 F4 = new Form4();
                        F4.ShowDialog();
                    }
                    else // process is not allocated
                    {
                        
                        temp_name = chart_name;
                        temp_id = chart_id;
                        temp_location = chart_location;
                        temp_size = chart_size;
                     /*   temp_name.Clear();
                        temp_id.Clear();
                        temp_location.Clear();
                        temp_size.Clear();

                        for (int p = 0; p < chart_id.Count(); p++)
                        {
                            string y = chart_name[p];
                            temp_id.Add(chart_id[p]);
                            temp_name.Add(y);
                            temp_location.Add(chart_location[p]);
                            temp_size.Add(chart_size[p]);
                        }*/
                        num_of_allocated_seg = 0; // reset number of segments
                        string message = "Process" + pro_count.ToString() + " Doesn't fit\n The process will wait";
                        MessageBox.Show(message);
                    }


                    /*--------------------------------------------------------------------*/

                }

                /*------------------------------BEST FIT--------------------------------------*/
                else if (best_fit.Checked == true)
                {
                    //num_processes++;
                    // int num_of_seg = Int32.Parse(textBox1.Text);
                    //textBox1.Text = fl.ToString();
                    int rowCount = seg_table.Rows.Count; // Count number of rows in data grid
                    for (int i = 0; i < num_of_seg; i++)
                    {
                        var name = dataGridView1.Rows[i].Cells[0].Value; // take value of cell
                        string name_str;
                        name_str = name.ToString(); // change it to string
                        seg_name.Add("P" + num_processes.ToString() + name_str); // add segment name
                        var size = dataGridView1.Rows[i].Cells[1].Value; // take value of cell
                        string size_str;
                        size_str = size.ToString();// change it to string
                        seg_size.Add(Int32.Parse(size_str)); // add segment size

                        seg_id.Add(num_processes); // add segment id which is process id, this id will be the same for all the segments of the same process
                                                   //seg_id++;
                    }

                    /*--------------------------------------------------------------------*/
                    //Allocating Segments of process i (process ID == num_process)

                    int num_of_allocated_seg = 0;
                    List<int> valid_holes_id = new List<int>();
                    List<int> valid_holes_size = new List<int>();
                   /// int temp_idd = 0;
                    
                    for (int n = 0; n < num_of_seg; n++)
                    {
                        int temp_idd = 0;
                        min_valid = 320000;
                        for (int h = 0; h < temp_size.Count(); h++)
                        {
                            if ((seg_size[n] <= temp_size[h]) && (temp_name[h] == "H"))
                            {
                               // valid_holes_id.Add(h);
                                valid_holes_id.Add(temp_id[h]);
                                valid_holes_size.Add(temp_size[h]);
                                 temp_idd = h ;
                                if (temp_size[h] < min_valid)
                                {
                                    min_valid = temp_size[h];
                                    min_id = h;
                                }

                            }
                        }
                        if (valid_holes_id.Count() == 1) // there is only one valid hole 
                        {
                            int id = valid_holes_id[0];
                            //allocate process here
                            if (temp_size[temp_idd] == seg_size[n])
                            {
                                temp_name.RemoveAt(temp_idd); // remove this hole
                                temp_name.Insert(temp_idd, seg_name[n]); // insert th esegmnet in the hole
                                temp_id.RemoveAt(temp_idd);
                                temp_id.Insert(temp_idd, n);
                                num_of_allocated_seg++;
                            }
                            else if (temp_size[temp_idd] > seg_size[n])
                            {
                                int tloc = temp_location[temp_idd];

                                temp_size[temp_idd] = temp_size[temp_idd] - seg_size[n]; // update hole size
                                                                           //insert the segment
                                temp_location[temp_idd] = temp_location[temp_idd] + seg_size[n];

                                temp_size.Insert(temp_idd, seg_size[n]);
                                temp_name.Insert(temp_idd, seg_name[n]);
                                temp_id.Insert(temp_idd, pro_count);
                                temp_location.Insert(temp_idd, tloc);
                                num_of_allocated_seg++;
                            }
                        }
                        else if (valid_holes_id.Count() > 1)
                        {
                            //Sorting holes ascendingly
                            int min_hole = valid_holes_size[0];
                            int id = 0;
                            /*for (int o = 0; o < valid_holes_id.Count(); o++)
                            {
                               /* for (int p = 1; p < valid_holes_id.Count(); p++)
                                {
                                    if (temp_size[valid_holes_id[p]] < min_hole)
                                    {
                                        min_hole = temp_size[valid_holes_id[p]];
                                        id = valid_holes_id[p];
                                    }
                                }
                            }*/
                            if (min_valid > seg_size[n])
                            {
                                int tloc = temp_location[min_id];

                                temp_size[min_id] = temp_size[min_id] - seg_size[n];
                                temp_location[min_id] = temp_location[min_id] + seg_size[n];

                                temp_size.Insert(min_id, seg_size[n]); // insert segment size
                                                                   //temp_name.RemoveAt(id); // remove this hole
                                temp_name.Insert(min_id, seg_name[n]); // insert th esegmnet in the hole
                                                                   //temp_id.RemoveAt(id);
                                temp_id.Insert(min_id, pro_count);
                                temp_location.Insert(min_id, tloc);
                                num_of_allocated_seg++;
                            }
                            else if (min_valid == seg_size[n])
                            {
                                temp_name.RemoveAt(min_id); // remove this hole
                                temp_name.Insert(min_id, seg_name[n]); // insert th esegmnet in the hole
                                temp_id.RemoveAt(min_id);
                                temp_id.Insert(min_id, pro_count);
                                num_of_allocated_seg++;
                            }

                            //num_of_allocated_seg++;
                        }
                        else if (valid_holes_id.Count() == 0)
                        {
                            break;
                        }

                        valid_holes_id.RemoveRange(0, valid_holes_id.Count());
                        valid_holes_size.RemoveRange(0, valid_holes_size.Count());

                    }

                    if (num_of_allocated_seg == num_of_seg)
                    {
                        pro_count++;
                        chart_name = temp_name;
                        chart_id = temp_id;
                        chart_location = temp_location;
                        chart_size = temp_size;
                        num_of_allocated_seg = 0; // reset number of segments
                                                  //Go to form4 (view memory) to draw segments
                        Form4 F4 = new Form4(temp_location, temp_size, temp_name, temp_id  , mem_size);
                        //Form4 F4 = new Form4();
                        F4.ShowDialog();
                    }
                    else
                    {
                        temp_name = chart_name;
                        temp_id = chart_id;
                        temp_location = chart_location;
                        temp_size = chart_size;
                        num_of_allocated_seg = 0; // reset number of segments
                        string message = "Process" + pro_count.ToString() + " Doesn't fit\n The process will wait";
                        MessageBox.Show(message);
                    }

                    /*--------------------------------------------------------------------*/
                }

                /*------------------------------WORST FIT--------------------------------------*/


                else if (worst_fit.Checked == true)
                {
                    /* //num_processes++;
                     //  int num_of_seg = Int32.Parse(textBox1.Text);
                     //textBox1.Text = fl.ToString();
                     int rowCount = seg_table.Rows.Count; // Count number of rows in data grid
                     for (int i = 0; i < num_of_seg; i++)
                     {
                         var name = dataGridView1.Rows[i].Cells[0].Value; // take value of cell
                         string name_str;
                         name_str = name.ToString(); // change it to string
                         seg_name.Add("P" + num_processes.ToString() + name_str);// add segment name
                         var size = dataGridView1.Rows[i].Cells[1].Value; // take value of cell
                         string size_str;
                         size_str = size.ToString();// change it to string
                         seg_size.Add(Int32.Parse(size_str));//add segment size

                         seg_id.Add(num_processes); // add segment id which is process id, this id will be the same for all the segments of the same process
                                                    //seg_id++;
                     }

                     //--------------------------------------------------------------------
                     //Allocating Segments of process i (process ID == num_process)
                     int num_of_allocated_seg = 0;
                     List<int> valid_holes_id = new List<int>();
                     for (int n = 0; n < num_of_seg; n++)
                     {
                         for (int h = 0; h < temp_size.Count(); h++)
                         {
                             if ((seg_size[n] <= temp_size[h]) && (chart_name[h] == "H"))
                             {
                                 valid_holes_id.Add(h);
                             }
                         }
                         if (valid_holes_id.Count() == 1) // there is only one valid hole 
                         {
                             int id = valid_holes_id[0];
                             //allocate process here
                             if (temp_size[id] == seg_size[n])
                             {
                                 temp_name.RemoveAt(id); // remove this hole
                                 temp_name.Insert(id, seg_name[n]); // insert th esegmnet in the hole
                                 temp_id.RemoveAt(id);
                                 temp_id.Insert(id, num_processes);
                                 num_of_allocated_seg++;
                             }
                             else if (temp_size[id] > seg_size[n])
                             {
                                 temp_size[id] = temp_id[id] - seg_size[n]; // update hole size
                                 temp_size.Insert(id, seg_size[n]);
                                 temp_name.Insert(id, seg_name[n]);
                                 temp_id.Insert(id, num_processes);
                                 temp_location.Insert(id, temp_location[id + 1]);
                             }
                         }
                         else if (valid_holes_id.Count() > 1)
                         {
                             //Sorting holes ascendingly
                             int min_hole = temp_size[valid_holes_id[0]];
                             int id = 0;
                             for (int o = 0; o < valid_holes_id.Count(); o++)
                             {
                                 for (int p = 1; p < valid_holes_id.Count(); p++)
                                 {
                                     if (temp_size[valid_holes_id[p]] > min_hole)
                                     {
                                         min_hole = temp_size[valid_holes_id[p]];
                                         id = valid_holes_id[p];
                                     }
                                 }
                             }
                             if (min_hole > seg_size[n])
                             {
                                 temp_size[id] = temp_size[id] - seg_size[n];
                                 temp_size.Insert(id, seg_size[n]); // insert segment size
                                                                    //temp_name.RemoveAt(id); // remove this hole
                                 temp_name.Insert(id, seg_name[n]); // insert th esegmnet in the hole
                                                                    //temp_id.RemoveAt(id);
                                 temp_id.Insert(id, num_processes);
                             }
                             else if (min_hole == seg_size[n])
                             {
                                 temp_name.RemoveAt(id); // remove this hole
                                 temp_name.Insert(id, seg_name[n]); // insert th esegmnet in the hole
                                 temp_id.RemoveAt(id);
                                 temp_id.Insert(id, num_processes);
                             }

                             num_of_allocated_seg++;
                         }
                         else if (valid_holes_id.Count() == 0)
                         {
                             break;
                         }

                         valid_holes_id.RemoveRange(0, valid_holes_id.Count());

                     }

                     if (num_of_allocated_seg == num_of_seg)
                     {
                         pro_count++;
                         chart_name = temp_name;
                         chart_id = temp_id;
                         chart_location = temp_location;
                         chart_size = temp_size;
                         num_of_allocated_seg = 0; // reset number of segments
                                                   //Go to form4 (view memory) to draw segments
                         Form4 F4 = new Form4(temp_location, temp_size, temp_name, temp_id,mem_size);
                         //Form4 F4 = new Form4();
                         F4.ShowDialog();
                     }
                     else
                     {
                         temp_name = chart_name;
                         temp_id = chart_id;
                         temp_location = chart_location;
                         temp_size = chart_size;
                         num_of_allocated_seg = 0; // reset number of segments
                         string message = "Process" + num_processes.ToString() + " Doesn't fit\n The process will wait";
                         MessageBox.Show(message);
                     }*/




                    //num_processes++;
                    // int num_of_seg = Int32.Parse(textBox1.Text);
                    //textBox1.Text = fl.ToString();
                    int rowCount = seg_table.Rows.Count; // Count number of rows in data grid
                    for (int i = 0; i < num_of_seg; i++)
                    {
                        var name = dataGridView1.Rows[i].Cells[0].Value; // take value of cell
                        string name_str;
                        name_str = name.ToString(); // change it to string
                        seg_name.Add("P" + num_processes.ToString() + name_str); // add segment name
                        var size = dataGridView1.Rows[i].Cells[1].Value; // take value of cell
                        string size_str;
                        size_str = size.ToString();// change it to string
                        seg_size.Add(Int32.Parse(size_str)); // add segment size

                        seg_id.Add(num_processes); // add segment id which is process id, this id will be the same for all the segments of the same process
                                                   //seg_id++;
                    }

                    /*--------------------------------------------------------------------*/
                    //Allocating Segments of process i (process ID == num_process)

                    int num_of_allocated_seg = 0;
                    List<int> valid_holes_id = new List<int>();
                    List<int> valid_holes_size = new List<int>();
                    /// int temp_idd = 0;

                    for (int n = 0; n < num_of_seg; n++)
                    {
                        int temp_idd = 0;
                        min_valid = 0;
                        for (int h = 0; h < temp_size.Count(); h++)
                        {
                            if ((seg_size[n] <= temp_size[h]) && (temp_name[h] == "H"))
                            {
                                // valid_holes_id.Add(h);
                                valid_holes_id.Add(temp_id[h]);
                                valid_holes_size.Add(temp_size[h]);
                                temp_idd = h;
                                if (temp_size[h] > min_valid)
                                {
                                    min_valid = temp_size[h];
                                    min_id = h;
                                }

                            }
                        }
                        if (valid_holes_id.Count() == 1) // there is only one valid hole 
                        {
                            int id = valid_holes_id[0];
                            //allocate process here
                            if (temp_size[temp_idd] == seg_size[n])
                            {
                                temp_name.RemoveAt(temp_idd); // remove this hole
                                temp_name.Insert(temp_idd, seg_name[n]); // insert th esegmnet in the hole
                                temp_id.RemoveAt(temp_idd);
                                temp_id.Insert(temp_idd, n);
                                num_of_allocated_seg++;
                            }
                            else if (temp_size[temp_idd] > seg_size[n])
                            {
                                int tloc = temp_location[temp_idd];

                                temp_size[temp_idd] = temp_size[temp_idd] - seg_size[n]; // update hole size
                                                                                         //insert the segment
                                temp_location[temp_idd] = temp_location[temp_idd] + seg_size[n];

                                temp_size.Insert(temp_idd, seg_size[n]);
                                temp_name.Insert(temp_idd, seg_name[n]);
                                temp_id.Insert(temp_idd, pro_count);
                                temp_location.Insert(temp_idd, tloc);
                                num_of_allocated_seg++;
                            }
                        }
                        else if (valid_holes_id.Count() > 1)
                        {
                            //Sorting holes ascendingly
                           
                            
                            if (min_valid > seg_size[n])
                            {
                                int tloc = temp_location[min_id];

                                temp_size[min_id] = temp_size[min_id] - seg_size[n];
                                temp_location[min_id] = temp_location[min_id] + seg_size[n];

                                temp_size.Insert(min_id, seg_size[n]); // insert segment size
                                                                       //temp_name.RemoveAt(id); // remove this hole
                                temp_name.Insert(min_id, seg_name[n]); // insert th esegmnet in the hole
                                                                       //temp_id.RemoveAt(id);
                                temp_id.Insert(min_id, pro_count);
                                temp_location.Insert(min_id, tloc);
                                num_of_allocated_seg++;
                            }
                            else if (min_valid == seg_size[n])
                            {
                                temp_name.RemoveAt(min_id); // remove this hole
                                temp_name.Insert(min_id, seg_name[n]); // insert th esegmnet in the hole
                                temp_id.RemoveAt(min_id);
                                temp_id.Insert(min_id, pro_count);
                                num_of_allocated_seg++;
                            }

                            //num_of_allocated_seg++;
                        }
                        else if (valid_holes_id.Count() == 0)
                        {
                            break;
                        }

                        valid_holes_id.RemoveRange(0, valid_holes_id.Count());
                        valid_holes_size.RemoveRange(0, valid_holes_size.Count());

                    }

                    if (num_of_allocated_seg == num_of_seg)
                    {
                        pro_count++;
                        chart_name = temp_name;
                        chart_id = temp_id;
                        chart_location = temp_location;
                        chart_size = temp_size;
                        num_of_allocated_seg = 0; // reset number of segments
                                                  //Go to form4 (view memory) to draw segments
                        Form4 F4 = new Form4(temp_location, temp_size, temp_name, temp_id, mem_size);
                        //Form4 F4 = new Form4();
                        F4.ShowDialog();
                    }
                    else
                    {
                        temp_name = chart_name;
                        temp_id = chart_id;
                        temp_location = chart_location;
                        temp_size = chart_size;
                        num_of_allocated_seg = 0; // reset number of segments
                        string message = "Process" + pro_count.ToString() + " Doesn't fit\n The process will wait";
                        MessageBox.Show(message);
                    }




                }
            }


            else
            {
                string message = "Invalid Input\nPlease Try Again";
                MessageBox.Show(message);
            }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deallocate_Click(object sender, EventArgs e) // Deallocation Button
        {
            //double mem_size = 0;
            if (int.TryParse(textBox2.Text, out int ph_id))
            {
                if (oldprocess.Checked == true)
                {
                    u = 0;
                    // int ph_id = Int32.Parse(textBox2.Text);
                    for (int y = 0; y < chart_size.Count(); y++)
                    {
                        if (chart_id[y] == ph_id && chart_name[y] == "P")
                        {
                            chart_id.RemoveAt(y);
                            chart_id.Insert(y, chart_id[chart_id.Count() - 1]++);
                            chart_name.RemoveAt(y);
                            chart_name.Insert(y, "H");
                        }
                    }

                    /*------------------------------COMPACTION-----------------------------------------*/
                    int g;
                    for (g = 0; g < chart_location.Count() - 1; g++) //Internal Compact holes
                    {
                        string compact_name = "";
                        int compact_id = 0;
                        int compact_size = 0;
                        int compact_location = 0;
                        if (chart_name[g] == "H" && chart_name[g + 1] == "H")
                        {
                            //compact them
                            compact_name = "H"; // name of both
                            compact_id = chart_id[g]; // id one of them
                            compact_size = chart_size[g] + chart_size[g + 1]; // total size of them
                            compact_location = chart_location[g]; // location of the first
                                                                  //remove both of them
                            chart_id.RemoveAt(g); // g
                            chart_id.RemoveAt(g); // g + 1
                            chart_id.Insert(g, compact_id);  // new id 

                            chart_name.RemoveAt(g); // g

                            chart_size.RemoveAt(g); // g
                            chart_size.RemoveAt(g); // g + 1
                            chart_size.Insert(g, compact_size);  // new size

                            chart_location.RemoveAt(g); // g
                            chart_location.RemoveAt(g); // g + 1
                            chart_location.Insert(g, compact_location);  // new id 
                            g--;

                        }
                    }
                }
                else if (newprocess.Checked == true)
                {
                    u = 0;
                    // int ph_id = Int32.Parse(textBox2.Text);
                    for (int y = 0; y < temp_size.Count(); y++)
                    {
                        if (temp_id[y] == ph_id && temp_name[y] != "H" && temp_name[y] != "P")
                        {
                            temp_id.RemoveAt(y);
                            int new_hole_id = temp_id.Count();
                            temp_id.Insert(y, new_hole_id++);
                            temp_name.RemoveAt(y);
                            temp_name.Insert(y, "H");
                        }
                    }

                    /*------------------------------COMPACTION-----------------------------------------*/
                    int g;
                    for (g = 0; g < temp_location.Count() - 1; g++) //Internal Compact holes
                    {
                        string compact_name = "";
                        int compact_id = 0;
                        int compact_size = 0;
                        int compact_location = 0;
                        if (temp_name[g] == "H" && temp_name[g + 1] == "H")
                        {
                            //compact them
                            compact_name = "H"; // name of both
                            compact_id = temp_id[g]; // id one of them
                            compact_size = temp_size[g] + temp_size[g + 1]; // total size of them
                            compact_location = temp_location[g]; // location of the first
                                                                 //remove both of them
                            temp_id.RemoveAt(g); // g
                            temp_id.RemoveAt(g); // g + 1
                            temp_id.Insert(g, compact_id);  // new id 

                            temp_name.RemoveAt(g); // g

                            temp_size.RemoveAt(g); // g
                            temp_size.RemoveAt(g); // g + 1
                            temp_size.Insert(g, compact_size);  // new size

                            temp_location.RemoveAt(g); // g
                            temp_location.RemoveAt(g); // g + 1
                            temp_location.Insert(g, compact_location);  // new id 


                            chart_id = temp_id;
                            chart_location = temp_location;
                            chart_name = temp_name;
                            chart_size = temp_size;
                            g--;

                        }
                    }
                }

                
                Form4 F4 = new Form4(chart_location, chart_size, chart_name, chart_id , mem_size);
                //Form4 F4 = new Form4();
                F4.ShowDialog();
            }
            else
            {
                string message = "Invalid Input\nPlease Try Again";
                MessageBox.Show(message);
            }
           
        }

        List<int> compact_id_list = new List<int>();
        private void compact_Click(object sender, EventArgs e)
        {
            //------------------------------COMPACTION-----------------------------------------
            int a;
            int sum_hole_size = 0;
            
            for (a = 0; a < chart_location.Count(); a++) //Internal Compact holes
            {
                if (chart_name[a] == "H")
                {
                    compact_id_list.Add(a); // id of holes
                    sum_hole_size += chart_size[a];
                }
            }

            for (int f = 0; f < compact_id_list.Count(); f++)
            {
                string compact_name = "";
                int compact_id = 0;
                int compact_size = 0;
                int compact_location = 0;

                compact_id = chart_id[compact_id_list[f]];
                compact_name = chart_name[compact_id_list[f]];
                compact_size = chart_size[compact_id_list[f]];
                compact_location = chart_location[compact_id_list[f]];

                chart_id.RemoveAt(compact_id_list[f]);
                chart_name.RemoveAt(compact_id_list[f]);
                chart_size.RemoveAt(compact_id_list[f]);
                chart_location.RemoveAt(compact_id_list[f]);

                chart_id.Insert(0, compact_id); // any id
                chart_name.Insert(0, "H");
                chart_size.Insert(0, compact_size);
                chart_location.Insert(0, 0);
                
                
            }
            //------------------------------COMPACTION-----------------------------------------
            int g;
            for (g = 0; g < chart_location.Count() - 1; g++) //Internal Compact holes
            {
                string compact_name = "";
                int compact_id = 0;
                int compact_size = 0;
                int compact_location = 0;
                if (chart_name[g] == "H" && chart_name[g + 1] == "H")
                {
                    //compact them
                    compact_name = "H"; // name of both
                    compact_id = chart_id[g]; // id one of them
                    compact_size = chart_size[g] + chart_size[g + 1]; // total size of them
                    compact_location = chart_location[g]; // location of the first
                                                          //remove both of them
                    chart_id.RemoveAt(g); // g
                    chart_id.RemoveAt(g); // g + 1
                    chart_id.Insert(g, compact_id);  // new id 

                    chart_name.RemoveAt(g); // g

                    chart_size.RemoveAt(g); // g
                    chart_size.RemoveAt(g); // g + 1
                    chart_size.Insert(g, compact_size);  // new size

                    chart_location.RemoveAt(g); // g
                    chart_location.RemoveAt(g); // g + 1
                    chart_location.Insert(g, compact_location);  // new id 
                    g--;

                }
            }

            chart_location[1] = sum_hole_size;
            for (int l = 2; l < chart_size.Count(); l++)
            {
                chart_location[l] = chart_location[l - 1] + chart_size[l - 1];
            }

            compact_id_list.RemoveRange(0, compact_id_list.Count());
            
            //View Memory
            Form4 F4 = new Form4(chart_location, chart_size, chart_name, chart_id , mem_size);
            //Form4 F4 = new Form4();
            F4.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cou = pro_count;
            this.Hide();
            Form3 F3 = new Form3 (chart_location, chart_size, chart_name, chart_id , pro_count , mem_size);
            //Form4 F4 = new Form4();
            F3.ShowDialog();
            
        }

        private void worst_fit_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
