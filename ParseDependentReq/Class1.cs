using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace ParseDependentReq
{
     [System.ComponentModel.Description("This custom plugin is to change the Parse Dependent request value for all the request in a web test-Means when is False no dependent request will be requested to server e.g image file,style sheet etc")]
    public class ParseDependentWebTestPlugin: WebTestPlugin
    {
       
        [System.ComponentModel.DisplayName("ParseDepRequestFlag"),System.ComponentModel.Description("select the False if you want to parse the dependent request value to be not included in your each web request in a web test"),System.ComponentModel.DefaultValue("True")]
        public bool parDepsevalue {get;set;}
        //since this web test is for each web request use the PreRequestEventArgs instead of the PreWebtesteventargs.
        //public override void PreWebTest(object sender, PreWebTestEventArgs e)
        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
 	// base.PreWebTest(sender, e);
          e.Request.ParseDependentRequests=this.parDepsevalue;
         }

    }
}
