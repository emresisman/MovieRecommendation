using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MovieRecommendation.Entities.Abstract;
using MovieRecommendation.Entities.Interface;

namespace MovieRecommendation.Entities
{
    public class Users : BaseEntity, IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
