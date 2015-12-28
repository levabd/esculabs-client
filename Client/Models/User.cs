namespace Client.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Роль пользователя
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Роль врача
        /// </summary>
        Physician = 1,

        /// <summary>
        /// Роль эксперта
        /// </summary>
        Expert = 2,

        /// <summary>
        /// Роль специалиста поддержки
        /// </summary>
        Support = 4,

        /// <summary>
        /// Роль разработчика
        /// </summary>
        Developer = 8
    }

    public sealed class User
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Required]
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        [Required]
        public string Position { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public UserRole Role { get; set; }
    }
}
