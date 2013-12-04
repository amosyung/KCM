using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Kobo.ContactManager.DAO.Model;
using Kobo.ContactManager.Contract;
using Kobo.ContactManager.Contract.Service;
using Kobo.ContactManager.Contract.DataAccess;

namespace Kobo.ContactManager.DAO
{
    public class ContactDataAccess : IContactDataAccess
    {
        public IEnumerable<PersonDTO> GetContacts(IEnumerable<string> searchParameters, int startPosition, int contactsToReturn)
        {
            using (var context = new ContactManagerEntities())
            {
                //query is assembled dynamically.
                var customers = context.Customers.AsExpandable<Customer>().Where(GetCustomerQueryExpression(searchParameters)).ToList();
                var suppliers = context.Suppliers.AsExpandable<Supplier>().Where(GetSupplierQueryExpression(searchParameters)).ToList();

                List<PersonDTO> result = customers.Select(c => (PersonDTO)CreateCustomerDTOInstance(c.Person))
                    .Union(suppliers.Select(s => (PersonDTO)CreateSupplierDTOInstance(s.Person)))
                    .OrderBy(p => p.LastName)
                    .ThenBy(p => p.FirstName)
                    .ThenBy(p => p.Id)
                    .ToList();

                return result;
            }
        }

        /// <summary>
        /// Create expression for various predicate conditions.
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        protected virtual Expression<Func<Customer, bool>> GetCustomerQueryExpression(IEnumerable<string> searchParameters)
        {
            Expression<Func<Customer, bool>> result = c => true;
            foreach (string p in searchParameters.Where(pr => !string.IsNullOrEmpty(pr)))
            {
                int numericParameter;
                DateTime dateParameter;
                if (int.TryParse(p, out numericParameter))
                    result = result.And<Customer>(c => c.PersonId == numericParameter);

                else if (DateTime.TryParse(p, out dateParameter))
                {
                    var dtStart = dateParameter;
                    var dtEnd = dateParameter.AddDays(1);
                    result = result.And<Customer>(c => c.BirthDay.HasValue && c.BirthDay.Value >= dtStart && c.BirthDay.Value < dtEnd);  //fix the date range 
                }
                else
                {
                    result = result.And<Customer>(c =>
                        c.Person.FirstName.ToUpper().Contains(p.ToUpper()) ||
                        c.Person.LastName.ToUpper().Contains(p.ToUpper()) ||
                        (c.Email != null && c.Email.ToUpper().Contains(p.ToUpper()))
                        );
                }
            }
            return result;
        }

        protected virtual Expression<Func<Supplier, bool>> GetSupplierQueryExpression(IEnumerable<string> searchParameters)
        {
            Expression<Func<Supplier, bool>> result = s => true;
            foreach (string p in searchParameters.Where(pr => !string.IsNullOrEmpty(pr)))
            {
                int numericParameter;
                if (int.TryParse(p, out numericParameter))
                    result = result.And<Supplier>(s => s.Phone.Contains(p));
                else
                    result = result.And<Supplier>(s =>
                        s.Person.FirstName.ToUpper().Contains(p.ToUpper()) ||
                        s.Person.LastName.ToUpper().Contains(p.ToUpper())
                        );
            }
            return result;
        }

        public PersonDTO GetContact(int contactId)
        {
            PersonDTO result = null;
            using (var context = new ContactManagerEntities())
            {
                var person = context.People.FirstOrDefault(p => p.Id == contactId);
                if (person != null && person.Customer != null)
                    result = CreateCustomerDTOInstance(person);
                else if (person != null && person.Supplier != null)
                    result = CreateSupplierDTOInstance(person);
            }
            return result;
        }

        public void DeleteContact(int contactId)
        {
            using (var context = new ContactManagerEntities())
            {
                var person = context.People.FirstOrDefault(p => p.Id == contactId);
                if (person != null)
                {
                    if (person.Customer != null)
                        context.Customers.Remove(person.Customer);
                    if (person.Supplier != null)
                        context.Suppliers.Remove(person.Supplier);
                    context.People.Remove(person);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateCustomer(CustomerDTO contact)
        {
            using (var context = new ContactManagerEntities())
            {
                var customer = context.Customers.FirstOrDefault(p => p.PersonId == contact.Id);
                customer.Person.FirstName = contact.FirstName;
                customer.Person.LastName = contact.LastName;
                customer.BirthDay = contact.BirthDay;
                customer.Email = contact.Email;
                context.SaveChanges();
            }
        }

        public void UpdateSupplier(SupplierDTO contact)
        {
            using (var context = new ContactManagerEntities())
            {
                var supplier = context.Suppliers.FirstOrDefault(p => p.PersonId == contact.Id);
                supplier.Person.FirstName = contact.FirstName;
                supplier.Person.LastName = contact.LastName;
                supplier.Phone = contact.Phone;
                context.SaveChanges();
            }
        }

        public CustomerDTO AddCustomer(CustomerDTO contact)
        {
            using (var context = new ContactManagerEntities())
            {
                var person = context.People.Create();
                person.FirstName = contact.FirstName;
                person.LastName = contact.LastName;
                var customer = context.Customers.Create();
                //customer.Person = person;
                person.Customer = customer;
                customer.BirthDay = contact.BirthDay;
                customer.Email = contact.Email;
                context.People.Add(person);
                context.Customers.Add(customer);
                context.SaveChanges();
                contact.Id = person.Id;
            }
            return contact;
        }

        public SupplierDTO AddSupplier(SupplierDTO contact)
        {
            using (var context = new ContactManagerEntities())
            {
                var person = context.People.Create();
                person.FirstName = contact.FirstName;
                person.LastName = contact.LastName;
                context.People.Add(person);
                var supplier = context.Suppliers.Create();
                supplier.Person = person;
                supplier.Phone = contact.Phone;
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                contact.Id = person.Id;
            }
            return contact;
        }

        private CustomerDTO CreateCustomerDTOInstance(Person person)
        {
            var result = new CustomerDTO()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDay = person.Customer.BirthDay,
                Email = person.Customer.Email
            };
            return result;
        }

        private SupplierDTO CreateSupplierDTOInstance(Person person)
        {
            var result = new SupplierDTO()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Phone = person.Supplier.Phone
            };
            return result;
        }
    }
}
