using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System.ComponentModel;
using System.Globalization;

namespace DateCurrent
    {
    [System.ComponentModel.DisplayName("Save current date time to context parameter")]
    [System.ComponentModel.Description("Saves date time of call to a context parameter")]
    public class DateTimeToContext : WebTestRequestPlugin
    {
        [System.ComponentModel.DisplayName("Parameter name")]
        [System.ComponentModel.Description("Name of context parameter.")]
        public string ParameterName { get; set; }

        [System.ComponentModel.DisplayName("Date-time format")]
        [System.ComponentModel.DefaultValue("MM-dd-yyyy")] //yyyy-MM-dd HH:mm:ss.fff")]
        public string DateTimeFormat { get; set; }

        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
            //using ternary operator
            string now 
                = string.IsNullOrWhiteSpace(DateTimeFormat) 
                ? System.DateTime.Now.ToString("MM-dd-yyyy") //yyyy-MM-dd HH:mm:ss.fff")
                : System.DateTime.Now.ToString(DateTimeFormat);

            e.WebTest.AddCommentToResult(string.Format("Setting context parameter '{0}' to '{1}'", ParameterName, now));
            e.WebTest.Context[ParameterName] = now;
        }
    }
}
