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
    public partial class BookFullDetails : Form
    {
        int bookid;
        int userId;
        public BookFullDetails(int userId,int bookid)
        {
            InitializeComponent();
            this.bookid = bookid;
            this.userId = userId;
            update();
            updatePhoto();
        }
        public void update()
        {
            BookRepo p = new BookRepo();
            SqlDataReader sqlDataReader;
            sqlDataReader = p.showBookInfo(bookid);
            while (sqlDataReader.Read())
            {
                lblTitle.Text = "Title: "+(string)(sqlDataReader.GetValue(1));
                lblAuthor.Text= "Author: " + (string)(sqlDataReader.GetValue(5));
                lblEdition.Text="Edition: "+(string)(sqlDataReader.GetValue(2));
                lblUsed.Text= "Used Duration: "+(int)(sqlDataReader.GetValue(3))+" Days";
            }
        }
        public void updatePhoto()
        {
            BookRepo p = new BookRepo();
            SqlDataReader sqlDataReader;
            sqlDataReader = p.showBookPic(bookid);
            while (sqlDataReader.Read())
            {
                pictureBox1.ImageLocation=(string)(sqlDataReader.GetValue(2));
                
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Search s = new Search(userId);
            s.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
