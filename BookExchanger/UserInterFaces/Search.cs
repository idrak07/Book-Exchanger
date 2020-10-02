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
    public partial class Search : Form
    {
        int userId;
        public Search(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            update();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {

               
                BookFullDetails b = new BookFullDetails(userId,int.Parse(listView1.SelectedItems[0].Text));
                b.Show();
                this.Dispose();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SellBook s = new SellBook(this,userId);
            s.Show();
            this.Hide();
        }
        public void update()
        {
            BookRepo p = new BookRepo();
            SqlDataReader sqlDataReader;
            sqlDataReader=p.showAllBooks();
            while(sqlDataReader.Read())
            {
                ListViewItem item = new ListViewItem(""+(int)sqlDataReader.GetValue(0));
                item.SubItems.Add(""+(string)sqlDataReader.GetValue(1));
                item.SubItems.Add("" + (int)sqlDataReader.GetValue(6));
                listView1.Items.Add(item);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            Search s = new Search(userId);
            s.Show();
            update();
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RequestBook r = new RequestBook(userId);
            r.Show();
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RequestedBook r = new RequestedBook(userId);
            r.Show();
            this.Dispose();
        }
    }
}
