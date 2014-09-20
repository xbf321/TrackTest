using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Track.Framework.Entities
{
    public class Tracks
    {
        private int _trackID;

        public int TrackID
        {
            get { return _trackID; }
            set { _trackID = value; }
        }
        private int _userApplicationID;

        public int UserApplicationID
        {
            get { return _userApplicationID; }
            set { _userApplicationID = value; }
        }
        private int _trackType;

        public int TrackType
        {
            get { return _trackType; }
            set { _trackType = value; }
        }
        private string _trackContent;

        public string TrackContent
        {
            get { return _trackContent; }
            set { _trackContent = value; }
        }
        private DateTime _trackDateTime;

        public DateTime TrackDateTime
        {
            get { return _trackDateTime; }
            set { _trackDateTime = value; }
        }
        private UserApplications _userApplication;
        public UserApplications UserApplication
        {
            get {
                if(this._userApplicationID != 0)
                {
                    return UserApplicationManager.Instance.GetUserApplicationByUserApplicationID(_userApplicationID);
                }
                return _userApplication; }
            set {
                _userApplication = value;
            }
        }
    }
}
