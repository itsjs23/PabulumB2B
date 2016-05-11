using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Specialized;

namespace DigitalMenu.Common
{
    public class AndroidGCMPushNotification
    {
        public AndroidGCMPushNotification()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //public string SendNotification(string deviceId, string message)
        //{
        //    //string GoogleAppID = "pabulum-2015";
        //    string GoogleAppID = "AIzaSyB5Mr1_Uh_QZyownFGtdJBFbvrVrTO8sM4";
        //    var SENDER_ID = "230925869317";
        //    var value = message;
        //    WebRequest tRequest;
        //    tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
        //    tRequest.Method = "post";
        //    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
        //    tRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));

        //    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
        //    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString()
        //        + "&registration_id=" + deviceId + "";
        //    Console.WriteLine(postData);
        //    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //    tRequest.ContentLength = byteArray.Length;

        //    Stream dataStream = tRequest.GetRequestStream();
        //    dataStream.Write(byteArray, 0, byteArray.Length);
        //    dataStream.Close();

        //    WebResponse tResponse = tRequest.GetResponse();

        //    dataStream = tResponse.GetResponseStream();

        //    StreamReader tReader = new StreamReader(dataStream);

        //    String sResponseFromServer = tReader.ReadToEnd();

        //    tReader.Close();
        //    dataStream.Close();
        //    tResponse.Close();
        //    return sResponseFromServer;
        //}

        //public void SendNotification(string deviceId, string message)
        //{
        //    // your RegistrationID paste here which is received from GCM server.                                                               
        //    string regId = deviceId;
        //    // applicationID means google Api key                                                                                                     
        //    var applicationID = "AIzaSyBjNFw_1Y6W59gTvVaGIrb50NAKwN-LKwQ";
        //    // SENDER_ID is nothing but your ProjectID (from API Console- google code)//                                          
        //    var SENDER_ID = "230925869317";

        //    var value = message; //message text box                                                                               

        //    WebRequest tRequest;

        //    tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");

        //    tRequest.Method = "post";

        //    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";

        //    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

        //    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

        //    //Data post to server                                                                                                                                         
        //    string postData =
        //         "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
        //          + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" +
        //             regId + "";


        //    Console.WriteLine(postData);

        //    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        //    tRequest.ContentLength = byteArray.Length;

        //    Stream dataStream = tRequest.GetRequestStream();

        //    dataStream.Write(byteArray, 0, byteArray.Length);

        //    dataStream.Close();

        //    WebResponse tResponse = tRequest.GetResponse();

        //    dataStream = tResponse.GetResponseStream();

        //    StreamReader tReader = new StreamReader(dataStream);

        //    String sResponseFromServer = tReader.ReadToEnd();   //Get response from GCM server.

        //    string Text = sResponseFromServer;      //Assigning GCM response to Label text 

        //    tReader.Close();

        //    dataStream.Close();
        //    tResponse.Close();
        //}
        //public void SendNotification(string deviceId, string message)
        //{
        //    string RegId = deviceId;
        //    string ApplicationID = "AIzaSyB5Mr1_Uh_QZyownFGtdJBFbvrVrTO8sM4";
        //    string SENDER_ID = "230925869317";
        //    var value = message; //message text box

        //    WebRequest tRequest;
        //    tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest.Method = "post";
        //    tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        //    tRequest.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
        //    //Data post to the Server
        //    string postData =
        //"collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
        // + value + "&data.time=" + System.DateTime.Now.ToString() +
        // "&registration_id=" + RegId + "";
        //    Console.WriteLine(postData);

        //    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //    tRequest.ContentLength = byteArray.Length;
        //    Stream dataStream = tRequest.GetRequestStream();
        //    dataStream.Write(byteArray, 0, byteArray.Length);
        //    dataStream.Close();
        //    WebResponse tResponse = tRequest.GetResponse(); dataStream = tResponse.GetResponseStream();
        //    StreamReader tReader = new StreamReader(dataStream);
        //    String sResponseFromServer = tReader.ReadToEnd();  //Get response from GCM server  
        //    //label_Result.Text = sResponseFromServer; //Assigning GCM response to Label text
        //    tReader.Close(); dataStream.Close();
        //    tResponse.Close();
        //}



        public string SendGCMNotification(string apiKey, string postData, string postDataContentType = "application/json")
        {
            
            
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            //
            //  SEND MESSAGE
            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    var text = "Unauthorized - need new token";
                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    var text = "Response from web service isn't OK";
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {
            }
            return "error";
        }


        public static bool ValidateServerCertificate(
                                                    object sender,
                                                    X509Certificate certificate,
                                                    X509Chain chain,
                                                    SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }



 }

//    AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();

//string strResponse =
//apnGCM.SendNotification("17BA0791499DB908433B80F37C5FBC89B870084B",
//"Test Push Notification message ");


}