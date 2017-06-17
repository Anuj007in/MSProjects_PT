using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace maxTestRun
{
    [System.ComponentModel.Description("This to select the proxy False/True at the web test root level!!")]
    public class TestProxyPlugin : WebTestPlugin
    {
        //[System.ComponentModel.Description("If True, proxy is enabled")]
        [System.ComponentModel.DisplayName("ProxyServer"),System.ComponentModel.Description("The proxy server ,if needed to use for this web test execution"),System.ComponentModel.DefaultValue("")]
        
        public string Proxytest { get; set; }
        
      /*  public TestProxyPlugin()
        {
            UpdateBeforeRequest = false;
            ContextParameter = "RandomNumber";
            MinimumValue = 1;
            MaximumValue = 100;

        } */
        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            e.WebTest.Proxy = this.Proxytest;

        }
        
    }
}
