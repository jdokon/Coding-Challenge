using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.Tests.BusinessLogicTests
{
    [TestClass]
    public class ContactsBusinessLogicTests
    {
        private IContactsDataAccess _contactsDataAccess;
        private ContactsService _contactsService;

        [TestInitialize]
        public void TestInitialize()
        {
            _contactsDataAccess = new InMemoryContactsDataAccess();
            _contactsService = new ContactsService(_contactsDataAccess);
        }

        [TestMethod]
        public void GetContacts()
        {
            var sampleContacts = new List<Contact>
            {
                new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com" },
                new Contact { FirstName = "Jane", LastName = "Doe", Email = "mary.doe@gmail.com" },
                new Contact { FirstName = "John", LastName = "Smith", Email = "john.smith@gmail.com" }
            };

            _contactsService.SaveContact(sampleContacts[0]);
            _contactsService.SaveContact(sampleContacts[1]);
            _contactsService.SaveContact(sampleContacts[2]);

            var returnedContacts = _contactsService.GetContacts("Doe", false).ToList();

            Assert.AreEqual(2, returnedContacts.Count);
        }
    }
}
