using ProjectRenan.Domain.Models;

namespace ProjectRenan.Domain.Entities
{
    public class User: Entity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
