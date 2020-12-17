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
            model.FirstName = "Tejaswini";
            model.Address = "LottePark";
            //repo.UpdateDataOfPersonInDatabase(model);
            //repo.AddingDataOfPersonIntoDatabase(model);
            repo.ObtainingDataFromDatabase();
        }
    }
}
