using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Entity
{
    public class MovieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }//property
        public string MovieName { get; set; }
        public string ActorName { get; set; }
        public string DirectorName { get; set; }
        public string ActressName { get; set; }
        public int Price { get; set; }
    }
}
