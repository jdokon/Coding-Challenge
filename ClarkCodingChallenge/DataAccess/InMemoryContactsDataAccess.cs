using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess
{
    public class InMemoryContactsDataAccess : IContactsDataAccess
    {
        private readonly List<Contact> _contacts = new List<Contact>();

        public void SaveContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }
    }
}
