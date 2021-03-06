using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormVentes f = new FormVentes();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string [] s = new string[3];
            s[0] = s[1] = s[2] = "";
            FormTelephones f = new FormTelephones(s);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAccessoires f = new FormAccessoires();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDettes f = new FormDettes();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormClients f = new FormClients();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormOffres f = new FormOffres();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormCaracteristiques f = new FormCaracteristiques();
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormAchats f = new FormAchats();
            f.Show();
        }
    }
}
