using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FDMJobSystemLogic
{
    public class JSService : IJSService
    {
        #region Login/Logout
        ILoginCommand login = new LoginCommand();

        public Guid Login(string username, string password, string type)
        {
            return login.VerifyDetails(username, password, type);
        }

        public Guid Login2(string username, string password, string type, string type2)
        {
            return login.VerifyDetails(username, password, type, type2);
        }

        public void Logout(Guid sessionId)
        {
            login.TerminateSession(sessionId);
        }

        #endregion

        #region User
        public IList<string> GetUserType()
        {
            SearchGetUserType userType = new SearchGetUserType();
            return userType.Execute();
        }

        public IList<string> GetStreamList()
        {
            SearchGetStream stream = new SearchGetStream();
            return stream.Execute();
        }

        public int GetNumOfUsers(string firstName, string lastName)
        {
            FindUser user = new FindUser();
            return user.NumOfUsers(firstName, lastName);
        }

        public bool InsertUser(List<DbUser> user, int stream_id)
        {
            InsertUser insUser = new InsertUser();
            return insUser.GetCommand(user, stream_id);
        }

        public List<DbUser> FindUser(DbUser user)
        {
            FindUser userDetails = new FindUser();
            return userDetails.Execute(user);
        }

        public List<DbUser> GetUserByUserName(string username)
        {
            FindUser user = new FindUser();
            return user.Execute(username);
        }

        //Delete User need implementation
        public bool DeleteUser(List<DbUser> user)
        {
            DeleteUser deluser = new DeleteUser();
            return deluser.GetCommand(user, 0);
        }
        
        public List<DbJob> CheckAccManagerJobExists(string username)
        {
            DeleteUser delUser = new DeleteUser();
            return delUser.CheckJobExists(username);
        }

        public string GetOneUser(int userId)
        {
            GetOneUser oneUser = new GetOneUser();
            return oneUser.Read(userId);
        }

        public string FindUsernameBySessionId(Guid sessionId)
        {
            FindUser findUser = new FindUser();
            return findUser.GetUsernameBySessionId(sessionId);
        }

        public List<string> GetUserSkills(int userId)
        {
            GetUserSkills uSkills = new GetUserSkills();
            return uSkills.Execute(userId);
        }

        public bool GetForgottenPassword(string username)
        {
            ForgottenPassword pswd = new ForgottenPassword();
            return pswd.EmailPassword(username);
        }

        public bool UpdatePassword(DbUser user)
        {
            EditPassword pswd = new EditPassword();
            return pswd.Execute(user);
        }

        public List<string> GetUserNamesForAutoFill()
        {
            FindUser usernames = new FindUser();
            return usernames.Execute();
        }

        public List<DbUser> GetAvailableConsultants(string stream)
        {
            FindUser find = new FindUser();
            return find.GetConsultants(stream);
        }

        public List<string> GetUserLocsForAutoFill()
        {
            UserLocForAutoFill locList = new UserLocForAutoFill();
            return locList.Execute();
        }

        #region Profile

        public DbUser DisplayProfile(Guid sessionid)
        {
            UserProfile profile = new UserProfile();
            FindUser find = new FindUser();
            int id = int.Parse(find.GetUserIDBySessionId(sessionid));
            DbUser user = profile.GetUserDetails(id);
            return user;
        }

        public bool UpdateProfile(DbUser alteredUser)
        {
            EditProfile profile = new EditProfile();
            bool updated = profile.Execute(alteredUser);
            return updated;
        }

        public bool AddUserSkill(string skill, int userID)
        {
            InsertUserSkill ins = new InsertUserSkill();
            //for (int i = 0; i < skill.Count; i++)
            //{
            if (ins.GetCommand(skill, userID))
            {
                return true;
            }
            //}
            else
            {
                return false;
            }
        }

        public bool RemoveUserSkill(string skill, int userID)
        {
            DeleteUserSkill del = new DeleteUserSkill();
            //for (int i = 0; i < skill.Count; i++)
            //{
            if (del.GetCommand(skill, userID))
            {
                return true;
            }
            //}
            else
            {
                return false;
            }
        }

        #endregion
        #endregion

        #region Job
        public bool InsertJob(DbJob job, List<string> skills, Guid sessionid)
        {
            InsertJob insJob = new InsertJob();
            return insJob.GetCommand(job, skills, sessionid);
        }

        public bool InsertSkill(string skill)
        {
            InsertSkill insSkill = new InsertSkill();
            return insSkill.GetCommand(skill);
        }

        public List<DbJob> RecentJobs(string stream)
        {
            RecentJobs recJobs = new RecentJobs();
            recJobs.SetStringStream(stream);
            return recJobs.Execute();
        }

        public string DetermineUserStream(int user_id)
        {
            RecentJobs recJobs = new RecentJobs();
            return recJobs.GetUserStream(user_id);
        }

        public List<string> GetJobSkills(int jobId)
        {
            GetJobSkills jobSkills = new GetJobSkills();
            return jobSkills.Execute(jobId);
        }

        public bool UpdateUserIdOfAJob(List<DbJob> jobs, int stream_id)
        {
            UpdateJob upJob = new UpdateJob();
            return upJob.GetCommand(jobs, stream_id);
        }

        public bool UpdateAMJob(List<DbJob> jobs)
        {
            UpdateJob upJob = new UpdateJob();
            return upJob.GetCommand(jobs);
        }

        public bool UpdateDeletedJobSkill(List<DbJob> jobs, List<string> deletedSkills)
        {
            UpdateJob upJob = new UpdateJob();
            return upJob.GetCommand(jobs, deletedSkills);
        }

        public bool UpdateAddedJobSkill(List<DbJob> jobs, List<string> newlyAddedSkills)
        {
            UpdateJob upJob = new UpdateJob();
            return upJob.addNewSkills(jobs[0].JobId, newlyAddedSkills);
        }

        public bool DeleteJob(List<DbJob> jobs, int stream_id)
        {
            DeleteJob delJob = new DeleteJob();
            return delJob.GetCommand(jobs, stream_id);
        }

        public List<string> GetAvailableCompanyNames()
        {
            GetCompanyForAutoFill comp = new GetCompanyForAutoFill();
            return comp.Execute();
        }

        public List<string> GetAvailableLocNames()
        {
            GetLocationForAutoFill loc = new GetLocationForAutoFill();
            return loc.Execute();
        }

        public DbJob GetOneJob(int jobID)
        {
            IRetrieveJobDetails job = new RetrieveJobDetails();
            return job.GetDetails(jobID);
        }
        #endregion

        #region Options
        public List<string> DisplaySkills()
        {
            GetSkills skills = new GetSkills();
            return skills.Execute();
        }

        public List<string> GetStatuses()
        {
            IGetOptions opts = new GetOptions();
            return opts.GetStatuses();
        }

        public List<string> GetStreams()
        {
            IGetOptions opts = new GetOptions();
            return opts.GetStreams();
        }

        public string FormatSkill(string skill)
        {
            InsertSkill insSkill = new InsertSkill();
            return insSkill.FormatSkill(skill);

        }

        public List<string> GetTStatuses()
        {
            IGetOptions opts = new GetOptions();
            return opts.GetTStatuses();
        }

        public List<string> GetLocation()
        {
            IGetOptions opts = new GetOptions();
            return opts.GetLocations();
        }

        public List<string> GetCompanies()
        {
            IGetOptions opts = new GetOptions();
            return opts.GetCompanies();
        }

        #endregion

        # region Search
        #region Search for Consultants

        public List<DbUser> SearchForConsultants(string stream, string status, List<string> skills)
        {
            ISearch search = new SearchConsultants();
            List<DbUser> users = search.Search(stream, status, skills);
            return users;
        }

        public DbUser GetProfile(int id)
        {
            UserProfile profile = new UserProfile();
            DbUser user = profile.GetUserDetails(id);
            return user;
        }

        public bool SendUserEmail(DbEmail email)
        {
            ISendEmail mail = new SendComInteropEmail();
            return mail.SendMail(email);
        }

        #endregion

        #region Search for Jobs
        public List<DbJob> SearchForJobs(string stream, string status, string location, string company, List<string> skills)
        {
            ISearchJob searchJob = new SearchJobs();
            List<DbJob> jobs = searchJob.Search(stream, status, location, company, skills);
            return jobs;
        }

        #endregion

        #endregion

        #region Comments

        public bool AddComment(int jobId, Guid sessionId, string commentText)
        {
            InsertComment insComment = new InsertComment();
            return insComment.GetCommand(jobId, sessionId, commentText);
        }

        public List<DbComments> ViewComments(int jobId)
        {
            ViewComments viewCom = new ViewComments();
            return viewCom.Execute(jobId);
        }

        public bool DeleteComment(int commentId)
        {
            DeleteComment delComment = new DeleteComment();
            return delComment.GetCommand(commentId);
        }

        public int GetUserIdByCommentId(int commentId)
        {
            GetUserIdComment getUser = new GetUserIdComment();
            return getUser.GetUserIdByCommentId(commentId);
        }

        #endregion

        #region FavouriteJobs
        public bool InsertFavourite(List<DbUser> obj, int job_id)
        {
            InserFav insFav = new InserFav();
            return insFav.GetCommand(obj, job_id);
        }

        public bool DeleteFavourite(List<DbUser> obj, int job_id)
        {
            DelFav delFav = new DelFav();
            return delFav.GetCommand(obj, job_id);
        }

        public List<DbJob> GetListOfFavJobs(DbJob job, Guid session_id)
        {
            GetFav getFav = new GetFav();
            getFav.setSessionId(session_id);
            return getFav.Execute(job);
        }
        #endregion

        #region Recommended People

        public List<DbRecommendation> RetreiveRecommendations(Guid sessionID)
        {
            IGetRecommendations rec = new GetRecommendations();
            return rec.Execute(sessionID);
        }

        public bool AddRecommendation(int recommender_id, int recommended_id, int job_id, string reason)
        {
            InsertRecommendation rec = new InsertRecommendation();
            return rec.GetCommand(recommender_id, recommended_id, job_id, reason);
        }

        public DbJob FindJob(int jobId)
        {
            RecentJobs jobs = new RecentJobs();
            return jobs.GetJob(jobId);
        }

        #endregion
    }
}
