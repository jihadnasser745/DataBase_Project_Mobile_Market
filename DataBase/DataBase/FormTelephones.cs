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
    public partial class FormTelephones : Form
    {
        string[] m;
        public FormTelephones(string [] s)
        {
            InitializeComponent();
            m = s;
        }

        private void FormTelephones_Load(object sender, EventArgs e)
        {
            textBox2.Text = m[0];
            textBox3.Text = m[1];
            textBox4.Text = m[2];
        }
        int n;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                n = 1;
                textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox1.Enabled = textBox6.Enabled = textBox7.Enabled = textBox9.Enabled = true;
            }
            else textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox1.Enabled = textBox6.Enabled = textBox7.Enabled = textBox9.Enabled = false;
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
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("Insert into Vendeur_De_Telephones.dbo.T_Vendus Values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox1.Text + "','" + textBox6.Text + "','" + textBox9.Text + "','" + textBox7.Text + "','" + "A vendre" + "')", con);
                    con.Open();
                    int rep = com.ExecuteNonQuery();
                    con.Close();
                    if (rep == 0)
                    {
                        MessageBox.Show("Unsuccess");
                    }
                    else
                    {
                        MessageBox.Show("Success");
                        DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                        try
                        {
                            int s = int.Parse(dl.GetValue("select Stock from T_Caracteristiques where T_Genre ='" + textBox3.Text + "' and T_Entreprise ='" + textBox4.Text + "'").ToString());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ce type n'est pas trouvee dans les data");
                        }
                    }
                }
                catch (Exception)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("Insert into Vendeur_De_Telephones.dbo.T_Vendus Values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox1.Text + "','" + textBox6.Text + "','" + textBox9.Text + "','" + textBox7.Text + "','" + "A vendre" + "')", con);
                    con.Open();
                    int rep = com.ExecuteNonQuery();
                    con.Close();
                    if (rep == 0)
                    {
                        MessageBox.Show("Unsuccess");
                    }
                    else MessageBox.Show("Success");
                }

            }
            else
            if (n == 3)
            {
                SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                SqlCommand com = new SqlCommand("update Vendeur_De_Telephones.dbo.T_Vendus set Prix ='" + textBox5.Text + "', T_ID = '" + textBox10.Text + "' where T_ID ='" + textBox2.Text + "'",con);
                con.Open();
                int rep = com.ExecuteNonQuery();
                con.Close();
                if (rep == 0)
                {
                    MessageBox.Show("Unsuccess");
                }
                else MessageBox.Show("Success");
            }
            else
            {
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                DataTable dt = new DataTable();
                if ((comboBox1.Text == "") || (textBox8.Text == ""))
                {
                    dt = dl.GetData("select * from T_Vendus", "T_Vendus");
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    try
                    {
                        dt = dl.GetData("select * from T_Vendus where " + comboBox1.Text + " ='" + textBox8.Text + "'", "T_Vendus");
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Il ya un default");
                    }
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                n = 3;
                textBox2.Enabled = textBox5.Enabled = textBox10.Enabled = true;
            }
            else textBox2.Enabled = textBox5.Enabled = textBox10.Enabled = false;
        }
    }
}
