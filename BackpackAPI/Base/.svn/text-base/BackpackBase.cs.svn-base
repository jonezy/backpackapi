using System;
using System.Collections.Generic;
using System.Text;

namespace jonezy.org.BackpackAPI
{
    public abstract class BackpackBase
    {
        public BackpackDispatcher bpDispatcher = null;
        public string _username = string.Empty;
        public string _token = string.Empty;

        public BackpackBase(string username, string token)
        {
            Setup(username, token);
        }

        public void Setup(string username, string token)
        {
            this._username = username;
            this._token = token;
            this.bpDispatcher = new BackpackDispatcher(this._username, this._token);
        }
    }
}
