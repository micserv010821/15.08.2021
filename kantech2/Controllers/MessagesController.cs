using kantech2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace kantech2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Chatter")]
    public class MessagesController : ControllerBase
    {

        private static List<Message> messages = new List<Message>();

        private static int counter = 0;

        static MessagesController()
        {
            messages.AddRange(new List<Message>()
            {
                new Message
                {
                    Id = ++counter,
                    Sender = "Danny",
                    Body = "Hello from Danny"
                },
                new Message
                {
                    Id = ++counter,
                    Sender = "Galit",
                    Body = "How are you today?"
                },
                new Message
                {
                    Id = ++counter,
                    Sender = "Moshe",
                    Body = "I'm back from vacation"
                },                
                new Message
                {
                    Id = ++counter,
                    Sender = "Hadar",
                    Body = "I just woke up!"
                },
            });
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return messages;
        }

        [HttpGet("{id}", Name ="GetMessage")]
        // messages/12
        public IActionResult Get(int id)
        {
            //return Ok();//200
            //return StatusCode(HttpStatusCode.Accepted);//202
            //return BadRequest();//400
            //return InternalServerError();//500
            //return Unauthorized();//401

            //return Ok(messages.FirstOrDefault(_ => _.Id == id));
            return StatusCode(200, messages.FirstOrDefault(_ => _.Id == id));

            // in case of error
            // { Error: " " }
        }

        [HttpGet("readfile")]
        public async Task<IActionResult> GetReadFile()
        {
            using (var reader = System.IO.File.OpenText(@"C:\Users\User\source\repos\kantech2\kantech2\Controllers\MessagesController.cs"))
            {
                // to keep track
                // Task<string> fileTextTask = reader.ReadToEndAsync();

                string fileText = await reader.ReadToEndAsync();

                return Ok(fileText);
            }
        }


        [HttpGet("search")]
        // messages ? sender = Danny
        public List<Message> GetByParams(string sender = null, string body = null, int above_id = 0)
        {

            return messages.Where(_ => (sender != null ? _.Sender.ToUpper().Contains(sender.ToUpper()) : true)  &&
                                       (body != null ? _.Body.ToUpper().Contains(body.ToUpper()) : true) &&
                                       _.Id > above_id).ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Message message)
        {
            if (message.Sender.ToUpper() == "HACKER")
                return BadRequest("hacking not allowed...");
            var r = Request;
            message.Id = ++counter;
            messages.Add(message);
            return CreatedAtRoute("GetMessage", new Message { Id = message.Id }, message);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Message message)
        {
            Message for_update = messages.FirstOrDefault(_ => _.Id == id);
            if (for_update != null)
            {
                for_update.Sender = message.Sender;
                for_update.Body = message.Body;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            messages = messages.Where(_ => _.Id != id).ToList();
        }
    }
}
