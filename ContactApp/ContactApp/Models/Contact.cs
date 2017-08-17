using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactApp.Models
{
    public class Contact: ICloneable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public bool Favorite { get; set; }
        public bool SelectedToDelete { get; set; }
        public string Relationship { get; set; }
        public string Description { get; set; }

        public object Clone()
        {
            return new Contact()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                DOB = this.DOB,
                PhoneNumber = this.PhoneNumber,
                Favorite = this.Favorite,
                SelectedToDelete = this.SelectedToDelete,
                Relationship = this.Relationship,
                Description = this.Description
            };
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Contact);
        }

        public bool Equals(Contact contact)
        {
            if((contact.Id == this.Id) && (contact.FirstName == this.FirstName) && (contact.LastName == this.LastName) 
                && (contact.Favorite == this.Favorite) && (contact.Favorite == this.Favorite) &&
                (contact.PhoneNumber == this.PhoneNumber) && (contact.Relationship == this.Relationship) && (contact.Favorite == this.Favorite) &&
                (contact.DOB == this.DOB) && (contact.Description == this.Description))
            {
                return true;
            }
            return false;
        }
    }
}