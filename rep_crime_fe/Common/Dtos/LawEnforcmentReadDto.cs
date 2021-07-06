using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class LawEnforcmentReadDto
    {
        public Guid Id { get; set; }
        public string BadgeId { get; set; }
        public string Agency { get; set; }
        public string Rank { get; set; }
        public IEnumerable<Guid> AssignedCasesIds { get; set; } = new List<Guid>();
    }
}
