using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensitiveWordsApi.Entities
{
    public class SensitiveWord
    { 
        [Key]
        public Guid WordId { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Word { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; }
    }
}
