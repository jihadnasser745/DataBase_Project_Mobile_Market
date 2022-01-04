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
using System.Drawing.Printing;

namespace DataBase
{
    public partial class FormVentes : Form
    {
        DataLayer dl1;
        public FormVentes()
        {
            InitializeComponent();
            dl1 = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
        }
        int n;

        DataTable dt1;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                n = 1;
                textBox2.Enabled = textBox1.Enabled = textBox4.Enabled = textBox5.Enabled = textBox7.Enabled = true;
            }
            else textBox2.Enabled = textBox1.Enabled = textBox4.Enabled = textBox5.Enabled = textBox7.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                n = 2;
                textBox8.Enabled = textBox9.Enabled = dateTimePicker1.Enabled = true;
            }
            else textBox8.Enabled = textBox9.Enabled = dateTimePicker1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                string s,ss = "";
                if (textBox4.Text == "")
                {
                    s = "null";
                }
                else s = textBox4.Text;
                try
                {
                    DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                    string c = dl.GetValue("select Prenom from Clients where C_ID ='" + textBox2.Text + "'").ToString();
                    float Tot, acc = 0, f;
                    try
                    {
                            f = float.Parse(dl.GetValue("select Prix_Nouvelle from Offres where T_ID ='" + textBox1.Text + "'").ToString());
                    }
                    catch (Exception)
                    {
                        try
                        {
                            f = float.Parse(dl.GetValue("select Prix from T_Vendus where T_ID ='" + textBox1.Text + "'").ToString());
                        }
                        catch (Exception)
                        {
                            f = 0;
                        }
                    }
                    try
                    {
                        if (textBox4.Text == "Charger")
                        {
                            acc = float.Parse(dl.GetValue("select Prix_Unite from Accessoires where Acc_type ='" + textBox4.Text + "' and Acc_Entreprise ='" + textBox5.Text + "'").ToString());
                            float a = float.Parse(dl.GetValue("select Stockage from Accessoires where Acc_type ='" + textBox4.Text + "' and Acc_Entreprise ='" + textBox5.Text + "' and T_Genre ='" + ss + "'").ToString());
                            if (a <= 0)
                            {
                                ss = "";
                                acc = 0;
                            }
                        }
                        else
                        {
                            if ((textBox4.Text == "NULL")||(textBox5.Text == "NULL"))
                            {
                                acc = 0;
                            }
                            else
                            {
                                ss = dl.GetValue("select T_Genre from T_Vendus where T_ID ='" + textBox1.Text + "'").ToString();
                                acc = float.Parse(dl.GetValue("select Prix_Unite from Accessoires where Acc_type ='" + textBox4.Text + "' and Acc_Entreprise ='" + textBox5.Text + "' and T_Genre ='" + ss + "'").ToString());
                                float a = float.Parse(dl.GetValue("select Stockage from Accessoires where Acc_type ='" + textBox4.Text + "' and Acc_Entreprise ='" + textBox5.Text + "' and T_Genre ='" + ss + "'").ToString());
                                if (a <= 0)
                                {
                                    ss = "";
                                    acc = 0;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        acc = 0;
                    }
                    Tot = acc + f;
                    int of;
                    try
                    {
                        of = int.Parse(dl.GetValue("select [Off_%] from Offres where T_ID ='" + textBox1.Text + "'").ToString());
                    }
                    catch (Exception)
                    {
                        of = 0;
                    }
                    int rep = 0;
                    SqlConnection con = new SqlConnection(@"Data Source=OMAR_OMAR\SQLEXPRESS;Initial Catalog=Vendeur_De_Telephones;Integrated Security=True");
                    SqlCommand com = new SqlCommand("Insert into Vendeur_De_Telephones.dbo.Ventes Values('" + textBox1.Text + "','" + textBox2.Text + "','" + DateTime.Today.ToShortDateString() + "','" + of.ToString() + "','" + s + "','" + acc.ToString() + "','" + Tot.ToString() + "','" + textBox7.Text + "')", con);

                    if (ss != "")
                    {
                        acc = float.Parse(dl.GetValue("select Stockage from Accessoires where Acc_type ='" + textBox4.Text + "' and Acc_Entreprise ='" + textBox5.Text + "' and T_Genre ='" + ss + "'").ToString());
                        acc--;
                        SqlCommand com2;
                        com2 = new SqlCommand("update Vendeur_De_Telephones.dbo.Accessoires set Stockage ='" + acc + "' where Acc_type ='" + textBox4.Text + "' and Acc_Entreprise ='" + textBox5.Text + "' and T_Genre ='" + ss + "'");
                    }
                     con.Open();
                     rep = com.ExecuteNonQuery();
                     con.Close();
                    if (rep == 0)
                    {
                        MessageBox.Show("Unuccess");
                    }
                    else
                    {
                        MessageBox.Show("Success");
                        com = new SqlCommand("update Vendeur_De_Telephones.dbo.T_Vendus set VendeeAvendre = 'Vendee' where T_ID ='" + textBox1.Text + "'");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Il ya un default");
                }
            }
            else
            {
                DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
                DataTable dt = new DataTable();
                try
                {
                    if ((textBox8.Text == "") && (textBox9.Text == ""))
                    {
                        dt = dl.GetData("select * from Ventes", "Ventes");
                    }
                    else
                    {
                        if ((textBox8.Text != "") && (textBox9.Text == ""))
                        {
                            dt = dl.GetData("select * from Ventes where T_ID = " + textBox8.Text, "Ventes");
                        }
                        else
                        {
                            if ((textBox8.Text == "") && (textBox9.Text != ""))
                            {
                                dt = dl.GetData("select * from Ventes where C_ID = " + textBox9.Text, "Ventes");
                            }
                            else
                            {
                                if ((textBox8.Text != "") && (textBox9.Text != ""))
                                {
                                        dt = dl.GetData("select * from Ventes where T_ID = " + textBox8.Text + "and C_ID =" + textBox9.Text, "Ventes");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    dt = dl.GetData("select * from Ventes", "Ventes");
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Ce ID n'est pas trouvee!!");
                }
                else
                dataGridView1.DataSource = dt;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Prenom.Enabled = Nom.Enabled = true;
            }
            else Prenom.Enabled = Nom.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataLayer dl = new DataLayer(@"OMAR_OMAR\SQLEXPRESS", "Vendeur_De_Telephones");
            DataTable dt = new DataTable();
            if (textBox9.Text == "")
            {
                dt = dl.GetData("select * from Ventes where Date ='" + dateTimePicker1.Value.ToShortDateString() + "'", "Ventes");
            }
            else dt = dl.GetData("select * from Ventes where Date ='" + dateTimePicker1.Value.ToShortDateString() + "' and C_ID ='" + textBox9.Text + "'", "Ventes");
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dl1 != null)
            {
                PrintDocument pd = new PrintDocument();
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    pd.PrinterSettings = printDialog1.PrinterSettings;
                    pd.PrintPage += Pd_PrintPage;
                    pd.Print();
                }
            }
        }
        private void FormVentes_Load(object sender, EventArgs e)
        {
            dt1 = (DataTable)dataGridView1.DataSource;
        }
        int rowindex = 0;
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            dt1 = (DataTable)dataGridView1.DataSource;
            Graphics g = e.Graphics;
            Font titlefont = new Font("times new roman", 20, FontStyle.Underline);
            Font normalfont = new Font("arial", 16, FontStyle.Regular);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            StringFormat sfr = new StringFormat();
            sfr.Alignment = StringAlignment.Center;

            Brush b = Brushes.Navy;
            Pen p = new Pen(b, 1.5f);

            if (rowindex == 0)
            {
                g.DrawString("La facture", titlefont, b, new Rectangle(new Point(0, 40), new Size(850, 50)), sf);
            }
            g.DrawRectangle(p, new Rectangle(new Point(50, 140), new Size(200, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(50, 240), new Size(200, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(50, 340), new Size(200, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(50, 440), new Size(200, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(50, 540), new Size(200, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(50, 640), new Size(200, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(50, 740), new Size(200, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(50, 840), new Size(200, 100)));

            g.DrawString("T_ID", normalfont, b, new Rectangle(new Point(50, 140), new Size(200, 100)), sf);
            g.DrawString("C_ID", normalfont, b, new Rectangle(new Point(50, 240), new Size(200, 100)), sf);
            g.DrawString("Date", normalfont, b, new Rectangle(new Point(50, 340), new Size(200, 100)), sf);
            g.DrawString("Off_%", normalfont, b, new Rectangle(new Point(50, 440), new Size(200, 100)), sf);
            g.DrawString("Acc_Type", normalfont, b, new Rectangle(new Point(50, 540), new Size(200, 100)), sf);
            g.DrawString("Acc_Prix", normalfont, b, new Rectangle(new Point(50, 640), new Size(200, 100)), sf);
            g.DrawString("Prix_Totale", normalfont, b, new Rectangle(new Point(50, 740), new Size(200, 100)), sf);
            g.DrawString("Paiment", normalfont, b, new Rectangle(new Point(50, 840), new Size(200, 100)), sf);

            g.DrawRectangle(p, new Rectangle(new Point(250, 140), new Size(500, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(250, 240), new Size(500, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(250, 340), new Size(500, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(250, 440), new Size(500, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(250, 540), new Size(500, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(250, 640), new Size(500, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(250, 740), new Size(500, 100)));
            g.DrawRectangle(p, new Rectangle(new Point(250, 840), new Size(500, 100)));

            g.DrawString(dt1.Rows[0]["T_ID"].ToString(), normalfont, b, new Rectangle(new Point(250, 174), new Size(500, 100)), sfr);
            g.DrawString(dt1.Rows[0]["C_ID"].ToString(), normalfont, b, new Rectangle(new Point(250, 274), new Size(500, 100)), sfr);
            g.DrawString(dt1.Rows[0]["Date"].ToString(), normalfont, b, new Rectangle(new Point(250, 374), new Size(500, 100)), sfr);
            g.DrawString(dt1.Rows[0]["Off_%"].ToString(), normalfont, b, new Rectangle(new Point(250, 474), new Size(500, 100)), sfr);
            g.DrawString(dt1.Rows[0]["Acc_Type"].ToString(), normalfont, b, new Rectangle(new Point(250, 574), new Size(500, 100)), sfr);
            g.DrawString(dt1.Rows[0]["Acc_Prix"].ToString(), normalfont, b, new Rectangle(new Point(250, 674), new Size(500, 100)), sfr);
            g.DrawString(dt1.Rows[0]["Prix_Totale"].ToString(), normalfont, b, new Rectangle(new Point(250, 774), new Size(500, 100)), sfr);
            g.DrawString(dt1.Rows[0]["Paiment"].ToString(), normalfont, b, new Rectangle(new Point(250, 874), new Size(500, 100)), sfr);
            DataTable dt2 = dl1.GetData("select Prenom,Nom from Clients where C_ID ='" + dt1.Rows[0]["C_ID"].ToString() + "'","Client");
            g.DrawString(dt2.Rows[0]["Prenom"].ToString() + dt2.Rows[0]["Nom"].ToString(), normalfont, b, new Rectangle(new Point(100, 974), new Size(200, 20)), sfr);
            g.DrawString("Signature:", normalfont, b, new Rectangle(new Point(50, 1000), new Size(200, 30)), sfr);
        }
    }
}
