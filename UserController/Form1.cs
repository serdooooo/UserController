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

namespace UserController
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        
        public Form1()
        {
            InitializeComponent();
        }
        string gelenID;


        private void button1_Click(object sender, EventArgs e)
        {
            
            con = new SqlConnection("server=SERDAR\\SQLEXPRESS; Initial Catalog=LoginController;Integrated Security=SSPI");
            con.Open();
            string query = "SELECT * FROM username where username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reading = cmd.ExecuteReader();
            if (reading.Read())
            {
                gelenID = reading["id"].ToString();
                reading.Close();
                string query1 = "select us.first_name,us.last_name,us.phone,us.city,us.county from  userdetails us inner join username u on us.id = u.id where u.id='"+gelenID+"'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataReader reading1 = cmd1.ExecuteReader();
                if (reading1.Read())
                {
                    Form2 obj1 = new Form2();
                    obj1.Show();
                    this.Visible = false;
                    ((TextBox)obj1.Controls["textBox1"]).Text = reading1["first_name"].ToString();
                    ((TextBox)obj1.Controls["textBox2"]).Text = reading1["last_name"].ToString();
                    ((TextBox)obj1.Controls["textBox3"]).Text = reading1["phone"].ToString();
                    ((TextBox)obj1.Controls["textBox4"]).Text = reading1["city"].ToString();
                    ((TextBox)obj1.Controls["textBox5"]).Text = reading1["county"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
                textBox1.Text = null;
                textBox2.Text = null;
            }
            

            con.Close();
        }
    }
}
