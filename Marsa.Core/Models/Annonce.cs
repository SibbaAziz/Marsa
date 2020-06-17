
using System.Collections.Generic;

namespace Marsa.Core.Models
{
    public class Annonce
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IEnumerable<string> Photos { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
    }
}
