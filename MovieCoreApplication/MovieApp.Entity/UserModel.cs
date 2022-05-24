using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace MovieApp.Entity
{
   public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity )]
        public int UserId { get; set; }//property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Mobile { get; set; }
    }
}
