using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    using Models;

    public class AuthArgs : EventArgs
    {
        public Physician Physician { get; set; } = null;
        public bool Succeded { get; set; } = false;
    }
}
