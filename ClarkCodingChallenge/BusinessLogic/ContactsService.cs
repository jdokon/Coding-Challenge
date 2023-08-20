using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.BusinessLogic
{
    public class ContactsService
    {
        private readonly IContactsDataAccess _contactsDataAccess;

        public ContactsService(IContactsDataAccess contactsDataAccess)
        {
            _contactsDataAccess = contactsDataAccess;
        }

        public void SaveContact(Contact contact)
        {
            _contactsDataAccess.SaveContact(contact);
        }

        public IEnumerable<Contact> GetContacts(string lastName, bool? ascending)
        {
            var contacts = _contactsDataAccess.GetAllContacts();

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                contacts = contacts.Where(x => x.LastName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase));
            }

            contacts = ascending.HasValue && !ascending.Value
                ? contacts.OrderByDescending(u => u.LastName).ThenByDescending(u => u.FirstName)
                : contacts.OrderBy(u => u.LastName).ThenBy(u => u.FirstName);

            return contacts;
        }
    }
}
