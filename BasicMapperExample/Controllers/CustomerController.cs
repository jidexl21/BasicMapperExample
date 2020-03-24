using BasicMapperExample.Core;
using BasicMapperExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OF.BasicMapper; 

namespace BasicMapperExample.Controllers
{
    public class CustomerController : ApiController
    {
        BasicMapper mapper; 
        public CustomerController()
        {
            mapper = new BasicMapper(); 
        }
        // GET api/customer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/customer
        public void Post([FromBody] CustomerInputModel value)
        {
            Customer c =  mapper.MapFields<Customer>(value);

        }

    }
}
