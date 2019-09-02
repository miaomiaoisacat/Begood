using System.Collections.Generic;
using BeGood.Core.Interfaces;
using BeGood.Core.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
    }

    public class TestA : BaseEntity
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
    }

    public class TestB : BaseEntity
    {
        public string B1 { get; set; }
        public string B2 { get; set; }
        public string B3 { get; set; }
    }

    public class TestC
    {
        public int ID { get; set; }
        public string C1 { get; set; }
        public int Cint { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<BaseEntity> lstEntity = new List<BaseEntity>();
            lstEntity.Add(new TestA
            {
                ID = 1,
                A1 = "a1",
                A2 = "a11"
            });
            lstEntity.Add(new TestA
            {
                ID = 2,
                A1 = "a2",
                A2 = "a22"
            });
            lstEntity.Add(new TestA
            {
                ID = 3,
                A1 = "a3",
                A2 = "a33"
            });
            lstEntity.Add(new TestB
            {
                ID = 4,
                B1 = "b1",
                B2 = "b11",
                B3 = "b111"
            });
            lstEntity.Add(new TestB
            {
                ID = 5,
                B1 = "b2",
                B2 = "b22",
                B3 = "b222"
            });
            lstEntity.Add(new TestB
            {
                ID = 6,
                B1 = "b3",
                B2 = "b33",
                B3 = "b333"
            });

            

            TestA a1 = lstEntity[1] as TestA;
            TestB b1 = lstEntity[5] as TestB;

            var arrProps = typeof(TestB).GetProperties();
            var arrProps2 = typeof(TestC).GetProperties();
            List<string> lstT = new List<string>();

            foreach (var item in arrProps)
            {
                lstT.Add(item.GetValue(lstEntity[3]).ToString());
            }


            return new JsonResult(lstT);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Sys s1 = new Sys() { Name = "测试1" };
            Sys s2 = new Sys() { Name = "测试2" };

            unitOfWork.Create<Sys>(new Sys { Name = "测试2" }, "sys");
            unitOfWork.Update<Store>(new Store { ID = 3, Name = "测试分店222" }, "store");
            bool res = unitOfWork.Commit();

            //unitOfWork.Create(s1);
            //unitOfWork.Create(s2);
            //bool res = unitOfWork.Commit();

            return new JsonResult("");
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
