using Microsoft.Extensions.Options;
using Myapp.Data;
using Myapp.DataADO.Models;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Myapp.DataADO
{
    public class UserRepository : IUserRepository
    {
        #region Private Members

        private readonly string _connection;

        #endregion

        #region Ctor

        public UserRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        #endregion

        #region Methods

        public async Task<User> GetByUserNamePass(string userName, string password)
        {
            string selectQuery = "select * from [user] where userName = @userName and password = @password";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("userName", userName);
                command.Parameters.AddWithValue("password", password);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                User user = null;

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        UserName = reader.GetString(3),
                        Password = reader.GetString(4),
                        Email = reader.GetString(5)
                    };
                }
                reader.Close();

                return user;
            }
        }

        public Task<User> GetByUserPass(string userName, string password)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
