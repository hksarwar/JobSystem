﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trainee_Consultant.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DbUser", Namespace="http://schemas.datacontract.org/2004/07/FDMJobSystemLogic")]
    [System.SerializableAttribute()]
    public partial class DbUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DegreeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModulesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] SkillsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StreamField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TypeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public string Degree {
            get {
                return this.DegreeField;
            }
            set {
                if ((object.ReferenceEquals(this.DegreeField, value) != true)) {
                    this.DegreeField = value;
                    this.RaisePropertyChanged("Degree");
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
        public string Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Modules {
            get {
                return this.ModulesField;
            }
            set {
                if ((object.ReferenceEquals(this.ModulesField, value) != true)) {
                    this.ModulesField = value;
                    this.RaisePropertyChanged("Modules");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
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
        public string Password {
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Skills {
            get {
                return this.SkillsField;
            }
            set {
                if ((object.ReferenceEquals(this.SkillsField, value) != true)) {
                    this.SkillsField = value;
                    this.RaisePropertyChanged("Skills");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Stream {
            get {
                return this.StreamField;
            }
            set {
                if ((object.ReferenceEquals(this.StreamField, value) != true)) {
                    this.StreamField = value;
                    this.RaisePropertyChanged("Stream");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TStatus {
            get {
                return this.TStatusField;
            }
            set {
                if ((object.ReferenceEquals(this.TStatusField, value) != true)) {
                    this.TStatusField = value;
                    this.RaisePropertyChanged("TStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TypeId {
            get {
                return this.TypeIdField;
            }
            set {
                if ((this.TypeIdField.Equals(value) != true)) {
                    this.TypeIdField = value;
                    this.RaisePropertyChanged("TypeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DbComments", Namespace="http://schemas.datacontract.org/2004/07/FDMJobSystemLogic")]
    [System.SerializableAttribute()]
    public partial class DbComments : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CommentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateAddedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int JobIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public int CommentId {
            get {
                return this.CommentIdField;
            }
            set {
                if ((this.CommentIdField.Equals(value) != true)) {
                    this.CommentIdField = value;
                    this.RaisePropertyChanged("CommentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateAdded {
            get {
                return this.DateAddedField;
            }
            set {
                if ((this.DateAddedField.Equals(value) != true)) {
                    this.DateAddedField = value;
                    this.RaisePropertyChanged("DateAdded");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int JobId {
            get {
                return this.JobIdField;
            }
            set {
                if ((this.JobIdField.Equals(value) != true)) {
                    this.JobIdField = value;
                    this.RaisePropertyChanged("JobId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DbJob", Namespace="http://schemas.datacontract.org/2004/07/FDMJobSystemLogic")]
    [System.SerializableAttribute()]
    public partial class DbJob : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompanyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DatePostedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DeadlineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int JobIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StreamField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
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
        public string Company {
            get {
                return this.CompanyField;
            }
            set {
                if ((object.ReferenceEquals(this.CompanyField, value) != true)) {
                    this.CompanyField = value;
                    this.RaisePropertyChanged("Company");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DatePosted {
            get {
                return this.DatePostedField;
            }
            set {
                if ((this.DatePostedField.Equals(value) != true)) {
                    this.DatePostedField = value;
                    this.RaisePropertyChanged("DatePosted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Deadline {
            get {
                return this.DeadlineField;
            }
            set {
                if ((this.DeadlineField.Equals(value) != true)) {
                    this.DeadlineField = value;
                    this.RaisePropertyChanged("Deadline");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int JobId {
            get {
                return this.JobIdField;
            }
            set {
                if ((this.JobIdField.Equals(value) != true)) {
                    this.JobIdField = value;
                    this.RaisePropertyChanged("JobId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Stream {
            get {
                return this.StreamField;
            }
            set {
                if ((object.ReferenceEquals(this.StreamField, value) != true)) {
                    this.StreamField = value;
                    this.RaisePropertyChanged("Stream");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IJSService")]
    public interface IJSService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetStreams", ReplyAction="http://tempuri.org/IJSService/GetStreamsResponse")]
        string[] GetStreams();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/FormatSkill", ReplyAction="http://tempuri.org/IJSService/FormatSkillResponse")]
        string FormatSkill(string skill);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetTStatuses", ReplyAction="http://tempuri.org/IJSService/GetTStatusesResponse")]
        string[] GetTStatuses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/SearchForConsultants", ReplyAction="http://tempuri.org/IJSService/SearchForConsultantsResponse")]
        Trainee_Consultant.ServiceReference1.DbUser[] SearchForConsultants(string stream, string status, string[] skills);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetProfile", ReplyAction="http://tempuri.org/IJSService/GetProfileResponse")]
        Trainee_Consultant.ServiceReference1.DbUser GetProfile(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/AddComment", ReplyAction="http://tempuri.org/IJSService/AddCommentResponse")]
        bool AddComment(int jobId, System.Guid sessionId, string commentText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/ViewComments", ReplyAction="http://tempuri.org/IJSService/ViewCommentsResponse")]
        Trainee_Consultant.ServiceReference1.DbComments[] ViewComments(int jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/DeleteComment", ReplyAction="http://tempuri.org/IJSService/DeleteCommentResponse")]
        bool DeleteComment(int commentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetUserIdByCommentId", ReplyAction="http://tempuri.org/IJSService/GetUserIdByCommentIdResponse")]
        int GetUserIdByCommentId(int commentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/InsertFavourite", ReplyAction="http://tempuri.org/IJSService/InsertFavouriteResponse")]
        bool InsertFavourite(Trainee_Consultant.ServiceReference1.DbUser[] obj, int job_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/DeleteFavourite", ReplyAction="http://tempuri.org/IJSService/DeleteFavouriteResponse")]
        bool DeleteFavourite(Trainee_Consultant.ServiceReference1.DbUser[] obj, int job_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetListOfFavJobs", ReplyAction="http://tempuri.org/IJSService/GetListOfFavJobsResponse")]
        Trainee_Consultant.ServiceReference1.DbJob[] GetListOfFavJobs(Trainee_Consultant.ServiceReference1.DbJob job, System.Guid session_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/Login", ReplyAction="http://tempuri.org/IJSService/LoginResponse")]
        System.Guid Login(string username, string password, string type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/Login2", ReplyAction="http://tempuri.org/IJSService/Login2Response")]
        System.Guid Login2(string username, string password, string type, string type2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/Logout", ReplyAction="http://tempuri.org/IJSService/LogoutResponse")]
        void Logout(System.Guid sessionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetUserType", ReplyAction="http://tempuri.org/IJSService/GetUserTypeResponse")]
        string[] GetUserType();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetStreamList", ReplyAction="http://tempuri.org/IJSService/GetStreamListResponse")]
        string[] GetStreamList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetNumOfUsers", ReplyAction="http://tempuri.org/IJSService/GetNumOfUsersResponse")]
        int GetNumOfUsers(string firstName, string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/InsertUser", ReplyAction="http://tempuri.org/IJSService/InsertUserResponse")]
        bool InsertUser(Trainee_Consultant.ServiceReference1.DbUser[] user, int stream_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/FindUser", ReplyAction="http://tempuri.org/IJSService/FindUserResponse")]
        Trainee_Consultant.ServiceReference1.DbUser[] FindUser(Trainee_Consultant.ServiceReference1.DbUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetUserByUserName", ReplyAction="http://tempuri.org/IJSService/GetUserByUserNameResponse")]
        Trainee_Consultant.ServiceReference1.DbUser[] GetUserByUserName(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/DeleteUser", ReplyAction="http://tempuri.org/IJSService/DeleteUserResponse")]
        bool DeleteUser(Trainee_Consultant.ServiceReference1.DbUser[] user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/CheckAccManagerJobExists", ReplyAction="http://tempuri.org/IJSService/CheckAccManagerJobExistsResponse")]
        Trainee_Consultant.ServiceReference1.DbJob[] CheckAccManagerJobExists(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetOneUser", ReplyAction="http://tempuri.org/IJSService/GetOneUserResponse")]
        string GetOneUser(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/FindUsernameBySessionId", ReplyAction="http://tempuri.org/IJSService/FindUsernameBySessionIdResponse")]
        string FindUsernameBySessionId(System.Guid sessionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/DisplayProfile", ReplyAction="http://tempuri.org/IJSService/DisplayProfileResponse")]
        Trainee_Consultant.ServiceReference1.DbUser DisplayProfile(System.Guid sessionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/UpdateProfile", ReplyAction="http://tempuri.org/IJSService/UpdateProfileResponse")]
        bool UpdateProfile(Trainee_Consultant.ServiceReference1.DbUser alteredUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/AddUserSkill", ReplyAction="http://tempuri.org/IJSService/AddUserSkillResponse")]
        bool AddUserSkill(string skill, int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/RemoveUserSkill", ReplyAction="http://tempuri.org/IJSService/RemoveUserSkillResponse")]
        bool RemoveUserSkill(string skill, int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/InsertJob", ReplyAction="http://tempuri.org/IJSService/InsertJobResponse")]
        bool InsertJob(Trainee_Consultant.ServiceReference1.DbJob job, string[] skills, System.Guid sessionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/InsertSkill", ReplyAction="http://tempuri.org/IJSService/InsertSkillResponse")]
        bool InsertSkill(string skill);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/RecentJobs", ReplyAction="http://tempuri.org/IJSService/RecentJobsResponse")]
        Trainee_Consultant.ServiceReference1.DbJob[] RecentJobs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetJobSkills", ReplyAction="http://tempuri.org/IJSService/GetJobSkillsResponse")]
        string[] GetJobSkills(int jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/UpdateUserIdOfAJob", ReplyAction="http://tempuri.org/IJSService/UpdateUserIdOfAJobResponse")]
        bool UpdateUserIdOfAJob(Trainee_Consultant.ServiceReference1.DbJob[] jobs, int stream_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/UpdateAMJob", ReplyAction="http://tempuri.org/IJSService/UpdateAMJobResponse")]
        bool UpdateAMJob(Trainee_Consultant.ServiceReference1.DbJob[] jobs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/UpdateDeletedJobSkill", ReplyAction="http://tempuri.org/IJSService/UpdateDeletedJobSkillResponse")]
        bool UpdateDeletedJobSkill(Trainee_Consultant.ServiceReference1.DbJob[] jobs, string[] deletedSkills);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/UpdateAddedJobSkill", ReplyAction="http://tempuri.org/IJSService/UpdateAddedJobSkillResponse")]
        bool UpdateAddedJobSkill(Trainee_Consultant.ServiceReference1.DbJob[] jobs, string[] newlyAddedSkills);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/DeleteJob", ReplyAction="http://tempuri.org/IJSService/DeleteJobResponse")]
        bool DeleteJob(Trainee_Consultant.ServiceReference1.DbJob[] jobs, int stream_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/DisplaySkills", ReplyAction="http://tempuri.org/IJSService/DisplaySkillsResponse")]
        string[] DisplaySkills();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJSService/GetStatuses", ReplyAction="http://tempuri.org/IJSService/GetStatusesResponse")]
        string[] GetStatuses();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IJSServiceChannel : Trainee_Consultant.ServiceReference1.IJSService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class JSServiceClient : System.ServiceModel.ClientBase<Trainee_Consultant.ServiceReference1.IJSService>, Trainee_Consultant.ServiceReference1.IJSService {
        
        public JSServiceClient() {
        }
        
        public JSServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public JSServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JSServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JSServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetStreams() {
            return base.Channel.GetStreams();
        }
        
        public string FormatSkill(string skill) {
            return base.Channel.FormatSkill(skill);
        }
        
        public string[] GetTStatuses() {
            return base.Channel.GetTStatuses();
        }
        
        public Trainee_Consultant.ServiceReference1.DbUser[] SearchForConsultants(string stream, string status, string[] skills) {
            return base.Channel.SearchForConsultants(stream, status, skills);
        }
        
        public Trainee_Consultant.ServiceReference1.DbUser GetProfile(int id) {
            return base.Channel.GetProfile(id);
        }
        
        public bool AddComment(int jobId, System.Guid sessionId, string commentText) {
            return base.Channel.AddComment(jobId, sessionId, commentText);
        }
        
        public Trainee_Consultant.ServiceReference1.DbComments[] ViewComments(int jobId) {
            return base.Channel.ViewComments(jobId);
        }
        
        public bool DeleteComment(int commentId) {
            return base.Channel.DeleteComment(commentId);
        }
        
        public int GetUserIdByCommentId(int commentId) {
            return base.Channel.GetUserIdByCommentId(commentId);
        }
        
        public bool InsertFavourite(Trainee_Consultant.ServiceReference1.DbUser[] obj, int job_id) {
            return base.Channel.InsertFavourite(obj, job_id);
        }
        
        public bool DeleteFavourite(Trainee_Consultant.ServiceReference1.DbUser[] obj, int job_id) {
            return base.Channel.DeleteFavourite(obj, job_id);
        }
        
        public Trainee_Consultant.ServiceReference1.DbJob[] GetListOfFavJobs(Trainee_Consultant.ServiceReference1.DbJob job, System.Guid session_id) {
            return base.Channel.GetListOfFavJobs(job, session_id);
        }
        
        public System.Guid Login(string username, string password, string type) {
            return base.Channel.Login(username, password, type);
        }
        
        public System.Guid Login2(string username, string password, string type, string type2) {
            return base.Channel.Login2(username, password, type, type2);
        }
        
        public void Logout(System.Guid sessionId) {
            base.Channel.Logout(sessionId);
        }
        
        public string[] GetUserType() {
            return base.Channel.GetUserType();
        }
        
        public string[] GetStreamList() {
            return base.Channel.GetStreamList();
        }
        
        public int GetNumOfUsers(string firstName, string lastName) {
            return base.Channel.GetNumOfUsers(firstName, lastName);
        }
        
        public bool InsertUser(Trainee_Consultant.ServiceReference1.DbUser[] user, int stream_id) {
            return base.Channel.InsertUser(user, stream_id);
        }
        
        public Trainee_Consultant.ServiceReference1.DbUser[] FindUser(Trainee_Consultant.ServiceReference1.DbUser user) {
            return base.Channel.FindUser(user);
        }
        
        public Trainee_Consultant.ServiceReference1.DbUser[] GetUserByUserName(string username) {
            return base.Channel.GetUserByUserName(username);
        }
        
        public bool DeleteUser(Trainee_Consultant.ServiceReference1.DbUser[] user) {
            return base.Channel.DeleteUser(user);
        }
        
        public Trainee_Consultant.ServiceReference1.DbJob[] CheckAccManagerJobExists(string username) {
            return base.Channel.CheckAccManagerJobExists(username);
        }
        
        public string GetOneUser(int userId) {
            return base.Channel.GetOneUser(userId);
        }
        
        public string FindUsernameBySessionId(System.Guid sessionId) {
            return base.Channel.FindUsernameBySessionId(sessionId);
        }
        
        public Trainee_Consultant.ServiceReference1.DbUser DisplayProfile(System.Guid sessionid) {
            return base.Channel.DisplayProfile(sessionid);
        }
        
        public bool UpdateProfile(Trainee_Consultant.ServiceReference1.DbUser alteredUser) {
            return base.Channel.UpdateProfile(alteredUser);
        }
        
        public bool AddUserSkill(string skill, int userID) {
            return base.Channel.AddUserSkill(skill, userID);
        }
        
        public bool RemoveUserSkill(string skill, int userID) {
            return base.Channel.RemoveUserSkill(skill, userID);
        }
        
        public bool InsertJob(Trainee_Consultant.ServiceReference1.DbJob job, string[] skills, System.Guid sessionid) {
            return base.Channel.InsertJob(job, skills, sessionid);
        }
        
        public bool InsertSkill(string skill) {
            return base.Channel.InsertSkill(skill);
        }
        
        public Trainee_Consultant.ServiceReference1.DbJob[] RecentJobs() {
            return base.Channel.RecentJobs();
        }
        
        public string[] GetJobSkills(int jobId) {
            return base.Channel.GetJobSkills(jobId);
        }
        
        public bool UpdateUserIdOfAJob(Trainee_Consultant.ServiceReference1.DbJob[] jobs, int stream_id) {
            return base.Channel.UpdateUserIdOfAJob(jobs, stream_id);
        }
        
        public bool UpdateAMJob(Trainee_Consultant.ServiceReference1.DbJob[] jobs) {
            return base.Channel.UpdateAMJob(jobs);
        }
        
        public bool UpdateDeletedJobSkill(Trainee_Consultant.ServiceReference1.DbJob[] jobs, string[] deletedSkills) {
            return base.Channel.UpdateDeletedJobSkill(jobs, deletedSkills);
        }
        
        public bool UpdateAddedJobSkill(Trainee_Consultant.ServiceReference1.DbJob[] jobs, string[] newlyAddedSkills) {
            return base.Channel.UpdateAddedJobSkill(jobs, newlyAddedSkills);
        }
        
        public bool DeleteJob(Trainee_Consultant.ServiceReference1.DbJob[] jobs, int stream_id) {
            return base.Channel.DeleteJob(jobs, stream_id);
        }
        
        public string[] DisplaySkills() {
            return base.Channel.DisplaySkills();
        }
        
        public string[] GetStatuses() {
            return base.Channel.GetStatuses();
        }
    }
}
