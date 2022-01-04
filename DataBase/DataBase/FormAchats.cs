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
    public partial class FormAchats : Form
    {
        public FormAchats()
        {
            InitializeComponent();
        }
        int n;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
            DataTable dt = new DataTable();
            dt = dl.GetData("select * from T_Achats where Date ='" + dateTimePicker1.Value.ToShortDateString() + "'", "Achats");
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                SqlCommand com = new SqlCommand("insert into Vendeur_De_Telephones.dbo.T_Achats Values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + DateTime.Today.ToShortDateString() + "')", con);
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
                    string[] s = new string[3];
                    s[0] = textBox2.Text; s[1] = textBox3.Text; s[2] = textBox4.Text;
                    FormTelephones f = new FormTelephones(s);
                    f.Show();
                }
            }
            else
            {
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                DataTable dt = new DataTable();
                if ((textBox8.Text == "") || (comboBox1.Text == ""))
                {
                    dt = dl.GetData("select * from T_Achats", "Achats");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    try
                    {
                        dt = dl.GetData("select * from T_Achats where " + comboBox1.Text + " ='" + textBox8.Text + "'", "Achats");
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Il ya un default");
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                n = 1;
                textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = true;
            }
            else textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = false;
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
    }
}
