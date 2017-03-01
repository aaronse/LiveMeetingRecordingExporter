using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Microsoft.LiveMeeting.RecordingExporter
{
    public class XmlApiClient
    {
        public static XmlDocument PostMessageRequest(XmlDocument requestXml)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            XmlDocument replyXml = null;

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(Config.PostingURL);
            webReq.Method = "POST";
            webReq.ContentType = "application/xml";

            HttpWebResponse webResp = null;
            try
            {
                byte[] byteArray = encoder.GetBytes(requestXml.OuterXml);
                webReq.ContentLength = byteArray.Length;
                Stream reqStream = webReq.GetRequestStream();
                reqStream.Write(byteArray, 0, byteArray.Length);
                reqStream.Close();

                // Get the response from the conference center
                webResp = (HttpWebResponse)webReq.GetResponse();
                Stream respStream = webResp.GetResponseStream();
                if (webResp.ContentType == "application/xml")
                {
                    replyXml = new XmlDocument();
                    replyXml.Load(respStream);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: {0}\nStack trace: {1}", e.Message, e.StackTrace);
            }
            finally
            {
                if (webResp != null)
                    webResp.Close();
            }

            return replyXml;
        }
    }
}
