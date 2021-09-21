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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=adi-1-laptop;Initial Catalog=Server_Database;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("select code from server where code='" + textBox1.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                MessageBox.Show("Access permitted");
                Form7 frm = new Form7();
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }
    }
}
