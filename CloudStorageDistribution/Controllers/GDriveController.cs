using System.Collections.Generic;
using CloudStorageDistribution.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudStorageDistribution.Controllers
{
    [Route("/gdrive")]
    [ApiController]
    public class GDriveController : ControllerBase
    {
        readonly IService _gDriveService;
        public  GDriveController(IService gDriveService)
        {
            _gDriveService = gDriveService;
        }
        // GET: /gdrive
        [HttpGet]
        public IEnumerable<string> Get()
        {
           // _gDriveService.ListAllFiles();
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public int Test0(int id)
        {
            return _gDriveService.Return0();
        }
    }
}
