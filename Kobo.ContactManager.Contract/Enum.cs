using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.ContactManager.Contract
{
    public enum SearchByEnums
    {
        ByAny,
        ByFirstName,
        ByLastName
    }

    public enum OrderByEnums
    {
        ById,
        ByLastName,
        ByFirstName,
        ByDateOfBirth
    }

    public enum ContactValidationErrors
    {
        ContactNotFound,
        ContactTypeNotSupported,
        FirstNameRequired,
        FirstNameLengthMismatch,
        LastNameRequired,
        LastNameLengthMismatch,
        PhoneNumberRequired,
        PhoneNumberInvalid,
        InvalidEmail,
        BirthDateInvalid,
        BirthDateInTheFuture
    }
}
