using Microsoft.EntityFrameworkCore;
using SensitiveWordsApi.Entities;
using SensitiveWordsApi.Persistence.Context;
using SensitiveWordsApi.ServiceLayer.Interfaces;

namespace SensitiveWordsApi.ServiceLayer
{
    public class SensitiveWordsService : ISensitiveWordsService
    {
        private readonly ApiDbContext _apiDbContext;

        public SensitiveWordsService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<List<SensitiveWord>> GetAllSensitiveWords()
        {
            var resultSet = await _apiDbContext.SensitiveWords.ToListAsync();

            return resultSet;
        }

        public async Task<SensitiveWord> GetSensitiveWordById(Guid sensitiveWordId)
        {
            var result = await _apiDbContext.SensitiveWords.FindAsync(sensitiveWordId);

            return result;
        }

        public async Task<SensitiveWord> GetSensitiveWordByName(string sensitiveWordName)
        {
            var resultSet = await _apiDbContext.SensitiveWords.FindAsync(sensitiveWordName);

            return resultSet;
        }

        public async Task<bool> CreateSensitiveWords(List<SensitiveWord> sensitiveWords)
        {
            _apiDbContext.SensitiveWords.AddRange(sensitiveWords);
            await _apiDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateSensitiveWord(SensitiveWord sensitiveWord)
        {
            _apiDbContext.Entry(sensitiveWord).State = EntityState.Modified;

            try
            {
                await _apiDbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (SensitiveWordExist(sensitiveWord.WordId))
                {
                    return true;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteSensitiveWord(Guid sensitiveWordId)
        {
            var sensitiveWord = await _apiDbContext.SensitiveWords.FindAsync(sensitiveWordId);

            if(sensitiveWord != null)
            {
                _apiDbContext.Remove(sensitiveWord);
                await _apiDbContext.SaveChangesAsync();

                return true;
            }
            
            return false;
        }

        private bool SensitiveWordExist(Guid sensitiveWordId)
        {
            return _apiDbContext.SensitiveWords.Any(x => x.WordId == sensitiveWordId);
        }
    }
}
