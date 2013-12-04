using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobo.ContactManager.Contract.Service;
namespace Kobo.ContactManager.Contract.DataAccess
{
    public interface IContactDataAccess
    {
        IEnumerable<PersonDTO> GetContacts(IEnumerable<string> searchParameters, int startPosition, int contactsToReturn);

        PersonDTO GetContact(int contactId);

        void DeleteContact(int contactId);

        void UpdateCustomer(CustomerDTO contact);

        void UpdateSupplier(SupplierDTO contact);

        CustomerDTO AddCustomer(CustomerDTO contact);

        SupplierDTO AddSupplier(SupplierDTO contact);
    }
}
