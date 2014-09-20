using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Track.Framework.Entities
{
    public class UserApplications
    {
        private int _userApplicationID;

        public int UserApplicationID
        {
            get { return _userApplicationID; }
            set { _userApplicationID = value; }
        }
        private int _applicationID;

        public int ApplicationID
        {
            get { return _applicationID; }
            set { _applicationID = value; }
        }
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private Users _user;
        public Users User
        {
            get { return _user; }
            set { _user = value; }
        }

        private Applications _application;
        public Applications Application
        {
            get {
                if(this._applicationID != 0)
                {
                    return ApplicationManager.Instance.GetApplicationByApplicationID(_applicationID);
                }
                return _application; }
            set { _application = value; }
        }
    }
}
