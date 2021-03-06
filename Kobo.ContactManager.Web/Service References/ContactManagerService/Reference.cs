﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kobo.ContactManager.Web.ContactManagerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonDTO", Namespace="http://schemas.datacontract.org/2004/07/Kobo.ContactManager.Contract.Service")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Kobo.ContactManager.Web.ContactManagerService.CustomerDTO))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Kobo.ContactManager.Web.ContactManagerService.SupplierDTO))]
    public partial class PersonDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CustomerDTO", Namespace="http://schemas.datacontract.org/2004/07/Kobo.ContactManager.Contract.Service")]
    [System.SerializableAttribute()]
    public partial class CustomerDTO : Kobo.ContactManager.Web.ContactManagerService.PersonDTO {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> BirthDayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> BirthDay {
            get {
                return this.BirthDayField;
            }
            set {
                if ((this.BirthDayField.Equals(value) != true)) {
                    this.BirthDayField = value;
                    this.RaisePropertyChanged("BirthDay");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SupplierDTO", Namespace="http://schemas.datacontract.org/2004/07/Kobo.ContactManager.Contract.Service")]
    [System.SerializableAttribute()]
    public partial class SupplierDTO : Kobo.ContactManager.Web.ContactManagerService.PersonDTO {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ContactUpdateResponse", Namespace="http://schemas.datacontract.org/2004/07/Kobo.ContactManager.Contract.Service")]
    [System.SerializableAttribute()]
    public partial class ContactUpdateResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Kobo.ContactManager.Web.ContactManagerService.PersonDTO ContactField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ErrorsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Kobo.ContactManager.Web.ContactManagerService.PersonDTO Contact {
            get {
                return this.ContactField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactField, value) != true)) {
                    this.ContactField = value;
                    this.RaisePropertyChanged("Contact");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Errors {
            get {
                return this.ErrorsField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorsField, value) != true)) {
                    this.ErrorsField = value;
                    this.RaisePropertyChanged("Errors");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccess {
            get {
                return this.IsSuccessField;
            }
            set {
                if ((this.IsSuccessField.Equals(value) != true)) {
                    this.IsSuccessField = value;
                    this.RaisePropertyChanged("IsSuccess");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ContactManagerService.IContactManagerService")]
    public interface IContactManagerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/SearchForContacts", ReplyAction="http://tempuri.org/IContactManagerService/SearchForContactsResponse")]
        Kobo.ContactManager.Web.ContactManagerService.PersonDTO[] SearchForContacts(string[] searchParameter, int fromPosition, int recordsToReturn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/SearchForContacts", ReplyAction="http://tempuri.org/IContactManagerService/SearchForContactsResponse")]
        System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.PersonDTO[]> SearchForContactsAsync(string[] searchParameter, int fromPosition, int recordsToReturn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/GetContact", ReplyAction="http://tempuri.org/IContactManagerService/GetContactResponse")]
        Kobo.ContactManager.Web.ContactManagerService.PersonDTO GetContact(int contactId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/GetContact", ReplyAction="http://tempuri.org/IContactManagerService/GetContactResponse")]
        System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.PersonDTO> GetContactAsync(int contactId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/AddContact", ReplyAction="http://tempuri.org/IContactManagerService/AddContactResponse")]
        Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse AddContact(Kobo.ContactManager.Web.ContactManagerService.PersonDTO contact);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/AddContact", ReplyAction="http://tempuri.org/IContactManagerService/AddContactResponse")]
        System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse> AddContactAsync(Kobo.ContactManager.Web.ContactManagerService.PersonDTO contact);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/DeleteContact", ReplyAction="http://tempuri.org/IContactManagerService/DeleteContactResponse")]
        Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse DeleteContact(int contactId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/DeleteContact", ReplyAction="http://tempuri.org/IContactManagerService/DeleteContactResponse")]
        System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse> DeleteContactAsync(int contactId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/UpdateContact", ReplyAction="http://tempuri.org/IContactManagerService/UpdateContactResponse")]
        Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse UpdateContact(Kobo.ContactManager.Web.ContactManagerService.PersonDTO contact);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IContactManagerService/UpdateContact", ReplyAction="http://tempuri.org/IContactManagerService/UpdateContactResponse")]
        System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse> UpdateContactAsync(Kobo.ContactManager.Web.ContactManagerService.PersonDTO contact);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IContactManagerServiceChannel : Kobo.ContactManager.Web.ContactManagerService.IContactManagerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ContactManagerServiceClient : System.ServiceModel.ClientBase<Kobo.ContactManager.Web.ContactManagerService.IContactManagerService>, Kobo.ContactManager.Web.ContactManagerService.IContactManagerService {
        
        public ContactManagerServiceClient() {
        }
        
        public ContactManagerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ContactManagerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ContactManagerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ContactManagerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Kobo.ContactManager.Web.ContactManagerService.PersonDTO[] SearchForContacts(string[] searchParameter, int fromPosition, int recordsToReturn) {
            return base.Channel.SearchForContacts(searchParameter, fromPosition, recordsToReturn);
        }
        
        public System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.PersonDTO[]> SearchForContactsAsync(string[] searchParameter, int fromPosition, int recordsToReturn) {
            return base.Channel.SearchForContactsAsync(searchParameter, fromPosition, recordsToReturn);
        }
        
        public Kobo.ContactManager.Web.ContactManagerService.PersonDTO GetContact(int contactId) {
            return base.Channel.GetContact(contactId);
        }
        
        public System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.PersonDTO> GetContactAsync(int contactId) {
            return base.Channel.GetContactAsync(contactId);
        }
        
        public Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse AddContact(Kobo.ContactManager.Web.ContactManagerService.PersonDTO contact) {
            return base.Channel.AddContact(contact);
        }
        
        public System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse> AddContactAsync(Kobo.ContactManager.Web.ContactManagerService.PersonDTO contact) {
            return base.Channel.AddContactAsync(contact);
        }
        
        public Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse DeleteContact(int contactId) {
            return base.Channel.DeleteContact(contactId);
        }
        
        public System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse> DeleteContactAsync(int contactId) {
            return base.Channel.DeleteContactAsync(contactId);
        }
        
        public Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse UpdateContact(Kobo.ContactManager.Web.ContactManagerService.PersonDTO contact) {
            return base.Channel.UpdateContact(contact);
        }
        
        public System.Threading.Tasks.Task<Kobo.ContactManager.Web.ContactManagerService.ContactUpdateResponse> UpdateContactAsync(Kobo.ContactManager.Web.ContactManagerService.PersonDTO contact) {
            return base.Channel.UpdateContactAsync(contact);
        }
    }
}
