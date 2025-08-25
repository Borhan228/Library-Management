using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form1 login = new Form1();   
            this.Hide();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (empty())
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin\Desktop\uni\Library Management\Library Management\Database1.mdf"";Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Login (Username,Password) VALUES ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "')", conn);

                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("your account was created successfully");
                    textBox2.Clear();
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("error");
                }
                conn.Close();
                
            }
        }
        private bool empty()
        {
            if (textBox1.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Pls enter you'r User name");
                return false;
            }
            else if (textBox2.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Pls enter you'r Password");
                return false;
            }
            return true;
        }
        private void Sign_up_Load(object sender, EventArgs e)
        {

        }
    }
}
