using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        string id = "admin";
        string pass = "1234";
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == id && textBox2.Text == pass)
            {
                Form3 AnaEkran = new Form3();
                this.Hide();
                AnaEkran.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void geri_butonu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Baslangic_Ekrani = new Form1();
            Baslangic_Ekrani.Show();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == id && textBox2.Text == pass)
                {
                    Form3 AnaEkran = new Form3();
                    this.Hide();
                    AnaEkran.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == id && textBox2.Text == pass)
                {
                    Form3 AnaEkran = new Form3();
                    this.Hide();
                    AnaEkran.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
    }
}
