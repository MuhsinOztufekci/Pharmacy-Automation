using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Automation
{
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            İlaçlar ilaçlar = new İlaçlar();
            ilaçlar.Show();
            Close();
        }
    }
}
