using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Kobo.ContactManager.Contract.Service;
using Spring.Core;
using Spring.Context;
using Spring.Context.Support;

namespace Kobo.ContactManager.ServiceHost
{
    public class ContactManagerFacade : IContactManagerService
    {

        public IEnumerable<PersonDTO> SearchForContacts(IEnumerable<string> searchParameter, int fromPosition, int recordsToReturn)
        {
            return ContactManager.SearchForContacts(searchParameter, fromPosition, recordsToReturn);
        }

        public PersonDTO GetContact(int contactId)
        {
            return ContactManager.GetContact(contactId);
        }

        public ContactUpdateResponse AddContact(PersonDTO contact)
        {
            return ContactManager.AddContact(contact);
        }

        public ContactUpdateResponse DeleteContact(int contactId)
        {
            return ContactManager.DeleteContact(contactId);
        }

        public ContactUpdateResponse UpdateContact(PersonDTO contact)
        {
            return ContactManager.UpdateContact(contact);
        }

        private IContactManagerService ContactManager
        {
            get
            {
                IApplicationContext context = ContextRegistry.GetContext();
                IContactManagerService mgr = context.GetObject("ContactManager") as IContactManagerService;
                return mgr;
            }
        }


    }
}