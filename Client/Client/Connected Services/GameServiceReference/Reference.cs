﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.GameServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WrongPasswordFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
    [System.SerializableAttribute()]
    public partial class WrongPasswordFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
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
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="GameInfo", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
    [System.SerializableAttribute()]
    public partial class GameInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FParticipantField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FParticipantPField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool LiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SParticipantField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SParticipantPField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WinnerField;
        
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
        public string FParticipant {
            get {
                return this.FParticipantField;
            }
            set {
                if ((object.ReferenceEquals(this.FParticipantField, value) != true)) {
                    this.FParticipantField = value;
                    this.RaisePropertyChanged("FParticipant");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FParticipantP {
            get {
                return this.FParticipantPField;
            }
            set {
                if ((this.FParticipantPField.Equals(value) != true)) {
                    this.FParticipantPField = value;
                    this.RaisePropertyChanged("FParticipantP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Live {
            get {
                return this.LiveField;
            }
            set {
                if ((this.LiveField.Equals(value) != true)) {
                    this.LiveField = value;
                    this.RaisePropertyChanged("Live");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SParticipant {
            get {
                return this.SParticipantField;
            }
            set {
                if ((object.ReferenceEquals(this.SParticipantField, value) != true)) {
                    this.SParticipantField = value;
                    this.RaisePropertyChanged("SParticipant");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SParticipantP {
            get {
                return this.SParticipantPField;
            }
            set {
                if ((this.SParticipantPField.Equals(value) != true)) {
                    this.SParticipantPField = value;
                    this.RaisePropertyChanged("SParticipantP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Winner {
            get {
                return this.WinnerField;
            }
            set {
                if ((object.ReferenceEquals(this.WinnerField, value) != true)) {
                    this.WinnerField = value;
                    this.RaisePropertyChanged("Winner");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CommonGamesInfo", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
    [System.SerializableAttribute()]
    public partial class CommonGamesInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ChampionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Client.GameServiceReference.GameInfo[] CommonGamesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PrecentageField;
        
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
        public string Champion {
            get {
                return this.ChampionField;
            }
            set {
                if ((object.ReferenceEquals(this.ChampionField, value) != true)) {
                    this.ChampionField = value;
                    this.RaisePropertyChanged("Champion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Client.GameServiceReference.GameInfo[] CommonGames {
            get {
                return this.CommonGamesField;
            }
            set {
                if ((object.ReferenceEquals(this.CommonGamesField, value) != true)) {
                    this.CommonGamesField = value;
                    this.RaisePropertyChanged("CommonGames");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Precentage {
            get {
                return this.PrecentageField;
            }
            set {
                if ((this.PrecentageField.Equals(value) != true)) {
                    this.PrecentageField = value;
                    this.RaisePropertyChanged("Precentage");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="InvitationFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
    [System.SerializableAttribute()]
    public partial class InvitationFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
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
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="LiveGameFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
    [System.SerializableAttribute()]
    public partial class LiveGameFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
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
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameServiceReference.IService", CallbackContract=typeof(Client.GameServiceReference.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ClientConnected", ReplyAction="http://tempuri.org/IService/ClientConnectedResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.GameServiceReference.WrongPasswordFault), Action="http://tempuri.org/IService/ClientConnectedWrongPasswordFaultFault", Name="WrongPasswordFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
        void ClientConnected(string userName, string hashedPasswd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ClientConnected", ReplyAction="http://tempuri.org/IService/ClientConnectedResponse")]
        System.Threading.Tasks.Task ClientConnectedAsync(string userName, string hashedPasswd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ClientDisconnect", ReplyAction="http://tempuri.org/IService/ClientDisconnectResponse")]
        void ClientDisconnect(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ClientDisconnect", ReplyAction="http://tempuri.org/IService/ClientDisconnectResponse")]
        System.Threading.Tasks.Task ClientDisconnectAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUsers", ReplyAction="http://tempuri.org/IService/GetUsersResponse")]
        System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>> GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetUsers", ReplyAction="http://tempuri.org/IService/GetUsersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>>> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetGames", ReplyAction="http://tempuri.org/IService/GetGamesResponse")]
        System.Collections.Generic.Dictionary<int, Client.GameServiceReference.GameInfo> GetGames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetGames", ReplyAction="http://tempuri.org/IService/GetGamesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, Client.GameServiceReference.GameInfo>> GetGamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCommonGames", ReplyAction="http://tempuri.org/IService/GetCommonGamesResponse")]
        Client.GameServiceReference.CommonGamesInfo GetCommonGames(string p1, string p2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetCommonGames", ReplyAction="http://tempuri.org/IService/GetCommonGamesResponse")]
        System.Threading.Tasks.Task<Client.GameServiceReference.CommonGamesInfo> GetCommonGamesAsync(string p1, string p2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetWaitingList", ReplyAction="http://tempuri.org/IService/GetWaitingListResponse")]
        string[] GetWaitingList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetWaitingList", ReplyAction="http://tempuri.org/IService/GetWaitingListResponse")]
        System.Threading.Tasks.Task<string[]> GetWaitingListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetGamesByPlayer", ReplyAction="http://tempuri.org/IService/GetGamesByPlayerResponse")]
        Client.GameServiceReference.GameInfo[] GetGamesByPlayer(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetGamesByPlayer", ReplyAction="http://tempuri.org/IService/GetGamesByPlayerResponse")]
        System.Threading.Tasks.Task<Client.GameServiceReference.GameInfo[]> GetGamesByPlayerAsync(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPlayerInfo", ReplyAction="http://tempuri.org/IService/GetPlayerInfoResponse")]
        int[] GetPlayerInfo(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetPlayerInfo", ReplyAction="http://tempuri.org/IService/GetPlayerInfoResponse")]
        System.Threading.Tasks.Task<int[]> GetPlayerInfoAsync(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddPlayerToLobby", ReplyAction="http://tempuri.org/IService/AddPlayerToLobbyResponse")]
        void AddPlayerToLobby(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddPlayerToLobby", ReplyAction="http://tempuri.org/IService/AddPlayerToLobbyResponse")]
        System.Threading.Tasks.Task AddPlayerToLobbyAsync(string Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendInvitation", ReplyAction="http://tempuri.org/IService/SendInvitationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.GameServiceReference.InvitationFault), Action="http://tempuri.org/IService/SendInvitationInvitationFaultFault", Name="InvitationFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
        void SendInvitation(string FromId, string ToId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendInvitation", ReplyAction="http://tempuri.org/IService/SendInvitationResponse")]
        System.Threading.Tasks.Task SendInvitationAsync(string FromId, string ToId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InvitationAnswer", ReplyAction="http://tempuri.org/IService/InvitationAnswerResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.GameServiceReference.InvitationFault), Action="http://tempuri.org/IService/InvitationAnswerInvitationFaultFault", Name="InvitationFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
        void InvitationAnswer(string FromId, bool YN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InvitationAnswer", ReplyAction="http://tempuri.org/IService/InvitationAnswerResponse")]
        System.Threading.Tasks.Task InvitationAnswerAsync(string FromId, bool YN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddMyMoveToBoard", ReplyAction="http://tempuri.org/IService/AddMyMoveToBoardResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.GameServiceReference.LiveGameFault), Action="http://tempuri.org/IService/AddMyMoveToBoardLiveGameFaultFault", Name="LiveGameFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
        void AddMyMoveToBoard(string username, string GameId, string col, bool IHaveFour);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddMyMoveToBoard", ReplyAction="http://tempuri.org/IService/AddMyMoveToBoardResponse")]
        System.Threading.Tasks.Task AddMyMoveToBoardAsync(string username, string GameId, string col, bool IHaveFour);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MyPoints", ReplyAction="http://tempuri.org/IService/MyPointsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.GameServiceReference.LiveGameFault), Action="http://tempuri.org/IService/MyPointsLiveGameFaultFault", Name="LiveGameFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
        void MyPoints(string username, string GameId, int p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/MyPoints", ReplyAction="http://tempuri.org/IService/MyPointsResponse")]
        System.Threading.Tasks.Task MyPointsAsync(string username, string GameId, int p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IQuit", ReplyAction="http://tempuri.org/IService/IQuitResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Client.GameServiceReference.LiveGameFault), Action="http://tempuri.org/IService/IQuitLiveGameFaultFault", Name="LiveGameFault", Namespace="http://schemas.datacontract.org/2004/07/FourRowService")]
        void IQuit(string userName, string GameId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IQuit", ReplyAction="http://tempuri.org/IService/IQuitResponse")]
        System.Threading.Tasks.Task IQuitAsync(string userName, string GameId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Ping", ReplyAction="http://tempuri.org/IService/PingResponse")]
        bool Ping();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Ping", ReplyAction="http://tempuri.org/IService/PingResponse")]
        System.Threading.Tasks.Task<bool> PingAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/ReceivedNewInvitation")]
        void ReceivedNewInvitation(string from);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/YourInvitationReturn")]
        void YourInvitationReturn(bool YN);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/YouLost")]
        void YouLost();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Draw")]
        void Draw();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/Turn")]
        void Turn(bool flag);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/AddMoveToYourBoard")]
        void AddMoveToYourBoard(string col);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/PlayerQuit")]
        void PlayerQuit();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Client.GameServiceReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<Client.GameServiceReference.IService>, Client.GameServiceReference.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void ClientConnected(string userName, string hashedPasswd) {
            base.Channel.ClientConnected(userName, hashedPasswd);
        }
        
        public System.Threading.Tasks.Task ClientConnectedAsync(string userName, string hashedPasswd) {
            return base.Channel.ClientConnectedAsync(userName, hashedPasswd);
        }
        
        public void ClientDisconnect(string userName) {
            base.Channel.ClientDisconnect(userName);
        }
        
        public System.Threading.Tasks.Task ClientDisconnectAsync(string userName) {
            return base.Channel.ClientDisconnectAsync(userName);
        }
        
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>> GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, int>>> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
        
        public System.Collections.Generic.Dictionary<int, Client.GameServiceReference.GameInfo> GetGames() {
            return base.Channel.GetGames();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, Client.GameServiceReference.GameInfo>> GetGamesAsync() {
            return base.Channel.GetGamesAsync();
        }
        
        public Client.GameServiceReference.CommonGamesInfo GetCommonGames(string p1, string p2) {
            return base.Channel.GetCommonGames(p1, p2);
        }
        
        public System.Threading.Tasks.Task<Client.GameServiceReference.CommonGamesInfo> GetCommonGamesAsync(string p1, string p2) {
            return base.Channel.GetCommonGamesAsync(p1, p2);
        }
        
        public string[] GetWaitingList() {
            return base.Channel.GetWaitingList();
        }
        
        public System.Threading.Tasks.Task<string[]> GetWaitingListAsync() {
            return base.Channel.GetWaitingListAsync();
        }
        
        public Client.GameServiceReference.GameInfo[] GetGamesByPlayer(string Id) {
            return base.Channel.GetGamesByPlayer(Id);
        }
        
        public System.Threading.Tasks.Task<Client.GameServiceReference.GameInfo[]> GetGamesByPlayerAsync(string Id) {
            return base.Channel.GetGamesByPlayerAsync(Id);
        }
        
        public int[] GetPlayerInfo(string Id) {
            return base.Channel.GetPlayerInfo(Id);
        }
        
        public System.Threading.Tasks.Task<int[]> GetPlayerInfoAsync(string Id) {
            return base.Channel.GetPlayerInfoAsync(Id);
        }
        
        public void AddPlayerToLobby(string Id) {
            base.Channel.AddPlayerToLobby(Id);
        }
        
        public System.Threading.Tasks.Task AddPlayerToLobbyAsync(string Id) {
            return base.Channel.AddPlayerToLobbyAsync(Id);
        }
        
        public void SendInvitation(string FromId, string ToId) {
            base.Channel.SendInvitation(FromId, ToId);
        }
        
        public System.Threading.Tasks.Task SendInvitationAsync(string FromId, string ToId) {
            return base.Channel.SendInvitationAsync(FromId, ToId);
        }
        
        public void InvitationAnswer(string FromId, bool YN) {
            base.Channel.InvitationAnswer(FromId, YN);
        }
        
        public System.Threading.Tasks.Task InvitationAnswerAsync(string FromId, bool YN) {
            return base.Channel.InvitationAnswerAsync(FromId, YN);
        }
        
        public void AddMyMoveToBoard(string username, string GameId, string col, bool IHaveFour) {
            base.Channel.AddMyMoveToBoard(username, GameId, col, IHaveFour);
        }
        
        public System.Threading.Tasks.Task AddMyMoveToBoardAsync(string username, string GameId, string col, bool IHaveFour) {
            return base.Channel.AddMyMoveToBoardAsync(username, GameId, col, IHaveFour);
        }
        
        public void MyPoints(string username, string GameId, int p) {
            base.Channel.MyPoints(username, GameId, p);
        }
        
        public System.Threading.Tasks.Task MyPointsAsync(string username, string GameId, int p) {
            return base.Channel.MyPointsAsync(username, GameId, p);
        }
        
        public void IQuit(string userName, string GameId) {
            base.Channel.IQuit(userName, GameId);
        }
        
        public System.Threading.Tasks.Task IQuitAsync(string userName, string GameId) {
            return base.Channel.IQuitAsync(userName, GameId);
        }
        
        public bool Ping() {
            return base.Channel.Ping();
        }
        
        public System.Threading.Tasks.Task<bool> PingAsync() {
            return base.Channel.PingAsync();
        }
    }
}
