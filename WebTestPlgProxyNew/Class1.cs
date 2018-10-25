using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace WebTestPlgProxyNew
{
    [System.ComponentModel.Description("New web test request plugin to set the prxy for all web test- select the value for proxy at web test root level-main")]
    public class NewProxyDemo: WebTestPlugin
    {
        [System.ComponentModel.DisplayName("New WebTest Proxy set"), System.ComponentModel.Description("Select the proxy server at root level"), System.ComponentModel.DefaultValue("")]
        public string newproxySetting { get; set; }
        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            //base.PreWebTest(sender, e);
            e.WebTest.Proxy = this.newproxySetting;
        }
    }
}
