using Microsoft.VisualStudio.TestTools.WebTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomeValidationRule
{
    [DisplayName("Sleep")]
    [Description("Pauses the test for a number of milliseconds.")]
    public class SleepValidationRule : ValidationRule
    {
        [DisplayName("Sleep for duration (ms)")]
        [Description("Number of milliseconds to sleep for.")]
        public int SleepForDuration { get; set; }

        public override void Validate(object sender, ValidationEventArgs e)
        {
            if (SleepForDuration < 0)
            {
                e.Message = "Sleep duration cannot be a negative number.";
                e.IsValid = false;
            }
            else
            {
                if (SleepForDuration > 0)
                {
                    Thread.Sleep(SleepForDuration);
                }

                e.Message = String.Format("Slept for {0}ms.", SleepForDuration);
                e.IsValid = true;
            }
        }
    }
}
