using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookExchanger.Repository
{
    class BookRepo
    {
        public void insertBookDetails(string photoName,string photoLoc,string title,string edition,int uDate,int userId,string author,int point )
        {
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                SqlCommand cd1;


                cnn.Open();

                string sql1 = string.Format("INSERT INTO BookPhoto(PhotoName,photoLoc,userId) VALUES('{0}','{1}','{2}')", photoName, photoLoc, userId);
                string sql2 = string.Format("INSERT INTO BookDetails(title,Edition,UsedDate,UserId,Author,Point) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", title, edition, uDate, userId, author, point);
               cd = new SqlCommand(sql1, cnn);
                int rows = -1;
                rows = cd.ExecuteNonQuery();
                cd1 = new SqlCommand(sql2, cnn);
                int rows2 = -1;
                rows2 = cd1.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
        }

        public SqlDataReader showAllBooks()
        {
            SqlDataReader sqlDataReader=null;
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                

                cnn.Open();

                string sql = "Select * from BookDetails";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public SqlDataReader showBookInfo(int bookid)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from BookDetails where id='"+bookid+"'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public SqlDataReader showBookPic(int bookid)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from BookPhoto where id='" + bookid + "'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public void insertRequestBook(string title,string author,int point,int userId)
        {
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                


                cnn.Open();

                string sql1 = string.Format("INSERT INTO RequestBook(title,author,point,userId) VALUES('{0}','{1}','{2}','{3}')", title, author, point, userId);
               
                cd = new SqlCommand(sql1, cnn);
                int rows = -1;
                rows = cd.ExecuteNonQuery();
                

                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
        }
        public SqlDataReader showAllReqBooks()
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from RequestBook";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }

    }
}
