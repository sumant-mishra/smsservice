using System;
using System.Collections.Generic;
namespace SMSSendAndReceive.Models
{
    public class SMSBody
    {
        
        public List<string> ToNumbers { get; set; }
        public string Body { get; set; }
    }
}
