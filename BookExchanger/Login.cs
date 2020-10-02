using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookExchanger.Repository;
using BookExchanger.UserInterFaces;

namespace BookExchanger
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserRepo c = new UserRepo();
            int x = c.checkLogin(int.Parse(txtId.Text),txtPass.Text);
            if (x != 0)
            {
                Search s = new Search(x);
                s.Show();
                this.Hide();
            }
            if(x==0)
            {
                Console.WriteLine("wrong");
            }
            else { }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp(this);
            signUp.Show();
            this.Hide();
        }
    }
}
