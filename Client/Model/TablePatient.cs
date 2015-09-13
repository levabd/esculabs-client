using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public partial class TablePatient
    {
        public TablePatient() { }

        public TablePatient(Patient Patient, Examine LastExamine, ElastoExam LastElastoExamine = null)
        {
            Id = Patient.Id;
            Name = string.Format("{0} {1} {2}", Patient.LastName, Patient.FirstName, Patient.MiddleName);

            if (LastExamine != null)
            {
                PhibrosisStage = LastElastoExamine.PhibrosisStage;
                LastExamineDate = LastExamine.CreatedAt;

                switch (LastElastoExamine.ExpertStatus)
                {
                    case (Client.ExpertStatus.Pending):
                        ExpertStatus = "pending";
                        break;
                    case (Client.ExpertStatus.Confirmed):
                        ExpertStatus = "confirmed";
                        break;
                    case (Client.ExpertStatus.Unconfirmed):
                        ExpertStatus = "unconfirmed";
                        break;
                    default:
                        ExpertStatus = "pending";
                        break;
                }

                LocalStatus = LastElastoExamine.Valid ? "correct" : "incorrect";
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PhibrosisStage { get; set; }

        public DateTime? LastExamineDate { get; set; }

        public string LocalStatus { get; set; }

        public string ExpertStatus { get; set; }

        public int PatientId { get; set; }

        public bool Filter(string name, DateTime? dateFrom, DateTime? dateTo)
        {
            if (!dateFrom.HasValue && !dateTo.HasValue)
            {
                return Name.ToLower().Contains(name.ToLower());
            }
            else
            {
                if (!dateFrom.HasValue)
                {
                    dateFrom = DateTime.MinValue;
                }

                if (!dateTo.HasValue)
                {
                    dateTo = DateTime.MaxValue;
                }

                return Name.ToLower().Contains(name.ToLower()) && LastExamineDate.HasValue &&
                    LastExamineDate.Value.Date >= dateFrom.Value.Date && LastExamineDate.Value.Date <= dateTo.Value.Date;
            }
        }
    }
}
