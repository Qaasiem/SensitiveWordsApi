using SensitiveWordsApi.Entities;

namespace SensitiveWordsApi.ServiceLayer.Interfaces
{
    public interface ISensitiveWordsService
    {
        Task<List<SensitiveWord>> GetAllSensitiveWords();
        Task<SensitiveWord> GetSensitiveWordById(Guid sensitiveWordId);
        Task<bool> CreateSensitiveWords(List<SensitiveWord> sensitiveWords);
        Task<bool> UpdateSensitiveWord(SensitiveWord sensitiveWord);
        Task<bool> DeleteSensitiveWord(Guid sensitiveWordId);
    }
}
