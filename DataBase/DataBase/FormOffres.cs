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

namespace DataBase
{
    public partial class FormOffres : Form
    {
        public FormOffres()
        {
            InitializeComponent();
        }
        int n;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                n = 1;
                textBox2.Enabled = textBox3.Enabled = true;
            }
            else textBox2.Enabled = textBox3.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                n = 2;
                textBox8.Enabled = true;
            }
            else textBox8.Enabled = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                DataLayer dll = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                try
                {
                    float a = float.Parse(dll.GetValue("select Prix from T_Vendus where T_ID ='" + textBox2.Text +"'").ToString());
                    textBox5.Text = (a - a * (float.Parse(textBox3.Text))/100).ToString();
                    textBox1.Text = a.ToString();
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("Insert into Vendeur_De_Telephones.dbo.Offres Values('" + textBox2.Text + "','" + textBox3.Text + "','" + a.ToString() + "','" + textBox5.Text + "')", con);
                    con.Open();
                    int rep = com.ExecuteNonQuery();
                    con.Close();
                    if (rep == 0)
                    {
                        MessageBox.Show("Unuccess");
                    }
                    else
                    {
                        MessageBox.Show("Success");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("L'ID n'est pas trouvee");
                }
            }
            else
            {
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                DataTable dt = new DataTable();
                if (textBox8.Text == "")
                {
                    dt = dl.GetData("select * from Offres", "Offres");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    try
                    {
                        dt = dl.GetData("select * from Offres where T_ID ='" + textBox8.Text + "'", "Offres");
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Il ya un default");
                    }
                }
            }
        }
    }
}
