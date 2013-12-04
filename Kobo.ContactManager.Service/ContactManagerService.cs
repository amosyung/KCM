using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Kobo.ContactManager.Contract;
using Kobo.ContactManager.Contract.Service;
using Kobo.ContactManager.Contract.DataAccess;
using Kobo.ContactManager.Contract.Validation;

namespace Kobo.ContactManager.Service
{
    public class ContactManagerService:IContactManagerService
    {
        public IEnumerable<PersonDTO> SearchForContacts(IEnumerable<string> searchParameter, int fromPosition, int recordsToReturn )
        {
            return ContactDAO.GetContacts(searchParameter, fromPosition, recordsToReturn);
        }

        public PersonDTO GetContact(int contactId)
        {
            return ContactDAO.GetContact(contactId);
        }

        public ContactUpdateResponse AddContact(PersonDTO contact)
        {
            var errors = ValidationRule.ValidateContact(contact);
            if (errors.Count() != 0)
                return CreateErrorResponse(errors);

            Action updateAction = null;

            if (contact is CustomerDTO)
                updateAction = () => ContactDAO.AddCustomer(contact as CustomerDTO);
            else if (contact is SupplierDTO)
                updateAction = () => ContactDAO.AddSupplier(contact as SupplierDTO);
            RunInTransaction(updateAction);
            return CreateSuccessResponse(contact);
        }

        public ContactUpdateResponse DeleteContact(int contactId)
        {
            var contact = ContactDAO.GetContact(contactId);
            if (contact != null)
                RunInTransaction(() => ContactDAO.DeleteContact(contactId));
            return CreateSuccessResponse(contact);
        }


        public ContactUpdateResponse UpdateContact(PersonDTO contact)
        {
            var errors = ValidationRule.ValidateContact(contact);
            if (errors.Count() != 0)
                return CreateErrorResponse(errors); 
            
            var person = ContactDAO.GetContact(contact.Id);
            Action updateAction = null;
            if (person is CustomerDTO && contact is CustomerDTO)
                updateAction = () => ContactDAO.UpdateCustomer(contact as CustomerDTO);
            else if (person is SupplierDTO && contact is SupplierDTO)
                updateAction = () => ContactDAO.UpdateSupplier(contact as SupplierDTO);

            RunInTransaction(updateAction);
            return CreateSuccessResponse(contact);
        }

        /// <summary>
        /// Container to run transaction
        /// </summary>
        /// <param name="action"></param>
        private void RunInTransaction(Action action)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                action();
                transaction.Complete();
            }
        }

        private ContactUpdateResponse CreateErrorResponse(IEnumerable<ContactValidationErrors> errors)
        {
            return new ContactUpdateResponse()
            {
                Contact = null,
                IsSuccess = false,
                Errors = errors.Select(e => e.ToString()).ToArray()
            };
        }

        private ContactUpdateResponse CreateSuccessResponse(PersonDTO contact)
        {
            return new ContactUpdateResponse()
            {
                Contact = contact,
                IsSuccess = true,
                Errors = new string[]{}
            };
        }

        /// <summary>
        /// Externalized validation rules. To be injected through spring.net        
        /// </summary>
        private IValidationRule _validationRule;
        public IValidationRule ValidationRule
        {
            get
            {
                if (_validationRule == null)
                    throw new NullReferenceException("Validation rule has not been set");
                return _validationRule;
            }
            set { _validationRule = value; }
        }

        /// <summary>
        /// Externalized data access layer. To be injected through spring.net
        /// </summary>
        private IContactDataAccess _contactDAO;
        public IContactDataAccess ContactDAO
        {
            get
            {
                if (_contactDAO == null)
                    throw new NullReferenceException("Contact DAO has not been set");
                return _contactDAO;
            }
            set { _contactDAO = value; }
        }

    }
}
