using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Track.Framework.Entities;
using System.Data;

namespace Track.Framework
{
    public class UserApplicationManager
    {
        public static UserApplicationManager Instance = new UserApplicationManager();
        private UserApplicationManager() { }
        public UserApplications GetUserApplicationByUserApplicationID(int _userApplicationID)
        {
            UserApplications _userApplication = null;
            string strSql = string.Format("SELECT * FROM UserApplications WHERE UserApplicationID = {0}",_userApplicationID);
            DataRow dr = Goodspeed.Library.Data.SQLPlus.ExecuteDataRow(CommandType.Text,strSql);
            if(dr != null)
            {
                _userApplication = new UserApplications();
                _userApplication.UserApplicationID = _userApplicationID;
                _userApplication.ApplicationID = Convert.ToInt32(dr["ApplicationID"]);
                _userApplication.UserID = Convert.ToInt32(dr["UserID"]);
            }
            return _userApplication;
        }
    }
}
