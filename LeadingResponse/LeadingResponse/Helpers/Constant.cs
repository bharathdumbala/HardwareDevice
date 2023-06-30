using LeadingResponse.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;
using Acr.UserDialogs;

namespace LeadingResponse.Helpers
{



    public static class NetWork
    {

        public static bool isNetConnected()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                return false;
            }
            return true;
        }

    }
    public static class Util
    {

        //public static HttpRequestMessage prepareRequestBy(string url)
        //{
        //    HttpRequestMessage httpRequest = new HttpRequestMessage();
        //    httpRequest.RequestUri = new Uri(url);
        //    httpRequest.RequestUri = new Uri(url);
        //    return httpRequest;
        //}

        //public static HttpRequestMessage prepareRequestBy(string url, object obj)
        //{
        //    HttpRequestMessage httpRequest = new HttpRequestMessage();
        //    var json = JsonConvert.SerializeObject(obj);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    httpRequest.RequestUri = new Uri(url);
        //    httpRequest.Content = content;
        //    return httpRequest;
        //}
        public static HttpRequestMessage prepareRequestBy(string url, object obj)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequest.RequestUri = new Uri(url);
            httpRequest.Content = content;
            httpRequest.Headers.Add("username", "admin");
            httpRequest.Headers.Add("password", "Rk2iK4tZm5I3");
            return httpRequest;
        }



        public static void exceptionLog(Exception ex)
        {
            Debug.WriteLine("expectionalHAndler", ex.ToString());
            try
            {
                
                StackTrace trace = new StackTrace(ex, true);
                var frame = trace.GetFrames();
                if (frame != null && frame.Length > 0)
                {
                    var stackFrame = frame.First();
                    Debug.Write("*********** Exception START ***************");
                    Debug.Write("File Name :: " + stackFrame.GetFileName());
                    Debug.Write("Method Name :: " + stackFrame.GetMethod().ReflectedType.FullName);
                    Debug.Write("Line  Number :: " + stackFrame.GetFileLineNumber());
                    Debug.Write("Column Number :: " + stackFrame.GetFileColumnNumber());
                    Debug.Write("Error Details :: " + ex.Message);
                    string innerExp = "";
                    if (ex.InnerException != null)
                    {
                        Debug.Write("Inner Excep Details :: " + ex.InnerException);
                        innerExp = ex.InnerException.ToString();
                    }
                    Debug.Write("*********** Exception End ***************");
                    string tim = DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString();
                    string currVersion = VersionTracking.CurrentVersion;
                    string err = "*********** Exception START *************** \n" +
                        "File Name :: " + stackFrame.GetFileName() + "\n" +
                        "Method Name :: " + stackFrame.GetMethod().ReflectedType.FullName + "\n" +
                        "Line  Number :: " + stackFrame.GetFileLineNumber() + "\n" +
                        "Column Number :: " + stackFrame.GetFileColumnNumber() + "\n" +
                        "Error Details :: " + ex.Message + innerExp + "\n" +
                        "Occured :: " + tim + "\n" +
                        "Version :: " + currVersion + "\n" +
                        "*********** Exception End ***************";

                    Debug.Write("str Error :: " + err);
                }



            }
            catch (Exception exception)
            {
                Console.WriteLine("exceptionLog  Exception :: " + exception);
            }
        }


      public static void startIndicator()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading Please wait...", MaskType.Black);

            }
            catch (Exception ex)
            {
                exceptionLog(ex);
            }


        }

        public static void stopIndicator()
        {
            try
            {

                UserDialogs.Instance.HideLoading();

            }
            catch (Exception ex)
            {
                exceptionLog(ex);
            }
        }

    }

    public static class RestCallUrls
    {
        public static string lrspprinttrack = "api/v1/lrsprinttrack";


    }
}
