using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankf1
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bankf;Integrated Security=True");
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            crn();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        void crn()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select CSN from info where username = '" + Form3.S1 + "'", con);
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    label1.Text = sdr.GetString(0);
                }
                con.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);        
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select bal from pinn where username = '" + Form3.S1 + "'", con);
            cmd.ExecuteNonQuery();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                MessageBox.Show(sdr.GetSqlValue(0).ToString());
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 newForm = new Form10();
            newForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 newForm = new Form6();
            newForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 newForm = new Form12();
            newForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
    
}
