using Microsoft.AspNetCore.Mvc;
using SensitiveWordsApi.Entities;
using SensitiveWordsApi.ServiceLayer.Interfaces;

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

        /// <summary>
        /// Retrieves all sensitive words
        /// </summary>
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

        /// <summary>
        /// Retrieves sensitive word using Id
        /// </summary>
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

        /// <summary>
        /// Creates new sensitive word 
        /// </summary>
        [HttpPost("CreateSenstiveWord")]
        public async Task<IActionResult> CreateSenstiveWord([FromBody] List<SensitiveWord> sensitiveWords)
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

        /// <summary>
        /// Updates sensitive word 
        /// </summary>
        [HttpPut("UpdateSensitiveWord")]
        public async Task<IActionResult> UpdateSensitiveWord([FromBody] SensitiveWord sensitiveWord)
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

        /// <summary>
        /// Deletes sensitive word using Id
        /// </summary>
        [HttpDelete("DeleteSensitiveWord")]
        public async Task<IActionResult> DeleteSensitiveWord(Guid sensitiveWordId)
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

        /// <summary>
        /// Sanitizes messages based on sensitive word collection
        /// </summary>
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
