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
        //SqlConnection con;

        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            con = new SqlConnection("server=DESKTOP-NJ1A8Q5\\SQLEXPRESS; Initial Catalog=LoginController;Integrated Security=SSPI");//sql'i bağladık
            con.Open();
            string query = "SELECT * FROM usercontroller where username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'"; //tablomuzu sorgusunu yaptık
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reading = cmd.ExecuteReader();
            if (reading.Read())
            {
                Form2 obj1 = new Form2();
                obj1.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
            con.Close();
            

        }
    }
}
