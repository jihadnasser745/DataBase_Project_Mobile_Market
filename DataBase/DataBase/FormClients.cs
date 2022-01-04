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
    public partial class FormClients : Form
    {
        public FormClients()
        {
            InitializeComponent();
        }
        int n = 0;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                n = 1;
                textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = comboBox2.Enabled = true;
            }
            else textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = comboBox2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                n = 2;
                textBox8.Enabled = comboBox1.Enabled = true;
            }
            else textBox8.Enabled = comboBox1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                textBox5.AccessibleDefaultActionDescription = "NULL";
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                string sa;
                try
                {
                    sa = textBox5.Text;
                    int s = int.Parse(dl.GetValue("select max(C_ID) from Clients").ToString()) + 1;
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("Insert into Vendeur_De_Telephones.dbo.Clients Values(" + s.ToString() + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + sa + ",'" + comboBox2.Text + "')", con);
                    con.Open();
                    int rep = com.ExecuteNonQuery();
                    con.Close();
                    if (rep == 0)
                    {
                        MessageBox.Show("Unuccess");
                    }
                    else MessageBox.Show("Success");
                }
                catch (Exception)
                {
                    sa = "NULL";
                    int s = int.Parse(dl.GetValue("select max(C_ID) from Clients").ToString()) + 1;
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("Insert into Vendeur_De_Telephones.dbo.Clients Values(" + s.ToString() + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + sa + ",'" + comboBox2.Text + "')", con);
                    con.Open();
                    int rep = com.ExecuteNonQuery();
                    con.Close();
                    if (rep == 0)
                    {
                        MessageBox.Show("Unuccess");
                    }
                    else MessageBox.Show("Success");
                }
                
            }
            else
            {
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                DataTable dt = new DataTable();
                if ((textBox8.Text == "") || (comboBox1.Text == ""))
                {
                    dt = dl.GetData("select * from Clients", "Clients");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    try
                    {
                        dt = dl.GetData("select * from Clients where " + comboBox1.Text + " ='" + textBox8.Text + "'", "Clients");
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
