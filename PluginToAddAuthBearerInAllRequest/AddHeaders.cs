//This plugin is to pass the dynamic token to all API. Created by :Anuj, date:17-06-15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System.ComponentModel;

namespace PluginToAddAuthBearerInAllRequest
{

    [DisplayName("Add Header")]
    [Description("Adds headers to each request")]
    //String[] Authorization =new string[];
 /*   public class AddHeaders : WebTestPlugin
    {
        public override void PreRequestDataBinding(object sender, PreRequestDataBindingEventArgs e)
        {
            e.Request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IklkVG9rZW5TaWduaW5nS2V5Q29udGFpbmVyIn0.eyJleHAiOjE0MzUyMzIxMDIsIm5iZiI6MTQzNTIyODUwMiwidmVyIjoiMS4wIiwiaXNzIjoiaHR0cHM6Ly9sb2dpbi5taWNyb3NvZnRvbmxpbmUuY29tL2Q2N2ZiOWNjLWRjYTgtNDQwMS1iZjhhLTNlYWY1YjU0NWZkMi8iLCJhY3IiOiJiMmNfMV9iMmNzaWduaW4iLCJzdWIiOiJnYzFDYk56ZjZQME5WWnhzakw5dTlvdnFLYVQzaGpPcS9VV2plVzJTdU9jPSIsImF1ZCI6ImU0Y2I3MDJkLTkzMjQtNGNmYi1hYTBhLTZmODE2OGVjYWE3OSIsIm5vbmNlIjoiNjM1NzA4MjUyODE2NzE0ODczLk5HVm1ZemcxTXpFdFpUVmxOUzAwT1RJeExUZzFabUl0TkRsak56YzNZbUV4WTJJMlpEZzJOREkyT0RNdE5XWXdOaTAwTkRZd0xUZ3lORGN0T0dRMk1tRTROalF6WW1RNCIsImlhdCI6MTQzNTIyODUwMiwiYXV0aF90aW1lIjoxNDM1MjI4NTAyLCJvaWQiOiI5MjE4NzAxYS0xMzgzLTRhYWMtOTBiNy1hOGE4MGM3NjFlODYiLCJnaXZlbl9uYW1lIjoiTWFuZWVzaCIsImZhbWlseV9uYW1lIjoiUmFqYW0iLCJuYW1lIjoiTWFuZWVzaCIsImV4dGVuc2lvbl9DcGltX0dISU5JRCI6Ijc2NTQ0MjExMjEiLCJjaXR5IjoiSHlkZXJhYmFkIiwiSm9iVGl0bGUiOiJDb25zdWx0YW50Iiwic3RhdGUiOiJBcml6b25hIiwic3RyZWV0QWRkcmVzcyI6Ik1hZGhhcHVyIiwicG9zdGFsQ29kZSI6IjQyNDMwIiwiZXh0ZW5zaW9uX0NwaW1fR0hJTkVNQUlMIjoibXJhamFtQGRlbG9pdHRlLmNvbSIsImNfaGFzaCI6IklYSG5pY1VBdENocnp3LTF3VHU1QUEiLCJhdF9oYXNoIjoiNHJiVUxPd0RtSFBucTAzMFQ3bkZaUSJ9.iJmgrpP5AjZXQYl9ljd4fwbEUsv4UvlrBZ-dLGTKnmeiiTv9FIz2IVIEp-vYmd6QbbXNhD2y9Cld_FuGYmie1akbtjZK8qkWFfe-9Lww0LtLZIcB27jitlCfwcQgCvW4CF_oPCygGM7xpmZh0EkRqB7822mqBhUMnM0uxe_BRW_ZlnBbDj7YrxZVf2Wj3nvBFgF-pTLHM0dob28MyPyzCs7O5Nj5zHz-lDVUQBQqpB1BYDf1X-CO7ifAjMaASJgNv2b0UkTeTsUYk3D13B18QfbVWOLPRZYvZ7GXjFN11DAENWPFNtvgSoJTp4rUKdTrwkOrIYhEr2lS9RzKwLaYIA");
 }
}
}
        */
//WTR Plugin is not needed for Bearer token append
    public class AddHeadersWTR : WebTestRequestPlugin
    {
        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
            // base.PreRequest(sender, e);

            if (e.Request.Url.Contains("AppDev"))
                
             //  if (e.Request.Url.Contains("http://usga-ghin-ws-q2.cloudapp.net"))
          // if (e.Request.Url.Contains("http://usgawebapisit.cloudapp.net")) 
                             
                    
            {
                //AK3 is the Bearer token context paramemeter

                 // if (e.WebTest.Context.ContainsKey("AppDev"))
               if (e.WebTest.Context.ContainsKey("Bearertoken"))
                    e.Request.Headers.Add("Authorization", "Bearer " + e.WebTest.Context["Bearertoken"].ToString());
            }
        }
    }
     
        //Below one needed to append the Bearer token to service request
        public class AddHeadersreq : WebTestPlugin
        {
            public override void PreRequestDataBinding(object sender, PreRequestDataBindingEventArgs e)
            {
                // base.PreRequest(sender, e);

                 if (e.Request.Url.Contains("AppDev"))
               // if (e.Request.Url.Contains("http://usga-ghin-ws-q2.cloudapp.net"))
               //if(e.Request.Url.Contains("http://usgawebapisit.cloudapp.net"))
                                                   
                {
                    if (e.WebTest.Context.ContainsKey("Bearertoken"))
                        e.Request.Headers.Add("Authorization", "Bearer " + e.WebTest.Context["Bearertoken"].ToString());
                }
            }
        }
        //public class Addquerysting : WebTestPlugin
        //{

        //    public override void PreRequest(object sender, PreRequestEventArgs e)
        //{
        //    base.PreRequest(sender, e);
        //    if(e.Request.URL.contains("clubId"))
        //            //if (ExtractClubID= null)
        //            {
        //                if (e.WebTest.Context.ContainsKey("ExtractClubID"))
        //                    e.Request.Headers.Add("clubId", +e.WebTest.Context[0].ToString());


        //            }
        //}
        }

    
