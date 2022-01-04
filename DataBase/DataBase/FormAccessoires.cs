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
    public partial class FormAccessoires : Form
    {
        public FormAccessoires()
        {
            InitializeComponent();
        }
        int n = 0;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                n = 1;
                textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox1.Enabled = true;
            }
            else textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox1.Enabled = false;
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
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                try
                {
                    int s = (int)dl.GetValue("select Stockage from Accessoires where Acc_type ='" + textBox2.Text + "' and T_Genre ='" + textBox3.Text + "'") + int.Parse(textBox1.Text);
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("Update Vendeur_De_Telephones.dbo.Accessoires set [Acc_type] ='" + textBox2.Text + "', [T_Genre] ='" + textBox3.Text + "',[Acc_Entreprise] ='" + textBox4.Text + "',[Prix_Unite] =" + textBox5.Text + ", [Stockage] =" + s + " where Acc_type ='" + textBox2.Text + "' and T_Genre ='" + textBox3.Text + "'", con);
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
                    int s = int.Parse(textBox1.Text);
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("insert into Vendeur_De_Telephones.dbo.Accessoires Values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + "," + s + ")", con);
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
                //else
                {
                    try
                    {
                        if ((textBox8.Text == "") && (comboBox1.Text == ""))
                        {
                            dt = dl.GetData("select * from Accessoires", "Clients");
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            dt = dl.GetData("select * from Accessoires where " + comboBox1.Text + " ='" + textBox8.Text + "'", "Clients");
                            dataGridView1.DataSource = dt;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Il ya un problem!");
                    }
                }
            }
        }
    }
}
