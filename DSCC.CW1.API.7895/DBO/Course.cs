using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DSCC.CW1.API._7895.DBO
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]        
        public double Fee { get; set; }
        [Required]
        [StringLength(15)]
        public string Duration { get; set; }
        public int TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
    }
}
