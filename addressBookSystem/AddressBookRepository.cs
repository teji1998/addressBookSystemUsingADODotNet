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

        /// <summary>
        /// Obtaining data from database
        /// </summary>
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

        /// <summary>
        /// Adding details of person into address book table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddingDataOfPersonIntoDatabase(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddingData", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_Name", model.FirstName);
                    command.Parameters.AddWithValue("@Last_Name", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@Mobile_Number", model.MobileNumber);
                    command.Parameters.AddWithValue("@Email_Id", model.EmailId);
                    command.Parameters.AddWithValue("@Address_Book_Name", model.AddressBookName);
                    command.Parameters.AddWithValue("Type", model.Type);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (!result.Equals(0))
                    {
                        return true;
                    }
                    return false;
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

        /// <summary>
        /// To update person in database
        /// </summary>
        /// <param name="addressModel"></param>
        /// <returns></returns>
        public bool UpdateDataOfPersonInDatabase(AddressBookModel addressModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUpdatingPersonData", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_Name", addressModel.FirstName);
                    command.Parameters.AddWithValue("@Address", addressModel.Address);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// To delete a person's details
        /// </summary>
        /// <param name="addressModel"></param>
        /// <returns></returns>
        public bool DeletePersonInDatabase(AddressBookModel addressModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spDeletingPersonData", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@First_Name", addressModel.FirstName);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// To retrieve data and give full details
        /// </summary>
        /// <param name="model"></param>
        public void RetrieveDataByCityOrState(AddressBookModel model)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spRetrieveDataByCityOrState", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    this.connection.Open();
                    SqlDataReader read = command.ExecuteReader();
                    //command.ExecuteNonQuery();
                    if (read.HasRows)
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
                        Console.WriteLine("Data not found");
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

        /// <summary>
        /// Retrieving Data based on city or state
        /// </summary>
        /// <param name="model"></param>
        public void RetrievingDataBasedOnCityOrState(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
             
                    SqlCommand command = new SqlCommand("spRetrieveDataUsingCityOrState", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.FirstName = dataReader.GetString(0);
                            model.LastName = dataReader.GetString(1);
                            model.City = dataReader.GetString(2);
                            model.State = dataReader.GetString(3);
                            Console.WriteLine("FirstName : {0},\nLastName : {1},\nCity : {2},\nState : {3}",
                                 model.FirstName,model.LastName, model.City, model.State);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
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

        /// <summary>
        /// Counting persons on based on city or state
        /// </summary>
        /// <param name="addressModel"></param>
        public void CountPersonsCityAndState(AddressBookModel addressModel)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spCountByCityOrState", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", addressModel.City);
                    command.Parameters.AddWithValue("@State", addressModel.State);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //command.ExecuteNonQuery();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Count of state  " + addressModel.State + ": " + reader.GetInt32(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data not found");
                    }
                    reader.Close();
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

        /// <summary>
        /// Sorting the persons alphabetically
        /// </summary>
        /// <param name="model"></param>
        public void SortByName(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spSortByName", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", model.City);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.FirstName = dataReader.GetString(0);
                            model.LastName = dataReader.GetString(1);
                            model.City = dataReader.GetString(2);
                            Console.WriteLine("FirstName : {0},\nLastName : {1},\nCity : {2}",
                                 model.FirstName, model.LastName,model.City);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
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

        /// <summary>
        /// Added values of person type and addressbook name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddingAddressbookTypeAndBookNameIntoTable(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddressBookTypeInfo", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@person_Type", model.PersonType);
                    command.Parameters.AddWithValue("@address_book_name", model.AddressBookName);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("No of rows affected : " + result);
                    if (!result.Equals(0))
                    {
                        return true;
                    }
                    return false;
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

        /// <summary>
        /// Added Values for relation between person and addressbook
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddPersonAndAddressBookData(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spPersonDepartmentInfo", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Person_Id", model.PersonId);
                    command.Parameters.AddWithValue("@Book_Id", model.BookId);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("No of rows affected : " + result);
                    if (!result.Equals(0))
                    {
                        return true;
                    }
                    return false;
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
