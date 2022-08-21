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
    public partial class Form4 : Form
    {
       

        public Form4()
        {
            InitializeComponent();
        }
        string connectionString = "server=localhost;user id=root;password=asd35356;database=aso";


        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void baslikyazMusteri ()
        {
            listView1.Columns.Add("MUSTERI ID", 90);
            listView1.Columns.Add("ADI", 80);
            listView1.Columns.Add("SOYADI", 80);
            listView1.Columns.Add("TEL NO", 100);
            listView1.Columns.Add("E-POSTA", 120);
        }
        private void baslikyazArac()
        {
            listView2.Columns.Add("MUSTERI ADI", 90);
            listView2.Columns.Add("PLAKA", 75);
            listView2.Columns.Add("URETIM YILI", 80);
            listView2.Columns.Add("MARKA", 50);
            listView2.Columns.Add("MODEL", 50);
            listView2.Columns.Add("ŞASİ NO", 120);
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            baslikyazMusteri();
            baslikyazArac();
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT marka_adi FROM markalar";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            if (textBox1.Text=="")
            {
                MessageBox.Show("Müşteri adını giriniz");
                    return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Müşteri Soyadını giriniz");
                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Telefon numarası boş kalamaz");
                return;
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("e-posta boş kalamaz");
                return;
            }
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.Parameters.AddWithValue("@adi", textBox1.Text);
                command.Parameters.AddWithValue("@soyadi", textBox2.Text);
                command.Parameters.AddWithValue("@tel_no", textBox3.Text);
                command.Parameters.AddWithValue("@e_posta", textBox4.Text);
                command.CommandText = "INSERT INTO musteriler (adi, soyadi, tel_no, e_posta) VALUES (@adi, @soyadi, @tel_no, @e_posta)";
                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("Başarı ile eklendi");

                command.CommandText = "SELECT * FROM musteriler WHERE tel_no=@tel_no";
                MySqlDataReader reader = command.ExecuteReader();

                listView1.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = reader["musteri_no"].ToString();
                    add.SubItems.Add(reader["adi"].ToString());
                    add.SubItems.Add(reader["soyadi"].ToString());
                    add.SubItems.Add(reader["tel_no"].ToString());
                    add.SubItems.Add(reader["e_posta"].ToString());
                    listView1.Items.Add(add);
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox9.Clear();
                label7.Text = " ____";
                textBox8.Text = listView1.Items[0].SubItems[1].Text;
                textBox7.Text = listView1.Items[0].SubItems[0].Text;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            comboBox2.Items.Clear();
            MySqlCommand command = con.CreateCommand();
            command.Parameters.AddWithValue("@marka_adi", comboBox1.SelectedItem);
            command.CommandText = "SELECT mo.model_adi FROM markalar AS ma INNER JOIN modeller AS mo ON ma.marka_id = mo.marka_id WHERE marka_adi = @marka_adi ";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader.GetString(0));
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            if (textBox8.Text == "")
            {
                MessageBox.Show("Aracın Kime ait olduğunu seçiniz");
                return;
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Marka seçiniz");
                return;
            }
            else if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Model seçiniz");
                return;
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Plaka boş kalamaz");
                return;
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Şasi numarası boş kalamaz");
                return;
            }
            else if (textBox16.Text == "")
            {
                MessageBox.Show("Üretim yılı giriniz");
                return;
            }
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.Parameters.AddWithValue("@musteri_no", textBox7.Text);
                command.Parameters.AddWithValue("@sasi_no", textBox6.Text);
                command.Parameters.AddWithValue("@plaka", textBox5.Text);
                command.Parameters.AddWithValue("@uretim_yili", textBox16.Text);
                command.Parameters.AddWithValue("@model_adi", comboBox2.SelectedItem);
                command.CommandText = "INSERT INTO araclar (plaka, sasi_no, uretim_yili, model_id, musteri_no) VALUES (@plaka, @sasi_no, @uretim_yili, " + "(SELECT model_id FROM modeller WHERE model_adi = @model_adi)" + ",@musteri_no)";
                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("Başarı ile eklendi");

                string musteriadi = "", marka = "", model = "";
                    command.CommandText = "SELECT adi FROM musteriler WHERE musteri_no=(SELECT musteri_no FROM araclar WHERE plaka=@plaka)";
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        musteriadi = reader.GetString(0);
                    }
                    reader.Close();
                    command.CommandText = "SELECT ma.marka_adi FROM markalar AS ma INNER JOIN modeller AS mo INNER JOIN araclar AS a ON a.model_id = mo.model_id AND mo.marka_id=ma.marka_id WHERE plaka=@plaka";
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        marka = reader.GetString(0);
                    }
                    reader.Close();
                    command.CommandText = "SELECT model_adi FROM modeller WHERE model_id=(SELECT model_id FROM araclar WHERE plaka=@plaka)";
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        model = reader.GetString(0);
                    }
                    reader.Close();

                command.CommandText = "SELECT * FROM araclar WHERE plaka=@plaka";
                reader = command.ExecuteReader();
                listView2.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = musteriadi.ToString();
                    add.SubItems.Add(reader["plaka"].ToString());
                    add.SubItems.Add(reader["uretim_yili"].ToString());
                    add.SubItems.Add(marka);
                    add.SubItems.Add(model);
                    add.SubItems.Add(reader["sasi_no"].ToString());
                    listView2.Items.Add(add);
                }
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox16.Clear();
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            listView1.Items.Clear();
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM musteriler WHERE tel_no='"+textBox9.Text+ "' OR adi='" + textBox9.Text + "'";
                MySqlDataReader reader = command.ExecuteReader();

                listView1.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = reader["musteri_no"].ToString();
                    add.SubItems.Add(reader["adi"].ToString());
                    add.SubItems.Add(reader["soyadi"].ToString());
                    add.SubItems.Add(reader["tel_no"].ToString());
                    add.SubItems.Add(reader["e_posta"].ToString());
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM musteriler";
            MySqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = reader["musteri_no"].ToString();
                add.SubItems.Add(reader["adi"].ToString());
                add.SubItems.Add(reader["soyadi"].ToString());
                add.SubItems.Add(reader["tel_no"].ToString());
                add.SubItems.Add(reader["e_posta"].ToString());
                listView1.Items.Add(add);
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            if (label7.Text == " ____")
            {
                MessageBox.Show("Listeden güncellenecek \"MUSTERI ID\" seçiniz ");
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Müşteri adını giriniz");
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Müşteri soyadını giriniz");
                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Telefon numarası boş kalamaz");
                return;
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("e-posta boş kalamaz");
                return;
            }
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.Parameters.AddWithValue("@musteri_no", label7.Text);
                command.Parameters.AddWithValue("@adi", textBox1.Text);
                command.Parameters.AddWithValue("@soyadi", textBox2.Text);
                command.Parameters.AddWithValue("@tel_no", textBox3.Text);
                command.Parameters.AddWithValue("@e_posta", textBox4.Text);
                command.CommandText = "UPDATE musteriler SET adi = @adi , soyadi = @soyadi, tel_no = @tel_no, e_posta = @e_posta WHERE musteri_no = @musteri_no";
                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("Başarı ile güncellendi");

                command.CommandText = "SELECT * FROM musteriler WHERE tel_no=@tel_no";
                MySqlDataReader reader = command.ExecuteReader();

                listView1.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = reader["musteri_no"].ToString();
                    add.SubItems.Add(reader["adi"].ToString());
                    add.SubItems.Add(reader["soyadi"].ToString());
                    add.SubItems.Add(reader["tel_no"].ToString());
                    add.SubItems.Add(reader["e_posta"].ToString());
                    listView1.Items.Add(add);
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox9.Clear();
                label7.Text = " ____";
                textBox8.Clear();
                textBox7.Clear();
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
            label7.Text = listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void label7_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label7.Text == " ____")
            {
                MessageBox.Show("Listeden silinecek \"MUSTERI ID\" seçiniz ");
                return;
            }
            DialogResult secenek = MessageBox.Show("Seçtiğinin Kişinin Tüm Araç ve Servis Bilgileri Silinecektir\n Emin Misiniz ?", "!!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                try
                {
                    con.Open();
                    MySqlCommand command = con.CreateCommand();
                    command.Parameters.AddWithValue("@musteri_no", label7.Text);
                    command.CommandText = "DELETE FROM yapilan_islem WHERE servis_id IN(SELECT servis_id FROM servis WHERE plaka IN(SELECT plaka FROM araclar WHERE musteri_no = @musteri_no))";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM servis WHERE plaka IN(SELECT plaka FROM araclar WHERE musteri_no = @musteri_no)";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM araclar WHERE musteri_no = @musteri_no";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM musteriler WHERE musteri_no = @musteri_no";
                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Başarı ile silindi");
                    }
                    temizle();
                    listView1.Items.Clear();
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
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox9.Clear();
            label7.Text = " ____";
            textBox8.Clear();
            textBox7.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            textBox11.Text = listView2.SelectedItems[0].SubItems[1].Text;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            listView2.Items.Clear();
            try
            {
                string musteriadi = "", marka = "", model = "";
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.Parameters.AddWithValue("@plaka", textBox10.Text);
                command.CommandText = "SELECT * FROM araclar WHERE plaka=@plaka or ";
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command.CommandText = "SELECT adi FROM musteriler WHERE musteri_no=(SELECT musteri_no FROM araclar WHERE plaka=@plaka)";
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        musteriadi = reader.GetString(0);
                    }
                    reader.Close();
                    command.CommandText = "SELECT ma.marka_adi FROM markalar AS ma INNER JOIN modeller AS mo INNER JOIN araclar AS a ON a.model_id = mo.model_id AND mo.marka_id=ma.marka_id WHERE plaka=@plaka";
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        marka = reader.GetString(0);
                    }
                    reader.Close();
                    command.CommandText = "SELECT model_adi FROM modeller WHERE model_id=(SELECT model_id FROM araclar WHERE plaka=@plaka)";
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        model = reader.GetString(0);
                    }
                    reader.Close();
                }
                else
                    reader.Close();
                command.CommandText = "SELECT * FROM araclar WHERE plaka=@plaka";
                reader = command.ExecuteReader();
                listView2.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = musteriadi.ToString();
                    add.SubItems.Add(reader["plaka"].ToString());
                    add.SubItems.Add(reader["uretim_yili"].ToString());
                    add.SubItems.Add(marka);
                    add.SubItems.Add(model);
                    add.SubItems.Add(reader["sasi_no"].ToString());
                    listView2.Items.Add(add);
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

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            MySqlConnection con1 = new MySqlConnection(connectionString);
            listView2.Items.Clear();
            try
            {
                string musteriadi = "", marka = "", model = "";
                con.Open();
                con1.Open();
                MySqlCommand command = con.CreateCommand();
                MySqlCommand command1 = con1.CreateCommand();
                command.CommandText = "SELECT * FROM araclar";
                MySqlDataReader reader = command.ExecuteReader();
                listView2.Items.Clear();
                while (reader.Read())
                {
                    command1.CommandText = "SELECT adi FROM musteriler WHERE musteri_no=(SELECT musteri_no FROM araclar WHERE plaka='"+ reader["plaka"].ToString() + "')";
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    if (reader1.Read())
                    {
                        musteriadi = reader1.GetString(0);
                    }
                    reader1.Close();
                    command1.CommandText = "SELECT ma.marka_adi FROM markalar AS ma INNER JOIN modeller AS mo INNER JOIN araclar AS a ON a.model_id = mo.model_id AND mo.marka_id=ma.marka_id WHERE plaka='" + reader["plaka"].ToString() + "'";
                    reader1 = command1.ExecuteReader();
                    if (reader1.Read())
                    {
                        marka = reader1.GetString(0);
                    }
                    reader1.Close();
                    command1.CommandText = "SELECT model_adi FROM modeller WHERE model_id=(SELECT model_id FROM araclar WHERE plaka='" + reader["plaka"].ToString() + "')";
                    reader1 = command1.ExecuteReader();
                    if (reader1.Read())
                    {
                        model = reader1.GetString(0);
                    }
                    reader1.Close();
                    ListViewItem add = new ListViewItem();
                    add.Text = musteriadi.ToString();
                    add.SubItems.Add(reader["plaka"].ToString());
                    add.SubItems.Add(reader["uretim_yili"].ToString());
                    add.SubItems.Add(marka);
                    add.SubItems.Add(model);
                    add.SubItems.Add(reader["sasi_no"].ToString());
                    listView2.Items.Add(add);
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                MessageBox.Show("Listeden silinecek \"ARACI\" seçiniz ");
                return;
            }
            DialogResult secenek = MessageBox.Show("Seçtiğiniz Araç ve Servis Bilgileri Silinecektir\n Emin Misiniz ?", "!!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                try
                {
                    con.Open();
                    MySqlCommand command = con.CreateCommand();
                    command.Parameters.AddWithValue("@plaka", textBox11.Text);
                    command.CommandText = "DELETE FROM yapilan_islem WHERE servis_id=(SELECT servis_id FROM servis WHERE plaka=@plaka)";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM servis WHERE plaka=@plaka";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE FROM araclar WHERE plaka = @plaka";
                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Başarı ile silindi");
                    }
                    listView2.Items.Clear();
                    textBox11.Clear();
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

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 AnaEkran = new Form3();
            this.Hide();
            AnaEkran.Show();
        }
    }
}
