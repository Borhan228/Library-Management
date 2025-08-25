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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (empty())
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin\Desktop\uni\Library Management\Library Management\Database1.mdf"";Integrated Security=True"))
                {
                    string query = "SELECT * FROM Login WHERE Username = '" + textBox1.Text.Trim() + "'AND Password = '" + textBox2.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    if ( data.Rows.Count == 1 )
                    {
                        Dashbord dash = new Dashbord();
                        this.Hide();
                        dash.Show();
                    }
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Sign_up sing = new Sign_up();
            this.Hide();
            sing.Show();
        }
    }
}
