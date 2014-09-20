using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Track.Framework.Entities
{
    public class Users
    {
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
    }
}
