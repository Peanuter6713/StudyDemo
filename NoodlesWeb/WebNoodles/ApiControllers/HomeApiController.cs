using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebNoodles.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebNoodles.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private INoodleRepository noodleRepository;
        public HomeApiController(INoodleRepository noodleRepository)
        {
            this.noodleRepository = noodleRepository;
        }

        // GET: api/<HomeApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            DbContextOptions<AppDbContext> options = new DbContextOptions<AppDbContext>();
            using (AppDbContext db = new AppDbContext(options))
            {
                string json = JsonConvert.SerializeObject(this.noodleRepository.GetAllNoodles());

                return json;
            }
        }


        // POST api/<HomeApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
