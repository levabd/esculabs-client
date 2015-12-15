namespace Client.Helpers
{
    using System;
    using EsculabsCommon.Models;

    public class PatientTileClickArgs : EventArgs
    {
        public Patient Patient { get; set; } = null;
    }
}
