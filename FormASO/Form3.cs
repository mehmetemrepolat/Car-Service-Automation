using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp10
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void yeni_kayit_Click(object sender, EventArgs e)
        {
            Form4 musteri_kayit = new Form4();
            this.Hide();
            musteri_kayit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form5 servis_kayit = new Form5();
            this.Hide();
            servis_kayit.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
