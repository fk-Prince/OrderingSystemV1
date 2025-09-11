using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace OrderingSystem.DatabaseConnection
{
    internal class DatabaseHandler
    {
        private static DatabaseHandler instance;
        private static readonly object lockObject = new object();
        private MySqlConnection conn;
        private SemaphoreSlim connectionSemaphore;
        private DatabaseHandler()
        {
            connectionSemaphore = new SemaphoreSlim(1, 1);
        }

        public static DatabaseHandler getInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseHandler();
                    }
                }
            }
            return instance;
        }
        public async Task<MySqlConnection> getConnection()
        {
            await connectionSemaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                if (conn == null)
                {

                    conn = new MySqlConnection(getConnectionString());
                }


                while (conn.State == ConnectionState.Connecting)
                {

                }


                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return conn;

        }
        public async Task closeConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                await conn.CloseAsync();
            }
            connectionSemaphore.Release();
        }
        private string getConnectionString()
        {
            return new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "root",
                Database = "mydb",
                SslMode = MySqlSslMode.None,
                AllowPublicKeyRetrieval = true,
                AllowUserVariables = true
            }.ConnectionString;
        }
    }
}
