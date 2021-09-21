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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            label4.Hide();
            textBox5.Hide();
            textBox5.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter the id");
            }
            else
            {
                button1.ForeColor = Color.Black;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand("select username from server where username='" + textBox1.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("User verified");
                }
                else
                {
                    MessageBox.Show("User is not verified"); ;
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            String sql="select name from server where username='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                if(reader["name"].ToString()!=textBox2.Text)
                {
                    MessageBox.Show("Name is not matched" +
                        "      do correction");
                    textBox2.Text = "";
                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Re-enter the password")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
                textBox4.PasswordChar = '*';
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Re-enter the password";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.PasswordChar = '\0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""|| textBox2.Text == ""|| textBox3.Text == ""|| textBox4.Text == "")
            {
                MessageBox.Show("Please provide all the information");
            }
            else
            {
                label4.Show();
                textBox5.Show();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand("select code from server where code='" + textBox5.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(textBox3.Text!=textBox4.Text)
                {
                    MessageBox.Show("Password mismatched");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else if (dt.Rows.Count > 0)
                {
                    string sql = "update server set password='" + textBox4.Text + "' where username='" + textBox1.Text + "'";
                    SqlCommand command = new SqlCommand(sql, con);
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    da1.InsertCommand = new SqlCommand(sql, con);
                    da1.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Password changed successfully    taking you to the login page");
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Secure code access failed");
                }
            }
        }
    }
}
