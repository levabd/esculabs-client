using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibrosis.Models
{
    using FibroscanProcessor;

    public enum ExpertStatus
    {
        Pending,
        Confirmed,
        Unconfirmed,
    }

    [Table("fibrosis.measures")]
    public class Measure
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("source", TypeName = "bytea")]
        public byte[] Source { get; set; }

        [Column("result_merged", TypeName = "bytea")]
        public byte[] ResultMerged { get; set; }

        [Column("result_mode_a", TypeName = "bytea")]
        public byte[] ResultModeA { get; set; }

        [Column("result_mode_m", TypeName = "bytea")]
        public byte[] ResultModeM { get; set; }

        [Column("result_elasto", TypeName = "bytea")]
        public byte[] ResultElasto { get; set; }

        [Column("validation_mode_a")]
        public VerificationStatus ValidationModeA { get; set; }

        [Column("validation_mode_m")]
        public VerificationStatus ValidationModeM { get; set; }

        [Column("validation_elasto")]
        public VerificationStatus ValidationElasto { get; set; }

        [Column("stiffness")]
        public double Stiffness { get; set; }

        [Column("created_at", TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        public virtual Examine Examine { get; set; }
    }
}
