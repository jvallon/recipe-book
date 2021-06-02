using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("users")]
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(45, ErrorMessage = "First name can't be longer than 45 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(45, ErrorMessage = "Last name can't be longer than 45 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(45, ErrorMessage = "Username can't be longer than 45 characters")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "EmailAddress is required")]
        [StringLength(45, ErrorMessage = "EmailAddress can't be longer than 45 characters")]
        public string? EmailAddress { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
        
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
