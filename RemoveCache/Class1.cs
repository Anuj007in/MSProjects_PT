using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace RemoveCache
{

    public class DisableCache : WebTestPlugin
    {
        public override void PostRequest(object sender, PostRequestEventArgs e)
        {
            foreach (WebTestRequest dependentRequest in e.Request.DependentRequests)
            {
                dependentRequest.Cache = false;
            }
          }

       }
}
