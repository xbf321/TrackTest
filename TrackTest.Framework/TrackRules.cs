using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Track.Framework.Entities;
using System.Runtime.Remoting;
using System.Reflection;

namespace Track.Framework
{
    public class TrackRules
    {
        public static TrackRules Instance = new TrackRules();
        private TrackRules() { }
        /// <summary>
        /// 我去看好友的首页，显示他自己的Track
        /// </summary>
        /// <param name="_userID"></param>
        /// <param name="_count"></param>
        /// <returns></returns>
        public DataTable GetTrackByUserID(int _userID, int _count)
        {
            return null;
        }
        /// <summary>
        /// 我进入我的首页，显示好友的Track
        /// </summary>
        /// <param name="_currentUserID"></param>
        /// <param name="_count"></param>
        /// <returns></returns>
        public IList<TrackInfo> GetFriendsTrackByUserID(int _currentUserID, int _count)
        {
            IList<TrackInfo> listTrackInfo = new List<TrackInfo>();
            TrackInfo _trackInfo = null;
            Tracks _track = null;
            string strSql = string.Format(@"WITH FriendInfo AS
                                (
                                    SELECT u.UserID,u.UserName FROM Friends AS f INNER JOIN Users AS u ON f.FriendID = u.UserID  WHERE f.UserID = {0} AND f.IsAccepted = 1
                                )
                              SELECT f.UserID,f.UserName,up.UserApplicationID,t.TrackType,t.TrackContent,t.TrackDateTime FROM FriendInfo As f INNER JOIN UserApplications As up ON f.UserID = up.UserID INNER JOIN Tracks AS t ON up.UserApplicationID = t.UserApplicationID ORDER BY t.TrackDateTime DESC",_currentUserID);
            SqlParameter[] parms = {
                                        new SqlParameter("@UserID",SqlDbType.Int)
                                   };
            parms[0].Value = _currentUserID;
            DataTable dt = Goodspeed.Library.Data.SQLPlus.ExecuteDataTable(CommandType.Text,strSql,parms);
            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    _track = new Tracks();
                    _track.UserApplicationID = Convert.ToInt32(dr["UserApplicationID"]);
                    _track.TrackType = Convert.ToInt32(dr["TrackType"]);
                    _track.TrackContent = dr["TrackContent"].ToString();
                    _track.TrackDateTime = Convert.ToDateTime(dr["TrackDateTime"]);

                    _trackInfo = new TrackInfo();
                    _trackInfo.UserID = Convert.ToInt32(dr["UserID"]);
                    _trackInfo.UserFullName = dr["UserName"].ToString();
                    _trackInfo.TrackText = GetTrackText(_track);
                    _trackInfo.TrackDateTime = Convert.ToDateTime(dr["TrackDateTime"]);

                    listTrackInfo.Add(_trackInfo);

                    
                }
                
            }

            return listTrackInfo;
        }
        private string GetTrackText(Tracks _track)
        {
            TrackApplication application = TrackAppPool.Instance.GetApplication(
               _track.UserApplication.Application.AssemblyName,
               _track.UserApplication.Application.ClassName);
            if (application != null)
            {
                string[] parameters = _track.TrackContent.Split(new string[] { "#####" }, StringSplitOptions.None);
                return application.GetTrackText(_track.TrackType, parameters);
            }
            return "";
        }
    }
    public class TrackInfo
    {
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private string _userFullName;

        public string UserFullName
        {
            get { return _userFullName; }
            set { _userFullName = value; }
        }
        private string _trackText;

        public string TrackText
        {
            get { return _trackText; }
            set { _trackText = value; }
        }
        private DateTime _trackDateTime;

        public DateTime TrackDateTime
        {
            get { return _trackDateTime; }
            set { _trackDateTime = value; }
        }
    }
    public class TrackAppPool
    {
        public static TrackAppPool Instance = new TrackAppPool();
        private Dictionary<string, TrackApplication> m_AppPool = new Dictionary<string, TrackApplication>();
        private TrackAppPool() { }
        public TrackApplication GetApplication(Type applicationType)
        {
            return GetApplication(applicationType.Assembly.FullName, applicationType.FullName);
        }

        public TrackApplication GetApplication(string assemblyName, string className)
        {
            string key = assemblyName + "*" + className;
            if (!m_AppPool.ContainsKey(key))
            {
                ObjectHandle o = Activator.CreateInstance(assemblyName, className);
                TrackApplication applicationObject = o.Unwrap() as TrackApplication;
                m_AppPool.Add(key, applicationObject);
                return applicationObject;
            }
            else
            {
                return m_AppPool[key];
            }
        }
    }
}
