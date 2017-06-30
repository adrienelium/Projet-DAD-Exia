using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;



namespace FrontWcfService.App_Code
{
    public class ModelUser
    {
        private string strConn = "Server=localhost\\SQLEXPRESS;Database=projetDAD;Trusted_Connection=True;";

        public ModelUser()
        {
            
        }

        public bool isUserExist(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                
                conn.ConnectionString = strConn;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT username, password FROM Users WHERE username = @0 AND password = @1", conn);
                command.Parameters.Add(new SqlParameter("0", username));
                command.Parameters.Add(new SqlParameter("1", password));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    conn.Close();
                    return true;
                }
                    
                else
                {
                    reader.Close();
                    conn.Close();
                    return false;
                }
                  
            }
        }

        public void updateResultByUsername(string docname, string content, string taux, string key, string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET result_docname = @0, result_content = @1, result_taux = @2, result_key = @3, result_found = @5 WHERE username = @4", conn);
                command.Parameters.Add(new SqlParameter("0", docname));
                command.Parameters.Add(new SqlParameter("1", content));
                command.Parameters.Add(new SqlParameter("2", taux));
                command.Parameters.Add(new SqlParameter("3", key));
                command.Parameters.Add(new SqlParameter("5", true));
                command.Parameters.Add(new SqlParameter("4", username));

                command.ExecuteReader();
                conn.Close();
            }
        }

        public void resetResultByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET result_docname = @0, result_content = @1, result_taux = @2, result_key = @3, result_found = @5 WHERE username = @4", conn);
                command.Parameters.Add(new SqlParameter("0", ""));
                command.Parameters.Add(new SqlParameter("1", ""));
                command.Parameters.Add(new SqlParameter("2", ""));
                command.Parameters.Add(new SqlParameter("3", ""));
                command.Parameters.Add(new SqlParameter("5", false));
                command.Parameters.Add(new SqlParameter("4", username));

                command.ExecuteReader();
                conn.Close();
            }
        }

        public bool isResultExist(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT result_found FROM Users WHERE username = @0", conn);
                command.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                bool res = reader.GetBoolean(0);

                reader.Close();
                conn.Close();

                return res;

            }
        }

        public string getMailByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT email FROM Users WHERE username = @0", conn);
                command.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                string res = reader.GetString(0);

                reader.Close();
                conn.Close();

                return res;

            }
        }

        public Result getResult(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();

                SqlCommand commanduser = new SqlCommand("SELECT result_docname,result_content,result_taux,result_key FROM Users WHERE username = @0", conn);
                commanduser.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader readeruser = commanduser.ExecuteReader();
                readeruser.Read();

                Result res = new Result { docname = readeruser.GetString(0), content = readeruser.GetString(1), taux = readeruser.GetInt32(2), key = readeruser.GetString(3) };

                readeruser.Close();
                conn.Close();

                return res;
            }
        }

        public int getProgressUser(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();

                SqlCommand commanduser = new SqlCommand("SELECT stat1,stat2,stat3,stat4 FROM Users WHERE username = @0", conn);
                commanduser.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader readeruser = commanduser.ExecuteReader();
                readeruser.Read();

                int res = 0;

                bool stat1 = readeruser.GetBoolean(0);
                bool stat2 = readeruser.GetBoolean(1);
                bool stat3 = readeruser.GetBoolean(2);
                bool stat4 = readeruser.GetBoolean(3);

                if (stat1)
                {
                    res = 10;
                }

                if (stat2)
                {
                    res = 100;
                }

                readeruser.Close();
                conn.Close();

                return res;
            }
        }

        public bool isTokenExist(string username,string token)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT username FROM Users WHERE username = @0 AND token = @1", conn);
                command.Parameters.Add(new SqlParameter("0", username));
                command.Parameters.Add(new SqlParameter("1", token));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    conn.Close();
                    return true;
                }

                else
                {
                    reader.Close();
                    conn.Close();
                    return false;
                }

            }
        }

        public void updateUserToken(int idUser, string token)
        {
            string id = idUser.ToString();
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET token = @0 WHERE id_user = @1", conn);
                command.Parameters.Add(new SqlParameter("0", token));
                command.Parameters.Add(new SqlParameter("1", id));

                command.ExecuteReader();
                conn.Close();
            }
                
        }

        public void updateStat1True(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET stat1 = @0, stat2 = @2 WHERE username = @1", conn);
                command.Parameters.Add(new SqlParameter("0", true));
                command.Parameters.Add(new SqlParameter("1", username));
                command.Parameters.Add(new SqlParameter("2", false));

                command.ExecuteReader();
                conn.Close();
            }

        }

        public void updateStat2True(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET stat2 = @0 WHERE username = @1", conn);
                command.Parameters.Add(new SqlParameter("0", true));
                command.Parameters.Add(new SqlParameter("1", username));

                command.ExecuteReader();
                conn.Close();
            }

        }

        public void updatePourcent(string username,int value)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET pourcent = @0 WHERE username = @1", conn);
                command.Parameters.Add(new SqlParameter("0", value.ToString()));
                command.Parameters.Add(new SqlParameter("1", username));

                command.ExecuteReader();
                conn.Close();
            }

        }

        public int getPourcent(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT pourcent FROM Users WHERE username = @0", conn);
                command.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                int value = reader.GetInt32(0);

                reader.Close();
                conn.Close();

                return value;
            }
        }

        public bool getStat1(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT stat1 FROM Users WHERE username = @0", conn);
                command.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                bool value = reader.GetBoolean(0);

                reader.Close();
                conn.Close();

                return value;
            }
        }

        public void updateResetStatAndPourcent(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET stat1 = @0, stat2 = @2, pourcent = @3 WHERE username = @1", conn);
                command.Parameters.Add(new SqlParameter("0", false));
                command.Parameters.Add(new SqlParameter("1", username));
                command.Parameters.Add(new SqlParameter("2", false));
                command.Parameters.Add(new SqlParameter("3","0"));

                command.ExecuteReader();
                conn.Close();
            }

        }

        public int getIdUser(string username)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = strConn;
                conn.Open();
                SqlCommand commanduser = new SqlCommand("SELECT id_user FROM Users WHERE username = @0", conn);
                commanduser.Parameters.Add(new SqlParameter("0", username));

                SqlDataReader readeruser = commanduser.ExecuteReader();
                readeruser.Read();

                int id = readeruser.GetInt32(0);

                readeruser.Close();
                conn.Close();
                return id;
            }
                

            
        }
    }
}