using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;



namespace FrontWcfService.App_Code
{
    public class ModelUser
    {
        private SqlConnection conn;

        public ModelUser()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=projetDAD;Trusted_Connection=True;";
            conn.Open();
        }

        public bool isUserExist(string username, string password)
        {
            using (SqlCommand command = new SqlCommand("SELECT username, password FROM Users WHERE username = @0 AND password = @1", conn))
            {
                command.Parameters.Add(new SqlParameter("0", username));
                command.Parameters.Add(new SqlParameter("1", password));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                    
                else
                {
                    reader.Close();
                    return false;
                }
                  
            }
        }

        public int getProgressUser(string username)
        {
            using (SqlCommand commanduser = new SqlCommand("SELECT stat1,stat2,stat3,stat4 FROM Users WHERE username = @0", conn))
            {
                commanduser.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader readeruser = commanduser.ExecuteReader();
                readeruser.Read();

                int res = 0;

                bool stat1 = readeruser.GetBoolean(0);
                bool stat2 = readeruser.GetBoolean(1);
                bool stat3 = readeruser.GetBoolean(2);
                bool stat4 = readeruser.GetBoolean(3);



                readeruser.Close();

                return res + Convert.ToInt32(stat1) + Convert.ToInt32(stat2) + Convert.ToInt32(stat3) + Convert.ToInt32(stat4);
            }
        }

        public bool isTokenExist(string username,string token)
        {
            using (SqlCommand command = new SqlCommand("SELECT username FROM Users WHERE username = @0 AND token = @1", conn))
            {
                command.Parameters.Add(new SqlParameter("0", username));
                command.Parameters.Add(new SqlParameter("1", token));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }

                else
                {
                    reader.Close();
                    return false;
                }

            }
        }

        public void updateUserToken(int idUser, string token)
        {
            string id = idUser.ToString();
            using (SqlCommand command = new SqlCommand("UPDATE Users SET token = @0 WHERE id_user = @1", conn))
            {
                command.Parameters.Add(new SqlParameter("0", token));
                command.Parameters.Add(new SqlParameter("1", id));

                command.ExecuteReader();
            }
                
        }

        public int getIdUser(string username)
        {
            using (SqlCommand commanduser = new SqlCommand("SELECT id_user FROM Users WHERE username = @0", conn))
            {
                commanduser.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader readeruser = commanduser.ExecuteReader();
                readeruser.Read();

                int id = readeruser.GetInt32(0);

                readeruser.Close();
                return id;
            }
                

            
        }
    }
}