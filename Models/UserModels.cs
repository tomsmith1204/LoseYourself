namespace SeniorProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public class UserModels
    {
        [Key]
        [DisplayName("User Name")]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Age { get; set; }

        [DisplayName("Male?")]
        public bool IsMale { get; set; }

        public int Height { get; set; }

        public double Weight { get; set; }

        [DisplayName("Goal Weight")]
        public int Goal { get; set; }

        public int Checkins { get; set; }




        //this holds relationships, edit here when ready to add relationships
        //public virtual ICollection<UserCheckin> UserCheckin { get; set; }

        //Might not need this code, we'll see...
        //public static implicit operator User(UserContext v)
        //{
        //    return new User();
        //}
    }
}
