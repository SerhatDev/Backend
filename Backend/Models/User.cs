using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
