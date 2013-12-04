using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kobo.ContactManager.Service;
using Kobo.ContactManager.Contract.Service;

namespace Kobo.ContactManager.UnitTest
{
    [TestClass]
    public class ValidationRuleTest
    {
        [TestMethod]
        public void ValidateContact_EmptyCustomer_ExpectErrorMessages()
        {
            ValidationRule v = new ValidationRule();
            var errMsgs = v.ValidateContact(new CustomerDTO()).ToList();
            Assert.IsTrue(errMsgs.Count() == 2);
            Assert.IsTrue(errMsgs.Contains(Contract.ContactValidationErrors.FirstNameRequired));
            Assert.IsTrue(errMsgs.Contains(Contract.ContactValidationErrors.LastNameRequired));
        }

        [TestMethod]
        public void ValidateContact_CustomerNameTooLong_ExpectErrorMessages()
        {
            ValidationRule v = new ValidationRule();
            CustomerDTO customer = new CustomerDTO()
            {
                FirstName = "ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ",
                LastName = "ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD ABCD "
            };
            var errMsgs = v.ValidateContact(customer).ToList();
            Assert.IsTrue(errMsgs.Count() == 2);
            Assert.IsTrue(errMsgs.Contains(Contract.ContactValidationErrors.FirstNameLengthMismatch));
            Assert.IsTrue(errMsgs.Contains(Contract.ContactValidationErrors.LastNameLengthMismatch));
        }

        [TestMethod]
        public void ValidateContact_EmptySupplier_ExpectErrorMessages()
        {
            ValidationRule v = new ValidationRule();
            var errMsgs = v.ValidateContact(new SupplierDTO()).ToList();
            Assert.IsTrue(errMsgs.Count() == 3);
            Assert.IsTrue(errMsgs.Contains(Contract.ContactValidationErrors.FirstNameRequired));
            Assert.IsTrue(errMsgs.Contains(Contract.ContactValidationErrors.LastNameRequired));
            Assert.IsTrue(errMsgs.Contains(Contract.ContactValidationErrors.PhoneNumberRequired));
        }

        [TestMethod]
        public void ValidateContact_SupplierInvalidPhone_ExpectErrorMessages()
        {
            ValidationRule v = new ValidationRule();
            var errMsgs = v.ValidateContact(new SupplierDTO() { Phone = "abc" }).ToList();
            Assert.IsTrue(errMsgs.Contains(Contract.ContactValidationErrors.PhoneNumberInvalid));
        }
    }
}
