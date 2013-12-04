using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Kobo.ContactManager.Contract.Service
{
    [ServiceContract]
    [ServiceKnownType(typeof(PersonDTO))]
    [ServiceKnownType(typeof(CustomerDTO))]
    [ServiceKnownType(typeof(SupplierDTO))]
    public interface IContactManagerService
    {
        [OperationContract]
        IEnumerable<PersonDTO> SearchForContacts(IEnumerable<string> searchParameter, int fromPosition, int recordsToReturn);

        [OperationContract]
        PersonDTO GetContact(int contactId);

        [OperationContract]
        ContactUpdateResponse AddContact(PersonDTO contact);

        [OperationContract]
        ContactUpdateResponse DeleteContact(int contactId);

        [OperationContract]
        ContactUpdateResponse UpdateContact(PersonDTO contact);

    }
}
