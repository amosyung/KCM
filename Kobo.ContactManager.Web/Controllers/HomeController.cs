using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kobo.ContactManager.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContacts()
        {
            ContactManagerService.ContactManagerServiceClient svc = new ContactManagerService.ContactManagerServiceClient();
            var r = svc.SearchForContacts(new string[] { },  0, 100);
            svc.Close();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SearchContacts(string searchText)
        {
            string[] searchKeys = searchText.Split(new char[] { ' ' });
            ContactManagerService.ContactManagerServiceClient svc = new ContactManagerService.ContactManagerServiceClient();
            var r = svc.SearchForContacts(searchKeys, 0, 100);
            svc.Close();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int contactId)
        {
            var contact = GetContact(contactId);
            if (contact == null)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["ContactToEdit"] = contact;
                if ((contact as ContactManagerService.CustomerDTO) != null)
                    return RedirectToAction("EditCustomer", new { id = contactId });
                else if ((contact as ContactManagerService.SupplierDTO) != null)
                    return RedirectToAction("EditSupplier", new { id = contactId });
                else
                    throw new InvalidOperationException("");
            }
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [HttpGet]
        public ActionResult GetCustomer(int id)
        {
            var contact = (ContactManagerService.CustomerDTO) GetContact(id);
            return Json(contact, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(ContactManagerService.CustomerDTO customer)
        {
            ContactManagerService.ContactManagerServiceClient svc = new ContactManagerService.ContactManagerServiceClient();
            var result = svc.UpdateContact(customer);
            return Json(result);
        }

        [HttpPost]
        public ActionResult AddCustomer(ContactManagerService.CustomerDTO customer)
        {
            ContactManagerService.ContactManagerServiceClient svc = new ContactManagerService.ContactManagerServiceClient();
            var result = svc.AddContact(customer);
            return Json(result);
        }

        [HttpPost]
        public ActionResult AddSupplier(ContactManagerService.SupplierDTO supplier)
        {
            ContactManagerService.ContactManagerServiceClient svc = new ContactManagerService.ContactManagerServiceClient();
            var result = svc.AddContact(supplier);
            return Json(result);
        }

        [HttpGet]
        public ActionResult EditSupplier(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [HttpGet]
        public ActionResult GetSupplier(int id)
        {
            var contact = (ContactManagerService.SupplierDTO)GetContact(id);
            return Json(contact, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateSupplier(ContactManagerService.SupplierDTO supplier)
        {
            ContactManagerService.ContactManagerServiceClient svc = new ContactManagerService.ContactManagerServiceClient();
            var result = svc.UpdateContact(supplier);
            return Json(result);
        }

        [HttpPost]
        public ActionResult DeleteContact(int contactId)
        {
            ContactManagerService.ContactManagerServiceClient svc = new ContactManagerService.ContactManagerServiceClient();
            var result = svc.DeleteContact(contactId);
            return Json(result);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return View();
        }

        private ContactManagerService.PersonDTO GetContact(int contactId)
        {
            ContactManagerService.ContactManagerServiceClient svc = new ContactManagerService.ContactManagerServiceClient();
            return svc.GetContact(contactId);
        }



    }
}
