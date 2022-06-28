using Epam.Auction.Common.Entites;
using Epam.Auction.DAL.Interfaces;
using System.Data.SqlClient;

namespace Epam.Auction.DAL.SqlDAL
{
    public class AuctionSqlDAO: IAuctionDAO
    {
        // устанавливаем экзепляр чтобы соедениться с бд
        // private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private static string _connectionString = @"Data Source=DESKTOP-6GI50JS;Initial Catalog=Auction;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public bool addLot(Lot lot)
        {
            using (_connection)
            {
                var strProc = "dbo.Auction_AddLot";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Name_Lot", lot.name);
                command.Parameters.AddWithValue("@Date_added", lot.dateAdded);
                command.Parameters.AddWithValue("@Price", lot.price);
                command.Parameters.AddWithValue("@Description", lot.description);

                // DBNull.Value

                _connection.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool deleteLot(int id)
        {
            using (_connection)
            {
                var strProc = "dbo.Auction_GetById";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool editLot(Lot lot)
        {
            using (_connection)
            {
                var strProc = "dbo.Auction_EditLot";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", lot.id);
                command.Parameters.AddWithValue("@Name_Lot", lot.name);
                command.Parameters.AddWithValue("@Date_added", lot.dateAdded);
                command.Parameters.AddWithValue("@Price", lot.price);
                command.Parameters.AddWithValue("@Decription", lot.description);

                _connection.Open();
                var result = command.ExecuteNonQuery();

                return (result > 0);
            }
        }

        public Lot getLot(int id)
        {
                using (_connection)
                {
                    var strProc = "dbo.Auction_GetById";

                    var command = new SqlCommand(strProc, _connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@id", id);

                    _connection.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Lot(
                            id: (int)reader["Id_Lot"],
                            name: reader["Name_Lot"] as string,
                            dateAdded: (DateTime)reader["Date_added"],
                            price: (double)reader["Price"],
                            description: reader["Decription"] as string);
                    }

                    throw new InvalidOperationException("Cannot find Lot whith ID = " + id);
                }
        }

        public IEnumerable<Lot> getLots()
        {
            using (_connection)
            {
                var strProc = "Auction_GetLots";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Lot(
                        id: (int)reader["Id_Lot"],
                        name: reader["Name_Lot"] as string,
                        dateAdded: (DateTime)reader["Date_added"],
                        price: (double)reader["Price"],
                        description: reader["Decription"] as string);
                }
            }
        }
    }
}
