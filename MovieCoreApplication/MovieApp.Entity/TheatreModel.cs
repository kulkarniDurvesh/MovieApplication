using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Entity
{
    public class TheatreModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThreatreId { get; set; }//property
        public string ThreatreName { get; set; }
        public string ThreatrePlayName { get; set; }
        public string ThreatreCapacity { get; set; }
        public int Price { get; set; }
    }
}
