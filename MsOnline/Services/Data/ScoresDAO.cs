using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MsOnline.Models;

namespace MsOnline.Services.Data
{
    public class ScoresDAO
    {

        public bool saveScore(Score score)
        {

            bool success = false;
            String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            String queryString = "INSERT INTO dbo.scores (time, clicks, username, user_id) VALUES (@time, @clicks, @username, @user_id)";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, conn))
                {
                    sqlCommand.Parameters.Add("@time", System.Data.SqlDbType.VarChar).Value = score.time;
                    sqlCommand.Parameters.Add("@clicks", System.Data.SqlDbType.Int).Value = score.clicks;
                    sqlCommand.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = score.username;
                    sqlCommand.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Value = score.user_id;
                    
                    try
                    {
                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        conn.Close();
                        success = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("failure to insert game");
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            return success;

        }
        

        internal List<Score> getUserScores(int id)
        {
            List<Score> scores = new List<Score>();
            String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String queryString = "SELECT * FROM dbo.scores WHERE user_id = '" + id + "'";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();


                        while (reader.Read())
                        {
                            Score scor = new Score(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4));
                            scores.Add(scor);
                        }


                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("failure to select game");
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            return scores;
        }

        public List<Score> getScores()
        {
            List<Score> scores = new List<Score>();
            String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String queryString = "SELECT * FROM dbo.scores";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();


                        while (reader.Read())
                        {
                            Score scor = new Score(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4));
                            scores.Add(scor);
                        }


                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("failure to select game");
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            return scores;

        }

        public Score getScore(string uid)
        {
            Score scor = new Score(0,"",0,"",0);
            String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String queryString = "SELECT TOP 1 * FROM dbo.scores where users_id = " + uid + " ORDER BY ID DESC";
            
            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = sqlCommand.ExecuteReader();


                        while (reader.Read())
                        {
                           
                            scor.id = reader.GetInt32(0); ;
                            scor.time = reader.GetString(1);
                            scor.clicks = reader.GetInt32(2);
                            scor.username = reader.GetString(3);
                            scor.user_id = reader.GetInt32(4);
                        }


                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("failure to select game");
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            return scor;

        }
    }
}