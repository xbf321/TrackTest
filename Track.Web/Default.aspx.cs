using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 我的首页，显示好友的Track
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.gvTrack.DataSource = Track.Framework.TrackRules.Instance.GetFriendsTrackByUserID(1,10);
        this.gvTrack.DataBind();
    }
    /// <summary>
    /// 好友的首页，显示他自己的Track
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.gvTrack.DataSource = Track.Framework.TrackRules.Instance.GetTrackByUserID(2,10);
        this.gvTrack.DataBind();
    }
}
