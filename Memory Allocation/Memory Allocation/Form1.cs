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
 * This form is to enter memory size
 */
namespace Memory_Allocation
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

        private void Next_Click(object sender, EventArgs e)
        {
            //double mem_size = 0;
            if (int.TryParse(textBox1.Text, out int mem_size))
            {
                Form2 F2 = new Form2(mem_size);
                F2.ShowDialog();
            }
            else
            {
                string message = "Invalid Input\nPlease Try Again";
                MessageBox.Show(message);
            }
    }
    }
}


