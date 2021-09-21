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

namespace Exposys_Project
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label2.Text = "Welcome:" + Form2.user;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string str = "select name from server where username='" + Form2.user + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dt = cmd.ExecuteReader();
            if (dt.Read())
            {
                label1.Text = dt["name"].ToString();
            }
            dt.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form4 frm = new Form4();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10();
            frm.Show();
            this.Hide();
        }
    }
}
