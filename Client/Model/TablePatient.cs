using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public partial class TablePatient
    {
        public TablePatient() {}

        public TablePatient(Patient Patient, Examine LastExamine)
        {
            Id = Patient.Id;
            Name = string.Format("{0} {1} {2}", Patient.LastName, Patient.FirstName, Patient.MiddleName);
            PhibrosisStage = LastExamine.PhibrosisStage;
            LastExamineDate = LastExamine.CreatedAt;

            LocalStatus = LastExamine.LocalStatus;
            ExpertStatus = LastExamine.ExpertStatus;

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PhibrosisStage { get; set; }

        public DateTime LastExamineDate { get; set; }

        public string LocalStatus { get; set; }

        public string ExpertStatus { get; set; }

        public int PatientId { get; set; }

        public bool Filter(string name, DateTime? date)
        {
            bool applyNameFilter = !string.IsNullOrWhiteSpace(name) && !name.Equals(name);
            bool applyDateFilter = date.HasValue;

            return applyNameFilter ? Name.Contains(name) : true) &&
                    (applyDateFilter ? (DateTime.Compare(LastExamineDate.Date, date.Value.Date) == 0;
        }
    }
}
