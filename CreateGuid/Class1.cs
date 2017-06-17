using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System.ComponentModel;


//[assembly: CLSCompliant(true)]

namespace Guidtest
{
    [System.ComponentModel.DisplayName("Generate Guid Custom Length")]
    [System.ComponentModel.Description("Generates a new Guid with a custom length")]
    public class UniqueIdentifierPlugin : WebTestPlugin
    {
        [System.ComponentModel.DisplayName("Target Context Parameter Name")]
        [System.ComponentModel.Description("Name of the context parameter that will receive the generated value.")]
        public string ContextParamTarget { get; set; }

        [System.ComponentModel.DisplayName("Output Format")]
        [System.ComponentModel.Description("Format for guid (optional). Ex: N")]
        public string OutputFormat { get; set; }

        [System.ComponentModel.DisplayName("Guid Length")]
        [System.ComponentModel.Description("Length of the generated guid.")]
        public int GuidLength { get; set; }

        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            // Generate new guid with specified output format
            var newGuid = System.Guid.NewGuid().ToString(OutputFormat);

            // Create substring of specified length
            if (GuidLength > 0 && GuidLength < newGuid.Length)
            {
                newGuid = newGuid.Substring(0, GuidLength - 1);
            }

            // Set the context paramaeter with generated guid
            e.WebTest.Context[ContextParamTarget] = newGuid;

            base.PreWebTest(sender, e);
        }
    }

}

//    //New
//    [Description("This plug-in allows any HTTP status code to be trapped and the request's outcome set to Pass. Status codes can be found at http://msdn.microsoft.com/en-us/library/aa383887.aspx.")]

//    [DisplayName("Filter Response Status Code")]

//    public class FilterAnyResponse_RPI : WebTestRequestPlugin
//    {

//        [Description("Choose the HTTP status code to match. If found, the request's outcome is overridden to Pass. 0 = Disable HTTP code status matching.")]

//        [DisplayName("Response Code")]

//        public int StatusCode { get; set; }

//        [Description("The text that will be included in the test result.")]

//        [DisplayName("Comment")]

//        [DefaultValue("Code matched. Outcome set to Pass.")]

//        public string CommentHTTPCode { get; set; }

//        public override void PostRequest(object sender, PostRequestEventArgs e)
//        {

//            CoreCode.ResponseTypeMatch(e, StatusCode, StatusCode.ToString() + "-" + CommentHTTPCode);

//        }

//    }

//    //new end

//    //[Description("This plug-in allows any HTTP status code to be trapped and the request's outcome set to Pass. Status codes can be found at http://msdn.microsoft.com/en-us/library/aa383887.aspx.")]

//    //[DisplayName("Filter Response Status Code")]

//    //public class FilterAnyResponse_RPI : WebTestRequestPlugin
//    //{

//    //    [Description("Choose the HTTP status code to match. If found, the request's outcome is overridden to Pass. 0 = Disable HTTP code status matching.")]

//    //    [DisplayName("Response Code")]

//    //    public int StatusCode { get; set; }

//    //    [Description("The text that will be included in the test result.")]

//    //    [DisplayName("Comment")]

//    //    [DefaultValue("Code matched. Outcome set to Pass.")]

//    //    public string CommentHTTPCode { get; set; }

//    //    public override void PostRequest(object sender, PostRequestEventArgs e)
//    //    {

//    //        CoreCode.ResponseTypeMatch(e, StatusCode, StatusCode.ToString() + "-" + CommentHTTPCode);

//    //    }

//    //}

//    //(In the Core Code class)
//    public static class CoreCode
//    {
//        public static void AddMsgAndSetOutcome(PostRequestEventArgs e, ref string Msg, Outcome Result = Outcome.Pass)
//        {

//            if (string.IsNullOrEmpty(Msg) == false)
//            {

//                e.WebTest.AddCommentToResult(Msg);

//            }

//            e.Request.Outcome = Result;

//        }
//        //core club new
//        public static bool ResponseTypeMatch(PostRequestEventArgs e, int sc, string Msg, Outcome Result = Outcome.Pass)
//        {

//            /// A return value of false let's the caller skip unnecessary operations since there was no match.

//            if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
//            {

//                AddMsgAndSetOutcome(e, ref Msg, Result);

//                return true;

//            }

//            else
//            {

//                return false;

//            }

//        }
//    }
//}


//        //new end
        

//////        public static bool ResponseTypeMatch(PostRequestEventArgs e, int sc, string Msg, Outcome Result = Outcome.Pass)
//////        {

//////            /// A return value of false let's the caller skip unnecessary operations since there was no match.

//////            if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
//////            {

//////                AddMsgAndSetOutcome(e, ref Msg, Result);

//////                return true;

//////            }

//////            else
//////            {

//////                return false;

//////            }

//////        }
//////    }
//////}

  