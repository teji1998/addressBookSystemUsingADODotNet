﻿using System;
using System.Collections.Generic;
using System.Text;

namespace addressBookSystem
{
    public class AddressBookModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string MobileNumber{ get; set; }
        public string EmailId { get; set; }
        public string AddressBookName { get; set; }
        public string Type { get; set; }
        public string PersonType { get; set; }
        public int PersonId { get; set; }
        public int BookId { get; set; }



    }
}
