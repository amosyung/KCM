using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Kobo.ContactManager.Contract;

namespace Kobo.ContactManager.Contract.Service
{
    [DataContract]
    public class ContactUpdateResponse
    {
        [DataMember]
        public PersonDTO Contact { get; set; }

        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string[] Errors { get; set; }
    }
}
