using System.Collections.Generic;
using BeGood.Core.Interfaces;
using BeGood.Core.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork<Sys> unitOfWork;

        public ValuesController(IUnitOfWork<Sys> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new JsonResult(new Sys { ID = 1, Name = "123" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Sys s1 = new Sys() { Name = "测试1" };
            Sys s2 = new Sys() { Name = "测试2" };

            unitOfWork.Create(s1);
            unitOfWork.Create(s2);
            bool res = unitOfWork.Commit();

            return new JsonResult(res);
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
