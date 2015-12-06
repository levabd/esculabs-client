using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibrosis.Helpers
{
    using Models;

    public class ExamineTileClickArgs : EventArgs
    {
        public Examine Examine { get; set; } = null;
    }
}
