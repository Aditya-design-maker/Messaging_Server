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
    public partial class Form5 : Form
    {
        int i = 0;
        int x = 1;
        public string str;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string str="select name from server where username='"+Form2.user+"'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dt = cmd.ExecuteReader();
            if(dt.Read())
            {
                label8.Text = dt["name"].ToString();
            }
            dt.Close();
            string str1 = "select name from server where username='" + Form4.a + "'";
            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dt1 = cmd1.ExecuteReader();
            if (dt1.Read())
            {
                label10.Text = dt1["name"].ToString();
            }
            dt1.Close();
            label1.Text = Form4.a;
            label3.Text = Form2.user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int n = 6;
            while (i < textBox2.Text.Length)
            {
                if(n==0)
                {
                    n = 6;
                }
                if (n > 0)
                {
                    if(n==6)
                    {
                        int x = (int)(textBox2.Text[i]) + 2;
                        sb.Append((char)(x));
                    }
                    if(n==5)
                    {
                        int x = (int)(textBox2.Text[i]) + 3;
                        sb.Append((char)(x));
                    }
                    if (n == 4)
                    {
                        int x = (int)(textBox2.Text[i]) + 4;
                        sb.Append((char)(x));
                    }
                    if (n == 3)
                    {
                        int x = (int)(textBox2.Text[i]) + 8;
                        sb.Append((char)(x));
                    }
                    if (n == 2)
                    {
                        int x = (int)(textBox2.Text[i]) + 9;
                        sb.Append((char)(x));
                    }
                    if (n == 1)
                    {
                        int x = (int)(textBox2.Text[i]) + 2;
                        sb.Append((char)(x));
                    }
                }
                n--;
                i++;
            }
            str = sb.ToString();
            textBox1.Text = str;
            x = 0;
            button1.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (x == 1)
            {
                MessageBox.Show("First enter the message and encrypt it");
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
                con.Open();
                string sql = "insert into [" + Form4.a + "] (username,message,users,date)values('" + Form4.a + "','" + str + "','" + Form2.user + "','"+DateTime.Now+"')";
                string sql1 = "insert into [" + Form2.user+"1" + "] (message,users,date) values('"+str+"','"+Form4.a+ "','" + DateTime.Now + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand(sql, con);
                da.InsertCommand.ExecuteNonQuery();
                da.Dispose();
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.InsertCommand = new SqlCommand(sql1, con);
                da1.InsertCommand.ExecuteNonQuery();
                da1.Dispose();
                MessageBox.Show("Message sent successfully");
                label11.Show();
                textBox1.Text = "";
                textBox2.Text = "";
                cmd.Dispose();
                con.Close();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully logged out");
            Form2 frm = new Form2();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Close();
        }
    }
}
