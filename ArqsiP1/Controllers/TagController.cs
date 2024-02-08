using ArqsiP1.Contexts;
using ArqsiP1.Dto;
using ArqsiP1.Repositories;
using ArqsiP1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TagController : ControllerBase
    {
        private TagRepo _repo;
        TagService _service;

        public TagController(Context db)
        {
            _repo = new TagRepo(db);
            _service = new TagService(_repo);
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Object> GetAllTags()
        {
            List<TagDto> responseBody;
            try
            {
                responseBody = _service.GetAllTags();
            }
            catch (NullReferenceException)
            {
                responseBody = new List<TagDto>();
            }
            return responseBody;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult CreateTag([FromBody] TagDto body)
        {
            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     PlayerDto response = _service.CreatePlayer(body);
            TagDto responseBody;
            try
            {
                responseBody = _service.CreateTag(body);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            //var token = JToken.Parse(response);
            return Created(nameof(GetTagById), responseBody);

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetTagById(int id)
        {
            TagDto responseBody;

            try
            {
                responseBody = _service.GetTagById(id);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            return Ok(responseBody);
        }


        [HttpPut("updateTag")]
        public IActionResult UpdateTag([FromBody] TagDto body)
        {
            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     TagDTO response = _service.CreateTag(body);
            TagDto responseBody;
            try
            {
                responseBody = _service.UpdateTag(body);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            //var token = JToken.Parse(response);
            return Ok(responseBody);

        }

        // GET: api/<ValuesController>
        [HttpGet("tagSearch")]
        public IEnumerable<Object> GetTagByName(String name)
        {
            List<TagDto> responseBody;
            try
            {
                responseBody = _service.RetrieveTagsByName(name);
            }
            catch (NullReferenceException)
            {
                responseBody = new List<TagDto>();
            }
            return responseBody;
        }

        [HttpGet("playerTags")]
        public IEnumerable<Object> GetTagByPlayerId([FromQuery] int playerId)
        {
            List<TagDto> responseBody;
            try
            {
                responseBody = _service.RetrieveTagsByPlayerId(playerId);
            }
            catch (NullReferenceException)
            {
                responseBody = new List<TagDto>();
            }
            return responseBody;
        }

        [HttpGet("connectionTags")]
        public IEnumerable<Object> GetTagByConnectionId([FromQuery] int connectionId)
        {
            List<TagDto> responseBody;
            try
            {
                responseBody = _service.RetrieveTagsByConnectionId(connectionId);
            }
            catch (NullReferenceException)
            {
                responseBody = new List<TagDto>();
            }
            return responseBody;
        }
    }
}
