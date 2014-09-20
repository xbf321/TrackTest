using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Track.Framework.Entities;

namespace Track.Framework
{
    public class ApplicationManager
    {
        public static ApplicationManager Instance = new ApplicationManager();
        private ApplicationManager() { }
        public Applications GetApplicationByApplicationID(int _applicationID)
        {
            Applications _application = null;
            string strSql = string.Format("SELECT * FROM Applications WHERE ApplicationID = {0}",_applicationID);
            DataRow dr = Goodspeed.Library.Data.SQLPlus.ExecuteDataRow(CommandType.Text,strSql);
            if(dr != null)
            {
                _application = new Applications();
                _application.ApplicationID = _applicationID;
                _application.ApplicationName = dr["ApplicationName"].ToString();
                _application.AssemblyName = dr["AssemblyName"].ToString();
                _application.ClassName = dr["ClassName"].ToString();
                _application.SystemName = dr["SystemName"].ToString();
            }
            return _application;
        }
    }
}
