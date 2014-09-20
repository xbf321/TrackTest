namespace Track.App
{
    public class FriendApp:Track.Framework.TrackApplication
    {
        public override string GetTrackText(int type, string[] parameters)
        {
            string result = "";
            switch (type)
            {
                //case 0:
                //    for (int i = 0; i < parameters.Length; i = i + 2)
                //    {
                //        result += string.Format("<a href='{0}'>{1}</a> ",
                //            //FrienDevAppPool.Instance.GetApiHelper().GetUserHomepageLink(parameters[i]), parameters[i + 1]);
                //    }
                //    result = string.Concat("与 ", result, "成为好友");
                //    break;
                case 1:
                    result = string.Format("<a style='vertical-align:middle;' href='{0}'><img border='0' alt='' src='{1}'></a> ",
                    parameters[0], parameters[1]);
                    result = string.Concat("更改了头像 " + result + " 快去看看吧~");
                    break;
                case 2:
                    result = "修改了个人基本信息，快去看看吧！";
                    break;
                case 3:
                    result = "修改了个人详细信息，快去看看吧！";
                    break;
                case 4:
                    result = "修改了个人联系方式，快去看看吧！";
                    break;
            }
            return result;
        }
    }
}
