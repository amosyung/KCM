using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobo.ContactManager.Contract.Service;

namespace Kobo.ContactManager.Contract.Validation
{
    public interface IValidationRule
    {
        IEnumerable<ContactValidationErrors> ValidateContact(PersonDTO contact);
    }
}
