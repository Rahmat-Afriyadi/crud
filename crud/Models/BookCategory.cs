using System.ComponentModel.DataAnnotations;

namespace BookCRUD.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; } = default;
        [Required]
        public string? Description { get; set; } = default;

        public ICollection<Book>? Books { get; set; } = default;


    }
}
