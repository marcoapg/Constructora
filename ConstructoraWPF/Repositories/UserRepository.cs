using ConstructoraWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraWPF.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        void IUserRepository.Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        bool IUserRepository.AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Usuario] where NombreUsuario=@NombreUsuario and [Contrasena]=@contrasena";
                command.Parameters.Add("@NombreUsuario", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@Contrasena", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        void IUserRepository.Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserModel> IUserRepository.GetByAll()
        {
            throw new NotImplementedException();
        }

        UserModel IUserRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        UserModel IUserRepository.GetByUsername(string nombreusuario)
        {
            UserModel user=null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Usuario] where NombreUsuario=@NombreUsuario";
                command.Parameters.Add("@NombreUsuario", SqlDbType.NVarChar).Value = nombreusuario;
                using (var reader= command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        user = new UserModel()
                        {
                            UsuarioID = Convert.ToInt32(reader[0]),
                            TrabajadorID = Convert.ToInt32(reader[1]),
                            NombreUsuario = reader[2].ToString(),
                            Contrasena = string.Empty,
                            Estado = Convert.ToBoolean(reader[4]),
                        };
                    }
                }
            }
            return user;
        }

        void IUserRepository.Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
