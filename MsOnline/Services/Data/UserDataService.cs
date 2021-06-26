using MsOnline.Models;
using MsOnline.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MsOnline.Services.Data
{
//Stanley Backlund & Jacob Hushaw
//26 January 2020
//CST-247
//This is my own code

    public class UserDataService
    {
        
        String connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=msonline;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int findByUser(User user)
        {
            msLogger.GetInstance().Info("Entering UserDataService.findByUser");
            int id = -1;
            String query = "Select * from dbo.users where username= @username and password = @password";
            using (SqlConnection connection = new SqlConnection(connect))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.password;
                
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            id = (int)reader["id"];


                        }
                    } else
                    {
                        id = -1;
                    }
                        reader.Close();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            msLogger.GetInstance().Info("Exiting UserDataService.findByUser");
            return id;
        }

        public User returnUser(int id)
        {
            msLogger.GetInstance().Info("Entering UserDataService.returnUser");
            User returned = new User();
            String query = "Select * from dbo.users where id = @ID";
            using (SqlConnection connection = new SqlConnection(connect))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@ID", System.Data.SqlDbType.Int, 50).Value = id;
                

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            returned.id = id;
                            returned.username = reader["username"].ToString();
                            returned.password = reader["password"].ToString();
                            returned.firstname = reader["firstname"].ToString();
                            returned.lastname = reader["lastname"].ToString();
                            returned.email = reader["email"].ToString();
                            returned.gender = reader["gender"].ToString();
                            returned.state = reader["state"].ToString();
                            returned.age = (int)reader["age"];

                        }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            msLogger.GetInstance().Info("Exiting UserDataService.returnUser");
            return returned;
        }
        public bool createUser(User user)
        {
            msLogger.GetInstance().Info("Entering UserDataService.createUser");
            bool success = false;
            String query = "INSERT INTO dbo.users (username,password,firstname,lastname,email,gender,state,age) VALUES (@USERNAME,@PASSWORD,@FIRSTNAME,@LASTNAME,@EMAIL,@GENDER,@STATE,@AGE)";
            using (SqlConnection connection = new SqlConnection(connect))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@USERNAME",user.username);
                command.Parameters.AddWithValue("@PASSWORD",user.password);
                command.Parameters.AddWithValue("@FIRSTNAME",user.firstname);
                command.Parameters.AddWithValue("@LASTNAME", user.lastname);
                command.Parameters.AddWithValue("@EMAIL", user.email);
                command.Parameters.AddWithValue("@GENDER", user.gender);
                command.Parameters.AddWithValue("@STATE", user.state);
                command.Parameters.AddWithValue("@AGE", user.age);
                
                
                    connection.Open();
                    int numrows = command.ExecuteNonQuery();
                    if (numrows == 1)
                        success = true;
                    connection.Close();
                
                
            }
            msLogger.GetInstance().Info("Exiting UserDataService.createUser");
            return success;
        }
    }
}