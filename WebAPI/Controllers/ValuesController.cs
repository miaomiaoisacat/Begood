using System;
using System.Collections.Generic;
using DAL;
using DAL.Appointment;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IRepository<Sys> rep = new SysRepository();

            //return new JsonResult(rep.Delete(new Sys { ID = 1, Name = "123" }));

            Sys sys = new Sys();

            return new JsonResult(rep.Delete(new Sys
            {
                ID = 1,
                Name = "123"
            }));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            IRepository<Sys> rep = new SysRepository();
            Sys outModel = rep.SelectSingle(new Sys { ID = id });

            return new JsonResult(outModel);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
