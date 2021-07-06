using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class CrimeEventReadDto
    {
        public Guid Id { get; set; }
        public DateTime DateOfCrime { get; set; }
        public string Description { get; set; }
        public Guid TypeOfCrimeId { get; set; }
        public string PlaceOfCrime { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public string AssignedLawEnforcmentId { get; set; }
    }
}
