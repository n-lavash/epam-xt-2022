using Epam.Auction.Common.Entites;
using Epam.Auction.DAL.Interfaces;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Epam.Auction.DAL.SqlDAL
{
    public class AuctionSqlDAO : IAuctionDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection;

        #region METHODS FOR LOTS
        public bool AddLot(Lot lot)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_AddLot";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Name", lot.Name);
                command.Parameters.AddWithValue("@Date_added", lot.DateAdded);
                command.Parameters.AddWithValue("@Price", lot.Price);
                command.Parameters.AddWithValue("@Description", lot.Description);

                _connection.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool DeleteLot(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.Auction_DeleteLot";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool EditLotWithAllParameters(Lot lot)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProcUser = "Auction_EditLot";

                var command = new SqlCommand(strProcUser, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", lot.Id);
                command.Parameters.AddWithValue("@Name", lot.Name);
                command.Parameters.AddWithValue("@Date_added", lot.DateAdded);
                command.Parameters.AddWithValue("@Price", lot.Price);
                command.Parameters.AddWithValue("@Description", lot.Description);

                _connection.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public Lot GetLot(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_GetLotById";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Lot(
                        id: Convert.ToInt32(reader["ID"]),
                        name: reader["Name"] as string,
                        dateAdded: Convert.ToDateTime(reader["Date_added"]),
                        price: Convert.ToDouble(reader["Price"]),
                        description: reader["Description"] as string);
                }
                throw new InvalidOperationException("Cannot find Lot whith ID = " + id);
            }
        }

        public IEnumerable<Lot> GetLots(string line)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_GetLotsByName";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@line", line);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Lot(
                        id: Convert.ToInt32(reader["ID"]),
                        name: reader["Name"] as string,
                        dateAdded: Convert.ToDateTime(reader["Date_added"]),
                        price: Convert.ToDouble(reader["Price"]),
                        description: reader["Description"] as string);
                }
            }
        }

        public IEnumerable<Lot> GetLots(double numberFrom, double numberTo)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_GetLotsByPrice";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@numberFrom", numberFrom);
                command.Parameters.AddWithValue("@numberTo", numberTo);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Lot(
                        id: Convert.ToInt32(reader["ID"]),
                        name: reader["Name"] as string,
                        dateAdded: Convert.ToDateTime(reader["Date_added"]),
                        price: Convert.ToDouble(reader["Price"]),
                        description: reader["Description"] as string);
                }
            }
        }

        public IEnumerable<Lot> GetLots(string dateFrom, string dateTo)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_GetLotsByDate";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@dateFrom", dateFrom);
                command.Parameters.AddWithValue("@dateTo", dateTo);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Lot(
                        id: Convert.ToInt32(reader["ID"]),
                        name: reader["Name"] as string,
                        dateAdded: Convert.ToDateTime(reader["Date_added"]),
                        price: Convert.ToDouble(reader["Price"]),
                        description: reader["Description"] as string);
                }
            }
        }

        public int GetLastIdForLot()
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "SELECT MAX(ID) FROM Lots";
                var command = new SqlCommand(strProc, _connection);

                _connection.Open();

                var result = command.ExecuteScalar();
                var id = Convert.ToInt32(result);

                return id;
            }
        }
        #endregion

        #region METHODS FOR USERS
        public bool AddUser(Account account)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_AddUser";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Birthdate", account.Birthdate);
                command.Parameters.AddWithValue("@Name", account.Name);
                command.Parameters.AddWithValue("@Registration_date", account.RegDate);
                command.Parameters.AddWithValue("@Email", account.Email);
                command.Parameters.AddWithValue("@Login", account.Login);
                command.Parameters.AddWithValue("@Password", account.Password);

                _connection.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool DeleteUser(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_DeleteUser";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool EditUserWithAllParameters(Account account)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProcUser = "Auction_EditUserWithAllParameters";

                var command = new SqlCommand(strProcUser, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", account.Id);
                command.Parameters.AddWithValue("@Birthdate", account.Birthdate);
                command.Parameters.AddWithValue("@Name", account.Name);
                command.Parameters.AddWithValue("@Registration_date", account.RegDate);
                command.Parameters.AddWithValue("@Email", account.Email);
                command.Parameters.AddWithValue("@Login", account.Login);
                command.Parameters.AddWithValue("@Password", account.Password);

                _connection.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool EditRoleInAccount(int id, string newRole)
        {
            if (newRole.Equals("user") || newRole.Equals("admin"))
            {
                using (_connection = new SqlConnection(_connectionString))
                {
                    var strProc = "Auction_EditRoleInAccount";
                    var command = new SqlCommand(strProc, _connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", newRole);

                    _connection.Open();
                    var result = command.ExecuteNonQuery();

                    return result > 0;
                }
            } throw new InvalidOperationException("Cannot find role with name " + newRole);
        }

        public Account GetAccount(int id)
        {
            var lots = GetUserLots(id);
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_GetUserWithAccountById";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Account(
                        id: Convert.ToInt32(reader["ID"]),
                        role: reader["Name"] as string,
                        birthdate: Convert.ToDateTime(reader["Birthdate"]),
                        name: reader["Name"] as string,
                        email: reader["Email"] as string,
                        login: reader["Login"] as string,
                        password: Convert.ToString(reader["Password"]),
                        regDate: Convert.ToDateTime(reader["Registration_date"]),
                        lots: lots);
                }
            }

            throw new InvalidOperationException("Cannot find Lot whith ID = " + id);
        }

        public User GetUser(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_GetUserById";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        id: Convert.ToInt32(reader["ID"]),
                        birthdate: Convert.ToDateTime(reader["Birthdate"]),
                        name: reader["Name"] as string,
                        regDate: Convert.ToDateTime(reader["Registration_date"]),
                        email: reader["Email"] as string);
                }

                throw new InvalidOperationException("Cannot find Lot whith ID = " + id);
            }
        }

        public IEnumerable<User> GetUsers(string line)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_GetUsersByName";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@line", line);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User(
                        id: (int)reader["ID"],
                        name: reader["Name"] as string,
                        birthdate: Convert.ToDateTime(reader["Birthdate"]),
                        email: reader["Email"] as string,
                        regDate: Convert.ToDateTime(reader["Registration_date"]));
                }
            }
        }

        public IEnumerable<User> GetUsers(string dateFrom, string dateTo)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_GetUsersByDate";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@dateFrom", dateFrom);
                command.Parameters.AddWithValue("@dateTo", dateTo);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User(
                        id: (int)reader["ID"],
                        name: reader["Name"] as string,
                        birthdate: Convert.ToDateTime(reader["Birthdate"]),
                        email: reader["Email"] as string,
                        regDate: Convert.ToDateTime(reader["Registration_date"]));
                }
            }
        }

        public IEnumerable<Lot> GetUserLots (int id)
        {
            var account = GetAccount(id);
            using (_connection = new SqlConnection(_connectionString))
            {
                if (account != null)
                {
                    var strProc = "Auction_GetUserLots";

                    var command = new SqlCommand(strProc, _connection) 
                    { 
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@ID", id);

                    _connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        yield return new Lot(
                            id: Convert.ToInt32(reader["ID"]),
                            name: reader["Name"] as string,
                            dateAdded: Convert.ToDateTime(reader["Date_added"]),
                            price: Convert.ToDouble(reader["Price"]),
                            description: reader["Description"] as string);
                    }
                }
            }
        }

        public int CheckAccount(string login, string password)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_CheckAccount";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Login", login);

                _connection.Open();

                var result = command.ExecuteScalar();

                return Convert.ToInt32(result);

            }
        }

        public int CheckRole(int id)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_CheckRole";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);

                _connection.Open();

                var result = command.ExecuteScalar();

                return Convert.ToInt32(result);

            }
        }

        public bool AddLotForUser(int userID, int lotID)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_AddLotForUser";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LotID", lotID);
                command.Parameters.AddWithValue("@UserID", userID);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;

            }
        }
        public bool DeleteLotForUser(int userID, int lotID)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "Auction_DeleteLotForUser";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@LotID", lotID);
                command.Parameters.AddWithValue("@UserID", userID);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;

            }
        }
        public int GetLastIdForUser()
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "SELECT MAX(ID) FROM Users";
                var command = new SqlCommand(strProc, _connection);

                _connection.Open();

                var result = command.ExecuteScalar();
                var id = Convert.ToInt32(result);

                return id;
            }
        }
        #endregion
    }
}