using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;

namespace Randomns
{
    [System.ComponentModel.Description("Creates a Random Number and stores the value in the Context Parameter defined. The value can be created once the test starts, or it can be updated before each web request.")]
    public class RandomNumberContextParameter : WebTestPlugin
    {
        [System.ComponentModel.Description("If True, the random number will be recalculated before each request is made. The default is false.")]
        [System.ComponentModel.DefaultValue(false)]
        public bool UpdateBeforeRequest { get; set; }

        [System.ComponentModel.Description("Name of the Context Paramter that will stroe the random number.")]
        [System.ComponentModel.DefaultValue("RandomNumber")]
        public string ContextParameter { get; set; }

        [System.ComponentModel.DefaultValue(1)]
        public int MinimumValue { get; set; }

        [System.ComponentModel.DefaultValue(101)]
        public int MaximumValue { get; set; }

        public RandomNumberContextParameter()
        {
            UpdateBeforeRequest = false;
            ContextParameter = "RandomNumber";
            MinimumValue = 1;
            MaximumValue = 100;

        }
        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            if (string.IsNullOrEmpty(ContextParameter))
                throw new ArgumentException(this.ToString() + "Error --> ContextParameter property cannot be null or empty. Please define a context paramater to output the random number.");

            if (MinimumValue > MaximumValue + 1)
                throw new ArgumentOutOfRangeException(this.ToString() + "Error --> The property for the MinimumValue must less than or equal to MaximumValue.");

            //note the Random.Next() method creates a random number based on the min, and max values, however the max value returnd is one less than specified
            //so we add one here so that it works the way most people would intuitively expect.
            e.WebTest.Context[ContextParameter] = new Random().Next(MinimumValue, MaximumValue + 1).ToString();

        }
        public override void PreRequestDataBinding(object sender, PreRequestDataBindingEventArgs e)
        {
            //if they want a new random number generated for each new request
            if (UpdateBeforeRequest)
                e.WebTest.Context[ContextParameter] = new Random().Next(MinimumValue, MaximumValue + 1).ToString();
        }

        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
            {
                base.PreRequest(sender, e);
                Guid guid = Guid.NewGuid();
                string value = guid.ToString();
                //foreach (string paramName in ParameterName)
                //{
                // e.WebTest.Context.Add(paramName, value);
                //}
            }
        }

    }
}
