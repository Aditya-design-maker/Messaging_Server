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
    public partial class Form6 : Form
    {
        int x = 1;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox7.PasswordChar = '*';
            button3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (x == 1)
            {
                MessageBox.Show("First check the security code");
            }
            else if (x == 0)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                {
                    MessageBox.Show("Please enter all the deatils");
                }
                else if (textBox6.Text != textBox5.Text)
                {
                    MessageBox.Show("Password not matched");
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("select username from server where username='" + textBox4.Text + "'", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd4);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show("User already exist");
                    }
                    else
                    {
                        string sql = "insert into server values('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.InsertCommand = new SqlCommand(sql, con);
                        da.InsertCommand.ExecuteNonQuery();
                        cmd.Dispose();
                        string sql1 = "create table [" + textBox4.Text + "](s_no INT NOT NULL IDENTITY(1,1) PRIMARY KEY,username varchar(30),message varchar(max),users varchar(30),date varchar(50))";
                        SqlCommand cmd1 = new SqlCommand(sql1, con);
                        cmd1.ExecuteNonQuery();
                        button3.Show();
                        MessageBox.Show("User created successfully");
                        cmd1.Dispose();
                        string sql2 = "create table [" + textBox4.Text + "1" + "](s_no INT NOT NULL IDENTITY(1,1) PRIMARY KEY,message varchar(max),users varchar(30),date varchar(50))";
                        SqlCommand cmd2 = new SqlCommand(sql2, con);
                        cmd2.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox7.Text=="5683")
            {
                MessageBox.Show("Secure code checked successfully");
                button2.ForeColor = Color.Black;
                x = 0;
            }
            else
            {
                MessageBox.Show("Invalid secure code");
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Re-enter your password";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Re-enter your password")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
                textBox6.PasswordChar = '*';
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
