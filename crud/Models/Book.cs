using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCRUD.Models
{
    public class Book
    {

        public int Id { get; set; }
        [Required]
        public string? Title { get; set; } = default;
        [Required]
        public string? Description { get; set; } = default;

        [Required]
        [ForeignKey("BookCategoryId")]
        public int BookCategoryId { get; set; }
        public BookCategory? BookCategory { get; set; } = default;

        
    }
}

