using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dotnetCHARTING.WinForms;
using System.Data.SqlClient;

namespace DataBase
{
    public partial class FormDettes : Form
    {
        public FormDettes()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
            DataTable dt = new DataTable();
            if (textBox8.Text == "")
            {
                dt = dl.GetData("select * from Dettes","Dettes");
                dataGridView1.DataSource = dt;
            }
            else
            {
                try
                {
                    dt = dl.GetData("select Prix_Totale,Paiment from Ventes where C_ID ='" + textBox8.Text + "'", "Paiment");
                    int pai = 0, Dt = 0, r;
                    foreach (DataRow dr in dt.Rows)
                    {
                        pai += int.Parse(dr["Paiment"].ToString());
                        Dt += int.Parse(dr["Prix_Totale"].ToString());
                    }
                    r = Dt - pai;
                    DataTable dette = new DataTable();
                    dette.Columns.Add("C_ID");
                    dette.Columns.Add("Paiment_Net");
                    dette.Columns.Add("Dettes_Totale");
                    dette.Columns.Add("Reste");
                    object[] dd = new object[4];
                    dd[0] = textBox8.Text;
                    dd[1] = pai;
                    dd[2] = Dt;
                    dd[3] = r;
                    dette.Rows.Add(dd);
                    dataGridView1.DataSource = dette;
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("Insert into Vendeur_De_Telephones.dbo.Dettes values('" + textBox8.Text + "','" + pai.ToString() + "','" + Dt + "','" + r + ")");
                }
                catch (Exception)
                {
                    MessageBox.Show("Somthing wrong");
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Prenom.Enabled = Nom.Enabled = button1.Enabled = true;
            }
            else Prenom.Enabled = Nom.Enabled = button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
            string c = dl.GetValue("select C_ID from Clients where Prenom ='" + Prenom.Text + "' and nom ='" + Nom.Text + "'").ToString();
            if (c == null)
            {
                MessageBox.Show("Le nom n'est pas trouvee");
            }
            else textBox13.Text = c;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
