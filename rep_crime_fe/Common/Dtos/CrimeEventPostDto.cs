using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class CrimeEventPostDto
    {
        public DateTime? DateOfCrime { get; set; }
        public string Description { get; set; }
        public Guid TypeOfCrimeId { get; set; }
        public string PlaceOfCrime { get; set; }
        public string Email { get; set; }
    }
}
