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
using ArqsiP1.DomainModels.Tag;

namespace ArqsiP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //https://localhost:5001/api/player
    public class PlayerController : ControllerBase
    {
        private PlayerRepo _repo;
        private TagRepo _repoTag;

        PlayerService _service;

        public PlayerController(Context db)
        {
            _repo = new PlayerRepo(db);
            _repoTag = new TagRepo(db);
            _service = new PlayerService(_repo, _repoTag);
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Object> GetAllPlayers()
        {
            List<PlayerDto> responseBody;
            try {
                responseBody = _service.GetAllPlayers();
            } 
            catch (NullReferenceException) {
                responseBody = new List<PlayerDto>();
            }
            return responseBody;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetPlayerById(int id)
        {
            PlayerDto responseBody;

            try { 
                responseBody = _service.GetPlayerById(id);
            } 
            catch (NullReferenceException) {
                return NotFound();
            }
            return Ok(responseBody);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult CreatePlayer([FromBody] PlayerDto body)
        {
            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     PlayerDto response = _service.CreatePlayer(body);
            PlayerDto responseBody;
            try
            {
                responseBody = _service.CreatePlayer(body);
            } catch (ArgumentException) {
                return BadRequest();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            //var token = JToken.Parse(response);
            return Created(nameof(GetPlayerById), responseBody);


        }
        
        [HttpPut("updatePlayer")]
        public IActionResult UpdatePlayer([FromBody] PlayerDto body)
        {
            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     PlayerDto response = _service.CreatePlayer(body);
            PlayerDto responseBody;
            try
            {
                responseBody = _service.UpdatePlayer(body);
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

        [HttpPut("updateHumor")]
        public IActionResult UpdatePlayerHumor([FromBody] PlayerDto body)
        {
            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     PlayerDto response = _service.CreatePlayer(body);
            PlayerDto responseBody;
            try
            {
                responseBody = _service.UpdatePlayerHumor(body);
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
        [HttpGet("playersearch")]
        public IEnumerable<Object> GetPlayersByName([FromQuery] String name)
        {
            List<PlayerDto> responseBody;
            try
            {
                responseBody = _service.RetrievePlayersByName(name);
            }
            catch (NullReferenceException)
            {
                responseBody = new List<PlayerDto>();
            }
            return responseBody;
        }

        [HttpGet("playerByEmail")]
        public PlayerDto GetPlayerByEmail([FromQuery] string email)
        {
            PlayerDto responseBody;
            try
            {
                responseBody = _service.RetrievePlayerByEmail(email);
            }
            catch (NullReferenceException)
            {
                responseBody = null;
            }
            return responseBody;
        }


        // GET: api/<ValuesController>
        [HttpGet("playerSugested/{id}")]
        public IEnumerable<Object> GetPlayersSugested(int id)
        {
            List<PlayerDto> responseBody;
            try
            {
                responseBody = _service.GetAllPlayersSugested(id);
            }
            catch (NullReferenceException)
            {
                responseBody = new List<PlayerDto>();
            }
            return responseBody;
        }


    }
}
