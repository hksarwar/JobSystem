using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class ConnectionString
    {
        string host = "oracle.fdmgroup.com";
        string port = "1521";
        string oracleServiceName = "XE";
        string username = "hinnahsarwar";
        string password = "tigress";

        private void SetHinnahConnString()
        {
            username = "hinnahsarwar";
            password = "tigress";
        }

        private void SetHannahConnString()
        {
            username = "hannahwilliams";
            password = "Eddies230686";
        }

        private void SetKimConnString()
        {
            username = "kimberleyjackson";
            password = "KJ48xc5R";
        }

        public string GetConnString()
        {
            SetHinnahConnString();
            string cnString = @"Provider = OraOLEDB.Oracle; OLEDBNet=True; PLSQLRSet=true;
                                Data Source = (DESCRIPTION = (CID = GTU_APP)(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)
                    (HOST = " + host + ")(PORT = " + port + ")))(CONNECT_DATA = (Service name = " + oracleServiceName +
                              ")(SERVER = DEDICATED))); User Id = " + username + "; Password = " + password + ";";
            return cnString;
        }
    }
}
