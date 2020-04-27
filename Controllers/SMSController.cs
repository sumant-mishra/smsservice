using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMSSendAndReceive.Models;

using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.Exceptions;


using Twilio.TwiML;
using Twilio.AspNet.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMSSendAndReceive.Controllers
{
    [Route("api")]
    public class SMSController : TwilioController
    {

        // GET api/values/5
        [HttpGet("send-sms")]
        public IEnumerable<SMSStatus> Send(int id)
        {
            var accountSid = "AC543bddcd8e90efaebd92577531c694d0";
            var authToken = "bba190cb04207b30a04a1126bef1ed1d";

            TwilioClient.Init(accountSid, authToken);

            List<string> toList = new List<string>();
            toList.Add("+919971740711");
            toList.Add("+919971740711");
            toList.Add("+919810447915");
            toList.Add("+91xxxxxxxxxx");

            var to = new PhoneNumber("+919971740711");
            var from = new PhoneNumber("+12244772941");

            List<SMSStatus> statusList = new List<SMSStatus>();


            foreach (string value in toList)
            {
                //Console.WriteLine(value);
                try
                {
                    var message = MessageResource.Create(
                        body: "Hi there! This is a test SMS using Twilio.",
                        from: from,
                        to: new PhoneNumber(value)
                    );

                    var status = new SMSStatus() { ToNumber = value, Status = message.Sid };
                    statusList.Add(status);

                }
                catch (TwilioException e)
                {
                    var status = new SMSStatus() { ToNumber = value, Status = e.Message};
                    statusList.Add(status);
                    //Console.WriteLine($"The file was not found: '{e}'");
                }
            }

            


            

            //Twilio.Exceptions.

            return statusList;
        }


        [HttpPost("send-sms")]
        public IActionResult SendSms(SMSBody smsBody)
        {
            var accountSid = "AC543bddcd8e90efaebd92577531c694d0";
            var authToken = "bba190cb04207b30a04a1126bef1ed1d";

            TwilioClient.Init(accountSid, authToken);

            List<string> toList = smsBody.ToNumbers;
            //toList.Add("+919971740711");
            //toList.Add("+919971740711");
            //toList.Add("+919810447915");
            //toList.Add("+91xxxxxxxxxx");

            //var to = new PhoneNumber("+919971740711");
            var from = new PhoneNumber("+12244772941");

            List<SMSStatus> statusList = new List<SMSStatus>();


            foreach (string value in toList)
            {
                //Console.WriteLine(value);
                try
                {
                    var message = MessageResource.Create(
                        body: smsBody.Body,
                        from: from,
                        to: new PhoneNumber(value)
                    );

                    var status = new SMSStatus() { ToNumber = value, Status = message.Sid };
                    statusList.Add(status);

                }
                catch (TwilioException e)
                {
                    var status = new SMSStatus() { ToNumber = value, Status = e.Message };
                    statusList.Add(status);
                    //Console.WriteLine($"The file was not found: '{e}'");
                }
            }


            return Ok(statusList);
        }
        // GET: api/values
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
