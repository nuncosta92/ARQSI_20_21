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

    //https://localhost:5001/api/player
    public class IntroductionController : ControllerBase
    {
        private IntroductionRepo _repo;
        private ConnectionRepo _connectionRepo;
        IntroductionService _service;

        public IntroductionController(Context db)
        {
            _repo = new IntroductionRepo(db);
            _connectionRepo = new ConnectionRepo(db);
            _service = new IntroductionService(_repo, _connectionRepo);
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Object> GetAllIntroductions()
        {
            List<IntroductionDto> responseBody;
            try {
                responseBody = _service.GetAllIntroductions();
            } 
            catch (NullReferenceException) {
                responseBody = new List<IntroductionDto>();
            }
            return responseBody;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetIntroductionById(int id)
        {
            IntroductionDto responseBody;

            try { 
                responseBody = _service.GetIntroductionById(id);
            } 
            catch (NullReferenceException) {
                return NotFound();
            }
            return Ok(responseBody);
        }

        [HttpGet("pending/{playerid}")]
        public IActionResult GetPendingIntroductionByPlayerId(int playerid)
        {
            List<IntroductionDto> responseBody;

            try
            {
                responseBody = _service.GetIntroductionPendingByPlayerId(playerid);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            return Ok(responseBody);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult CreateIntroduction([FromBody] IntroductionDto body)
        {
            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     PlayerDto response = _service.CreatePlayer(body);
            IntroductionDto responseBody;
            try
            {
                responseBody = _service.CreateIntroduction(body);
            } catch (ArgumentException) {
                return BadRequest();
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            //var token = JToken.Parse(response);
            return Created(nameof(GetIntroductionById), responseBody);
        }

        // POST api/<ValuesController>
        [HttpPut("accept")]
        public IActionResult AcceptIntroductin(int playerId, int itermediatePlayerId, int targetPlayerId)
        {
            ConnectionDto responseBody = _service.acceptIntoduction(playerId, itermediatePlayerId, targetPlayerId);
            return Ok(responseBody);
        }

        // POST api/<ValuesController>
        [HttpPut("reject")]
        public IActionResult RejectIntroductin(int playerId, int itermediatePlayerId, int targetPlayerId)
        {
            IntroductionDto responseBody = _service.rejectIntroduction(playerId, itermediatePlayerId, targetPlayerId);
            return Ok(responseBody);
        }

    }
}
