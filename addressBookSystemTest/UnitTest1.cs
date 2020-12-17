using addressBookSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressBookSystemTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookModel model = new AddressBookModel();
        AddressBookRepository repo = new AddressBookRepository();

        /// <summary>
        /// Given the details when added into address book table should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedIntoAddressBookTable_ShouldReturnTrue()
        {
            model.FirstName = "Sravani";
            model.LastName = "Sabbisetti";
            model.Address = "WDNagar";
            model.City = "Hyderabad";
            model.State = "Telangana";
            model.Zip = 580002;
            model.MobileNumber = "9789334089";
            model.EmailId = "sravani_123@gmail.com";
            model.AddressBookName = "A";
            model.Type = "Friend";
            bool result = repo.AddingDataOfPersonIntoDatabase(model);
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Given the details when updated in address book table should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenUpdatedInAddressBookTable_ShouldReturnTrue()
        {
            model.FirstName = "Lee";
            model.Address = "Gangwon";
            bool result = repo.UpdateDataOfPersonInDatabase(model);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Given the first name when contact is deleted using it in address book table should return true.
        /// </summary>
        [TestMethod]
        public void givenFirstName_WhenContactIsDeletedInAddressBookTable_ShouldReturnTrue()
        {
            model.FirstName = "Roopa";
            bool result = repo.DeletePersonInDatabase(model);
            Assert.IsTrue(result);
        }
    }
}
