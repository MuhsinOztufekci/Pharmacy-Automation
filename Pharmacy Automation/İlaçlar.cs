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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pharmacy_Automation
{
    public partial class İlaçlar : Form
    {
        public İlaçlar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("data source = LAPTOP-EA33PHT6; Initial Catalog = pharmacy_automation; Integrated Security = true ");
        private void verileriGoruntule()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM medicine ", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["drugName"].ToString());
                ekle.SubItems.Add(oku["drugCompany"].ToString());
                ekle.SubItems.Add(oku["drugType"].ToString());
                ekle.SubItems.Add(oku["price"].ToString());
                ekle.SubItems.Add(oku["stock_quantity"].ToString());
                ekle.SubItems.Add(oku["sales_quantity"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verileriGoruntule();
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into medicine (id,drugName,drugCompany,drugType,price,stock_quantity, sales_quantity) VALUES ('" + textBox1.Text + "' ,'" + textBox2.Text + "' ,'" + textBox3.Text + "' ,'" + textBox4.Text + "' ,'" + textBox5.Text + "', '" + textBox6.Text + "','" + textBox7.Text + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From medicine Where id = (" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update medicine Set id = '" + textBox1.Text + "', drugName = '" + textBox2.Text + "' , drugCompany = '" + textBox3.Text + "' , drugType = '" + textBox4.Text + "' , Price = '" + textBox5.Text + "', stock_quantity = '" + textBox6.Text + "' , sales_quantity = '" + textBox7.Text + "'  Where id = " + id + " ", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Selection selection = new Selection();
            selection.Show();
            Close();
        }
    }
}
