using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dao.Context
{
    public class CommonSqlcon
    {
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DsCarLoanSQLConnection"].ConnectionString);
            }
        }

    }
}
