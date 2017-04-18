using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TriggerMonitor.Models;

namespace TriggerMonitor.Controllers
{
    public class CounterController : ApiController
    {
        //TODO: These should be persistent and cloud ready
        // Use a DB or Durable Cache to Update the Count
        // This is just a means to see that the trigger is firing as expected
        static Counter[] counters = new Counter[]
           {
            new Counter { Id = 0, Count = 0 },
            new Counter { Id = 1, Count = 0 },
           };


        // GET api/<controller>
        public IEnumerable<Counter> Get()
        {
            return counters;
        }

        // GET api/<controller>/5
        public Counter Get(int id)
        {
            return (id < counters.Count() ? counters[id] : new Counter() { Id = -1 , Count = 0});
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            //for now, only update counter 0 in a Post - ignore the value from body
            //TODO: future feature could be that each instance of a scheduler updates a specific counters
            counters[0].Count++;
            System.Diagnostics.Debug.WriteLine("Count updated to : [" + counters[0].Count + "]");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}