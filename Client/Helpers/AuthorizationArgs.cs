using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    using Models;

    public class AuthorizationArgs : EventArgs
    {
        public bool Authorized { get; set; } = false;
        public Physician Physician { get; set; }
    }
}
