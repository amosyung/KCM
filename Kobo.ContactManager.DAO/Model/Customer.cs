//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kobo.ContactManager.DAO.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int PersonId { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string Email { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
