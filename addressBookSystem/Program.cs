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
            repo.ObtainingDataFromDatabase();
        }
    }
}
