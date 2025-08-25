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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management
{
    public partial class viewbook : Form
    {
        public viewbook()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin\Desktop\uni\Library Management\Library Management\Database1.mdf"";Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Book WHERE Booktitle LIKE '"+textBox1.Text+"%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin\Desktop\uni\Library Management\Library Management\Database1.mdf"";Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Book ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void viewbook_Load(object sender, EventArgs e)
        {

            panel1.Visible = false;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin\Desktop\uni\Library Management\Library Management\Database1.mdf"";Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Book ";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }
        int Id;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!= null)
            {
               Id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel1.Visible = true;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin\Desktop\uni\Library Management\Library Management\Database1.mdf"";Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Book WHERE Id = "+Id+"";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            textBox4.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox2.Text = ds.Tables[0].Rows[0][2].ToString();
            textBox3.Text = ds.Tables[0].Rows[0][3].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this. Hide();
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string Booktitle = textBox4.Text;
                string Bookauthor = textBox2.Text;
                Int64 Bookprice = Int64.Parse(textBox3.Text);
                string pdate = dateTimePicker1.Text;

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin\Desktop\uni\Library Management\Library Management\Database1.mdf"";Integrated Security=True");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
               
                cmd.CommandText = "UPDATE Book SET  Booktitle = '" +Booktitle+ "',Bookauthor = '" +Bookauthor+ "' ,Bookprice = "+Bookprice+" ,pdate = '"+pdate+"' WHERE Id = "+rowid+"";
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                MessageBox.Show("Data saved.", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Clear();
                textBox2.Clear();
                textBox3.Clear();

            }
            else
            {
                MessageBox.Show("empty text box no allowed", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
