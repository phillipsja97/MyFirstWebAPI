﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5    ---- "{number}" is a route parameter
        // the route parameter has to match the parameter passed into the Get method, capatilization does matter.
        // the method name does not matter what it is called. Be specific on what that method is bring back.
        [HttpGet("echonumbers/{number}")]
        public IActionResult EchoBackANumber(int number)
        {
            if (number >= 1000)
            {
                return NotFound("You suck at life.");
            }
            return Ok(number);
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
        }
    }
}
