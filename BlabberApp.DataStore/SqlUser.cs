using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public class SqlUser : IPlugin
    {
        MySqlConnection connection;
        public SqlUser()
        {
            //copied from SqlBlab
            connection = new MySqlConnection("server=142.93.114.73;database=aubsparrow;user=aubsparrow;password=letmein");
            try
            {
                connection.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.ToString());
            }
        }

        public void Close()
        {
            connection.Close();
        }

        public void Create(IDatum obj)
        {
            User user = (User)obj;
            try
            {
                DateTime now = DateTime.Now;
                string sql = "INSERT INTO Users (SysID, Email, RegistrationDTTM, LastLoginDTTM) VALUES ('"
                     + user.Id + "', '"
                     + user.Email + "', '"
                     + now.ToString("yyyy-MM-dd HH:mm:ss")
                     + "', '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable ReadAll()
        {
            try
            {
                string sqlSelectAll = "SELECT * FROM Users";
                MySqlDataAdapter adapterUser = new MySqlDataAdapter(sqlSelectAll, connection); 
                MySqlCommandBuilder commandUser = new MySqlCommandBuilder(adapterUser);
                DataSet setUsers = new DataSet();

                adapterUser.Fill(setUsers);

                ArrayList users = new ArrayList();

                foreach (DataRow row in setUsers.Tables[0].Rows)
                {
                    users.Add(convertRowToUesr(row));
                }

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
 
        public IDatum GetById(Guid Id)
        {
            try
            {
                string sqlSelectUser = "SELECT * FROM Users WHERE Users.SysID = '" + Id.ToString() + "'";
                MySqlDataAdapter adapterUser = new MySqlDataAdapter(sqlSelectUser, connection); 
                MySqlCommandBuilder commandUser = new MySqlCommandBuilder(adapterUser);
                DataSet setUsers = new DataSet();

                adapterUser.Fill(setUsers);
                User retrievedUser = convertRowToUesr(setUsers.Tables[0].Rows[0]);

                return retrievedUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }  

        public void Delete(IDatum obj)
        {
            try
            {
                User user = (User)obj;
                string Id = user.Id.ToString();
                string DeleteSQL = "DELETE FROM Users WHERE Users.SysID = '" + Id + "'";
                MySqlCommand DeleteCommand = new MySqlCommand(DeleteSQL, connection);
                DeleteCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.ToString());
            }
        }     

        private User convertRowToUesr(DataRow row)
        {
            User user = new User();
            user.Id = new Guid(row["SysID"].ToString());
            user.ChangeEmail(row["Email"].ToString());
            user.RegisterDTTM = (DateTime)row["RegistrationDTTM"];
            user.LastLoginDTTM = (DateTime)row["LastLoginDTTM"];

            return user;
        }
    }
}