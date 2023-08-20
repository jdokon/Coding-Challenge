using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess
{
    public interface IContactsDataAccess
    {
        void SaveContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
    }
}
