using BookExchanger.Repository;
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

namespace BookExchanger.UserInterFaces
{
    public partial class SignUp : Form
    {
        Login l;
        public SignUp(Login l)
        {
            this.l = l;
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            l.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRepo r = new UserRepo();
            r.insertUserDetails(txtId.Text,txtPass.Text,txtName.Text,txtEmail.Text,txtPhone.Text,txtAdress.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void insertDB()
        {
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                SqlDataReader sqlDataReader;

                cnn.Open();

                string sql = "insert into login ";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
        }
    }
}
