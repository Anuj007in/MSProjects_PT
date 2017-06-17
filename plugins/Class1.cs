using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System.Threading.Tasks;
using System.Diagnostics;

namespace plugins
{
    [System.ComponentModel.Description("There is no custome value to select a run duration for a web test,to customize this this plugin would input the run duration and if this exceed by context run it will Fail")]
    public class RunDuration : WebTestPlugin

    {
        private Stopwatch SWatch;
        [System.ComponentModel.DisplayName("maximum Test time"), System.ComponentModel.Description("Define the max total time the web test can take in milliseconds"), System.ComponentModel.DefaultValue("0")]
        public int maximumTesttime { get; set; }

        public RunDuration()
        {
            SWatch = new Stopwatch();
        }
        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            SWatch.Start();

        }
        public override void PostWebTest(object sender, PostWebTestEventArgs e)
        {
            //base.PostWebTest(sender, e);
            SWatch.Stop();
            var elapsedtimeinms = SWatch.ElapsedMilliseconds;
            if (this.maximumTesttime > 0)
            {
                if (elapsedtimeinms > maximumTesttime)
                {
                    e.WebTest.Outcome = Outcome.Fail;
                }
            }
        }

    }
}
