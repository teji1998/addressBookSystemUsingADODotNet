using System;

namespace addressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem using ADO dotnet !!!");
            AddressBookModel model = new AddressBookModel();
            AddressBookRepository repo = new AddressBookRepository();
            bool i = true;
            while (i)
            {
                Console.WriteLine("1. Obtain full data");
                Console.WriteLine("2. To get full data by city or state");
                Console.WriteLine("3. To get data by city or state");
                Console.WriteLine("4. To get count of persons based on city or state");
                Console.WriteLine("5. To get names in alphabetical order when grouped by name");
                Console.WriteLine("6. To get count of persons by type");
                Console.WriteLine("7. Exit");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            repo.ObtainingDataFromDatabase();
                            break;
                        case 2:
                            Console.WriteLine("Enter city name : ");
                            model.City = Console.ReadLine();
                            Console.WriteLine("Enter state name : ");
                            model.State = Console.ReadLine();
                            repo.RetrieveDataByCityOrState(model);
                            break;
                        case 3:
                            Console.WriteLine("Enter city name : ");
                            model.City = Console.ReadLine();
                            Console.WriteLine("Enter state name : ");
                            model.State = Console.ReadLine();
                            repo.RetrievingDataBasedOnCityOrState(model);
                            break;
                        case 4:
                            Console.WriteLine("Enter city name : ");
                            model.City = Console.ReadLine();
                            Console.WriteLine("Enter state name : ");
                            model.State = Console.ReadLine();
                            repo.CountPersonsCityAndState(model);
                            break;
                        case 5:
                            Console.WriteLine("Enter city name : ");
                            model.City = Console.ReadLine();
                            repo.SortByName(model);
                            break;
                        case 6:
                            repo.CountByPersonType();
                            break;
                        case 7:
                            i = false;
                            break;
                        default:
                            Console.WriteLine("Choose valid option");
                            break;
                    }
                }
                catch (System.FormatException formatException)
                {
                    Console.WriteLine(formatException);
                }
            }
        }
        /*model.FirstName = "Bhagya";
        model.LastName = "Lakshmi";
        model.Address = "JPNagar";
        model.City = "Hyderabad";
        model.State = "Telangana";
        model.Zip = 580000;
        model.MobileNumber = "9903455467";
        model.EmailId = "bhagya1997@yahoo.com";
        model.AddressBookName = "B";
        model.Type = "Friend";*/
        //model.FirstName = "Varun";

        //repo.DeletePersonInDatabase(model);
        //repo.UpdateDataOfPersonInDatabase(model);
        //repo.AddingDataOfPersonIntoDatabase(model);
        //repo.ObtainingDataFromDatabase();
        // model.City = "Mumbai";
        //model.State = "Maharashtra";
        //repo.CountPersonsCityAndState(model);
        //repo.RetrevingDataBasedOnCityOrState(model);
        //repo.RetrieveDataByCityOrState(model);
        //repo.SortByName(model);
        //   model.PersonType = "Friend";
        // model.AddressBookName = "Friend_Address_Book";
        //repo.AddingAddressbookTypeAndBookNameIntoTable(model);
        /*model.PersonId = 17;
        model.BookId = 4;
        repo.AddPersonAndAddressBookData(model);*/
        //repo.CountByPersonType();
    }
}

