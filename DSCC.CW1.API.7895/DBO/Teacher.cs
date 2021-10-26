using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DSCC.CW1.API._7895.DBO
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }       
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; }
    }
}
