using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Richards.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Navigation property
        public List<Movie> Movies { get; set; }
    }
}