using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Crime.API.Models
{
    public class CrimeEvent
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime DateOfCrime { get; set; }
        public string Description { get; set; }
        public Guid TypeOfCrimeId { get; set; }  
        public string PlaceOfCrime { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public Guid AssignedLawEnforcmentId { get; set; }
    }
}
