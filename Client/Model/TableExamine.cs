using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class TableExamine
    {
        public TableExamine() { }

        public TableExamine(Examine examine, int id = 0)
        {
            if (examine != null)
            {
                Guid = examine.Id;
                PhibrosisStage = examine.ElastoExam.PhibrosisStage;
                CreatedAt = examine.CreatedAt;
                ExpertStatus = examine.ElastoExam.ExpertStatus.ToString().ToLower();

                LocalStatus = examine.ElastoExam.Valid ? "correct" : "incorrect";

                if (id == 0)
                {
                    Id = examine.Id;
                }
                else
                {
                    Id = id.ToString();
                }

                MeasuresCount = examine.ElastoExam.Measures.Count();
                MED = examine.ElastoExam.MED;

                if (MED != 0 && examine.ElastoExam.IQR != 0)
                {
                    IqrMed = Math.Round((examine.ElastoExam.IQR / MED) * 100).ToString() + "%";
                }
                else
                {
                    IqrMed = "Нет данных";
                }
            }
        }

        public string Guid { get; set; }
        
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
