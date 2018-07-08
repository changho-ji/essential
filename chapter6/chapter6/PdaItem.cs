using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter6
{
    public class PdaItem
    {
        public string Name { get; set; }

        public DateTime LastUpdated { get; set; }

        protected Guid ObjectKey { get; set; }
    }
}
