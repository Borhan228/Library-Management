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
    public partial class addbooks : Form
    {
        public addbooks()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    string Booktitle = textBox1.Text;
                    string Bookauthor = textBox2.Text;
                    Int64 Bookprice = Int64.Parse(textBox3.Text);
                    string pdate = dateTimePicker1.Text;

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin\Desktop\uni\Library Management\Library Management\Database1.mdf"";Integrated Security=True");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "INSERT INTO Book (Booktitle,Bookauthor,Bookprice,pdate) VALUES ('" + Booktitle + "','" + Bookauthor + "','" + Bookprice + "','" + pdate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data saved.", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                }
                else
                {
                    MessageBox.Show("empty text box no allowed", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pls enter a number for the price"+ ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" are you sure to go back.", "are you sure", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Hide();
                Dashbord dashbord = new Dashbord();
                dashbord.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
