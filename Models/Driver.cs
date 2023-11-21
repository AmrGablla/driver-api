using System.ComponentModel.DataAnnotations;
using SQLite;
using Helpers;

namespace Models
{
    [Table("Drivers")]
    public class Driver
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Indexed]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Indexed]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Column("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Ignore]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        [Ignore]
        public string AlphabetizedFullName
        {
            get { return $"{Order.Alphabetically(FirstName)} {Order.Alphabetically(LastName)}"; }
        }
    }
}
