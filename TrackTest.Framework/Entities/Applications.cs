using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Track.Framework.Entities
{
    public class Applications
    {
        private int _applicationID;

        public int ApplicationID
        {
            get { return _applicationID; }
            set { _applicationID = value; }
        }
        private string _applicationName;

        public string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }
        private string _systemName;

        public string SystemName
        {
            get { return _systemName; }
            set { _systemName = value; }
        }
        private string _assemblyName;

        public string AssemblyName
        {
            get { return _assemblyName; }
            set { _assemblyName = value; }
        }
        private string _className;

        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }
    }
}
