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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        int bal = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bankf;Integrated Security=True");

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from pinn where mpin='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            
            {


                if (dt.Rows[0][0].ToString() == "2")
                {
                    
                        SqlCommand cmd2 = new SqlCommand("update pinn set bal=bal-'" + Form10.amt + "'where username = '" + Form3.S1 + "'", con);
                        cmd2.ExecuteNonQuery();
                        SqlCommand command1 = new SqlCommand("insert into ball(username,amt,bal,date) select '" + Form3.S1 + "','" + Form10.amt + "',bal,getdate() from pinn where username='" + Form3.S1 + "'", con);
                        command1.ExecuteNonQuery();
                        SqlCommand cmd = new SqlCommand("select bal from pinn where username = '" + Form3.S1 + "'", con);
                        cmd.ExecuteNonQuery();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        Form10 newForm = new Form10();
                        if (sdr.Read())
                        {
                            MessageBox.Show(sdr.GetSqlValue(0).ToString());

                            newForm.Show();
                            this.Hide();
                        }
                        con.Close();
                    }
                    


             



                else
                {
                    MessageBox.Show("Mpin is incorrect");
                }
                con.Close();
            }
            
        }
    }
}
