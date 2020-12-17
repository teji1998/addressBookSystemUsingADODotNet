using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace addressBookSystem
{
    public class AddressBookRepository
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void ObtainingDataFromDatabase()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spObtainingData", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader read = command.ExecuteReader();
                    if(read.HasRows)
                    {
                        while (read.Read())
                        {
                            model.Id = read.GetInt32(0);
                            model.FirstName = read.GetString(1);
                            model.LastName = read.GetString(2);
                            model.Address = read.GetString(3);
                            model.City = read.GetString(4);
                            model.State = read.GetString(5);
                            model.Zip = read.GetInt32(6);
                            model.MobileNumber = read.GetString(7);
                            model.EmailId = read.GetString(8);
                            model.AddressBookName = read.GetString(9);
                            model.Type = read.GetString(10);
                            Console.WriteLine("Id: {0}\nFirstName: {1}\nLastName: {2}\nAddress: {3}\nCity: {4}\nState: {5}\nZip: {6}\nMobileNumber: {7}\nEmailId: {8}\n" +
                                "AddressBookName: {9},\nType: {10}", model.Id, model.FirstName, model.LastName, model.Address, model.City, model.State, model.Zip, model.MobileNumber,
                                model.EmailId, model.AddressBookName, model.Type);
                            Console.WriteLine("\n");

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    read.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
