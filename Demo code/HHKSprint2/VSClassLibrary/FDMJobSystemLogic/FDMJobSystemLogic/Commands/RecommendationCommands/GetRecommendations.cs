using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class GetRecommendations : IGetRecommendations
    {
        public List<DbRecommendation> Execute(Guid sessionID)
        {
            DbRecommendation rec = new DbRecommendation();
            FindUser find = new FindUser();
            int userId = int.Parse(find.GetUserIDBySessionId(sessionID).ToString());

            string qry = "SELECT FDMUSER.firstname ||' '|| FDMUSER.lastname AS Name FROM FDMUSER JOIN RECOMMENDATIONS ON RECOMMENDATIONS.recomender_id = FDMUSER.user_id WHERE RECOMMENDATIONS.recomender_id = " + userId;
            IReadOneCommand cmd = new ReadOneCommand();
            rec.Recommender = cmd.Execute(qry);

            string qry2 = "SELECT FDMUSER.firstname ||' '|| FDMUSER.lastname AS Name, JOBPOST.title, JOBPOST.job_id, recommendations.reason FROM FDMUSER JOIN RECOMMENDATIONS ON RECOMMENDATIONS.recomendee_id = FDMUSER.user_id JOIN JOBPOST ON RECOMMENDATIONS.job_id = JOBPOST.job_id WHERE RECOMMENDATIONS.recomender_id = " + userId;
            IReadCommand cmd2 = new ReadCommand();
            DataTable dt = cmd2.Execute(qry2);
            List<DbRecommendation> recPeople = new List<DbRecommendation>(dt.Rows.Count);

            recPeople = (from DataRow row in dt.Rows

                       select new DbRecommendation
                       {
                           Recommended = row["NAME"].ToString(),
                           JobTitle = row["TITLE"].ToString(),
                           JobID = int.Parse(row["JOB_ID"].ToString()),
                           Reason = row["REASON"].ToString()
                       }).ToList();

            return recPeople;
        }
    }
}
