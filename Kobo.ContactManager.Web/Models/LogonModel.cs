using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kobo.ContactManager.Web.Models
{
    [Serializable]
    public class LogonModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}