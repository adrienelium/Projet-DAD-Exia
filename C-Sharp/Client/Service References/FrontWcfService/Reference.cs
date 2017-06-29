﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.FrontWcfService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LogInfo", Namespace="http://schemas.datacontract.org/2004/07/FrontWcfService")]
    [System.SerializableAttribute()]
    public partial class LogInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tokenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
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
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string token {
            get {
                return this.tokenField;
            }
            set {
                if ((object.ReferenceEquals(this.tokenField, value) != true)) {
                    this.tokenField = value;
                    this.RaisePropertyChanged("token");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="State", Namespace="http://schemas.datacontract.org/2004/07/FrontWcfService")]
    [System.SerializableAttribute()]
    public partial class State : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int amountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string commentField;
        
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
        public int amount {
            get {
                return this.amountField;
            }
            set {
                if ((this.amountField.Equals(value) != true)) {
                    this.amountField = value;
                    this.RaisePropertyChanged("amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string comment {
            get {
                return this.commentField;
            }
            set {
                if ((object.ReferenceEquals(this.commentField, value) != true)) {
                    this.commentField = value;
                    this.RaisePropertyChanged("comment");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FrontWcfService.IDecryptageService")]
    public interface IDecryptageService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDecryptageService/Login", ReplyAction="http://tempuri.org/IDecryptageService/LoginResponse")]
        Client.FrontWcfService.LogInfo Login(Client.FrontWcfService.LogInfo loginInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDecryptageService/Login", ReplyAction="http://tempuri.org/IDecryptageService/LoginResponse")]
        System.Threading.Tasks.Task<Client.FrontWcfService.LogInfo> LoginAsync(Client.FrontWcfService.LogInfo loginInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDecryptageService/LaunchDecryptProcess", ReplyAction="http://tempuri.org/IDecryptageService/LaunchDecryptProcessResponse")]
        bool LaunchDecryptProcess(string[] str, string[] filesNames, string username, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDecryptageService/LaunchDecryptProcess", ReplyAction="http://tempuri.org/IDecryptageService/LaunchDecryptProcessResponse")]
        System.Threading.Tasks.Task<bool> LaunchDecryptProcessAsync(string[] str, string[] filesNames, string username, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDecryptageService/GetState", ReplyAction="http://tempuri.org/IDecryptageService/GetStateResponse")]
        Client.FrontWcfService.State GetState(string username, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDecryptageService/GetState", ReplyAction="http://tempuri.org/IDecryptageService/GetStateResponse")]
        System.Threading.Tasks.Task<Client.FrontWcfService.State> GetStateAsync(string username, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDecryptageService/Reset", ReplyAction="http://tempuri.org/IDecryptageService/ResetResponse")]
        void Reset(string username, string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDecryptageService/Reset", ReplyAction="http://tempuri.org/IDecryptageService/ResetResponse")]
        System.Threading.Tasks.Task ResetAsync(string username, string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDecryptageServiceChannel : Client.FrontWcfService.IDecryptageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DecryptageServiceClient : System.ServiceModel.ClientBase<Client.FrontWcfService.IDecryptageService>, Client.FrontWcfService.IDecryptageService {
        
        public DecryptageServiceClient() {
        }
        
        public DecryptageServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DecryptageServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DecryptageServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DecryptageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.FrontWcfService.LogInfo Login(Client.FrontWcfService.LogInfo loginInfo) {
            return base.Channel.Login(loginInfo);
        }
        
        public System.Threading.Tasks.Task<Client.FrontWcfService.LogInfo> LoginAsync(Client.FrontWcfService.LogInfo loginInfo) {
            return base.Channel.LoginAsync(loginInfo);
        }
        
        public bool LaunchDecryptProcess(string[] str, string[] filesNames, string username, string token) {
            return base.Channel.LaunchDecryptProcess(str, filesNames, username, token);
        }
        
        public System.Threading.Tasks.Task<bool> LaunchDecryptProcessAsync(string[] str, string[] filesNames, string username, string token) {
            return base.Channel.LaunchDecryptProcessAsync(str, filesNames, username, token);
        }
        
        public Client.FrontWcfService.State GetState(string username, string token) {
            return base.Channel.GetState(username, token);
        }
        
        public System.Threading.Tasks.Task<Client.FrontWcfService.State> GetStateAsync(string username, string token) {
            return base.Channel.GetStateAsync(username, token);
        }
        
        public void Reset(string username, string token) {
            base.Channel.Reset(username, token);
        }
        
        public System.Threading.Tasks.Task ResetAsync(string username, string token) {
            return base.Channel.ResetAsync(username, token);
        }
    }
}
