using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConstructoraWPF.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _ConnectionString;
        public RepositoryBase()
        {
            _ConnectionString = Properties.Settings.Default.connString;
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_ConnectionString);
        }
    }
}
