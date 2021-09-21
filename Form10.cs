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
    public partial class Form10 : Form
    {
        int n;
        int x;
        int i = 0;
        int a = 0;
        string str;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            button4.Hide();
            label1.Text = "Welcome:" + Form2.user;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string str = "select name from server where username='" + Form2.user + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dt = cmd.ExecuteReader();
            if (dt.Read())
            {
                label2.Text = dt["name"].ToString();
            }
            dt.Close();
            string sql = "select * from [" + Form2.user +"1"+ "]";
            string sql1 = "select * from [" + Form2.user+"1" + "] where s_no=(select max(s_no) from [" + Form2.user+"1" + "])";
            SqlCommand command = new SqlCommand(sql1, con);
            SqlCommand cmd1 = new SqlCommand(sql, con);
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable dt1 = new DataTable();
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                dr.Fill(dt1);
                foreach (DataRow row1 in dt1.Rows)
                {
                    n = Convert.ToInt32(row1["s_no"].ToString());
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);
                foreach (DataRow row in dt2.Rows)
                {
                    x = Convert.ToInt32(row["s_no"].ToString());
                    if (x == n)
                    {
                        label3.Show();
                        label4.Show();
                        button1.Show();
                        label5.Show();
                        label3.Text = row["users"].ToString();
                        label5.Text = row["date"].ToString();
                        string sql2 = "select name from server where username='" + label3.Text + "'";
                        SqlCommand command1 = new SqlCommand(sql2, con);
                        SqlDataReader reader1 = command1.ExecuteReader();
                        if (reader1.Read())
                        {
                            label4.Text = reader1["name"].ToString(); ;
                        }
                        reader1.Close();
                    }
                    if (x == (n - 1))
                    {
                        label6.Show();
                        label7.Show();
                        button2.Show();
                        label8.Show();
                        label6.Text = row["users"].ToString();
                        label8.Text = row["date"].ToString();
                        string sql3 = "select name from server where username='" + label6.Text + "'";
                        SqlCommand command2 = new SqlCommand(sql3, con);
                        SqlDataReader reader2 = command2.ExecuteReader();
                        if (reader2.Read())
                        {
                            label7.Text = reader2["name"].ToString(); ;
                        }
                        reader2.Close();
                    }
                    if (x == (n - 2))
                    {
                        label9.Show();
                        label10.Show();
                        button3.Show();
                        label11.Show();
                        label11.Text = row["date"].ToString();
                        label9.Text = row["users"].ToString();
                        string sql4 = "select name from server where username='" + label9.Text + "'";
                        SqlCommand command3 = new SqlCommand(sql4, con);
                        SqlDataReader reader3 = command3.ExecuteReader();
                        if (reader3.Read())
                        {
                            label10.Text = reader3["name"].ToString(); ;
                        }
                        reader3.Close();
                    }
                    
                }
            }
            else
            {
                label13.Show();
                label13.Text = "No records found";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4.a = label3.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select message from [" + Form2.user+"1" + "] where users='" + label3.Text + "' and s_no='" + x + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            textBox1.Show();
            textBox1.Text = "";
            label12.Show();
            if (dt.Read())
            {
                textBox1.Text = dt["message"].ToString();
            }
            dt.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            StringBuilder sb = new StringBuilder();
            i = 0;
            int a = 6;
            while (i < textBox1.Text.Length)
            {
                if (a == 0)
                {
                    a = 6;
                }
                if (a > 0)
                {
                    if (a == 6)
                    {
                        int x = (int)(textBox1.Text[i]) - 2;
                        sb.Append((char)(x));
                    }
                    if (a == 5)
                    {
                        int x = (int)(textBox1.Text[i]) - 3;
                        sb.Append((char)(x));
                    }
                    if (a == 4)
                    {
                        int x = (int)(textBox1.Text[i]) - 4;
                        sb.Append((char)(x));
                    }
                    if (a == 3)
                    {
                        int x = (int)(textBox1.Text[i]) - 8;
                        sb.Append((char)(x));
                    }
                    if (a == 2)
                    {
                        int x = (int)(textBox1.Text[i]) - 9;
                        sb.Append((char)(x));
                    }
                    if (a == 1)
                    {
                        int x = (int)(textBox1.Text[i]) - 2;
                        sb.Append((char)(x));
                    }
                }
                a--;
                i++;
            }
            str = sb.ToString();
            textBox2.Text = str;
            textBox2.Show();
            button4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4.a = label6.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select message from [" + Form2.user + "1" + "] where users='" + label6.Text + "' and s_no='" + (x-1) + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            textBox1.Show();
            textBox1.Text = "";
            label12.Show();
            if (dt.Read())
            {
                textBox1.Text = dt["message"].ToString();
            }
            dt.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4.a = label9.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select message from [" + Form2.user + "1" + "] where users='" + label9.Text + "' and s_no='" + (x-2) + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            textBox1.Show();
            textBox1.Text = "";
            label12.Show();
            if (dt.Read())
            {
                textBox1.Text = dt["message"].ToString();
            }
            dt.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
            this.Hide();
        }
    }
}
