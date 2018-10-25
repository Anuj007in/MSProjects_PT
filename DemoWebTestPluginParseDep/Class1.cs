using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.VisualStudio.QualityTools.WebTestFramework;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace DemoWebTestPluginParseDep
{
//New Demo july
    [System.ComponentModel.Description("Apply the Parse dep req value to all request in one go")]
    public class WebTestReqParseDR : WebTestPlugin
    {
        [System.ComponentModel.DisplayName("New Parse Dependent Request setting"),System.ComponentModel.Description("Select False to avoid images,style sheet etc not included in the request to server"),System.ComponentModel.DefaultValue("True")]
        public bool NewparseDependentvalue { get; set;}
        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
            base.PreRequest(sender, e);
            e.Request.ParseDependentRequests = this.NewparseDependentvalue;
        }
    }
}
