using MyMDB.Data;
using System.ComponentModel.DataAnnotations;

namespace MyMDB.Model
{
    public class Movie : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
