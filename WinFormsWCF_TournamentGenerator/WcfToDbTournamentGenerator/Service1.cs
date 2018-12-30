using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfToDbTournamentGenerator
{
    public class Service1 : IService1
    {
        
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        SqlConnectionStringBuilder sqlConnStringBuilder;

        public Service1()
        {
            ConnectToDb();
        }

        #region CONNECTION TO DATABASE
        void ConnectToDb()
        {
            sqlConnStringBuilder = new SqlConnectionStringBuilder();
            sqlConnStringBuilder.DataSource = "DESKTOP-NKTLH0P";
            sqlConnStringBuilder.InitialCatalog = "WCF_TournamentGenerator";
            sqlConnStringBuilder.Encrypt = true;
            sqlConnStringBuilder.TrustServerCertificate = true;
            sqlConnStringBuilder.ConnectTimeout = 50;
            sqlConnStringBuilder.AsynchronousProcessing = true;
            sqlConnStringBuilder.MultipleActiveResultSets = true;
            sqlConnStringBuilder.IntegratedSecurity = true;

            sqlConnection = new SqlConnection(sqlConnStringBuilder.ToString());
            sqlCommand = sqlConnection.CreateCommand();
        }

        #endregion

        #region CREATE PLAYER

        public int CreatePlayer(Player player)
        {
            try
            {
                sqlCommand.CommandText = "INSERT INTO T_Players VALUES(@FirstName, @LastName, @Age, @Speed, @Strength, @Skill)";
                //sqlCommand.Parameters.AddWithValue("Id", player.Id);
                sqlCommand.Parameters.AddWithValue("FirstName", player.FirstName);
                sqlCommand.Parameters.AddWithValue("LastName", player.LastName);
                sqlCommand.Parameters.AddWithValue("Age", player.Age);
                sqlCommand.Parameters.AddWithValue("Speed", player.Speed);
                sqlCommand.Parameters.AddWithValue("Strength", player.Strength);
                sqlCommand.Parameters.AddWithValue("Skill", player.Skill);

                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        #endregion

        #region UPDATE PLAYER

        public int UpdatePlayer(Player player)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE T_Players SET FirstName=@FirstName, Age=@Age, Speed=@Speed, Strength=@Strength, Skill=@Skill WHERE Id=@Id";
                sqlCommand.Parameters.AddWithValue("@Id", player.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", player.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", player.LastName);
                sqlCommand.Parameters.AddWithValue("@Age", player.Age);
                sqlCommand.Parameters.AddWithValue("@Speed", player.Speed);
                sqlCommand.Parameters.AddWithValue("@Strength", player.Strength);
                sqlCommand.Parameters.AddWithValue("@Skill", player.Skill);

                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        #endregion

        #region DELETE PLAYER

        public int DeletePlayer(Player player)
        {
            try
            {
                sqlCommand.CommandText = "DELETE T_Players WHERE Id=@Id";
                sqlCommand.Parameters.AddWithValue("Id", player.Id);     

                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        #endregion

        #region GET 1 PLAYER

        public Player GetPlayer(Player player)
        {
            Player p = new Player();
            try
            {
                sqlCommand.CommandText = "SELECT * FROM T_Players WHERE Id=@Id";
                sqlCommand.Parameters.AddWithValue("Id", player.Id);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    p.Id = Convert.ToInt32(reader[0]);
                    p.FirstName = Convert.ToString(reader[1]);
                    p.LastName = Convert.ToString(reader[2]);
                    p.Age = Convert.ToInt32(reader[3]);
                    p.Speed = Convert.ToInt32(reader[4]);
                    p.Strength = Convert.ToInt32(reader[5]);
                    p.Skill = Convert.ToInt32(reader[6]);
                }
                return p;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        #endregion

        #region GET ALL PLAYERS

        public List<Player> GetAllPlayers()
        {
            List<Player> playerList = new List<Player>();
            try
            {
                sqlCommand.CommandText = "SELECT * FROM T_Players";
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Player p = new Player()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        FirstName = Convert.ToString(reader[1]),
                        LastName = Convert.ToString(reader[2]),
                        Age = Convert.ToInt32(reader[3]),
                        Speed = Convert.ToInt32(reader[4]),
                        Strength = Convert.ToInt32(reader[5]),
                        Skill = Convert.ToInt32(reader[6])
                    };

                    playerList.Add(p);
                }
                    
                return playerList;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        #endregion

    }
}
