﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment4TryIt.AddPersonServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/AddPerson")]
    [System.SerializableAttribute()]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Assignment4TryIt.AddPersonServiceReference.Category CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Assignment4TryIt.AddPersonServiceReference.Credential CredentialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Assignment4TryIt.AddPersonServiceReference.Name NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Assignment4TryIt.AddPersonServiceReference.Phone PhoneField;
        
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
        public Assignment4TryIt.AddPersonServiceReference.Category Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Assignment4TryIt.AddPersonServiceReference.Credential Credential {
            get {
                return this.CredentialField;
            }
            set {
                if ((object.ReferenceEquals(this.CredentialField, value) != true)) {
                    this.CredentialField = value;
                    this.RaisePropertyChanged("Credential");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Assignment4TryIt.AddPersonServiceReference.Name Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Assignment4TryIt.AddPersonServiceReference.Phone Phone {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Category", Namespace="http://schemas.datacontract.org/2004/07/AddPerson")]
    [System.SerializableAttribute()]
    public partial class Category : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryValueField;
        
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
        public string CategoryValue {
            get {
                return this.CategoryValueField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryValueField, value) != true)) {
                    this.CategoryValueField = value;
                    this.RaisePropertyChanged("CategoryValue");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Credential", Namespace="http://schemas.datacontract.org/2004/07/AddPerson")]
    [System.SerializableAttribute()]
    public partial class Credential : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Assignment4TryIt.AddPersonServiceReference.Password PasswordField;
        
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
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Assignment4TryIt.AddPersonServiceReference.Password Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Name", Namespace="http://schemas.datacontract.org/2004/07/AddPerson")]
    [System.SerializableAttribute()]
    public partial class Name : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastField;
        
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
        public string First {
            get {
                return this.FirstField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstField, value) != true)) {
                    this.FirstField = value;
                    this.RaisePropertyChanged("First");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Last {
            get {
                return this.LastField;
            }
            set {
                if ((object.ReferenceEquals(this.LastField, value) != true)) {
                    this.LastField = value;
                    this.RaisePropertyChanged("Last");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Phone", Namespace="http://schemas.datacontract.org/2004/07/AddPerson")]
    [System.SerializableAttribute()]
    public partial class Phone : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Assignment4TryIt.AddPersonServiceReference.Cell CellField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WorkField;
        
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
        public Assignment4TryIt.AddPersonServiceReference.Cell Cell {
            get {
                return this.CellField;
            }
            set {
                if ((object.ReferenceEquals(this.CellField, value) != true)) {
                    this.CellField = value;
                    this.RaisePropertyChanged("Cell");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Work {
            get {
                return this.WorkField;
            }
            set {
                if ((object.ReferenceEquals(this.WorkField, value) != true)) {
                    this.WorkField = value;
                    this.RaisePropertyChanged("Work");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Password", Namespace="http://schemas.datacontract.org/2004/07/AddPerson")]
    [System.SerializableAttribute()]
    public partial class Password : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EncryptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordValueField;
        
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
        public string Encryption {
            get {
                return this.EncryptionField;
            }
            set {
                if ((object.ReferenceEquals(this.EncryptionField, value) != true)) {
                    this.EncryptionField = value;
                    this.RaisePropertyChanged("Encryption");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordValue {
            get {
                return this.PasswordValueField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordValueField, value) != true)) {
                    this.PasswordValueField = value;
                    this.RaisePropertyChanged("PasswordValue");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Cell", Namespace="http://schemas.datacontract.org/2004/07/AddPerson")]
    [System.SerializableAttribute()]
    public partial class Cell : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CellNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProviderField;
        
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
        public string CellNumber {
            get {
                return this.CellNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.CellNumberField, value) != true)) {
                    this.CellNumberField = value;
                    this.RaisePropertyChanged("CellNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Provider {
            get {
                return this.ProviderField;
            }
            set {
                if ((object.ReferenceEquals(this.ProviderField, value) != true)) {
                    this.ProviderField = value;
                    this.RaisePropertyChanged("Provider");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Persons", Namespace="http://schemas.datacontract.org/2004/07/AddPerson")]
    [System.SerializableAttribute()]
    public partial class Persons : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Assignment4TryIt.AddPersonServiceReference.Person[] PersonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string XsdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string XsiField;
        
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
        public Assignment4TryIt.AddPersonServiceReference.Person[] Person {
            get {
                return this.PersonField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonField, value) != true)) {
                    this.PersonField = value;
                    this.RaisePropertyChanged("Person");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Xsd {
            get {
                return this.XsdField;
            }
            set {
                if ((object.ReferenceEquals(this.XsdField, value) != true)) {
                    this.XsdField = value;
                    this.RaisePropertyChanged("Xsd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Xsi {
            get {
                return this.XsiField;
            }
            set {
                if ((object.ReferenceEquals(this.XsiField, value) != true)) {
                    this.XsiField = value;
                    this.RaisePropertyChanged("Xsi");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AddPersonServiceReference.IAddPerson")]
    public interface IAddPerson {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/AddNewPerson", ReplyAction="http://tempuri.org/IAddPerson/AddNewPersonResponse")]
        void AddNewPerson(Assignment4TryIt.AddPersonServiceReference.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/AddNewPerson", ReplyAction="http://tempuri.org/IAddPerson/AddNewPersonResponse")]
        System.Threading.Tasks.Task AddNewPersonAsync(Assignment4TryIt.AddPersonServiceReference.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/RemovePerson", ReplyAction="http://tempuri.org/IAddPerson/RemovePersonResponse")]
        void RemovePerson(Assignment4TryIt.AddPersonServiceReference.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/RemovePerson", ReplyAction="http://tempuri.org/IAddPerson/RemovePersonResponse")]
        System.Threading.Tasks.Task RemovePersonAsync(Assignment4TryIt.AddPersonServiceReference.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/UserIdCheck", ReplyAction="http://tempuri.org/IAddPerson/UserIdCheckResponse")]
        bool UserIdCheck(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/UserIdCheck", ReplyAction="http://tempuri.org/IAddPerson/UserIdCheckResponse")]
        System.Threading.Tasks.Task<bool> UserIdCheckAsync(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/PersonNameCheck", ReplyAction="http://tempuri.org/IAddPerson/PersonNameCheckResponse")]
        bool PersonNameCheck(string firstName, string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/PersonNameCheck", ReplyAction="http://tempuri.org/IAddPerson/PersonNameCheckResponse")]
        System.Threading.Tasks.Task<bool> PersonNameCheckAsync(string firstName, string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/GetPersons", ReplyAction="http://tempuri.org/IAddPerson/GetPersonsResponse")]
        Assignment4TryIt.AddPersonServiceReference.Persons GetPersons();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddPerson/GetPersons", ReplyAction="http://tempuri.org/IAddPerson/GetPersonsResponse")]
        System.Threading.Tasks.Task<Assignment4TryIt.AddPersonServiceReference.Persons> GetPersonsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAddPersonChannel : Assignment4TryIt.AddPersonServiceReference.IAddPerson, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddPersonClient : System.ServiceModel.ClientBase<Assignment4TryIt.AddPersonServiceReference.IAddPerson>, Assignment4TryIt.AddPersonServiceReference.IAddPerson {
        
        public AddPersonClient() {
        }
        
        public AddPersonClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AddPersonClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddPersonClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddPersonClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddNewPerson(Assignment4TryIt.AddPersonServiceReference.Person person) {
            base.Channel.AddNewPerson(person);
        }
        
        public System.Threading.Tasks.Task AddNewPersonAsync(Assignment4TryIt.AddPersonServiceReference.Person person) {
            return base.Channel.AddNewPersonAsync(person);
        }
        
        public void RemovePerson(Assignment4TryIt.AddPersonServiceReference.Person person) {
            base.Channel.RemovePerson(person);
        }
        
        public System.Threading.Tasks.Task RemovePersonAsync(Assignment4TryIt.AddPersonServiceReference.Person person) {
            return base.Channel.RemovePersonAsync(person);
        }
        
        public bool UserIdCheck(string userId) {
            return base.Channel.UserIdCheck(userId);
        }
        
        public System.Threading.Tasks.Task<bool> UserIdCheckAsync(string userId) {
            return base.Channel.UserIdCheckAsync(userId);
        }
        
        public bool PersonNameCheck(string firstName, string lastName) {
            return base.Channel.PersonNameCheck(firstName, lastName);
        }
        
        public System.Threading.Tasks.Task<bool> PersonNameCheckAsync(string firstName, string lastName) {
            return base.Channel.PersonNameCheckAsync(firstName, lastName);
        }
        
        public Assignment4TryIt.AddPersonServiceReference.Persons GetPersons() {
            return base.Channel.GetPersons();
        }
        
        public System.Threading.Tasks.Task<Assignment4TryIt.AddPersonServiceReference.Persons> GetPersonsAsync() {
            return base.Channel.GetPersonsAsync();
        }
    }
}
