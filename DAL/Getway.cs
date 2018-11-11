using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_ADO_CRUD.DAL
{
    public class Getway
    {

        string connectionString = "Data Source=DESKTOP-5IL5I4V;Initial Catalog=EmpDB;Integrated Security=True";

        public SqlConnection Connection { get; set; }

        public SqlCommand Command { get; set; }



        public Getway()
        {
            Connection = new SqlConnection(connectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }


    }
}
