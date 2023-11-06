namespace SensitiveWordsApi.ServiceLayer.Models
{
    public class SensitiveWords
    {
        public Guid WordId { get; set; }

        public string Word { get; set; } = string.Empty;

        public DateTime DateAdded { get; set; }
    }
}
