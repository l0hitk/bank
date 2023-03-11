using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bankf1
{
    public partial class Form5 : Form
    {
        public static int mp = 0;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bankf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from info where username='" + textBox1.Text + "'and pass ='" + textBox3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                mp = Convert.ToInt32( textBox2.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into pinn values('" + textBox1.Text + "','" + textBox3.Text + "'," + textBox2.Text+","+0+")" , con);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("insert into ball values('" + Form2.bcsn + "'," + 0 + "," + 0 + ",getdate())", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                Form1 newForm = new Form1();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Entered details does not match");
            }

        }
    }
}
