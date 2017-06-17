using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.WebTesting;
using System.Diagnostics;
using System.Globalization;


namespace customvalidationDemoDay3
{
    
    [DisplayName("MaxRequestSizeValidation_Demo3")]
    [Description("Validates req size is below the limit")]

    public class MaxRequestValidationRuleCustom : ValidationRule
    {
        [DisplayName("Max req length")]
        [Description("Specify the max req length in bytes")]
        [DefaultValue("0")]

        public int MaximumRequestLength { get; set; }

string m_message;
public string Message
{ 
  get {return m_message;}
}

private static bool Validate(string document)
{
    Debug.Assert(document != null);
    throw (new NotImplementedException("ValidationRule1:MyValidationFunction not implemented !"));
}

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
            catch(Exception ex)
            {
                e.Message = String.Format(CultureInfo.CurrentCulture, "{ValidationRule}Exception: {0}",ex.Message.ToString());
                e.IsValid = false;
            }
        }
    }
}
