﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinFormsWCF_TournamentGenerator.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/WcfToDbTournamentGenerator")]
    [System.SerializableAttribute()]
    public partial class Player : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SkillField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SpeedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StrengthField;
        
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
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Skill {
            get {
                return this.SkillField;
            }
            set {
                if ((this.SkillField.Equals(value) != true)) {
                    this.SkillField = value;
                    this.RaisePropertyChanged("Skill");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Speed {
            get {
                return this.SpeedField;
            }
            set {
                if ((this.SpeedField.Equals(value) != true)) {
                    this.SpeedField = value;
                    this.RaisePropertyChanged("Speed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Strength {
            get {
                return this.StrengthField;
            }
            set {
                if ((this.StrengthField.Equals(value) != true)) {
                    this.StrengthField = value;
                    this.RaisePropertyChanged("Strength");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreatePlayer", ReplyAction="http://tempuri.org/IService1/CreatePlayerResponse")]
        int CreatePlayer(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreatePlayer", ReplyAction="http://tempuri.org/IService1/CreatePlayerResponse")]
        System.Threading.Tasks.Task<int> CreatePlayerAsync(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdatePlayer", ReplyAction="http://tempuri.org/IService1/UpdatePlayerResponse")]
        int UpdatePlayer(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdatePlayer", ReplyAction="http://tempuri.org/IService1/UpdatePlayerResponse")]
        System.Threading.Tasks.Task<int> UpdatePlayerAsync(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeletePlayer", ReplyAction="http://tempuri.org/IService1/DeletePlayerResponse")]
        int DeletePlayer(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeletePlayer", ReplyAction="http://tempuri.org/IService1/DeletePlayerResponse")]
        System.Threading.Tasks.Task<int> DeletePlayerAsync(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPlayer", ReplyAction="http://tempuri.org/IService1/GetPlayerResponse")]
        WinFormsWCF_TournamentGenerator.ServiceReference1.Player GetPlayer(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPlayer", ReplyAction="http://tempuri.org/IService1/GetPlayerResponse")]
        System.Threading.Tasks.Task<WinFormsWCF_TournamentGenerator.ServiceReference1.Player> GetPlayerAsync(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllPlayers", ReplyAction="http://tempuri.org/IService1/GetAllPlayersResponse")]
        WinFormsWCF_TournamentGenerator.ServiceReference1.Player[] GetAllPlayers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllPlayers", ReplyAction="http://tempuri.org/IService1/GetAllPlayersResponse")]
        System.Threading.Tasks.Task<WinFormsWCF_TournamentGenerator.ServiceReference1.Player[]> GetAllPlayersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WinFormsWCF_TournamentGenerator.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WinFormsWCF_TournamentGenerator.ServiceReference1.IService1>, WinFormsWCF_TournamentGenerator.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CreatePlayer(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player) {
            return base.Channel.CreatePlayer(player);
        }
        
        public System.Threading.Tasks.Task<int> CreatePlayerAsync(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player) {
            return base.Channel.CreatePlayerAsync(player);
        }
        
        public int UpdatePlayer(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player) {
            return base.Channel.UpdatePlayer(player);
        }
        
        public System.Threading.Tasks.Task<int> UpdatePlayerAsync(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player) {
            return base.Channel.UpdatePlayerAsync(player);
        }
        
        public int DeletePlayer(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player) {
            return base.Channel.DeletePlayer(player);
        }
        
        public System.Threading.Tasks.Task<int> DeletePlayerAsync(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player) {
            return base.Channel.DeletePlayerAsync(player);
        }
        
        public WinFormsWCF_TournamentGenerator.ServiceReference1.Player GetPlayer(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player) {
            return base.Channel.GetPlayer(player);
        }
        
        public System.Threading.Tasks.Task<WinFormsWCF_TournamentGenerator.ServiceReference1.Player> GetPlayerAsync(WinFormsWCF_TournamentGenerator.ServiceReference1.Player player) {
            return base.Channel.GetPlayerAsync(player);
        }
        
        public WinFormsWCF_TournamentGenerator.ServiceReference1.Player[] GetAllPlayers() {
            return base.Channel.GetAllPlayers();
        }
        
        public System.Threading.Tasks.Task<WinFormsWCF_TournamentGenerator.ServiceReference1.Player[]> GetAllPlayersAsync() {
            return base.Channel.GetAllPlayersAsync();
        }
    }
}
