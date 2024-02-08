using ArqsiP1.Contexts;
using ArqsiP1.Dto;
using ArqsiP1.Repositories;
using ArqsiP1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArqsiP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private TestRepo _repo;
        TestService _service;

        public TestController(Context db)
        {
            _repo = new TestRepo(db);
            _service = new TestService(_repo);
        }

        [HttpDelete]
        public IActionResult TearDown()
        {
            _service.TearDown();
            return Ok();
        }
    }
}
