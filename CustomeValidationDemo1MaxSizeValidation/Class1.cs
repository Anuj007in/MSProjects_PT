//Author Anuj Sharma-custom validation rule
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System.Diagnostics;
using System.Globalization;

namespace CustomValidationDemo1MaxSizeValidation
{
    [DisplayName("MaxRequestSizeValidation_customAnuj")]
    [Description("Validates req size is below the limit")]

    //Use the ValidateRule interface for new public class
    public class MaxRequestValidationRuleCustom : ValidationRule
    {
        [DisplayName("Max req length")]
        [Description("Specify the max req length in bytes")]
        [DefaultValue("0")]

        public int MaximumRequestLength { get; set; }

        //define the message prop
string m_message;
public string Message
{ 
  get {return m_message;}
}

        //additional methode to validate and assert-Optional
private static bool Validate(string document)
{

    Debug.Assert(document != null);
    throw (new NotImplementedException("ValidationRule1:MyValidationFunction not implemented !"));
}

        //Override the Validate method and grab the ValidationEventArgs exception
        public override void Validate(object sender, ValidationEventArgs e)
        {
            try
            {
                if (MaximumRequestLength > 0)
                {
                    e.IsValid = e.Request.ContentLength <= MaximumRequestLength;
                }
                e.Message = Message;
            }
            catch (Exception ex)
            {
                e.Message = String.Format(CultureInfo.CurrentCulture, "{ValidationRule}Exception: {0}", ex.Message.ToString());
                e.IsValid = false;
            }
        }
    }
}