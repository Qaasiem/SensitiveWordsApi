using Microsoft.AspNetCore.Mvc;
using SensitiveWordsApi.Entities;
using SensitiveWordsApi.ServiceLayer.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensitiveWordsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensitiveWordsController : ControllerBase
    {
        private readonly ISensitiveWordsService _services;
        public SensitiveWordsController(ISensitiveWordsService services)
        {
            _services = services;
        }

        // GET: api/<SensitiveWordsController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var resultSet = await _services.GetAllSensitiveWords();
                return StatusCode(200, resultSet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid sensitiveWordId)
        {
            try
            {
                var result = await _services.GetSensitiveWordById(sensitiveWordId);
                return StatusCode(200, result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // POST api/<SensitiveWordsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<SensitiveWord> sensitiveWords)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resultSet = await _services.CreateSensitiveWords(sensitiveWords);
                    return StatusCode(200, resultSet);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/<SensitiveWordsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SensitiveWord sensitiveWord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _services.UpdateSensitiveWord(sensitiveWord);
                    return StatusCode(200, result);
                }
                else
                    return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE api/<SensitiveWordsController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid sensitiveWordId)
        {
            try
            {
                var result = await _services.DeleteSensitiveWord(sensitiveWordId);
                return StatusCode(200, result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("MessageSanitizer")]
        public async Task<IActionResult> MessageSanitizer([FromBody] string message)
        {
            try
            {
                string santizedMessage = await _services.MessageSanitizer(message);
                return StatusCode(200, santizedMessage);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
