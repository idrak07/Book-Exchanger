using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BookExchanger.Repository
{
    class UserRepo
    {
        public int checkLogin(int userId,string password)
        {
            int s=0;
            string pass;
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                SqlDataReader sqlDataReader;
                
                cnn.Open();

                string sql = "Select * from login where userId='"+userId+"' and password='"+password+"'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    s = (int)sqlDataReader.GetValue(1);
                    pass = (string)sqlDataReader.GetValue(2);
                    
                    Console.WriteLine("" + s + "" + pass);
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return s;
        }

        public void insertUserDetails(string id,string password,string name,string email,string phone,string adress)
        {
            try
            {
                string connection = "Data Source=DESKTOP-P447JTH;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                SqlCommand cd1;


                cnn.Open();

                string sql1 = string.Format("INSERT INTO login(userid,password,type) VALUES('{0}','{1}','{2}')", id,password, 0); 
                string sql2 = string.Format("INSERT INTO UserDetails(userid,name,email,phone,adress,point) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id,name, email,phone,adress,100);
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
    }
}
