using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    using Models;

    public class PatientTileClickArgs : EventArgs
    {
        public Patient Patient { get; set; } = null;
    }
}
