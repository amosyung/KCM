using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobo.ContactManager.Contract;
using Kobo.ContactManager.Contract.Service;
using Kobo.ContactManager.Contract.Validation;
using Spring.Core;
using Spring.Context;
using Spring.Context.Support;
using Spring.Validation;

namespace Kobo.ContactManager.Service
{
    public class ValidationRule:IValidationRule
    { 
        public IEnumerable<ContactValidationErrors> ValidateContact(PersonDTO contact)
        { 
            if (contact is CustomerDTO)
                return Validate(contact as CustomerDTO);
            else if (contact is SupplierDTO)
                return Validate(contact as SupplierDTO);
            else
                throw new TypeMismatchException();
        }



        private IEnumerable<ContactValidationErrors> Validate(CustomerDTO customer)
        {
            return Validate(customer, CustomerValidator);
        }

        private IEnumerable<ContactValidationErrors> Validate(SupplierDTO supplier)
        {
            return Validate(supplier, SupplierValidator);
        }

        private IEnumerable<ContactValidationErrors> Validate(PersonDTO person, IValidator validator)
        {
            IValidationErrors validationErrors = new ValidationErrors();
            PersonValidator.Validate(person, validationErrors);
            validator.Validate(person, validationErrors);
            List<string> errorIds = new List<string>();
            foreach (string provider in validationErrors.Providers)
                foreach (ErrorMessage errMsg in validationErrors.GetErrors(provider))
                    errorIds.Add(errMsg.Id);
            foreach (string errorId in errorIds)
                yield return (ContactValidationErrors)Enum.Parse(typeof(ContactValidationErrors), errorId);
        }

        

        private static IValidator _personValidator;
        private static IValidator _customerValidator;
        private static IValidator _supplierValidator;
        private IValidator PersonValidator { get { return GetValidator(ref _personValidator, "PersonValidator"); } }
        private IValidator CustomerValidator { get { return GetValidator(ref _customerValidator, "CustomerValidator"); } }
        private IValidator SupplierValidator { get { return GetValidator(ref _supplierValidator, "SupplierValidator"); } }

        private IValidator GetValidator(ref IValidator validator, string validatorKey)
        {
            if (validator == null)
            {
                IApplicationContext context = ContextRegistry.GetContext();
                validator = context.GetObject(validatorKey) as IValidator;
            }
            return validator;
        }


    }
}
