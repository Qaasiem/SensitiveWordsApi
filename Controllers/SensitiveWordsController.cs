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
        public async Task<List<SensitiveWord>> GetAll()
        {
            var resultSet = await _services.GetAllSensitiveWords();
           
            return resultSet;
        }

        [HttpGet("GetById")]
        public async Task<SensitiveWord> GetById(Guid sensitiveWordId)
        {
            var result = await _services.GetSensitiveWordById(sensitiveWordId);

            return result;
        }

        // POST api/<SensitiveWordsController>
        [HttpPost]
        public async Task<bool> Post([FromBody] List<SensitiveWord> sensitiveWords)
        {
            var resultSet = await _services.CreateSensitiveWords(sensitiveWords);

            return resultSet;
        }

        // PUT api/<SensitiveWordsController>/5
        [HttpPut]
        public async Task<bool> Put([FromBody] SensitiveWord sensitiveWord)
        {
            var result = await _services.UpdateSensitiveWord(sensitiveWord);

            return result;
        }

        // DELETE api/<SensitiveWordsController>/5
        [HttpDelete]
        public async Task<bool> Delete(Guid sensitiveWordId)
        {
            var result = await _services.DeleteSensitiveWord(sensitiveWordId);

            return result;
        }
    }
}
