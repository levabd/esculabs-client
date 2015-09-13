using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public partial class TableExamine
    {
        public TableExamine() { }

        public TableExamine(Examine examine, int id = 0)
        {
            if (examine != null)
            {
                ElastoExam elastoExam = examine.ElastoExams.ToList().FirstOrDefault();

                PhibrosisStage = elastoExam.PhibrosisStage;
                CreatedAt = examine.CreatedAt;

                switch (elastoExam.ExpertStatus)
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

                LocalStatus = elastoExam.Valid ? "correct" : "incorrect";

                if (id == 0)
                {
                    Id = examine.Id;
                }
                else
                {
                    Id = id.ToString();
                }

                MeasuresCount = elastoExam.Measures.Count();
                MED = elastoExam.MED;

                if (MED != 0 && elastoExam.IQR != 0)
                {
                    IqrMed = Math.Round((elastoExam.IQR / MED) * 100).ToString() + "%";
                }
                else
                {
                    IqrMed = "Нет данных";
                }
            }
        }

        public string Id { get; set; }

        public int MeasuresCount { get; set; }

        public string IqrMed { get; set; }

        public double MED { get; set; }

        public string PhibrosisStage { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string LocalStatus { get; set; }

        public string ExpertStatus { get; set; }

        public int PatientId { get; set; }
    }
}
