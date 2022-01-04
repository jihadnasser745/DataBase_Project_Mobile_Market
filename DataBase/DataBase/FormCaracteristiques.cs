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
    public partial class FormCaracteristiques : Form
    {
        public FormCaracteristiques()
        {
            InitializeComponent();
        }
        int n;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                n = 1;
                textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled = textBox10.Enabled = true;
            }
            else textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled = textBox10.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                n = 2;
                textBox9.Enabled = comboBox1.Enabled = true;
            }
            else textBox9.Enabled = comboBox1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                SqlCommand com = new SqlCommand("Insert into Vendeur_De_Telephones.dbo.T_Caracteristiques Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" +textBox6.Text + "','" +textBox7.Text + "','" + textBox10.Text + "',0)", con);
                con.Open();
                int rep = com.ExecuteNonQuery();
                con.Close();
                if (rep == 0)
                {
                    MessageBox.Show("Unuccess");
                }
                else MessageBox.Show("Success");
            }
            else
            {
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                DataTable dt = new DataTable();
                if ((textBox9.Text == "")||(comboBox1.Text == ""))
                {
                    dt = dl.GetData("select * from T_Caracteristiques", "Caracteristiques");
                    foreach (DataRow dr in dt.Rows)
                    {
                        string G, E;
                        G = dr["T_Genre"].ToString();
                        E = dr["T_Entreprise"].ToString();
                        string s = dl.GetValue("select COUNT(*) from T_Vendus where T_Genre ='" + G + "' and T_Entreprise = '" + E + "' and VendeeAvendre ='" + "A vendre" + "'").ToString();
                        if ((s == "NULL") || (s == "null") || (s == null))
                        {
                            s = "0";
                        }
                        dr["Stock"] = s.ToString();
                    }
                    dataGridView1.DataSource = dt;
                }
                try
                {
                    dt = dl.GetData("select * from T_Caracteristiques where " + comboBox1.Text + " ='" + textBox9.Text + "'", "Caracteristiques");
                    foreach (DataRow dr in dt.Rows)
                    {
                        string G, E;
                        G = dr["T_Genre"].ToString();
                        E = dr["T_Entreprise"].ToString();
                        string s = dl.GetValue("select COUNT(*) from T_Vendus where T_Genre ='" + G + "' and T_Entreprise = '" + E + "' and VendeeAvendre ='" + "A vendre" + "'").ToString();
                        if ((s == "NULL")||(s == "null")||(s == null))
                        {
                            s = "0";
                        }
                        dr["Stock"] = s.ToString();
                    }
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
