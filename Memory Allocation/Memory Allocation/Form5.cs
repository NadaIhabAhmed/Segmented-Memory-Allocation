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
    public partial class Form5 : Form
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

        DataTable seg_table = new DataTable();

        public Form5(List<int> loc, List<int> si, List<string> name, List<int> id, int num_proc)
        {
            InitializeComponent();
            chart_location = loc;
            chart_size = si;
            chart_name = name;
            chart_id = id;

            temp_location = loc;
            temp_size = si;
            temp_name = name;
            temp_id = id;

            num_processes = num_proc;

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
