using Api.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IUserService 
    {
        User GetUser();
    }

    [MyIntercept]
    public class UserService:IUserService
    {
        private IDbConnection dbConnection;

        public UserService(IDbConnection dbConnection) 
        {
            this.dbConnection = dbConnection;
        }
        public User GetUser()
        {
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select * from student;";
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                var s = "";
            }
            
            reader.Close();
            dbConnection.Close();

            return new User() { };
        }
    }
}
