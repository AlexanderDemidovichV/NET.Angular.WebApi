using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ContactApp.Services
{
    public sealed class ContactsService
    {
        private static readonly Lazy<ContactsService> _instance = new Lazy<ContactsService>(() => new ContactsService(), LazyThreadSafetyMode.PublicationOnly);

        private List<Contact> contacts;
        private int _nextId;

        ContactsService() { }

        static ContactsService()
        {
            _instance.Value.contacts = new List<Contact>
            {
                new Contact { Id = 1, FirstName = "Adam", LastName = "White", DOB = "01.02.1996", PhoneNumber = "2345567", Favorite = false, Relationship = "Home", Description = "about Adam" },
                new Contact { Id = 2, FirstName = "Eva", LastName = "Black", DOB = "05.01.1997", PhoneNumber = "4535345", Favorite = false, Relationship = "Work", Description = "about Eva" },
                new Contact { Id = 3, FirstName = "Nick", LastName = "Green", DOB = "07.04.1995", PhoneNumber = "6767545", Favorite = true, Relationship = "Home", Description = "about Nick" },
                new Contact { Id = 4, FirstName = "Chelsea", LastName = "House", DOB = "01.01.1998", PhoneNumber = "1231232", Favorite = false, Relationship = "Other", Description = "about Chelsea" }
            };
            _instance.Value._nextId = 5;
        }

        public static ContactsService Instance { get { return _instance.Value; } }

        public IQueryable<Contact> GetContacts()
        {
            return Instance.contacts.AsQueryable();
        }

        public int GetContactsCount()
        {
            return Instance.contacts.Count;
        }

        public Contact Add(Contact item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("newContact");
            }
            item.Id = _nextId++;
            Instance.contacts.Add(item);
            return item;
        }

        public bool Update(Contact item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("newContact");
            }
            int index = Instance.contacts.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            Instance.contacts.RemoveAt(index);
            Instance.contacts.Add(item);
            return true;
        }

        public void Remove(int id)
        {
            Instance.contacts.RemoveAll(p => p.Id == id);
        }
    }
}