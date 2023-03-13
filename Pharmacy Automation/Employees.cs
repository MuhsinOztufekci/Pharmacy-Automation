using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Principal;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pharmacy_Automation
{
    public partial class Employees : Form
    {
        SqlConnection baglan = new SqlConnection("data source = LAPTOP-EA33PHT6; Initial Catalog = pharmacy_automation; Integrated Security = true ");
        public Employees()
        {
            InitializeComponent();
        }

        private void verileriGoruntule()
        {
            listView1.Items.Clear();
            string connectionString = "data source = LAPTOP-EA33PHT6; Initial Catalog = pharmacy_automation; Integrated Security = true";
            string queryString = "SELECT* FROM Employees";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                baglan.Open();


                using (SqlCommand command = new SqlCommand(queryString, baglan))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
              
                            ListViewItem ekle = new ListViewItem();
                            ekle.Text = reader["identification_number"].ToString();
                            ekle.SubItems.Add(reader["Name"].ToString());
                            ekle.SubItems.Add(reader["Surname"].ToString());
                            ekle.SubItems.Add(reader["Age"].ToString());
                            ekle.SubItems.Add(reader["Salary"].ToString());
                            listView1.Items.Add(ekle);
                        }

                        baglan.Close();
                    }
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            verileriGoruntule();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Employees (identification_number,Name,Surname,Age,Salary ) VALUES ('" + textBox1.Text + "' ,'" + textBox2.Text + "' ,'" + textBox3.Text + "' ,'" + textBox4.Text + "' ,'" + textBox5.Text + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            //int identification_number = 0;
            baglan.Open();
            //SqlCommand komut = new SqlCommand("Delete From Employees Where identification_number = (" + identification_number + ")", baglan);
            SqlCommand komut = new SqlCommand("DELETE FROM Employees WHERE identification_number = @identification_number", baglan);
            komut.Parameters.AddWithValue("@identification_number", textBox1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            long identification_number = long.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update Employees Set identification_number = '" + textBox1.Text + "', Name = '" + textBox2.Text + "', Surname = '" + textBox3.Text + "', Age = '" + textBox4.Text + "', Salary ='" + textBox5.Text + "' ", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Selection selection = new Selection();
            selection.Show();
            Close();
        }

       
    }
}