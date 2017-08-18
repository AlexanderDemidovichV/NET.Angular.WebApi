using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
                new Contact { Id = 1, FirstName = "Adam", LastName = "White", DOB = new DateTime(1999, 12, 4), PhoneNumber = "2345567", Gender = 'm', Favorite = false, Relationship = "Home", Description = "about Adam" },
                new Contact { Id = 2, FirstName = "Eva", LastName = "Black", DOB = new DateTime(1994, 3, 6), PhoneNumber = "4535345", Gender = 'f', Favorite = false, Relationship = "Work", Description = "about Eva" },
                new Contact { Id = 3, FirstName = "Nick", LastName = "Green", DOB = new DateTime(1978, 3, 1), PhoneNumber = "6767545", Gender = 'm', Favorite = true, Relationship = "Home", Description = "about Nick" },
                new Contact { Id = 4, FirstName = "Chelsea", LastName = "House", DOB = new DateTime(1994, 6, 4), PhoneNumber = "1231232", Gender = 'f', Favorite = false, Relationship = "Other", Description = "about Chelsea" },
                new Contact { Id = 5, FirstName = "Fart", LastName = "Bart", DOB = new DateTime(1999, 12, 6), PhoneNumber = "4532343", Gender = 'm', Favorite = false, Relationship = "Other", Description = "about Bart" }
            };
            _instance.Value._nextId = 6;
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
            int index = Instance.contacts.FindIndex(c => c.Id == item.Id);
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
            Instance.contacts.RemoveAll(c => c.Id == id);
        }
    }
}