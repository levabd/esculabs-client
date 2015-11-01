﻿namespace Client.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("public.physicians")]
    public partial class Physician
    {
        public Physician()
        {
            Roles = new List<Role>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Index("IX_Login", 1, IsUnique = true)]
        [Column("login")]
        public string Login { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [StringLength(255)]
        [Column("position")]
        public string Position { get; set; }

        /// <summary>
        /// Роли врача
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
    }
}