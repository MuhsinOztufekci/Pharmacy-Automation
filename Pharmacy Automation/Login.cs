using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Automation
{
    public partial class Login : Form
    {
        SqlConnection baglan = new SqlConnection("data source = LAPTOP-EA33PHT6; Initial Catalog = pharmacy_automation; Integrated Security = true ");
        public Login()
        {
            InitializeComponent();

        }
        bool isThere;
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass = textBox2.Text;
          

            baglan.Open();
            SqlCommand command = new SqlCommand("Select * From Users", baglan);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               if( username == reader["E_mail"].ToString().TrimEnd() && pass == reader["Pass"].ToString().TrimEnd())
                {
                    isThere= true;
                    Selection selection = new Selection();
                    selection.Show();
                    this.Close();
                }
                else
                {
                    isThere= false;
                }
            }

            baglan.Close();

            if(isThere)
            {
                MessageBox.Show("Hoşgeldiniz", "Program");
            }

            else
            {
                MessageBox.Show("Hatalı bilgi girdiniz lütfen tekrar deneyin", "Program");
            }
        }

      
    }
}
