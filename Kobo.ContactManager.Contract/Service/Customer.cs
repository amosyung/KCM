using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Kobo.ContactManager.Contract.Service
{
    [DataContract]
    public class CustomerDTO: PersonDTO
    {
        [DataMember]
        public DateTime? BirthDay { get; set; }

        [DataMember]        
        public string Email { get; set; }
    }
}
