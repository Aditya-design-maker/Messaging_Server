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
    public partial class Form8 : Form
    {
        int i = 0;
        int n = 0;
        int j = 1;
        int x;
        string str;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome:"+Form2.user;
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
            label3.Hide();
            label4.Hide();
            button3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button10.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select users,date from ["+Form2.user+"] where s_no=(select max(s_no) from ["+Form2.user+"])";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataReader dt = cmd.ExecuteReader();
            if (dt.HasRows)
            {
                if (dt.Read())
                {
                    label3.Text =  dt["users"].ToString();
                    label17.Text = dt["date"].ToString();
                }
                label3.Show();
                label17.Show();
                cmd.Dispose();
                dt.Close();
                string sql1 = "select name from server where username=(select users from [" + Form2.user + "] where s_no=(select max(s_no) from [" + Form2.user + "]))";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataReader dt1 = cmd1.ExecuteReader();
                if (dt1.Read())
                {
                    label4.Text = dt1["name"].ToString();
                }
                dt1.Close();
                label4.Show();
                button3.Show();
            }
            else
            {
                label16.Show();
                label16.Text = "No records found";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4.a = label3.Text;
            button10.Hide();
            SqlConnection con = new SqlConnection();
            textBox2.Text = "";
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select message from ["+Form2.user+ "] where s_no=(select max(s_no) from [" + Form2.user + "])";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataReader dt = cmd.ExecuteReader();
            if(dt.Read())
            {
                textBox1.Text = dt["message"].ToString();
            }
            dt.Close();
            textBox1.Show();
            label5.Show();

            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            StringBuilder sb = new StringBuilder();
            i = 0;
            int n = 6;
            while (i < textBox1.Text.Length)
            {
                if (n == 0)
                {
                    n = 6;
                }
                if (n > 0)
                {
                    if (n == 6)
                    {
                        int x = (int)(textBox1.Text[i]) - 2;
                        sb.Append((char)(x));
                    }
                    if (n == 5)
                    {
                        int x = (int)(textBox1.Text[i]) - 3;
                        sb.Append((char)(x));
                    }
                    if (n == 4)
                    {
                        int x = (int)(textBox1.Text[i]) - 4;
                        sb.Append((char)(x));
                    }
                    if (n == 3)
                    {
                        int x = (int)(textBox1.Text[i]) - 8;
                        sb.Append((char)(x));
                    }
                    if (n == 2)
                    {
                        int x = (int)(textBox1.Text[i]) - 9;
                        sb.Append((char)(x));
                    }
                    if (n == 1)
                    {
                        int x = (int)(textBox1.Text[i]) - 2;
                        sb.Append((char)(x));
                    }
                }
                n--;
                i++;
            }
            str = sb.ToString();
            textBox2.Text = str;
            textBox2.Show();
            button10.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select * from [" + Form2.user + "]";
            string sql1 = "select * from [" + Form2.user + "] where s_no=(select max(s_no) from ["+Form2.user+"])";
            SqlCommand command = new SqlCommand(sql1, con);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable dt1 = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                dr.Fill(dt1);
                foreach (DataRow row1 in dt1.Rows)
                {
                    n = Convert.ToInt32(row1["s_no"].ToString());
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    x = Convert.ToInt32(row["s_no"].ToString());
                    if (x == n)
                    {
                        label6.Show();
                        label7.Show();
                        button4.Show();
                        label18.Show();
                        label6.Text = row["users"].ToString();
                        label18.Text = row["date"].ToString();
                        string sql2 = "select name from server where username='" + label6.Text + "'";
                        SqlCommand command1 = new SqlCommand(sql2, con);
                        SqlDataReader reader1 = command1.ExecuteReader();
                        if (reader1.Read())
                        {
                            label7.Text = reader1["name"].ToString(); ;
                        }
                        reader1.Close();
                    }
                    if (x == (n - 1))
                    {
                        label8.Show();
                        label9.Show();
                        button5.Show();
                        label19.Show();
                        label8.Text = row["users"].ToString();
                        label19.Text = row["date"].ToString();
                        string sql3 = "select name from server where username='" + label8.Text + "'";
                        SqlCommand command2 = new SqlCommand(sql3, con);
                        SqlDataReader reader2 = command2.ExecuteReader();
                        if (reader2.Read())
                        {
                            label9.Text = reader2["name"].ToString(); ;
                        }
                        reader2.Close();
                    }
                    if (x == (n - 2))
                    {
                        label10.Show();
                        label11.Show();
                        button6.Show();
                        label20.Show();
                        label20.Text = row["date"].ToString();
                        label10.Text = row["users"].ToString();
                        string sql4 = "select name from server where username='" + label10.Text + "'";
                        SqlCommand command3 = new SqlCommand(sql4, con);
                        SqlDataReader reader3 = command3.ExecuteReader();
                        if (reader3.Read())
                        {
                            label11.Text = reader3["name"].ToString(); ;
                        }
                        reader3.Close();
                    }
                    if (x == (n - 3))
                    {
                        label12.Show();
                        label13.Show();
                        button7.Show();
                        label21.Show();
                        label21.Text = row["date"].ToString();
                        label12.Text = row["users"].ToString();
                        string sql5 = "select name from server where username='" + label12.Text + "'";
                        SqlCommand command4 = new SqlCommand(sql5, con);
                        SqlDataReader reader4 = command4.ExecuteReader();
                        if (reader4.Read())
                        {
                            label13.Text = reader4["name"].ToString(); ;
                        }
                        reader4.Close();
                    }
                    if (x == (n - 4))
                    {
                        label14.Show();
                        label15.Show();
                        button8.Show();
                        label22.Show();
                        label22.Text = row["date"].ToString();
                        label14.Text = row["users"].ToString();
                        string sql6 = "select name from server where username='" + label14.Text + "'";
                        SqlCommand command5 = new SqlCommand(sql6, con);
                        SqlDataReader reader5 = command5.ExecuteReader();
                        if (reader5.Read())
                        {
                            label15.Text = reader5["name"].ToString(); ;
                        }
                        reader5.Close();
                    }
                }
            }
            else
            {
                label16.Show();
                label16.Text = "No records found";
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label3.Hide();
            button10.Hide();
            label4.Hide();
            button3.Hide();
            Form4.a = label6.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select message from [" + Form2.user + "] where users='"+label6.Text+"' and s_no='"+x+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            textBox1.Show();
            textBox1.Text = "";
            label5.Show();
            if (dt.Read())
            {
                textBox1.Text = dt["message"].ToString();
            }
            dt.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label3.Hide();
            button10.Hide();
            label4.Hide();
            button3.Hide();
            Form4.a = label8.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select message from [" + Form2.user + "] where users='" + label8.Text + "' and s_no='" + (x-1) + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            textBox1.Show();
            label5.Show();
            textBox1.Text = "";
            if (dt.Read())
            {
                textBox1.Text = dt["message"].ToString();
            }
            dt.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label3.Hide();
            label4.Hide();
            button3.Hide();
            button10.Hide();
            Form4.a = label10.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select message from [" + Form2.user + "] where users='" + label10.Text + "' and s_no='" + (x - 2) + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            textBox1.Show();
            label5.Show();
            textBox1.Text = "";
            if (dt.Read())
            {
                textBox1.Text = dt["message"].ToString();
            }
            dt.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label3.Hide();
            label4.Hide();
            button3.Hide();
            button10.Hide();
            Form4.a = label12.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            string sql = "select message from [" + Form2.user + "] where users='" + label12.Text + "' and s_no='" + (x - 3) + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            textBox1.Show();
            label5.Show();
            textBox1.Text = "";
            if (dt.Read())
            {
                textBox1.Text = dt["message"].ToString();
            }
            dt.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button10.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
