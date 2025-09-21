using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.DatabaseConnection;

namespace OrderingSystem.Repository.Coupon
{
    public class CouponRepository : ICouponRepository
    {
        public async Task<Model.CouponModel> getCoupon(string code)
        {
            var db = DatabaseHandler.getInstance();

            try
            {
                var conn = await db.getConnection();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Coupon WHERE coupon_code = @coupon_code LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@coupon_code", code);
                MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    return new Model.CouponModel(
                        reader.GetString("coupon_code"),
                        reader.GetString("status"),
                        reader.GetDouble("rate"),
                        reader.GetDateTime("expiry_Date")
                       );
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await db.closeConnection();
            }

            return null;
        }


    }
}
