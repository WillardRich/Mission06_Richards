using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Richards.Models
{

    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public List<Movie> Movies { get; set; }
    }

}