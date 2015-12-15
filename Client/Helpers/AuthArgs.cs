namespace Client.Helpers
{
    using System;
    using EsculabsCommon.Models;

    public class AuthArgs : EventArgs
    {
        public Physician Physician { get; set; } = null;
        public bool Succeded { get; set; } = false;
    }
}
