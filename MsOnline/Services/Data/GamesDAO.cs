using MsOnline.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MsOnline.Services.Data
{
    public class GamesDAO
    {

        public bool saveGame(GameObject game)
        {

            bool success = false;
            String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            String queryString = "INSERT INTO dbo.games (gamestring, users_id) VALUES (@gamestring, @users_id)";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, conn))
                {
                    sqlCommand.Parameters.Add("@gamestring", SqlDbType.Text).Value = game.JSONstring;
                    sqlCommand.Parameters.Add("@users_id", SqlDbType.Int).Value = game.users_id;
                    try
                    {
                        conn.Open();

                        sqlCommand.ExecuteNonQuery();

                        conn.Close();
                        success = true;
                    } catch (Exception e)
                    {
                        Console.WriteLine("failure to insert game");
                        Debug.WriteLine(e.Message);
                    }
                }
            }
                return success;

        }

        public GameObject getGame(string uid)
        {
            GameObject game = new GameObject(1, "", Int32.Parse(uid));

            String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            String queryString = "SELECT TOP 1 * FROM dbo.games where users_id = " + uid + " ORDER BY ID DESC";

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
                            game.id = reader.GetInt32(0);
                            game.JSONstring = reader.GetString(1);
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
            return game;
        }

        public GameObject loadGame(int id)
        {
            GameObject game = new GameObject(1, "", id);

            String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            String queryString = "SELECT TOP 1 * FROM dbo.games where users_id = " + id + " ORDER BY ID DESC";

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
                            game.id = reader.GetInt32(0);
                            game.JSONstring = reader.GetString(1);
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
            return game;
        }
        public ArrayList getGames()
        {
            ArrayList games = new ArrayList();
            GameObject game = new GameObject(1, "", 0);

            String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            String queryString = "SELECT * FROM dbo.games";

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
                            game.id = reader.GetInt32(0);
                            game.JSONstring = reader.GetString(1);
                            game.users_id = reader.GetInt32(2);
                            games.Add(game);
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
            return games;
        }
    }
}