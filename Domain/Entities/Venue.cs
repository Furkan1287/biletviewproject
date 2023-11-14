using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venue : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        // Mekan ile ilişkilendirilmiş etkinliklerin bir koleksiyonu
        public ICollection<Event> Events { get; set; }
    }
}
