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
    public partial class Form4 : Form
    {
        int x = 1;
        public static string a;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("select username from server where username='"+textBox1.Text+"'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                a = textBox1.Text;
                MessageBox.Show("User verified");
                button2.ForeColor = Color.Black;
                x = 0;
            }
            else
            {
                MessageBox.Show("User is not verified"); ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(x==1)
            {
                MessageBox.Show("check the user first");
            }
            else
            {
                Form5 frm = new Form5();
                frm.Show();
                this.Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            SqlCommand cmd=new SqlCommand("select ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully logged out");
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
