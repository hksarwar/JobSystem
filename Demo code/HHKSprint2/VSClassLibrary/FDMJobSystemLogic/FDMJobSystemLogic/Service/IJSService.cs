using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.ServiceModel;
using System.ServiceModel.Web;

namespace FDMJobSystemLogic
{
    [ServiceContract]
    public interface IJSService
    {
        #region Login/Logout
        [OperationContract]
        [WebGet]
        Guid Login(string username, string password, string type);

        [OperationContract]
        [WebGet]
        Guid Login2(string username, string password, string type, string type2);

        [OperationContract]
        [WebGet]
        void Logout(Guid sessionId);

        #endregion

        #region User
        [OperationContract]
        [WebGet]
        IList<string> GetUserType();

        [OperationContract]
        [WebGet]
        IList<string> GetStreamList();

        [OperationContract]
        [WebGet]
        int GetNumOfUsers(string firstName, string lastName);

        [OperationContract]
        [WebGet]
        bool InsertUser(List<DbUser> user, int stream_id);

        [OperationContract]
        [WebGet]
        List<DbUser> FindUser(DbUser user);

        [OperationContract]
        [WebGet]
        List<DbUser> GetUserByUserName(string username);


        [OperationContract]
        [WebGet]
        bool DeleteUser(List<DbUser> user);

        [OperationContract]
        [WebGet]
        List<DbJob> CheckAccManagerJobExists(string username);

        [OperationContract]
        [WebGet]
        string GetOneUser(int userId);

        [OperationContract]
        [WebGet]
        string FindUsernameBySessionId(Guid sessionId);


        [OperationContract]
        [WebGet]
        bool AddUserSkill(string skill, int userID);

        [OperationContract]
        [WebGet]
        bool RemoveUserSkill(string skill, int userID);


        [OperationContract]
        [WebGet]
        List<string> GetUserSkills(int userId);

        [OperationContract]
        [WebGet]
        bool GetForgottenPassword(string username);


        [OperationContract]
        [WebGet]
        bool UpdatePassword(DbUser user);

        [OperationContract]
        [WebGet]
        List<string> GetUserNamesForAutoFill();


        [OperationContract]
        [WebGet]
        List<string> GetUserLocsForAutoFill();

        #region Profile
        [OperationContract]
        [WebGet]
        DbUser DisplayProfile(Guid sessionid);

        [OperationContract]
        [WebGet]
        bool UpdateProfile(DbUser alteredUser);


        #endregion
        #endregion

        #region Job
        [OperationContract]
        [WebGet]
        bool InsertJob(DbJob job, List<string> skills, Guid sessionid);

        [OperationContract]
        [WebGet]
        bool InsertSkill(string skill);

        [OperationContract]
        [WebGet]
        List<DbJob> RecentJobs(string stream);

        [OperationContract]
        [WebGet]
        List<string> GetJobSkills(int jobId);

        [OperationContract]
        [WebGet]
        string DetermineUserStream(int user_id);

        [OperationContract]
        [WebGet]
        bool UpdateUserIdOfAJob(List<DbJob> jobs, int stream_id);
        
        [OperationContract]
        [WebGet]
        bool UpdateAMJob(List<DbJob> jobs);
        
        [OperationContract]
        [WebGet]
        bool UpdateDeletedJobSkill(List<DbJob> jobs, List<string> deletedSkills);

        [OperationContract]
        [WebGet]
        bool UpdateAddedJobSkill(List<DbJob> jobs, List<string> newlyAddedSkills);

        [OperationContract]
        [WebGet]
        bool DeleteJob(List<DbJob> jobs, int stream_id);

        [OperationContract]
        [WebGet]
        List<string> GetAvailableCompanyNames();

        [OperationContract]
        [WebGet]
        List<string> GetAvailableLocNames();

        [OperationContract]
        [WebGet]
        List<DbUser> GetAvailableConsultants(string stream);

        [OperationContract]
        [WebGet]
        DbJob GetOneJob(int jobID);
        #endregion

        #region Options

        [OperationContract]
        [WebGet]
        List<string> DisplaySkills();

        [OperationContract]
        [WebGet]
        List<string> GetStatuses();

        [OperationContract]
        [WebGet]
        List<string> GetStreams();

        [OperationContract]
        [WebGet]
        string FormatSkill(string skill);

        [OperationContract]
        [WebGet]
        List<string> GetTStatuses();

        [OperationContract]
        [WebGet]
        List<string> GetCompanies();

        [OperationContract]
        [WebGet]
        List<string> GetLocation();
        #endregion

        #region Search for Consultants
        [OperationContract]
        [WebGet]
        List<DbUser> SearchForConsultants(string stream, string status, List<string> skills);

        [OperationContract]
        [WebGet]
        DbUser GetProfile(int id);

        [OperationContract]
        [WebGet]
        bool SendUserEmail(DbEmail email);

        #endregion

        #region Search for jobs
        [OperationContract]
        [WebGet]
        List<DbJob> SearchForJobs(string stream, string status, string location, string company, List<string> skills);
        #endregion

        #region Comments

        [OperationContract]
        [WebGet]
        bool AddComment(int jobId, Guid sessionId, string commentText);

        [OperationContract]
        [WebGet]
        List<DbComments> ViewComments(int jobId);

        [OperationContract]
        [WebGet]
        bool DeleteComment(int commentId);

        [OperationContract]
        [WebGet]
        int GetUserIdByCommentId(int commentId);

        #endregion

        #region FavouriteJobs
        [OperationContract]
        [WebGet]
        bool InsertFavourite(List<DbUser> obj, int job_id);


        [OperationContract]
        [WebGet]
        bool DeleteFavourite(List<DbUser> obj, int job_id);

        [OperationContract]
        [WebGet]
        List<DbJob> GetListOfFavJobs(DbJob job, Guid session_id);
        #endregion

        #region RecommendedPeople
        [OperationContract]
        [WebGet]
        List<DbRecommendation> RetreiveRecommendations(Guid sessionID);

        [OperationContract]
        [WebGet]
        bool AddRecommendation(int recommender_id, int recommended_id, int job_id, string reason);

        [OperationContract]
        [WebGet]
        DbJob FindJob(int jobId);
        #endregion
    }
}
