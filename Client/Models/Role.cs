namespace Client.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("public.roles")]
    public partial class Role
    {
        public Role()
        {
            Physicians = new List<Physician>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<Physician> Physicians { get; set; }
    }
}
