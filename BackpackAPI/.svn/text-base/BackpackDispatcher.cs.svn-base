using System;
using System.IO;
using System.Net;
using System.Xml;

namespace jonezy.org.BackpackAPI
{
    public class BackpackDispatcher
    {
        private string _backpackUrl = "http://{0}.backpackit.com/";
        private string _username = string.Empty;
        private string _token = string.Empty;

        public BackpackDispatcher(string username, string token)
        {
            _backpackUrl = String.Format(_backpackUrl, username);
            _username = username;
            _token = token;
        }

        public XmlDocument ExecuteRequest(string serviceUrl)
        {
            return ExecuteRequest(serviceUrl, null);
        }

        public XmlDocument ExecuteRequest(string serviceUrl, XmlNode requestBody)
        {
            return ExecuteRequest(serviceUrl, "", null);
        }

        public XmlDocument ExecuteRequest(string serviceUrl, string requestMethod, XmlNode requestBody)
        {
            WebRequest req = null;
            WebResponse res = null;
            string url = String.Empty;
            
            url = String.Format("{0}{1}", this._backpackUrl, serviceUrl);

            try
            {
                req = DoRequest(url, requestMethod, requestBody);
                res = req.GetResponse();
            }
            catch (System.Net.WebException)
            {
                //#TODO - figure out a strategy for handling 404 errors and returning something useful, maybe build a custom 404 xml documnet
                return BuildErrorXml();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return ProcessResponse(res);
        }


        /// <summary>
        /// To do:
        /// handle the get, post, put, delete scenarios better.
        /// </summary>
        /// <param name="url">url to send the request to</param>
        /// <param name="requestMethod">method to use when sending the request (GET, POST, PUT, DELETE)</param>
        /// <param name="requestBody">Xml node with any custom request details</param>
        /// <returns></returns>
        private WebRequest DoRequest(string url, string requestMethod, XmlNode requestBody)
        {
            bool requiresRequestToken = true;
            WebRequest webRequest = WebRequest.Create(url);
            XmlDocument xmlRequestDocument = new XmlDocument();
            XmlDocument xmlPayloadDocument = new XmlDocument();
            string requestXml = string.Empty;

            // populate the request xml with authentication token
            xmlRequestDocument.AppendChild(xmlRequestDocument.ImportNode(this.BuildAuthenticationToken(), true));

            if (requestMethod == "GET" || requestMethod == "DELETE" || ((requestMethod == "POST" || requestMethod == "PUT") && url.Contains(".xml")))
                requiresRequestToken = false;

            // if we require the authentication node and we have custome request details, append custom request details.
            if (requiresRequestToken && requestBody != null)
                xmlRequestDocument.SelectSingleNode("/request").AppendChild(xmlRequestDocument.ImportNode(requestBody, true));

            // build the request string to pass to the web service
            if (requiresRequestToken)
                requestXml = xmlRequestDocument.SelectSingleNode("/").InnerXml;
            else if (requestBody != null)
                requestXml = requestBody.OuterXml; // changed to outerxml to get ready for Backpack Objects

            webRequest.Method = requestMethod == "" ? "POST" : requestMethod;

            if(requestMethod != "GET" && requestMethod != "DELETE")
            {
                // build the request
                webRequest.Headers.Add("X-POST_DATA_FORMAT", "xml");
                webRequest.ContentType = "application/xml";
                
                webRequest.ContentLength = requestXml.Length;

                // write the request token to the stream
                StreamWriter writer = new StreamWriter(webRequest.GetRequestStream());
                writer.Write(requestXml);
                writer.Close();
            }

            return webRequest;
        }

        private XmlDocument ProcessResponse(WebResponse webResponse)
        {
            Stream dataStream = null;
            StreamReader streamReader = null;
            XmlDocument xmlResults = new XmlDocument();

            try
            {
                dataStream = webResponse.GetResponseStream();
                streamReader = new StreamReader(dataStream);
                xmlResults.Load(streamReader);
            }
            catch (System.Xml.XmlException)
            {
                // some of these methods don't return xml (god knows why) need to build a special response here or something
                return BuildResponseXml(webResponse.Headers, webResponse.ResponseUri);
            }

            return xmlResults;
        }

        private XmlNode BuildAuthenticationToken()
        {
            Token token = new Token();
            token.AuthenticationToken = this._token;

            return token.ToXml().SelectSingleNode("/request");
        }

        private XmlDocument BuildErrorXml()
        {
            XmlDocument errorXml = new XmlDocument();
            XmlElement responseEl = errorXml.CreateElement("response");
            XmlElement errorEl = errorXml.CreateElement("error");

            responseEl.SetAttribute("success", "false");
            errorEl.SetAttribute("code", "404");
            errorEl.InnerText = "Record not found";

            responseEl.AppendChild(errorEl);
            errorXml.AppendChild(responseEl);

            return errorXml; // root
        }

        private XmlDocument BuildResponseXml(WebHeaderCollection headers, Uri responseUri)
        {
            XmlDocument successXml = new XmlDocument();
            XmlElement responseEl = successXml.CreateElement("response");
            XmlElement statusEl = successXml.CreateElement("status");

            string[] status = headers["Status"].Split(' ');

            statusEl.SetAttribute("code", status[0].ToString());
            if (headers["Location"] != null)
                statusEl.SetAttribute("location", headers["Location"].ToString());
            statusEl.InnerText = status[1].ToString().ToLower();

            responseEl.AppendChild(statusEl);
            successXml.AppendChild(responseEl);

            return successXml; // root
        }
               
    }
}
