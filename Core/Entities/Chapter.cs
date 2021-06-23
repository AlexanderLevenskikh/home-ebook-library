using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Chapter
    {
        [Required]
        public string Description { get; set; }
        public int PageNumber { get; set; }
    }
}