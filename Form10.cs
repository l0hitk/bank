using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankf1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        public static int amt = 0;
        
        public static string pay ="";
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            amt = Convert.ToInt32(textBox1.Text);
            pay = textBox2.Text;
            Form11 newForm = new Form11();
            newForm.Show();
            this.Hide();
        }
    }
}
