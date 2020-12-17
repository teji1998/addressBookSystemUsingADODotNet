using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace addressBookSystem
{
    public class AddressBookRepository
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
    }
}
