using MySql.Data.MySqlClient;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string connectionString = "server=localhost;user id=root;password=asd35356;database=aso";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM araclar WHERE plaka='" + textBox6.Text + "'";
                MySqlDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Lütfen kayıtlı bir plaka giriniz");
                    return;
                }
                reader.Close();
                command.Parameters.AddWithValue("@servis_km", textBox1.Text);
                command.Parameters.AddWithValue("@servis_tarih", textBox3.Text);
                command.Parameters.AddWithValue("@sonraki_servis_km", textBox4.Text);
                command.Parameters.AddWithValue("@sonraki_servis_tarih", textBox5.Text);
                command.Parameters.AddWithValue("@plaka", textBox6.Text);
                command.Parameters.AddWithValue("@aciklama", textBox7.Text);
                command.CommandText = "INSERT INTO servis(servis_km, servis_tarih, sonraki_servis_km, sonraki_servis_tarih, plaka, aciklama) values(@servis_km, @servis_tarih, @sonraki_servis_km, @sonraki_servis_tarih, @plaka, @aciklama)";
                command.ExecuteNonQuery();
                command.Dispose();
                string islemler = textBox2.Text;
                string[] liste = islemler.Split(',');
                foreach (string s in liste)
                {
                    command.CommandText = "SELECT distinct * from islemler where islem_adi='" + s + "'";
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                      command.CommandText = "INSERT INTO yapilan_islem(islem_id,servis_id) VALUES(" + "(SELECT islem_id FROM islemler WHERE islem_adi='" + s + "')" + "," + "(SELECT servis_id FROM servis WHERE plaka=@plaka AND servis_km=@servis_km AND servis_tarih=@servis_tarih)" + ")";
                      command.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Close();
                        command.CommandText = "INSERT INTO islemler(islem_adi) VALUES('" + s + "')";
                        command.ExecuteNonQuery();
                        command.CommandText = "INSERT INTO yapilan_islem(islem_id,servis_id) VALUES(" + "(SELECT islem_id FROM islemler WHERE islem_adi='" + s + "')" + "," + "(SELECT servis_id FROM servis WHERE plaka=@plaka AND servis_km=@servis_km AND servis_tarih=@servis_tarih)" + ")";
                        command.ExecuteNonQuery();
                    }
                }
                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("Başarı ile eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = false;
        }

        private void textBox6_ReadOnlyChanged(object sender, EventArgs e)
        {

        }
        private void baslik_yaz ()
        {
            listView1.Columns.Add("SERVIS ID", 75);
            listView1.Columns.Add("PLAKA", 75);
            listView1.Columns.Add("BAKIM KM", 75);
            listView1.Columns.Add("BAKIM TARIH", 120);
            listView1.Columns.Add("G. BAKIM KM", 100);
            listView1.Columns.Add("G. BAKIM TARIH", 120);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string tarih = DateTime.Now.Date.ToString("dd.MM.yyyy");
            textBox3.Text = tarih;
            tarih = DateTime.Now.Date.AddYears(1).ToString("dd.MM.yyyy");
            textBox5.Text = tarih;
            baslik_yaz();
            /*textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;*/
        }

        private void kayit_sayisi()
        {
            int x = listView1.Items.Count;
            label7.Text = "KAYIT SAYISI  "+Convert.ToString(x);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem==null)
            {
                MessageBox.Show("Tarih boş kalamaz");
                return;
            }
            label7.Text = "ÖZEL ARAMA";
            listView1.Items.Clear();
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.Parameters.AddWithValue("@plaka", textBox8.Text);
                command.Parameters.AddWithValue("@tarih", comboBox1.SelectedItem);
                command.CommandText = "SELECT islem_adi FROM servis AS s INNER JOIN yapilan_islem AS y INNER JOIN islemler AS i ON s.servis_id = y.servis_id AND i.islem_id = y.islem_id WHERE plaka = @plaka AND servis_tarih=@tarih";
                 string s="";
                 MySqlDataReader readera = command.ExecuteReader();
                 while (readera.Read())
                 {
                    s=s+readera.GetString(0)+',';
                 }
                s = s.Substring(0, s.Length - 1);
                s = s.Substring(0, s.LastIndexOf(','));
                readera.Close();
                
                    textBox10.Text = s;
                    command.CommandText = "SELECT aciklama FROM servis WHERE plaka=@plaka AND servis_tarih=@tarih";
                    MySqlDataReader readerb = command.ExecuteReader();
                    if (readerb.Read())
                        textBox11.Text = readerb.GetString(0);
                    readerb.Close();
                
                command.CommandText = "SELECT * FROM servis WHERE plaka=@plaka AND servis_tarih='"+ comboBox1.SelectedItem + "'";
                MySqlDataReader reader = command.ExecuteReader();

                listView1.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = reader["servis_id"].ToString();
                    add.SubItems.Add(reader["plaka"].ToString());
                    add.SubItems.Add(reader["servis_km"].ToString());
                    add.SubItems.Add(reader["servis_tarih"].ToString());
                    add.SubItems.Add(reader["sonraki_servis_km"].ToString());
                    add.SubItems.Add(reader["sonraki_servis_tarih"].ToString());
                    listView1.Items.Add(add);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox10.Clear();
            textBox11.Clear();
            listView1.Items.Clear();
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.Parameters.AddWithValue("@plaka", textBox8.Text);
                command.CommandText = "SELECT * FROM servis WHERE plaka=@plaka";
                MySqlDataReader reader = command.ExecuteReader();

                listView1.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = reader["servis_id"].ToString();
                    add.SubItems.Add(reader["plaka"].ToString());
                    add.SubItems.Add(reader["servis_km"].ToString());
                    add.SubItems.Add(reader["servis_tarih"].ToString());
                    add.SubItems.Add(reader["sonraki_servis_km"].ToString());
                    add.SubItems.Add(reader["sonraki_servis_tarih"].ToString());
                    listView1.Items.Add(add);
                }
                kayit_sayisi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT servis_tarih FROM servis WHERE plaka='" + textBox8.Text + "'";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            con.Close();
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Tarih boş kalamaz");
                return;
            }
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.Parameters.AddWithValue("@plaka", textBox8.Text);
                command.Parameters.AddWithValue("@tarih", comboBox1.SelectedItem);
                command.CommandText = "DELETE FROM yapilan_islem WHERE servis_id IN (SELECT servis_id FROM servis WHERE plaka = @plaka AND servis_tarih = @tarih)";
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM servis WHERE plaka=@plaka AND servis_tarih=@tarih";
                if (command.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("Başarı ile silindi");
                }
                listView1.Items.Clear();
                textBox8.Clear();
                comboBox1.Items.Clear();
                textBox10.Clear();
                textBox11.Clear();
                label7.Text = "-----";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 AnaEkran = new Form3();
            this.Hide();
            AnaEkran.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM servis";
                MySqlDataReader reader = command.ExecuteReader();

                listView1.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = reader["servis_id"].ToString();
                    add.SubItems.Add(reader["plaka"].ToString());
                    add.SubItems.Add(reader["servis_km"].ToString());
                    add.SubItems.Add(reader["servis_tarih"].ToString());
                    add.SubItems.Add(reader["sonraki_servis_km"].ToString());
                    add.SubItems.Add(reader["sonraki_servis_tarih"].ToString());
                    listView1.Items.Add(add);
                }
                kayit_sayisi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
