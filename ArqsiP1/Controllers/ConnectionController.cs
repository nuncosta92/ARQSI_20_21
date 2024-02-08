using ArqsiP1.Contexts;
using ArqsiP1.Repositories;
using ArqsiP1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiP1.Dto;
using Newtonsoft.Json;

namespace ArqsiP1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //https://localhost:5001/api/Connection
    public class ConnectionController : ControllerBase
    {
        private ConnectionRepo _repo;
        ConnectionService _service;

        public ConnectionController(Context db)
        {
            _repo = new ConnectionRepo(db);
            _service = new ConnectionService(_repo);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Object> GetAllConnections()
        {
            return _service.GetAllConnections(); ;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult CreateConnection([FromBody] ConnectionDto body)
        {
            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     PlayerDto response = _service.CreatePlayer(body);
            ConnectionDto responseBody;
            try
            {
                responseBody = _service.CreateConnection(body);
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
            return Created(nameof(GetConnectionById), responseBody);

        }

        [HttpPut("{id}/updateStrength")]
        public IActionResult UpdateStrength(int id, [FromQuery] int strength)
        {


            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     PlayerDto response = _service.CreatePlayer(body);
            ConnectionDto responseBody;
            try
            {
                responseBody = _service.UpdateStrength(id, strength);
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

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult GetConnectionById(int id)
        {
            ConnectionDto responseBody;

            try
            {
                responseBody = _service.GetConnectionById(id);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            return Ok(responseBody);
        }


        
        // GET: api/<ValuesController/>
        [HttpGet("pendingConnections")]
        public IEnumerable<Object> GetPending([FromQuery] int playerId)
        {
            return _service.getPendingConnections(playerId); 
        }

        [HttpGet("activeConnections")]
        public IEnumerable<Object> GetActiveConnections([FromQuery] int playerId)
        {
            return _service.getActiveConnections(playerId); ;
        }

        [HttpPut("action")]
        public IActionResult takeActionConnection([FromBody] ConnectionDto body)
        {
            //Returns a task, because of the async on the service the JToken is used to remove / on the response
            //     PlayerDto response = _service.CreatePlayer(body);
            ConnectionDto responseBody;
            try
            {
                responseBody = _service.takeActionConnection(body);
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
            return Created(nameof(GetConnectionById), responseBody);

        }

        // GET api/<ValuesController>/5
        [HttpGet("network/{id}")]
        public string GetNetworkById(int id)
        {
            NetworkDto responseBody;

            responseBody = _service.getNetworkFromPlayerPrespective(id);
            
            return JsonConvert.SerializeObject(responseBody);
        }
    }
}
