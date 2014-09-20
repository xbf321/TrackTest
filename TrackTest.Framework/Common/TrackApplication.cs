using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Track.Framework
{
    public abstract class TrackApplication
    {
        public TrackApplication()
        {
        }

        public abstract string GetTrackText(int type, string[] parameters);
    }
}
