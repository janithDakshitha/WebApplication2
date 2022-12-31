using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class degree
    {
        [Key]
        public int Degree_ID { get; set; }
        public string Degre_Name { get; set; }

        [ForeignKey("Class")]
        public string UserId { get; set; }
        public Class Class { get; set; }
    }
}
