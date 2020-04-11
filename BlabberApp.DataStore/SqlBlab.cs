using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public class SqlBlab : IBlabPlugin
    {
        private MySqlConnection connection;

        public SqlBlab()
        {
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

        public void close()
        {
            connection.Close();
        }

        public void Create(IDatum obj)
        {
            Blab blab = (Blab) obj;
            try
            {
                DateTime DTTMNow = DateTime.Now;
                string sql = "INSERT INTO Blab (SysID, Message, CreatedDTTM, UserID) VALUES'"
                    + blab.Id + "', '" 
                    + blab.Message + "', '"
                    + DTTMNow.ToString("yyyy-MM-dd HH:mm:ss") + "', '"
                    + blab.user.Email + "')";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception (ex.ToString());
            }
        }

        public IDatum GetById(Guid Id)
        {
            try
            {
                string sql = "SELECT * FROM Blab Where Blab.SysID = '" + Id.ToString() + "'";
                MySqlDataAdapter adapterBlab = new MySqlDataAdapter(sql, connection);
                MySqlCommandBuilder command = new MySqlCommandBuilder(adapterBlab);
                DataSet BlabSet = new DataSet();

                adapterBlab.Fill(BlabSet);
                ArrayList BlabList = new ArrayList();
                
                foreach(DataRow row in BlabSet.Tables[0].Rows)
                {
                    BlabList.Add(row);
                }
                return (IDatum)BlabList; 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception (ex.ToString());
            }
        } 

        public IEnumerable ReadAll()
        {
            string sqlSElect = "SELECT * FROM Blab";
            MySqlDataAdapter adapterBlabs = new MySqlDataAdapter(sqlSElect, this.connection);
            MySqlCommandBuilder commandBlabs = new MySqlCommandBuilder(adapterBlabs);
            DataSet BlabSet = new DataSet();

            adapterBlabs.Fill(BlabSet);

            ArrayList listBlabs = new ArrayList();

            foreach(DataRow row in BlabSet.Tables[0].Rows)
            {
                listBlabs.Add(row);
            }
            return listBlabs;
        }
        
        public IEnumerable ReadByUserId(string email)
        {
            string sqlGetUserBlabs = "SELECT * FROM Blab Where Blab.UserID = '" + email.ToString() + "'";
            MySqlDataAdapter adapterBlabs = new MySqlDataAdapter(sqlGetUserBlabs, this.connection);
            MySqlCommandBuilder commandBlabs = new MySqlCommandBuilder(adapterBlabs);
            DataSet BlabSet = new DataSet();

            adapterBlabs.Fill(BlabSet);

            ArrayList listBlabs = new ArrayList();

            foreach(DataRow row in BlabSet.Tables[0].Rows)
            {
                listBlabs.Add(row);
            }
            return listBlabs;
        }

        public void Update(IDatum obj)
        {
            return;
        }

        public void Delete(IDatum obj)
        {
            return;
        }


    }
}