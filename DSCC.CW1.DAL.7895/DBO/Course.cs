using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSCC.CW1.DAL._7895.DBO
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName="money")]
        public decimal Fee { get; set; }
        [Required]
        [StringLength(15)]
        public string Duration { get; set; }
        //Level, Branch and Status entites were defined as nullable to avoid conflicts in migrations
        public Level? Level { get; set; }
        public Branch? Branch { get; set; }
        public Status? Status { get; set; }
        
    }
}
