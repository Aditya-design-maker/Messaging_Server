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
    public partial class Form2 : Form
    {
        public static string user;
        public Form2()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString= "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            if (textBox1.Text == "Username" || textBox1.Text == "" && textBox2.Text == "Password" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter valid username and password");
                return;
            }
            SqlCommand cmd = new SqlCommand("select username,password from server where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlCommand cmd1 = new SqlCommand("select username from server where username='" + textBox1.Text + "'",con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt.Rows.Count > 0)
            {
                user = textBox1.Text;
                MessageBox.Show("Login Success");
                Form3 frm = new Form3();
                frm.Show();
                this.Close();
            }
            else if(dt1.Rows.Count>0)
            {
                MessageBox.Show("Please enter the valid password");
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Login Failed");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void textbox_enter(object sender, EventArgs e)
        {
            if(textBox1.Text=="Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textbox_leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textbox2_enter(object sender, EventArgs e)
        {
            if(textBox2.Text=="Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';
            }
        }

        private void textbox2_leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 frm = new Form9();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
