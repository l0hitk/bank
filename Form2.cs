using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bankf1
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bankf;Integrated Security=True");
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public static int bcsn = 0;
       
        public Form2()
        {
            InitializeComponent();
        }
        static Random random = new Random();
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int csn = random.Next(100000, 999999);
            try
            {
                bcsn = csn;
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into info values('" + csn + "', '" + textBox1.Text + "', '" + textBox2.Text + "', " + textBox4.Text + ", '" + textBox5.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Form5 newForm = new Form5();
                newForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
