using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI
{
    public class UserService : BackpackBase, IUserService
    {

        public UserService(string username, string token)
            : base (username, token)
        {
        }

        #region IUserService Members

        public System.Xml.XmlDocument List()
        {
            return bpDispatcher.ExecuteRequest(String.Format("{0}/users.xml", this._token));
        }

        public System.Xml.XmlDocument Show(string userId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("{0}/users/{1}.xml", this._token, userId));
            
        }

        #endregion
    }
}
